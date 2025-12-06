using Project.Managers;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

// MenuItem 이름 충돌 방지
using MenuItem = Project.Models.MenuItem;

namespace Project
{
    public partial class KioskForm : Form
    {
        // 장바구니 데이터 (Key: 메뉴ID, Value: (메뉴객체, 수량))
        private Dictionary<int, (MenuItem Menu, int Qty)> cart = new Dictionary<int, (MenuItem, int)>();

        // 현재 선택된 언어 (기본: 한국어)
        private string currentLang = "ko";

        public KioskForm()
        {
            InitializeComponent();

            // 1. 폼 초기 설정
            this.Text = "Cafe Kiosk";
            this.StartPosition = FormStartPosition.CenterScreen;
            

            // 2. 그리드(장바구니) 설정
            StyleManager.ApplyGridStyle(Dgv_Cart);
            SetupCartGrid();

            // 3. 초기 메뉴 로드
            LoadMenuButtons();
        }

        // ---------------------------------------------------------
        // 1. 초기 설정 및 그리드 구성
        // ---------------------------------------------------------
        private void SetupCartGrid()
        {
            Dgv_Cart.Columns.Clear();

            // [0] ID (숨김)
            Dgv_Cart.Columns.Add("colId", "ID");
            Dgv_Cart.Columns["colId"].Visible = false;

            // [1] 메뉴명
            Dgv_Cart.Columns.Add("colName", "메뉴명");
            Dgv_Cart.Columns["colName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // [2] 수량
            Dgv_Cart.Columns.Add("colQty", "수량");
            Dgv_Cart.Columns["colQty"].Width = 40;
            Dgv_Cart.Columns["colQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // [3] 금액
            Dgv_Cart.Columns.Add("colPrice", "금액");
            Dgv_Cart.Columns["colPrice"].Width = 70;
            Dgv_Cart.Columns["colPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // [4] (+) 버튼
            DataGridViewButtonColumn btnPlus = new DataGridViewButtonColumn();
            btnPlus.Name = "btnPlus";
            btnPlus.HeaderText = "";
            btnPlus.Text = "+";
            btnPlus.UseColumnTextForButtonValue = true;
            btnPlus.Width = 30;
            Dgv_Cart.Columns.Add(btnPlus);

            // [5] (-) 버튼
            DataGridViewButtonColumn btnMinus = new DataGridViewButtonColumn();
            btnMinus.Name = "btnMinus";
            btnMinus.HeaderText = "";
            btnMinus.Text = "-";
            btnMinus.UseColumnTextForButtonValue = true;
            btnMinus.Width = 30;
            Dgv_Cart.Columns.Add(btnMinus);

            // [6] (X) 삭제 버튼
            DataGridViewButtonColumn btnDel = new DataGridViewButtonColumn();
            btnDel.Name = "btnDel";
            btnDel.HeaderText = "";
            btnDel.Text = "X";
            btnDel.UseColumnTextForButtonValue = true;
            btnDel.Width = 30;
            btnDel.DefaultCellStyle.ForeColor = Color.Red;
            Dgv_Cart.Columns.Add(btnDel);

            Dgv_Cart.RowHeadersVisible = false;
            Dgv_Cart.AllowUserToAddRows = false;
            Dgv_Cart.ReadOnly = true;
        }

        // ---------------------------------------------------------
        // 2. 메뉴 버튼 생성 (이미지 + 번역 + 품절체크)
        // ---------------------------------------------------------
        private async void LoadMenuButtons()
        {
            Flow_Menu.Controls.Clear();
            List<MenuItem> menuList = ProductManager.GetMenus();
            string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MenuImages");
            string myId = Global.CurrentUserID;

            this.Text = "메뉴 불러오는 중...";

            foreach (var menu in menuList)
            {
                Button btn = new Button();
                btn.Size = new Size(180, 220);
                btn.BackColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Font = new Font("맑은 고딕", 11, FontStyle.Bold);
                btn.Margin = new Padding(15);
                btn.Tag = menu;

                // (1) 번역 및 텍스트 설정
                string displayName = menu.Name;
                if (currentLang != "ko")
                {
                    displayName = await TranslationManager.TranslateAsync(menu.Name, currentLang);
                }
                btn.Text = $"{displayName}\n{menu.Price:N0}원";

                // (2) 이미지 로드
                string imagePath = Path.Combine(imageFolder, menu.Name + ".png");
                if (!File.Exists(imagePath)) imagePath = Path.Combine(imageFolder, menu.Name + ".jpg");

                if (File.Exists(imagePath))
                {
                    Image originalImg = Image.FromFile(imagePath);
                    btn.Image = ResizeImage(originalImg, 140, 140);
                }

                // (3) ★ 품절 체크 로직 수정 ★
                bool isAvailable = StockManager.CheckMenuAvailability(myId, menu.Id);

                if (isAvailable)
                {
                    btn.ForeColor = Color.Black;
                }
                else
                {
                    // 품절이지만 버튼은 살아있어야 함! (Enabled = false 삭제)
                    string soldOutText = (currentLang == "en") ? "(Sold Out)" : (currentLang == "ja") ? "(売切れ)" : "(품절)";
                    btn.Text = $"{displayName}\n{soldOutText}";
                    btn.ForeColor = Color.Red;

                    // btn.Enabled = false;  <-- ★ 이 줄을 지웠습니다! (클릭 가능하게)

                    if (btn.Image != null) btn.Image = DrawSoldOutMark(btn.Image);
                }

                // (4) 클릭 이벤트는 품절 여부 상관없이 무조건 연결
                btn.Click += MenuBtn_Click;

                btn.TextImageRelation = TextImageRelation.ImageAboveText;
                btn.TextAlign = ContentAlignment.BottomCenter;
                btn.ImageAlign = ContentAlignment.TopCenter;
                btn.Padding = new Padding(0, 10, 0, 10);

                Flow_Menu.Controls.Add(btn);
            }

            this.Text = "Cafe Kiosk";
        }

        // ---------------------------------------------------------
        // 3. 이벤트 핸들러 (클릭 동작)
        // ---------------------------------------------------------

        // [언어 변경] 라디오 버튼 클릭 시
        private void Language_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null || !rb.Checked) return;

            if (rb.Name == "Rb_En") currentLang = "en";
            else if (rb.Name == "Rb_Ja") currentLang = "ja";
            else currentLang = "ko";

            UpdateUILanguage(); // UI 번역
            LoadMenuButtons();  // 메뉴 다시 로드
        }

        // UI 텍스트 번역
        private void UpdateUILanguage()
        {
            if (currentLang == "en")
            {
                // 라벨 이름 확인 필요 (디자인 화면의 이름으로 맞추세요)
                if (Controls["label1"] != null) Controls["label1"].Text = "Order List";
                Btn_Order.Text = "Pay";
                Btn_Clear.Text = "Clear";
                if (Lbl_TotalPrice != null) Lbl_TotalPrice.Text = Lbl_TotalPrice.Text.Replace("총 결제금액", "Total");
            }
            else if (currentLang == "ja")
            {
                if (Controls["label1"] != null) Controls["label1"].Text = "注文リスト";
                Btn_Order.Text = "決済";
                Btn_Clear.Text = "空にする";
                if (Lbl_TotalPrice != null) Lbl_TotalPrice.Text = Lbl_TotalPrice.Text.Replace("총 결제금액", "合計");
            }
            else
            {
                if (Controls["label1"] != null) Controls["label1"].Text = "주문 내역";
                Btn_Order.Text = "결제하기";
                Btn_Clear.Text = "비우기";
                if (Lbl_TotalPrice != null) Lbl_TotalPrice.Text = Lbl_TotalPrice.Text.Replace("Total", "총 결제금액").Replace("合計", "총 결제금액");
            }
        }

        // [메뉴 버튼 클릭] -> 장바구니 추가
        private void MenuBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            MenuItem menu = btn.Tag as MenuItem;
            string myId = Global.CurrentUserID;

            // ★ 클릭했을 때 재고 확인 (여기서 막음)
            bool isAvailable = StockManager.CheckMenuAvailability(myId, menu.Id);

            if (!isAvailable)
            {
                // 품절 메시지 출력
                string msg = (currentLang == "en") ? "This item is sold out." :
                             (currentLang == "ja") ? "この商品は売り切れです。" :
                             "이 메뉴는 품절되어 선택할 수 없습니다.";

                MessageBox.Show(msg, "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // 장바구니에 담지 않고 함수 종료
            }

            // 재고가 있으면 장바구니 추가
            AddToCart(menu.Id, menu, 1);
        }

        // [장바구니 버튼 클릭] (+, -, X)
        private void Dgv_Cart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // 메뉴 ID 가져오기
            int menuId = Convert.ToInt32(Dgv_Cart.Rows[e.RowIndex].Cells["colId"].Value);

            if (!cart.ContainsKey(menuId)) return;
            var item = cart[menuId];

            string colName = Dgv_Cart.Columns[e.ColumnIndex].Name;

            if (colName == "btnPlus") AddToCart(menuId, item.Menu, 1);
            else if (colName == "btnMinus") AddToCart(menuId, item.Menu, -1);
            else if (colName == "btnDel") { cart.Remove(menuId); UpdateCartDisplay(); }
        }

