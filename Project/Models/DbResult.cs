namespace Project.Models
{
    // [선택 조건: 제네릭 클래스 (Generic Class)]
    // - 데이터베이스 작업 결과(성공여부, 메시지, 데이터)를 포장하는 공통 클래스
    // - <T>: 반환할 데이터의 타입 (User, int, List 등 다양한 타입 지원)
    public class DbResult<T>
    {
        // 성공 여부 (True/False)
        public bool IsSuccess { get; set; }

        // 결과 메시지 (성공 알림 또는 에러 사유)
        public string Message { get; set; }

        // [제네릭 활용] 실제 데이터 본문 (T 타입)
        public T Data { get; set; }

        // 생성자: 결과 객체 초기화
        public DbResult(bool isSuccess, string message, T data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }
    }
}