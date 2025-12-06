using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Project.Models;

namespace Project.Managers
{
    public static class SalesManager
    {
        // 1. 대시보드 통계 조회 (이 부분이 사라져서 오류가 났던 것입니다)
        public static (int ingCount, int menuCount, int totalSales) GetDashboardStats(string ownerId)
        {
            int iCount = 0, mCount = 0, sales = 0;
            using (SQLiteConnection conn = new SQLiteConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                // 원재료 수
                using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Ingredients", conn))
                    iCount = Convert.ToInt32(cmd.ExecuteScalar());
                // 메뉴 수
                using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM MenuItems", conn))
                    mCount = Convert.ToInt32(cmd.ExecuteScalar());

                // 총 매출액
                string salesQuery = "SELECT IFNULL(SUM(TotalAmt), 0) FROM SalesLogs WHERE OwnerID = @owner";
                using (var cmd = new SQLiteCommand(salesQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@owner", ownerId);
                    sales = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return (iCount, mCount, sales);
        }

        // 2. 매출 내역 조회 (이 부분도 복구되었습니다)
        public static DataTable GetSalesData(string ownerId, DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            string start = fromDate.ToString("yyyy-MM-dd 00:00:00");
            string end = toDate.ToString("yyyy-MM-dd 23:59:59");

            using (SQLiteConnection conn = new SQLiteConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT SaleDate, MenuName, Qty, TotalAmt FROM SalesLogs WHERE OwnerID = @owner AND SaleDate BETWEEN @start AND @end ORDER BY SaleDate DESC";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@owner", ownerId);
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd)) { adapter.Fill(dt); }
                }
            }
            return dt;
        }

        // 3. 메뉴 판매 처리 (예외 처리가 적용된 새 버전)
        public static DbResult<int> SellMenu(string ownerId, int menuId, int qty)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                var tran = conn.BeginTransaction();
                try
                {
                    // (1) 레시피 조회 (재료 이름까지 가져오도록 JOIN 사용)
                    var recipes = new List<RecipeItem>();
                    string sqlRecipe = @"SELECT r.IngredientID, i.Name, r.Amount 
                                         FROM Recipes r 
                                         JOIN Ingredients i ON r.IngredientID = i.IngredientID
                                         WHERE r.MenuItemID = @mid";

                    using (var cmd = new SQLiteCommand(sqlRecipe, conn))
                    {
                        cmd.Parameters.AddWithValue("@mid", menuId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                recipes.Add(new RecipeItem
                                {
                                    IngredientId = Convert.ToInt32(reader[0]),
                                    IngredientName = reader[1].ToString(),
                                    Amount = Convert.ToDouble(reader[2])
                                });
                            }
                        }
                    }

                    if (recipes.Count == 0) throw new Exception("레시피가 없는 메뉴입니다.");

                    // (2) 재고 확인 및 차감
                    foreach (var r in recipes)
                    {
                        double needQty = r.Amount * qty;

                        string sqlCheck = "SELECT IFNULL(Quantity, 0) FROM Stock WHERE OwnerID=@oid AND IngredientID=@iid";
                        var cmdCheck = new SQLiteCommand(sqlCheck, conn);
                        cmdCheck.Parameters.AddWithValue("@oid", ownerId);
                        cmdCheck.Parameters.AddWithValue("@iid", r.IngredientId);

                        object res = cmdCheck.ExecuteScalar();
                        double current = (res == null) ? 0 : Convert.ToDouble(res);

                        // ★ [핵심] 재고 부족 시 OutOfStockException 발생 (데이터 포함)
                        if (current < needQty)
                        {
                            double shortage = needQty - current; // 부족분 계산
                            throw new OutOfStockException(r.IngredientName, shortage);
                        }

                        // 재고 차감 업데이트
                        string sqlUpd = "UPDATE Stock SET Quantity = Quantity - @qty WHERE OwnerID=@oid AND IngredientID=@iid";
                        var cmdUpd = new SQLiteCommand(sqlUpd, conn);
                        cmdUpd.Parameters.AddWithValue("@qty", needQty);
                        cmdUpd.Parameters.AddWithValue("@oid", ownerId);
                        cmdUpd.Parameters.AddWithValue("@iid", r.IngredientId);
                        cmdUpd.ExecuteNonQuery();
                    }

                    // (3) 판매 로그 기록
                    string sqlLog = "INSERT INTO SalesLogs (OwnerID, MenuName, Qty, TotalAmt, SaleDate) VALUES (@oid, (SELECT Name FROM MenuItems WHERE MenuItemID=@mid), @qty, (SELECT Price FROM MenuItems WHERE MenuItemID=@mid)*@qty, @date)";
                    var cmdLog = new SQLiteCommand(sqlLog, conn);
                    cmdLog.Parameters.AddWithValue("@oid", ownerId);
                    cmdLog.Parameters.AddWithValue("@mid", menuId);
                    cmdLog.Parameters.AddWithValue("@qty", qty);
                    cmdLog.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmdLog.ExecuteNonQuery();

                    tran.Commit();
                    return new DbResult<int>(true, "판매 완료!", 1);
                }
                catch (OutOfStockException)
                {
                    tran.Rollback();
                    throw; // 폼에서 데이터를 꺼내 쓸 수 있게 그대로 던짐
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return new DbResult<int>(false, "판매 실패: " + ex.Message, 0);
                }
            }
        }
    }
}