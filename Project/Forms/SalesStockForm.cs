using Project.Managers;
using Project.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project
{
    // [조건: Form 4개 이상] 재고 트랜잭션 처리 화면
    public partial class SalesStockForm : Form
    {
        // 화면 상태(판매/입고/폐기) 관리용 열거형
        private enum Mode { Sell, In, Out }
        private Mode currentMode = Mode.Sell;

        // 생성자: 화면 초기화
        public SalesStockForm()
        {
            InitializeComponent();
        }

        // 1. 폼 로드 시 초기 설정
        private void SalesStockForm_Load(object sender, EventArgs e)
        {
            // [조건: 클래스 사용] 메뉴 및 UI 제어
            MenuManager.HighlightMenu(panelTop, Btn_Stock);
            MenuManager.AttachNavigation(this, panelTop);

            // 그리드 스타일 적용
            StyleManager.ApplyGridStyle(Dgv_Stock);
            SetupGrid();

            // 초기 모드 설정 (판매)
            Rb_Sell.Checked = true;
            UpdateUIMode();
            LoadStockGrid();
        }

        // 그리드 컬럼 구성
        private void SetupGrid()
        {
            Dgv_Stock.Columns.Clear();
            Dgv_Stock.Columns.Add("colName", "품목명");
            Dgv_Stock.Columns.Add("colCurrent", "현재 재고");
            Dgv_Stock.Columns.Add("colMin", "최소 재고");
            Dgv_Stock.Columns.Add("colState", "상태");

            Dgv_Stock.Columns["colName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        // 2. 라디오 버튼 변경 시 UI 모드 전환
        private void Rb_Mode_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUIMode();
        }

        // UI 모드 업데이트 (버튼 색상 및 콤보박스 변경)
        private void UpdateUIMode()
        {
            if (Rb_Sell.Checked)
            {
                currentMode = Mode.Sell;
                Btn_Action.Text = "🛒 판매 처리";
                Btn_Action.BackColor = Color.Black;
                // [조건: 파일 처리/DB] 메뉴 목록 로드
                LoadCombo_Menu();
            }
            else if (Rb_In.Checked)
            {
                currentMode = Mode.In;
                Btn_Action.Text = "📦 입고 처리";
                Btn_Action.BackColor = Color.ForestGreen;
                // [조건: 파일 처리/DB] 원재료 목록 로드
                LoadCombo_Ingredient();
            }
            else if (Rb_Out.Checked)
            {
                currentMode = Mode.Out;
                Btn_Action.Text = "🗑 폐기 처리";
                Btn_Action.BackColor = Color.Crimson;
                LoadCombo_Ingredient();
            }
        }

        // 원재료 콤보박스 로드 (StockManager 사용)
        private void LoadCombo_Ingredient()
        {
            var data = StockManager.GetAllIngredients();
            if (data.Count > 0)
            {
                Cbo_Item.DataSource = new BindingSource(data, null);
                Cbo_Item.DisplayMember = "Value";
                Cbo_Item.ValueMember = "Key";
            }
        }

        // 메뉴 콤보박스 로드 (ProductManager 사용)
        private void LoadCombo_Menu()
        {
            var data = ProductManager.GetMenuCombo();
            if (data.Count > 0)
            {
                Cbo_Item.DataSource = new BindingSource(data, null);
                Cbo_Item.DisplayMember = "Value";
                Cbo_Item.ValueMember = "Key";
            }
        }

        // 재고 현황 그리드 조회 (Read)
        private void LoadStockGrid()
        {
            Dgv_Stock.Rows.Clear();
            // [조건: 파일 처리/DB] StockManager를 통해 재고 데이터 조회
            var list = StockManager.GetMyStock(Global.CurrentUserID);

            foreach (var item in list)
            {
                // 재고율 및 상태 계산 (3단계: 품절/부족/정상)
                double rate = (item.MinStock > 0) ? (item.CurrentStock / item.MinStock * 100) : 0;

                string statusText = "정상";
                Color statusColor = Color.LimeGreen;
                Color rowBackColor = Color.White;

                if (item.CurrentStock == 0)
                {
                    statusText = "품절";
                    statusColor = Color.Red;
                    rowBackColor = Color.FromArgb(255, 240, 240);
                }
                else if (rate < 50.0)
                {
                    statusText = "부족";
                    statusColor = Color.Orange;
                    rowBackColor = Color.FromArgb(255, 250, 235);
                }
                else
                {
                    statusText = "정상";
                    statusColor = Color.LimeGreen;
                    rowBackColor = Color.White;
                }

                // 데이터 추가
                int idx = Dgv_Stock.Rows.Add(
                    item.Name,
                    item.CurrentStock + " " + item.Unit,
                    item.MinStock + " " + item.Unit,
                    statusText
                );

                // 스타일 적용 (색상)
                Dgv_Stock.Rows[idx].Cells["colState"].Style.ForeColor = statusColor;
                Dgv_Stock.Rows[idx].Cells["colState"].Style.SelectionForeColor = statusColor;

                if (rowBackColor != Color.White)
                {
                    Dgv_Stock.Rows[idx].DefaultCellStyle.BackColor = rowBackColor;
                }
            }
        }

        // 3. 트랜잭션 실행 버튼 클릭
        private void Btn_Action_Click(object sender, EventArgs e)
        {
            if (Cbo_Item.SelectedValue == null) return;

            int id = (int)Cbo_Item.SelectedValue;
            int qty = (int)Num_Qty.Value;
            string myId = Global.CurrentUserID;

            // [선택 조건: 제네릭 사용] 결과 반환값
            DbResult<int> result = null;

            try
            {
                if (qty <= 0) { MessageBox.Show("수량은 1 이상이어야 합니다."); return; }

                switch (currentMode)
                {
                    case Mode.Sell:
                        // [조건: 파일 처리/DB] SalesManager를 통해 판매 처리 (트랜잭션)
                        // 내부에서 재고 부족 시 OutOfStockException 발생시킴
                        result = SalesManager.SellMenu(myId, id, qty);
                        break;
                    case Mode.In:
                        // [조건: 파일 처리/DB] StockManager를 통해 입고 처리
                        result = StockManager.UpdateStock(myId, id, qty, true);
                        break;
                    case Mode.Out:
                        // [선택 조건: 인덱서 사용] 폐기 전 재고 확인
                        string selectedName = Cbo_Item.Text;
                        Inventory myStock = StockManager.GetInventory(myId);

                        // 인덱서를 사용하여 현재 재고 조회 (myStock["이름"])
                        if (myStock[selectedName] < qty)
                        {
                            MessageBox.Show($"현재 재고({myStock[selectedName]})보다 더 많이 폐기할 수 없습니다.");
                            return;
                        }

                        // [조건: 파일 처리/DB] StockManager를 통해 폐기 처리
                        result = StockManager.UpdateStock(myId, id, qty, false);
                        break;
                }

                if (result != null)
                {
                    MessageBox.Show(result.Message);
                    if (result.IsSuccess) LoadStockGrid(); // 성공 시 목록 갱신
                }
            }
            // [선택 조건: 사용자 정의 예외 처리]
            catch (OutOfStockException ex)
            {
                MessageBox.Show($"[재고 부족] {ex.Message}\n발주가 필요합니다.", "판매 불가", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // [조건: 예외 처리]
            catch (Exception ex)
            {
                MessageBox.Show("오류: " + ex.Message);
            }
        }
    }
}