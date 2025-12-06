using System;

namespace Project.Models
{
    // [조건: 클래스 사용] 부족한 재료 이름과 수량을 담는 '진짜 기능이 있는' 예외 클래스
    public class OutOfStockException : Exception
    {
        // ★ 교수님 설명용: "어떤 재료가 얼마나 부족한지 데이터를 담기 위해 속성을 추가했습니다."
        public string ItemName { get; private set; }
        public double Deficit { get; private set; }

        // 생성자에서 데이터를 받아서 저장함
        public OutOfStockException(string itemName, double deficit)
            : base($"재료 '{itemName}'이(가) {deficit}만큼 부족합니다.")
        {
            ItemName = itemName;
            Deficit = deficit;
        }
    }
}