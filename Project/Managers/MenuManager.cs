using Project.Models; // Global 사용
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project.Managers
{
    // [조건: 클래스 사용] UI 제어(색상/이동) 로직 전담 클래스
    public static class MenuManager
    {
        // =================================================================
        // [선택 조건: 다형성 - 메서드 중복(Overloading)]
        // 같은 기능을 하는 'HighlightMenu' 메서드를 두 가지 방식으로 구현함
        // =================================================================

        // 1. 색상 변경 (버튼 객체 기준)
        public static void HighlightMenu(Panel panel, Control activeBtn)
        {
            if (activeBtn == null) return;

            foreach (Control c in panel.Controls)
            {
                // 버튼이나 라벨인 경우만 처리
                if (c is Button || c is Label)
                {
                    bool isActive = (c == activeBtn);
                    // 활성 상태에 따라 색상 변경 (파랑/회색)
                    c.ForeColor = isActive ? Color.DodgerBlue : Color.Gray;
                }
            }
        }

        // 2. 색상 변경 (버튼 이름 기준) - 오버로딩
        public static void HighlightMenu(Panel panel, string activeBtnName)
        {
            foreach (Control c in panel.Controls)
            {
                if (c is Button || c is Label)
                {
                    bool isActive = (c.Name == activeBtnName);
                    c.ForeColor = isActive ? Color.DodgerBlue : Color.Gray;
                }
            }
        }

        // 3. 이동 기능 자동 연결
        public static void AttachNavigation(Form currentForm, Control container)
        {
            foreach (Control c in container.Controls)
            {
                // 재귀 탐색: 패널 안에 패널이 있을 경우 내부까지 탐색
                if (c.HasChildren)
                {
                    AttachNavigation(currentForm, c);
                }

                // 로그아웃 버튼 연결
                if (c.Name == "Btn_Logout")
                {
                    c.Click -= Logout_Click; // 중복 방지
                    c.Click += Logout_Click;
                }
                // 메뉴 이동 버튼 연결 (Btn_으로 시작하는 경우)
                else if ((c is Button || c is Label) && c.Name.StartsWith("Btn_"))
                {
                    // 람다식을 사용하여 핸들러 연결
                    c.Click -= (s, e) => HandleMenuClick(s, currentForm);
                    c.Click += (s, e) => HandleMenuClick(s, currentForm);
                }
            }
        }

        // 로그아웃 처리 메서드
        private static void Logout_Click(object sender, EventArgs e)
        {
            // 로그아웃 확인 메시지
            if (MessageBox.Show("로그아웃 하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // [조건: 전역 변수 활용] 로그인 정보 초기화
                Global.CurrentUserID = "";

                // 프로그램 재시작 (로그인 화면으로 복귀)
                Application.Restart();
            }
        }

        // 4. 화면 전환 메서드 (공통 사용)
        public static void OpenForm(Form current, Form next)
        {
            // 다음 폼 위치 및 시작 지점 설정
            next.StartPosition = FormStartPosition.Manual;
            next.Location = current.Location;

            // 폼 종료 시 어플리케이션 종료 이벤트 연결
            next.FormClosed += (s, args) => Application.Exit();

            // 화면 전환 (다음 폼 표시 후 현재 폼 숨김)
            next.Show();
            current.Hide();
        }

        // 내부 메뉴 클릭 처리 로직
        private static void HandleMenuClick(object sender, Form currentForm)
        {
            Control clickedBtn = sender as Control;
            if (clickedBtn == null) return;

            Form nextForm = null;

            // 버튼 이름에 따른 이동 대상 폼 결정
            switch (clickedBtn.Name)
            {
                case "Btn_Main":
                    if (currentForm is MainForm) return; // 현재 화면이면 이동 안 함
                    nextForm = new MainForm();
                    break;

                case "Btn_Ingredient":
                    if (currentForm is IngredientManageForm) return;
                    nextForm = new IngredientManageForm();
                    break;

                case "Btn_Menu":
                    if (currentForm is MenuManageForm) return;
                    nextForm = new MenuManageForm();
                    break;

                case "Btn_Stock": // 재고 처리 버튼
                    if (currentForm is SalesStockForm) return;
                    nextForm = new SalesStockForm();
                    break;

                case "Btn_Sales": // 매출 조회 버튼
                    if (currentForm is SalesViewForm) return;
                    nextForm = new SalesViewForm();
                    break;
            }

            // 이동 대상이 있을 경우 화면 전환 수행
            if (nextForm != null)
            {
                OpenForm(currentForm, nextForm);
            }
        }
    }
}