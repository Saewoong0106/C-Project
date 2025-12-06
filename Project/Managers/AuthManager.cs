using System;
using System.Data.SQLite;
using Project.Models;

namespace Project.Managers
{
    public static class AuthManager
    {
        public static DbResult<User> Authenticate(string id, string pw)
        {
            // DB 연결은 여기서 try로 감싸지만, "로그인 실패" 로직은 예외로 던집니다.
            using (SQLiteConnection conn = new SQLiteConnection(DBHelper.ConnectionString))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    // DB 연결 자체가 실패한 경우
                    return new DbResult<User>(false, "DB 연결 실패: " + ex.Message, null);
                }

                // 쿼리 실행
                string query = "SELECT * FROM Users WHERE UserID = @id AND Password = @pw";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@pw", pw);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // [성공]
                            User user = new User
                            {
                                Id = reader["UserID"].ToString(),
                                Password = reader["Password"].ToString()
                            };
                            return new DbResult<User>(true, "로그인 성공", user);
                        }
                    }
                }
            }

            // [실패] DB 조회는 잘 됐는데, 아이디/비번이 없는 경우
            // try-catch 바깥에서 던져서 확실하게 폼으로 보냅니다.
            throw new LoginFailedException(id);
        }
    }
}