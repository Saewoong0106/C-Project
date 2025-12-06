using System;
using System.Data.SQLite;
using Project.Models; // User, DbResult 참조

namespace Project.Managers
{
    // [조건: 클래스 2개 이상 사용] 사용자 인증(로그인) 기능 전담 클래스
    public static class AuthManager
    {
        // 로그인 인증 처리 메서드
        // [선택 조건: 제네릭 사용] 반환 타입으로 DbResult<User> 활용 (결과 및 데이터 포장)
        public static DbResult<User> Authenticate(string id, string pw)
        {
            try
            {
                // [조건: 파일 처리/DB] SQLite 연결 객체 생성 (DBHelper 경로 사용)
                using (SQLiteConnection conn = new SQLiteConnection(DBHelper.ConnectionString))
                {
                    conn.Open();

                    // SQL 파라미터 바인딩 (SQL 인젝션 방지)
                    string query = "SELECT * FROM Users WHERE UserID = @id AND Password = @pw";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@pw", pw);

                    // 데이터 조회 (Read)
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // [성공] 사용자 객체 생성 및 반환
                            User user = new User
                            {
                                Id = reader["UserID"].ToString(),
                                Password = reader["Password"].ToString()
                            };
                            return new DbResult<User>(true, "로그인 성공", user);
                        }

                        // [실패] 일치 데이터 없음
                        return new DbResult<User>(false, "아이디 또는 비밀번호가 틀렸습니다.", null);
                    }
                }
            }
            catch (Exception ex)
            {
                // [조건: 예외 처리] DB 연결/조회 중 오류 발생 시 처리
                return new DbResult<User>(false, "DB 에러: " + ex.Message, null);
            }
        }
    }
}