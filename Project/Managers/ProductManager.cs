using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Project.Models;

namespace Project.Managers
{
    // [조건: 클래스 분리] 메뉴 및 레시피 관리 전담 클래스
    public static class ProductManager
    {
        // 1. 메뉴 목록 조회 (Read)
        // [조건: 파일 처리/DB] MenuItems 테이블 전체 조회
        public static List<MenuItem> GetMenus()
        {
            var list = new List<MenuItem>();
            using (SQLiteConnection conn = new SQLiteConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                using (var reader = new SQLiteCommand("SELECT * FROM MenuItems", conn).ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(new MenuItem { Id = Convert.ToInt32(reader["MenuItemID"]), Name = reader["Name"].ToString(), Price = Convert.ToInt32(reader["Price"]) });
                }
            }
            return list;
        }

        // 2. 메뉴 저장 (Create / Update)
        // [조건: 파일 처리/DB] ID 유무에 따른 INSERT / UPDATE 분기 처리
        public static DbResult<int> SaveMenu(int id, string name, int price)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                // 신규(0)는 INSERT, 기존(ID)은 UPDATE 쿼리 실행
                string sql = (id == 0)
                    ? "INSERT INTO MenuItems (Name, Price) VALUES (@name, @price)"
                    : "UPDATE MenuItems SET Name=@name, Price=@price WHERE MenuItemID=@id";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                if (id != 0) cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            return new DbResult<int>(true, "저장됨", 1);
        }

        // 3. 메뉴 삭제 (Delete)
        // [조건: 파일 처리/DB] 참조 무결성 고려 (레시피 -> 메뉴 순 삭제)
        public static void DeleteMenu(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                // 자식 데이터(레시피) 선 삭제
                new SQLiteCommand($"DELETE FROM Recipes WHERE MenuItemID={id}", conn).ExecuteNonQuery();
                // 부모 데이터(메뉴) 후 삭제
                new SQLiteCommand($"DELETE FROM MenuItems WHERE MenuItemID={id}", conn).ExecuteNonQuery();
            }
        }

        // 4. 레시피 상세 조회
        // [조건: 파일 처리/DB] JOIN 쿼리를 통한 재료 정보 포함 조회
        public static List<RecipeItem> GetRecipes(int menuId)
        {
            var list = new List<RecipeItem>();
            string sql = "SELECT r.IngredientID, i.Name, r.Amount FROM Recipes r JOIN Ingredients i ON r.IngredientID = i.IngredientID WHERE r.MenuItemID = @id";
            using (SQLiteConnection conn = new SQLiteConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", menuId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new RecipeItem
                        {
                            IngredientId = Convert.ToInt32(reader[0]),
                            IngredientName = reader[1].ToString(),
                            Amount = Convert.ToDouble(reader[2])
                        });
                    }
                }
            }
            return list;
        }

        // 5. 레시피 추가 및 수정
        // [조건: 파일 처리/DB] 존재 여부 확인 후 INSERT / UPDATE 처리
        public static void AddRecipe(int menuId, int ingId, double amount)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                // 기존 등록 여부 확인
                string sqlCheck = "SELECT COUNT(*) FROM Recipes WHERE MenuItemID=@mid AND IngredientID=@iid";
                SQLiteCommand cmdCheck = new SQLiteCommand(sqlCheck, conn);
                cmdCheck.Parameters.AddWithValue("@mid", menuId);
                cmdCheck.Parameters.AddWithValue("@iid", ingId);

                // 존재 시 수량 업데이트, 미존재 시 신규 추가
                string sql = (Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0)
                    ? "UPDATE Recipes SET Amount=@amt WHERE MenuItemID=@mid AND IngredientID=@iid"
                    : "INSERT INTO Recipes (MenuItemID, IngredientID, Amount) VALUES (@mid, @iid, @amt)";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@amt", amount);
                cmd.Parameters.AddWithValue("@mid", menuId);
                cmd.Parameters.AddWithValue("@iid", ingId);
                cmd.ExecuteNonQuery();
            }
        }

        // 6. 레시피 항목 삭제
        // [조건: 파일 처리/DB] 서브쿼리를 이용한 ID 조회 및 삭제
        public static void DeleteRecipe(int menuId, string ingredientName)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Recipes WHERE MenuItemID = @mid AND IngredientID = (SELECT IngredientID FROM Ingredients WHERE Name = @name)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mid", menuId);
                cmd.Parameters.AddWithValue("@name", ingredientName);
                cmd.ExecuteNonQuery();
            }
        }

        // 7. 콤보박스 바인딩용 데이터 조회
        // [조건: 파일 처리/DB] 메뉴 ID와 이름 매핑 리스트 반환
        public static Dictionary<int, string> GetMenuCombo()
        {
            var list = new Dictionary<int, string>();
            using (SQLiteConnection conn = new SQLiteConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                using (var reader = new SQLiteCommand("SELECT MenuItemID, Name FROM MenuItems", conn).ExecuteReader())
                {
                    while (reader.Read()) list.Add(Convert.ToInt32(reader[0]), reader[1].ToString());
                }
            }
            return list;
        }
    }
}