using System;

namespace Project.Models
{
    // [선택 조건: 사용자 정의 예외 클래스 (Custom Exception)]
    // - 시스템 예외가 아닌 '재고 부족'이라는 특정 비즈니스 로직 에러 정의
    // - Exception 클래스 상속 및 확장
    public class OutOfStockException : Exception
    {
        // 기본 생성자
        public OutOfStockException() { }

        // 메시지 전달 생성자
        // - 예외 발생 원인을 문자열로 전달받아 상위 클래스(Exception)에 초기화
        public OutOfStockException(string message) : base(message) { }
    }
}