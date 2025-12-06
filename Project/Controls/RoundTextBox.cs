using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CafeStockSystem // 본인 프로젝트 이름으로 꼭 맞추세요!
{
    [System.ComponentModel.DefaultEvent("TextChanged")]
    public class RoundTextBox : UserControl
    {
        // 내부에서 사용할 진짜 텍스트박스
        private TextBox textBox1 = new TextBox();

        // --- 속성 (Properties) ---
        public int BorderRadius { get; set; } = 15;
        public Color BorderColor { get; set; } = Color.DarkGray;
        public int BorderSize { get; set; } = 2;

        // 힌트 텍스트 (예: "아이디를 입력하세요")
        private string placeholderText = "";
        public string PlaceholderText
        {
            get { return placeholderText; }
            set
            {
                placeholderText = value;
                textBox1.Text = ""; // 초기화
                SetPlaceholder();
            }
        }

        // 텍스트 속성 연결 (이걸 안 하면 겉에서 텍스트를 못 읽습니다)
        public override string Text
        {
            get
            {
                if (isPlaceholder) return "";
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
                SetPlaceholder();
            }
        }

        private bool isPlaceholder = false;

        public RoundTextBox()
        {
            // 컨테이너(UserControl) 설정
            this.AutoScaleMode = AutoScaleMode.None;
            this.Padding = new Padding(10, 5, 10, 5); // 내부 여백 (상하좌우)
            this.BackColor = Color.White;
            this.Size = new Size(250, 30);

            // 내부 텍스트박스 설정
            textBox1.BorderStyle = BorderStyle.None; // 테두리 없애기
            textBox1.Dock = DockStyle.Fill;
            textBox1.BackColor = this.BackColor;
            textBox1.Font = new Font("맑은 고딕", 9.5F);

            // 이벤트 연결
            textBox1.Enter += TextBox1_Enter;
            textBox1.Leave += TextBox1_Leave;
            textBox1.TextChanged += (s, e) => { if (!isPlaceholder) OnTextChanged(e); };

            this.Controls.Add(textBox1);
        }

        // --- 플레이스홀더 로직 ---
        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) && placeholderText != "")
            {
                isPlaceholder = true;
                textBox1.Text = placeholderText;
                textBox1.ForeColor = Color.Silver;

                // ★ 핵심: 안내 문구는 가리면 안 되니까 비밀번호 기능 끄기
                textBox1.PasswordChar = '\0';
            }
        }

        private void RemovePlaceholder()
        {
            if (isPlaceholder)
            {
                isPlaceholder = false;
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;

                // ★ 핵심: 입력 시작하면 저장해둔 문자로 다시 가리기
                textBox1.PasswordChar = _userPasswordChar;
            }
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder();
            this.Invalidate(); // 테두리 색 강조 등을 위해 다시 그리기
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            SetPlaceholder();
            this.Invalidate();
        }

        // --- 디자인 그리기 (둥근 테두리) ---
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetFigurePath(this.ClientRectangle, BorderRadius))
            using (Pen pen = new Pen(BorderColor, BorderSize))
            {
                // 배경 채우기
                this.Region = new Region(path);
                // 테두리 그리기
                g.DrawPath(pen, path);
            }
        }

        // 둥근 경로 계산 함수
        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        // 배경색 변경 시 내부 텍스트박스도 같이 변경
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            textBox1.BackColor = BackColor;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            textBox1.Focus(); // 핵심: 알맹이로 포커스 토스!
        }

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                if (textBox1 != null)
                {
                    textBox1.Font = value;
                }
            }
        }

        public char PasswordChar
        {
            get { return _userPasswordChar; }
            set
            {
                _userPasswordChar = value;
                // 지금 플레이스홀더 상태가 '아닐 때만' 즉시 적용
                if (!isPlaceholder)
                {
                    textBox1.PasswordChar = value;
                }
            }
        }

        // (선택사항) 시스템 기본 비밀번호 문자(까만 점) 사용 여부
        public bool UseSystemPasswordChar
        {
            get { return textBox1.UseSystemPasswordChar; }
            set { textBox1.UseSystemPasswordChar = value; }
        }

        private char _userPasswordChar = '\0'; // 사용자가 설정한 비밀번호 문자 저장용

    }
}