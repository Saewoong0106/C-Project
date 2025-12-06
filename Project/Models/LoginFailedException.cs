using System;

namespace Project.Models
{
    // [조건: 클래스 사용] 로그인 실패한 ID 정보를 담는 예외 클래스
    public class LoginFailedException : Exception
    {
        // ★ 교수님 설명용: "누가 로그인에 실패했는지 기록하기 위해 ID 속성을 추가했습니다."
        public string AttemptedId { get; private set; }

        public LoginFailedException(string id)
            : base($"ID '{id}' 로그인 실패")
        {
            AttemptedId = id;
        }
    }
}