        // [결제하기]
        private void Btn_Order_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0) return;

            if (MessageBox.Show("결제하시겠습니까?", "주문", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string myId = Global.CurrentUserID;
                int successCount = 0;

                foreach (var item in cart.Values)
                {
                    try
                    {
                        // ★ [예외 처리 사용] 여기서도 예외가 터질 수 있음
                        var result = SalesManager.SellMenu(myId, item.Menu.Id, item.Qty);
                        if (result.IsSuccess) successCount++;
                    }
                    catch (OutOfStockException ex) // ★ [예외 잡기]
                    {
                        MessageBox.Show(ex.Message, "품절 알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("시스템 오류: " + ex.Message);
                    }
                }

                if (successCount > 0)
                {
                    MessageBox.Show("주문이 완료되었습니다!");
                    cart.Clear();
                    UpdateCartDisplay();
                }
            }
        }

        // [비우기]
        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            if (cart.Count > 0)
            {
                cart.Clear();
                UpdateCartDisplay();
            }
        }

        // ---------------------------------------------------------
        // 4. 내부 로직 (계산 및 이미지 처리)
        // ---------------------------------------------------------

        private void AddToCart(int id, MenuItem menu, int qtyDelta)
        {
            if (cart.ContainsKey(id))
            {
                var item = cart[id];
                int newQty = item.Qty + qtyDelta;
                if (newQty <= 0) cart.Remove(id);
                else cart[id] = (item.Menu, newQty);
            }
            else if (qtyDelta > 0)
            {
                cart.Add(id, (menu, qtyDelta));
            }
            UpdateCartDisplay();
        }

