using System.Collections.Generic;
using System.Linq;

namespace Project.Models
{
    // [선택 조건: 인덱서 (Indexer)]
    // 재고 리스트를 감싸서, 이름으로 수량을 쏙쏙 뽑아쓰게 해주는 클래스
    public class Inventory
    {
        private List<Ingredient> _items;

        public Inventory(List<Ingredient> items)
        {
            _items = items;
        }

        // ★ 인덱서 구현부
        // 사용법: inventory["원두"] -> 5.0 (수량 반환)
        public double this[string name]
        {
            get
            {
                var item = _items.FirstOrDefault(i => i.Name == name);
                return item != null ? item.CurrentStock : 0;
            }
        }
    }
}