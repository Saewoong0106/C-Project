using Project.Managers;
using Project.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // 차트 사용 필수

namespace Project
{
    // [조건: Form 4개 이상] 매출 조회 및 통계 화면
    public partial class SalesViewForm : Form
    {
        // 생성자: 화면 초기화
        public SalesViewForm()
        {
            InitializeComponent();

            // 1. 메뉴바 설정
            // [조건: 클래스 사용] MenuManager를 통한 상단 메뉴 제어
            MenuManager.HighlightMenu(panelTop, Btn_Sales);
            MenuManager.AttachNavigation(this, panelTop);

            // 2. 그리드 스타일 적용
            // [조건: 클래스 사용] StyleManager를 통한 디자인 통일
            StyleManager.ApplyGridStyle(Dgv_SalesHistory);
            StyleManager.ApplyGridStyle(Dgv_MenuStats);

            // 3. 날짜 초기값 설정 (이번 달 1일 ~ 오늘)
            Dt_Start.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            Dt_End.Value = DateTime.Now;
        }

        // [조회] 버튼 클릭 이벤트
        private void Btn_Search_Click(object sender, EventArgs e)
        {
            LoadSalesData();
        }

        // 매출 데이터 조회 및 시각화
        private void LoadSalesData()
        {
            try
            {
                // [조건: 파일 처리/DB] SalesManager를 통해 기간별 매출 조회
                // [선택 조건: 제네릭 사용] DataTable 활용
                DataTable dt = SalesManager.GetSalesData(Global.CurrentUserID, Dt_Start.Value, Dt_End.Value);
                Dgv_SalesHistory.DataSource = dt;

                // 그리드 컬럼 설정 (헤더명 및 너비)
                if (Dgv_SalesHistory.Columns.Count > 0)
                {
                    Dgv_SalesHistory.Columns["SaleDate"].HeaderText = "판매 일시";
                    Dgv_SalesHistory.Columns["MenuName"].HeaderText = "메뉴명";
                    Dgv_SalesHistory.Columns["Qty"].HeaderText = "수량";
                    Dgv_SalesHistory.Columns["TotalAmt"].HeaderText = "금액";

                    // 컬럼 너비 자동 조절
                    Dgv_SalesHistory.Columns["SaleDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Dgv_SalesHistory.Columns["Qty"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Dgv_SalesHistory.Columns["TotalAmt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Dgv_SalesHistory.Columns["MenuName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // 3. 통계 계산 및 데이터 가공 (LINQ 활용)
                var rows = dt.AsEnumerable();

                // 데이터 없음 처리
                if (rows.Count() == 0)
                {
                    MessageBox.Show("조회된 데이터가 없습니다.");
                    ClearCharts();
                    return;
                }

                // [선택 조건: LINQ 사용] 요약 정보 계산 (합계, 개수)
                int totalAmt = rows.Sum(r => Convert.ToInt32(r["TotalAmt"]));
                int totalQty = rows.Sum(r => Convert.ToInt32(r["Qty"]));
                int menuCount = rows.Select(r => r["MenuName"].ToString()).Distinct().Count();

                // 요약 카드 업데이트
                Lbl_TotalSales.Text = totalAmt.ToString("#,##0") + "원";
                Lbl_TotalCount.Text = totalQty.ToString("#,##0") + "건";
                Lbl_TotalMenuType.Text = menuCount.ToString() + "종";

                // 4. 메뉴별 판매 요약 (그룹화 및 정렬)
                // [선택 조건: LINQ 사용] GroupBy를 통한 메뉴별 집계
                var menuStats = rows
                    .GroupBy(r => r["MenuName"].ToString())
                    .Select(g => new
                    {
                        MenuName = g.Key,
                        TotalQty = g.Sum(r => Convert.ToInt32(r["Qty"])),
                        TotalAmt = g.Sum(r => Convert.ToInt32(r["TotalAmt"]))
                    })
                    .OrderByDescending(x => x.TotalAmt) // 매출액 기준 내림차순 정렬
                    .ToList();

                // 메뉴별 통계 그리드 바인딩
                Dgv_MenuStats.DataSource = menuStats;
                Dgv_MenuStats.Columns["MenuName"].HeaderText = "메뉴명";
                Dgv_MenuStats.Columns["TotalQty"].HeaderText = "총 판매량";
                Dgv_MenuStats.Columns["TotalAmt"].HeaderText = "총 매출액";
                Dgv_MenuStats.Columns["MenuName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // 5. 차트 시각화
                DrawCharts(menuStats);
            }
            catch (Exception ex)
            {
                // [조건: 예외 처리] 오류 메시지 출력
                MessageBox.Show("조회 중 오류: " + ex.Message);
            }
        }

        // 차트 및 요약 정보 초기화
        private void ClearCharts()
        {
            Chart_Bar.Series.Clear();
            Chart_Pie.Series.Clear();
            Lbl_TotalSales.Text = "0원";
            Lbl_TotalCount.Text = "0건";
            Lbl_TotalMenuType.Text = "0종";
        }

        // 차트 그리기 (막대/파이)
        private void DrawCharts(dynamic menuStats)
        {
            // 1. 막대 차트 (매출액)
            Chart_Bar.Series.Clear();
            Series seriesBar = new Series("매출액");
            seriesBar.ChartType = SeriesChartType.Column;

            foreach (var item in menuStats)
            {
                seriesBar.Points.AddXY(item.MenuName, item.TotalAmt);
            }
            Chart_Bar.Series.Add(seriesBar);
            Chart_Bar.ChartAreas[0].AxisX.Interval = 1; // X축 라벨 전체 표시

            // 2. 파이 차트 (판매 비율)
            Chart_Pie.Series.Clear();
            Series seriesPie = new Series("판매비율");
            seriesPie.ChartType = SeriesChartType.Pie;

            foreach (var item in menuStats)
            {
                seriesPie.Points.AddXY(item.MenuName, item.TotalQty);
            }
            Chart_Pie.Series.Add(seriesPie);

            // 라벨 포맷 설정 (이름 + 퍼센트)
            seriesPie.Label = "#VALX (#PERCENT)";
            seriesPie.LegendText = "#VALX";
        }
    }
}