        private void UpdateCartDisplay()
        {
            Dgv_Cart.Rows.Clear();
            int totalPrice = 0;

            foreach (var kvp in cart)
            {
                int id = kvp.Key;
                var item = kvp.Value;
                int sum = item.Menu.Price * item.Qty;
                totalPrice += sum;

                Dgv_Cart.Rows.Add(id, item.Menu.Name, item.Qty, sum.ToString("N0"), "+", "-", "X");
            }

            string prefix = (currentLang == "en") ? "Total: " : (currentLang == "ja") ? "合計: " : "총 결제금액: ";
            Lbl_TotalPrice.Text = $"{prefix}{totalPrice:N0}원";
        }

        private Image ResizeImage(Image img, int w, int h)
        {
            Bitmap bmp = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, w, h);
            }
            return bmp;
        }

        private Image DrawSoldOutMark(Image original)
        {
            Bitmap bmp = new Bitmap(original);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                using (Brush dimBrush = new SolidBrush(Color.FromArgb(150, 50, 50, 50)))
                    g.FillRectangle(dimBrush, 0, 0, bmp.Width, bmp.Height);

                string text = "SOLD OUT";
                Font font = new Font("Arial", 20, FontStyle.Bold);
                SizeF textSize = g.MeasureString(text, font);
                float x = (bmp.Width - textSize.Width) / 2;
                float y = (bmp.Height - textSize.Height) / 2;

                g.DrawString(text, font, Brushes.Red, x, y);
                g.DrawRectangle(new Pen(Color.Red, 3), x - 5, y - 5, textSize.Width + 10, textSize.Height + 10);
            }
            return bmp;
        }
    }
}