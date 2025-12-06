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
            // ★ 디버깅용: 이 메시지가 안 뜨면 1번(버튼 연결) 문제입니다.
            // MessageBox.Show("버튼 클릭됨!"); 

            string inputID = Text_ID.Text;
            string inputPW = Text_PW.Text;

            try
            {
                // 1. 여기서 로그인 시도 -> 실패 시 예외가 날아옴
                DbResult<User> result = AuthManager.Authenticate(inputID, inputPW);

                // 2. 예외 없이 통과했다면 성공 로직 진행 (혹은 DB연결 실패 메시지)
                if (result.IsSuccess)
                {
                    Global.CurrentUserID = result.Data.Id;

                    // 화면 전환
                    if (Chk_Kiosk.Checked)
                    {
                        KioskForm kiosk = new KioskForm();
                        kiosk.FormClosed += (s, args) => this.Close();
                        kiosk.Show();
                    }
                    else
                    {
                        MainForm main = new MainForm();
                        main.FormClosed += (s, args) => this.Close();
                        main.Show();
                    }
                    this.Hide();
                }
                else
                {
                    // DB 연결 오류 등은 여기서 처리
                    MessageBox.Show(result.Message, "시스템 오류");
                }
            }
            // ★ 3. 여기서 '로그인 실패 예외'를 잡아서 메시지 출력
            catch (LoginFailedException ex)
            {
                MessageBox.Show($"입력하신 ID '{ex.AttemptedId}'는 존재하지 않거나 비밀번호가 틀렸습니다.",
                    "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("알 수 없는 오류: " + ex.Message);
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