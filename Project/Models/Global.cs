namespace Project.Models
{
    // [조건: 클래스 사용] 프로그램 전역 데이터 관리용 정적 클래스
    public static class Global
    {
        // [조건: 전역 변수 활용]
        // - 현재 로그인한 사용자 ID 저장
        // - 프로그램 종료 시까지 메모리에 유지되며 모든 폼에서 접근 가능
        public static string CurrentUserID = "";
    }
}