using System.Drawing;
using System.Windows.Forms;

namespace Project.Managers
{
    // [조건: 클래스 2개 이상 사용] UI 디자인 및 스타일 관리 전담 클래스
    public static class StyleManager
    {
        // 그리드뷰 스타일 일괄 적용 메서드
        public static void ApplyGridStyle(DataGridView dgv)
        {
            // 1. 기본 설정
            // - 배경색 흰색 지정 및 테두리 제거
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            // - 셀 테두리: 가로선만 표시
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // 2. 헤더 스타일 설정
            // - 윈도우 테마 스타일 해제 (커스텀 색상 적용 필수)
            dgv.EnableHeadersVisualStyles = false;
            // - 배경: 연회색, 글자: 연한 검정, 폰트: 굵게
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(100, 100, 100);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 45;

            // 3. 내용(행) 스타일 설정
            // - 폰트 및 글자색 지정
            dgv.DefaultCellStyle.Font = new Font("맑은 고딕", 10F);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            // - 선택 시 색상: 연한 파랑 배경, 검정 글자
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0); // 좌측 여백

            // 4. 기타 속성 설정
            // - 행 높이 확장 및 행 추가/수정 제한
            dgv.RowTemplate.Height = 40;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ReadOnly = true;

            // 5. 버그 방지 처리
            // - 클릭 시 그리드 크기 축소 현상 방지 (자동 크기 조절 해제)
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            // - 부모 컨테이너 채움 설정 (필요시 주석 해제)
            // dgv.Dock = DockStyle.Fill;
        }
    }
}