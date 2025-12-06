using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Project.Models;

namespace Project.Managers
{
    public static class StockManager
    {
        public static List<Ingredient> GetMyStock(string ownerId)
        {
            var list = new List<Ingredient>();
            string query = @"SELECT i.IngredientID, i.Name, i.Unit, i.MinStock, IFNULL(s.Quantity, 0) as Quantity
                             FROM Ingredients i LEFT JOIN Stock s ON i.IngredientID = s.IngredientID AND s.OwnerID = @owner";

            using (SQLiteConnection conn = new SQLiteConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@owner", ownerId);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Ingredient
                        {
                            Id = Convert.ToInt32(reader["IngredientID"]),
                            Name = reader["Name"].ToString(),
                            Unit = reader["Unit"].ToString(),
                            CurrentStock = Convert.ToDouble(reader["Quantity"]),
                            MinStock = Convert.ToDouble(reader["MinStock"])
                        });
                    }
                }
            }
            return list;
        }

        // ★ [추가됨] 인덱서 사용을 위한 Inventory 객체 반환
        public static Inventory GetInventory(string ownerId)
        {
            List<Ingredient> list = GetMyStock(ownerId);
            return new Inventory(list);
        }

        public static DbResult<int> SaveIngredient(string ownerId, int id, string name, string unit, double current, double min)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                var tran = conn.BeginTransaction();
                try
                {
                    if (id == 0)
                    {
                        string sql1 = "INSERT INTO Ingredients (Name, Unit, MinStock) VALUES (@name, @unit, @min); SELECT last_insert_rowid();";
                        SQLiteCommand cmd1 = new SQLiteCommand(sql1, conn);
                        cmd1.Parameters.AddWithValue("@name", name);
                        cmd1.Parameters.AddWithValue("@unit", unit);
                        cmd1.Parameters.AddWithValue("@min", min);
                        int newId = Convert.ToInt32(cmd1.ExecuteScalar());

                        string sql2 = "INSERT INTO Stock (OwnerID, IngredientID, Quantity) VALUES (@owner, @ingId, @qty)";
                        SQLiteCommand cmd2 = new SQLiteCommand(sql2, conn);
                        cmd2.Parameters.AddWithValue("@owner", ownerId);
                        cmd2.Parameters.AddWithValue("@ingId", newId);
                        cmd2.Parameters.AddWithValue("@qty", current);
                        cmd2.ExecuteNonQuery();
                    }
                    else
                    {
                        string sql1 = "UPDATE Ingredients SET Name=@name, Unit=@unit, MinStock=@min WHERE IngredientID=@id";
                        SQLiteCommand cmd1 = new SQLiteCommand(sql1, conn);
                        cmd1.Parameters.AddWithValue("@name", name);
                        cmd1.Parameters.AddWithValue("@unit", unit);
                        cmd1.Parameters.AddWithValue("@min", min);
                        cmd1.Parameters.AddWithValue("@id", id);
                        cmd1.ExecuteNonQuery();

                        string sqlCheck = "SELECT COUNT(*) FROM Stock WHERE OwnerID=@owner AND IngredientID=@id";
                        SQLiteCommand cmdCheck = new SQLiteCommand(sqlCheck, conn);
                        cmdCheck.Parameters.AddWithValue("@owner", ownerId);
                        cmdCheck.Parameters.AddWithValue("@id", id);

                        if (Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0)
                        {
                            string sqlUpd = "UPDATE Stock SET Quantity=@qty WHERE OwnerID=@owner AND IngredientID=@id";
                            SQLiteCommand cmdUpd = new SQLiteCommand(sqlUpd, conn);
                            cmdUpd.Parameters.AddWithValue("@qty", current);
                            cmdUpd.Parameters.AddWithValue("@owner", ownerId);
                            cmdUpd.Parameters.AddWithValue("@id", id);
                            cmdUpd.ExecuteNonQuery();
                        }
                        else
                        {
                            string sqlIns = "INSERT INTO Stock (OwnerID, IngredientID, Quantity) VALUES (@owner, @id, @qty)";
                            SQLiteCommand cmdIns = new SQLiteCommand(sqlIns, conn);
                            cmdIns.Parameters.AddWithValue("@owner", ownerId);
                            cmdIns.Parameters.AddWithValue("@id", id);
                            cmdIns.Parameters.AddWithValue("@qty", current);
                            cmdIns.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                    return new DbResult<int>(true, "저장되었습니다.", 1);
                }
                catch (Exception ex) { tran.Rollback(); return new DbResult<int>(false, "저장 실패: " + ex.Message, 0); }
            }
        }

        public static DbResult<int> DeleteIngredient(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                var tran = conn.BeginTransaction();
                try
                {
                    new SQLiteCommand($"DELETE FROM Stock WHERE IngredientID={id}", conn).ExecuteNonQuery();
                    new SQLiteCommand($"DELETE FROM Recipes WHERE IngredientID={id}", conn).ExecuteNonQuery();
                    new SQLiteCommand($"DELETE FROM Ingredients WHERE IngredientID={id}", conn).ExecuteNonQuery();
                    tran.Commit();
                    return new DbResult<int>(true, "삭제되었습니다.", 1);
                }
                catch (Exception ex) { tran.Rollback(); return new DbResult<int>(false, "삭제 실패: " + ex.Message, 0); }
            }
        }

        public static DbResult<int> UpdateStock(string ownerId, int ingId, double qty, bool isAdd)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                try
                {
                    string checkSql = "SELECT COUNT(*) FROM Stock WHERE OwnerID=@oid AND IngredientID=@iid";
                    SQLiteCommand cmdCheck = new SQLiteCommand(checkSql, conn);
                    cmdCheck.Parameters.AddWithValue("@oid", ownerId);
                    cmdCheck.Parameters.AddWithValue("@iid", ingId);

                    if (Convert.ToInt32(cmdCheck.ExecuteScalar()) == 0)
                    {
                        string insertSql = "INSERT INTO Stock (OwnerID, IngredientID, Quantity) VALUES (@oid, @iid, 0)";
                        SQLiteCommand cmdInsert = new SQLiteCommand(insertSql, conn);
                        cmdInsert.Parameters.AddWithValue("@oid", ownerId);
                        cmdInsert.Parameters.AddWithValue("@iid", ingId);
                        cmdInsert.ExecuteNonQuery();
                    }

                    string oper = isAdd ? "+" : "-";
                    string sql = $"UPDATE Stock SET Quantity = Quantity {oper} @qty WHERE OwnerID=@oid AND IngredientID=@iid";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@oid", ownerId);
                    cmd.Parameters.AddWithValue("@iid", ingId);
                    cmd.ExecuteNonQuery();
                    return new DbResult<int>(true, "재고가 반영되었습니다.", 1);
                }
                catch (Exception ex) { return new DbResult<int>(false, "오류: " + ex.Message, 0); }
            }
        }

        public static Dictionary<int, string> GetAllIngredients()
        {
            var list = new Dictionary<int, string>();
            using (SQLiteConnection conn = new SQLiteConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                using (var reader = new SQLiteCommand("SELECT IngredientID, Name FROM Ingredients", conn).ExecuteReader())
                {
                    while (reader.Read()) list.Add(Convert.ToInt32(reader[0]), reader[1].ToString());
                }
            }
            return list;
        }

        // 품절 체크 (키오스크용)
        public static bool CheckMenuAvailability(string ownerId, int menuId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT COUNT(*)
                    FROM Recipes r
                    LEFT JOIN Stock s ON r.IngredientID = s.IngredientID AND s.OwnerID = @owner
                    WHERE r.MenuItemID = @mid
                    AND (IFNULL(s.Quantity, 0) < r.Amount)";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@owner", ownerId);
                    cmd.Parameters.AddWithValue("@mid", menuId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) == 0;
                }
            }
        }
    }
}