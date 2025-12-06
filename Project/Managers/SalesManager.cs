using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Project.Models;

namespace Project.Managers
{
    public static class SalesManager
    {
        public static (int ingCount, int menuCount, int totalSales) GetDashboardStats(string ownerId)
        {
            int iCount = 0, mCount = 0, sales = 0;
            using (SQLiteConnection conn = new SQLiteConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Ingredients", conn))
                    iCount = Convert.ToInt32(cmd.ExecuteScalar());
                using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM MenuItems", conn))
                    mCount = Convert.ToInt32(cmd.ExecuteScalar());

                string salesQuery = "SELECT IFNULL(SUM(TotalAmt), 0) FROM SalesLogs WHERE OwnerID = @owner";
                using (var cmd = new SQLiteCommand(salesQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@owner", ownerId);
                    sales = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return (iCount, mCount, sales);
        }

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

        public static DbResult<int> SellMenu(string ownerId, int menuId, int qty)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                var tran = conn.BeginTransaction();
                try
                {
                    var recipes = new List<RecipeItem>();
                    string sqlRecipe = "SELECT IngredientID, Amount FROM Recipes WHERE MenuItemID = @mid";
                    using (var cmd = new SQLiteCommand(sqlRecipe, conn))
                    {
                        cmd.Parameters.AddWithValue("@mid", menuId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                recipes.Add(new RecipeItem { IngredientId = Convert.ToInt32(reader[0]), Amount = Convert.ToDouble(reader[1]) });
                        }
                    }

                    if (recipes.Count == 0) throw new Exception("레시피가 없는 메뉴입니다.");

                    foreach (var r in recipes)
                    {
                        double needQty = r.Amount * qty;
                        string sqlCheck = "SELECT Quantity FROM Stock WHERE OwnerID=@oid AND IngredientID=@iid";
                        var cmdCheck = new SQLiteCommand(sqlCheck, conn);
                        cmdCheck.Parameters.AddWithValue("@oid", ownerId);
                        cmdCheck.Parameters.AddWithValue("@iid", r.IngredientId);
                        object res = cmdCheck.ExecuteScalar();
                        double current = (res == null) ? 0 : Convert.ToDouble(res);

                        // ★ [조건 충족] 여기서 예외 발생!
                        if (current < needQty)
                            throw new OutOfStockException($"재료(ID:{r.IngredientId}) 재고가 부족합니다.");

                        string sqlUpd = "UPDATE Stock SET Quantity = Quantity - @qty WHERE OwnerID=@oid AND IngredientID=@iid";
                        var cmdUpd = new SQLiteCommand(sqlUpd, conn);
                        cmdUpd.Parameters.AddWithValue("@qty", needQty);
                        cmdUpd.Parameters.AddWithValue("@oid", ownerId);
                        cmdUpd.Parameters.AddWithValue("@iid", r.IngredientId);
                        cmdUpd.ExecuteNonQuery();
                    }

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
                catch (Exception ex)
                {
                    tran.Rollback();
                    // 예외를 밖으로 던져서 폼에서 처리하게 함 (혹은 여기서 잡아서 Result로 보냄)
                    // 여기서는 폼에서 catch를 보여주기 위해 다시 던집니다.
                    return new DbResult<int>(false, "판매 실패: " + ex.Message, 0);
                }
            }
        }
    }
}