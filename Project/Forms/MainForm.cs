using Project.Managers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Project
{
    // [조건: Form 4개 이상] 메인 대시보드 화면 클래스
    public partial class MainForm : Form
    {
        // 생성자: 화면 구성요소 초기화
        public MainForm()
        {
            InitializeComponent();

            // 1. 메뉴바 설정
            // [조건: 클래스 사용] MenuManager를 통한 상단 메뉴 UI 제어
            Project.Managers.MenuManager.HighlightMenu(panelTop, Btn_Main);
            Project.Managers.MenuManager.AttachNavigation(this, this);

            // 2. 그리드 스타일 설정
            // [조건: 클래스 사용] StyleManager를 통한 디자인 통일
            Project.Managers.StyleManager.ApplyGridStyle(Dgv_Stock);

            // 3. 데이터 로드 및 시각화
            LoadDashboardData();
        }

        // 대시보드 데이터 조회 및 UI 반영 메서드
        private void LoadDashboardData()
        {
            try
            {
                // [조건: 전역 변수 활용] 로그인한 사용자 ID 조회
                string myId = Project.Models.Global.CurrentUserID;

                // ----------------------------------------------------
                // 1. 상단 요약 카드 데이터 설정
                // ----------------------------------------------------
                // [조건: 파일 처리/DB] SalesManager를 통해 통계 데이터 조회
                var stats = Project.Managers.SalesManager.GetDashboardStats(myId);

                Label_IngredientNum.Text = stats.ingCount.ToString();      // 원재료 수
                Label_MenuNum.Text = stats.menuCount.ToString();           // 메뉴 수
                Label_SaelsNum.Text = stats.totalSales.ToString("#,##0") + "원"; // 총 매출

                // ----------------------------------------------------
                // 2. 하단 재고 현황 그리드 구성
                // ----------------------------------------------------
                // [조건: 제네릭 사용] List<Ingredient> 타입으로 데이터 수신
                // [조건: 파일 처리/DB] StockManager를 통해 재고 목록 조회
                List<Project.Models.Ingredient> stockList = Project.Managers.StockManager.GetMyStock(myId);

                Dgv_Stock.Rows.Clear(); // 기존 데이터 초기화

                int lowStockCount = 0; // 재고 부족 품목 카운터

                foreach (var item in stockList)
                {
                    // 변수 초기화
                    string statusDot = "●";
                    Color statusColor;      // 상태 표시 점 색상
                    Color rowBackColor;     // 행 배경 색상

                    // 재고율 계산 (현재고 / 최소재고 * 100)
                    double rate = (item.MinStock > 0) ? (item.CurrentStock / item.MinStock * 100) : 0;

                    // 상태 판단 로직 (3단계: 품절/부족/정상)
                    if (item.CurrentStock == 0)
                    {
                        // [품절]
                        statusColor = Color.Red;
                        rowBackColor = Color.FromArgb(255, 240, 240); // 연한 빨강
                        lowStockCount++;
                    }
                    else if (rate < 50.0)
                    {
                        // [부족] (재고율 50% 미만)
                        statusColor = Color.Orange;
                        rowBackColor = Color.FromArgb(255, 250, 235); // 연한 주황
                        lowStockCount++;
                    }
                    else
                    {
                        // [정상]
                        statusColor = Color.LimeGreen;
                        rowBackColor = Color.White;
                    }

                    // 그리드 행 추가
                    int rowIndex = Dgv_Stock.Rows.Add(
                        statusDot,
                        item.Name,
                        item.Unit,
                        item.CurrentStock,
                        item.MinStock,
                        rate.ToString("0") + "%"
                    );

                    // 스타일 적용 (상태 점 색상 변경)
                    Dgv_Stock.Rows[rowIndex].Cells["colStatus"].Style.ForeColor = statusColor;
                    Dgv_Stock.Rows[rowIndex].Cells["colStatus"].Style.SelectionForeColor = statusColor;

                    // 배경색 적용 (비정상 상태일 경우 강조)
                    if (rowBackColor != Color.White)
                    {
                        Dgv_Stock.Rows[rowIndex].DefaultCellStyle.BackColor = rowBackColor;
                    }
                }

                // ----------------------------------------------------
                // 3. 재고 부족 경고 배너 제어
                // ----------------------------------------------------
                if (lowStockCount > 0)
                {
                    Box_Warning.Visible = true;
                    if (Box_WarningExp != null)
                        Box_WarningExp.Text = $"⚠ 재고 부족 경고: {lowStockCount}개의 원재료가 최소 재고 수준 이하입니다.";
                }
                else
                {
                    Box_Warning.Visible = false;
                }
            }
            catch (Exception ex)
            {
                // [조건: 예외 처리] 실행 중 오류 발생 시 메시지 출력
                MessageBox.Show("데이터 로드 오류: " + ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            IngredientManageForm nextForm = new IngredientManageForm();

            // 2. 매니저에게 맡기기 (현재 폼, 다음 폼)
            MenuManager.OpenForm(this, nextForm);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MenuManageForm nextForm = new MenuManageForm();

            // 2. 매니저에게 맡기기 (현재 폼, 다음 폼)
            MenuManager.OpenForm(this, nextForm);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            SalesStockForm nextForm = new SalesStockForm();

            // 2. 매니저에게 맡기기 (현재 폼, 다음 폼)
            MenuManager.OpenForm(this, nextForm);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            SalesViewForm nextForm = new SalesViewForm();

            // 2. 매니저에게 맡기기 (현재 폼, 다음 폼)
            MenuManager.OpenForm(this, nextForm);
        }
    }
}