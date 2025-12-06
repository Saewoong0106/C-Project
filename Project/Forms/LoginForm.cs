using Project.Managers; // AuthManager 사용
using Project.Models;   // User, DbResult, Global 사용
using System;
using System.Windows.Forms;
using Project;

namespace Project
{
    // [조건: Form 4개 이상] 로그인 화면 클래스
    public partial class LoginFrom : Form
    {
        // 생성자: 컴포넌트 초기화
        public LoginFrom()
        {
            InitializeComponent();
        }

        // [이벤트] 로그인 버튼 클릭
        private void Button_Login_Click(object sender, EventArgs e)
        {
            // 사용자 입력값(ID/PW) 추출
            string inputID = Text_ID.Text;
            string inputPW = Text_PW.Text;

            // =========================================================
            // [조건: 클래스 분리] 로그인 로직을 AuthManager로 위임
            // [선택 조건: 제네릭 사용] 반환 타입으로 DbResult<User> 사용
            // =========================================================
            DbResult<User> result = AuthManager.Authenticate(inputID, inputPW);

            if (result.IsSuccess)
            {
                // ID 저장 (이걸로 메뉴/매출 연동됨!)
                Global.CurrentUserID = result.Data.Id;

                // ★ [여기 수정] 체크박스 확인
                if (Chk_Kiosk.Checked)
                {
                    // 키오스크 화면 띄우기
                    KioskForm kioskForm = new KioskForm();
                    kioskForm.FormClosed += (s, args) => this.Close();
                    kioskForm.Show();
                }
                else
                {
                    // 관리자 화면 띄우기 (기존)
                    MainForm mainForm = new MainForm();
                    mainForm.FormClosed += (s, args) => this.Close();
                    mainForm.Show();
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show(result.Message, "로그인 실패");
            }
        }

        // [이벤트] 취소/종료 버튼 클릭
        private void Button_Calncell_Click(object sender, EventArgs e)
        {
            // 프로그램 전체 종료
            Application.Exit();
        }
    }
}