using System.Collections.Generic;

namespace Project.Models
{
    // =========================================================
    // [필수 조건: 추상 클래스] 원재료와 메뉴의 공통 부모
    // [필수 조건: 클래스] 데이터 모델 설계
    // =========================================================
    public abstract class Item
    {
        // [필수 조건: 프로퍼티] 캡슐화된 데이터 접근
        public int Id { get; set; }
        public string Name { get; set; }

        // [선택 조건: 다형성 - 추상 메서드] 자식 클래스 구현 강제
        public abstract string GetSummary();
    }

    // =========================================================
    // [필수 조건: 상속] Item 클래스 확장 (원재료)
    // =========================================================
    public class Ingredient : Item
    {
        public double CurrentStock { get; set; }
        public string Unit { get; set; }
        public double MinStock { get; set; }

        // [선택 조건: 다형성 - 오버라이딩] 원재료 맞춤형 요약 반환
        public override string GetSummary()
        {
            return $"{Name}: {CurrentStock}{Unit}";
        }
    }

    // =========================================================
    // [필수 조건: 상속] Item 클래스 확장 (판매 메뉴)
    // =========================================================
    public class MenuItem : Item
    {
        public int Price { get; set; }

        // [선택 조건: 제네릭 사용] 레시피 목록 관리 (List<T>)
        public List<RecipeItem> Recipes { get; set; } = new List<RecipeItem>();

        // [선택 조건: 다형성 - 오버라이딩] 메뉴 맞춤형 요약 반환
        public override string GetSummary()
        {
            return $"{Name}: {Price}원";
        }
    }

    // [보조 클래스] 레시피 상세 정보
    public class RecipeItem
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public double Amount { get; set; }
    }

    // [보조 클래스] 사용자 정보
    public class User
    {
        public string Id { get; set; }
        public string Password { get; set; }
    }
}