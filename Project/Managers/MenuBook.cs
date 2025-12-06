using System.Collections.Generic;
using System.Linq;

namespace Project.Models
{
    // 메뉴 리스트를 관리하는 래퍼 클래스
    public class MenuBook
    {
        private List<MenuItem> _menus;

        public MenuBook(List<MenuItem> menus)
        {
            _menus = menus;
        }

        // [인덱서 2] ID로 메뉴 이름 찾기 (정수 인덱스)
        public string this[int id]
        {
            get
            {
                var menu = _menus.FirstOrDefault(m => m.Id == id);
                return menu != null ? menu.Name : "알 수 없는 메뉴";
            }
        }
    }
}