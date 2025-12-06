using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CafeStockSystem // 본인 프로젝트 이름 확인!
{
    public class RoundGroupBox : GroupBox
    {
        public int BorderRadius { get; set; } = 20;
        public Color BorderColor { get; set; } = Color.LightGray;

        public RoundGroupBox()
        {
            this.DoubleBuffered = true;
            // 크기가 변할 때마다 둥근 모양을 다시 계산하도록 설정
            this.Resize += RoundGroupBox_Resize;
        }

        private void RoundGroupBox_Resize(object sender, EventArgs e)
        {
            if (this.DesignMode) UpdateRegion(); // 디자인 모드일 때만 갱신 (선택사항)
        }

        // 핵심: 컨트롤의 실제 모양(Region)을 둥글게 잘라버리는 함수
        private void UpdateRegion()
        {
            if (this.Width == 0 || this.Height == 0) return;

            // Region은 테두리보다 약간 안쪽으로 잡아야 깔끔합니다
            using (GraphicsPath path = GetRoundPath(this.ClientRectangle, BorderRadius))
            {
                this.Region = new Region(path);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // 1. 화면에 그리기 전에 모양을 먼저 잘라냅니다.
            UpdateRegion();

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // 사각형 영역 계산
            Rectangle rect = this.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;

            using (GraphicsPath path = GetRoundPath(rect, BorderRadius))
            using (Pen pen = new Pen(BorderColor, 1))
            {
                // 글자 크기 측정
                SizeF stringSize = g.MeasureString(this.Text, this.Font);
                Rectangle textRect = new Rectangle(10, 0, (int)stringSize.Width + 2, (int)stringSize.Height);

                // 내부 배경색 채우기 (필요하면 활성화)
                // g.FillPath(new SolidBrush(Color.White), path); 

                // 테두리 그리기
                g.DrawPath(pen, path);

                // 텍스트 그리기 (배경색으로 덮어서 선 지움)
                // 주의: 여기서 BackColor는 부모의 색이 아니라 이 컨트롤의 내부 색상입니다.
                // 만약 내부를 흰색으로 쓰고 싶다면 Color.White로 바꾸세요.
                g.FillRectangle(new SolidBrush(this.BackColor), textRect);
                g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), 10, 0);
            }
        }

        private GraphicsPath GetRoundPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            // 크기가 너무 작으면 에러 방지
            if (d > rect.Width) d = rect.Width;
            if (d > rect.Height) d = rect.Height;

            path.AddArc(rect.X, rect.Y + 7, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y + 7, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}