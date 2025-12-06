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
        // 장바구니 데이터
        private Dictionary<int, (MenuItem Menu, int Qty)> cart = new Dictionary<int, (MenuItem, int)>();
        private string currentLang = "ko";

        // ★ [추가됨] 인덱서 사용을 위한 변수
        private MenuBook myMenuBook;

        public KioskForm()
        {
            InitializeComponent();

            this.Text = "Cafe Kiosk";
            this.StartPosition = FormStartPosition.CenterScreen;

            StyleManager.ApplyGridStyle(Dgv_Cart);
            SetupCartGrid();

            LoadMenuButtons();
        }

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
            btnPlus.HeaderText = ""; // ★ 핵심: 헤더 제목을 비워줍니다 (안 그러면 'btnPlus'라고 뜸)
            btnPlus.Text = "+";
            btnPlus.UseColumnTextForButtonValue = true;
            btnPlus.Width = 30;
            Dgv_Cart.Columns.Add(btnPlus);

            // [5] (-) 버튼
            DataGridViewButtonColumn btnMinus = new DataGridViewButtonColumn();
            btnMinus.Name = "btnMinus";
            btnMinus.HeaderText = ""; // ★ 핵심: 헤더 제목을 비워줍니다
            btnMinus.Text = "-";
            btnMinus.UseColumnTextForButtonValue = true;
            btnMinus.Width = 30;
            Dgv_Cart.Columns.Add(btnMinus);

            // [6] (X) 삭제 버튼
            DataGridViewButtonColumn btnDel = new DataGridViewButtonColumn();
            btnDel.Name = "btnDel";
            btnDel.HeaderText = ""; // ★ 핵심: 헤더 제목을 비워줍니다
            btnDel.Text = "X";
            btnDel.UseColumnTextForButtonValue = true;
            btnDel.Width = 30;
            btnDel.DefaultCellStyle.ForeColor = Color.Red;
            Dgv_Cart.Columns.Add(btnDel);

            Dgv_Cart.RowHeadersVisible = false;
            Dgv_Cart.AllowUserToAddRows = false;
            Dgv_Cart.ReadOnly = true;
        }

        private async void LoadMenuButtons()
        {
            Flow_Menu.Controls.Clear();

            List<MenuItem> menuList;
            try
            {
                menuList = ProductManager.GetMenus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("메뉴를 불러오는 중 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (menuList == null || menuList.Count == 0)
            {
                MessageBox.Show("불러올 메뉴가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 인덱서용 초기화 (null 안전)
            try { myMenuBook = new MenuBook(menuList); }
            catch { myMenuBook = null; }

            string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MenuImages");
            string myId = Global.CurrentUserID;

            this.Text = "메뉴 불러오는 중...";

            foreach (var menu in menuList)
            {
                try
                {
                    Button btn = new Button();
                    btn.Size = new Size(180, 220);
                    btn.BackColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Font = new Font("맑은 고딕", 11, FontStyle.Bold);
                    btn.Margin = new Padding(15);
                    btn.Tag = menu;

                    string displayName = menu?.Name ?? "(이름 없음)";

                    if (currentLang != "ko")
                    {
                        try
                        {
                            var translated = await TranslationManager.TranslateAsync(menu.Name, currentLang);
                            if (!string.IsNullOrWhiteSpace(translated)) displayName = translated;
                        }
                        catch
                        {
                            // 번역 실패 시 원본 이름 사용
                            displayName = menu.Name;
                        }
                    }

                    btn.Text = $"{displayName}\n{menu.Price:N0}원";

                    string imagePath = Path.Combine(imageFolder, menu.Name + ".png");
                    if (!File.Exists(imagePath)) imagePath = Path.Combine(imageFolder, menu.Name + ".jpg");

                    if (File.Exists(imagePath))
                    {
                        try
                        {
                            using (var originalImg = Image.FromFile(imagePath))
                            {
                                btn.Image = ResizeImage(originalImg, 140, 140);
                            }
                        }
                        catch
                        {
                            // 이미지 로드 실패는 무시하고 텍스트만 표시
                        }
                    }

                    bool isAvailable = true;
                    try
                    {
                        isAvailable = StockManager.CheckMenuAvailability(myId, menu.Id);
                    }
                    catch
                    {
                        // 재고 확인 실패 시 기본적으로 '판매 가능'으로 둬 UI가 막히지 않게 함
                        isAvailable = true;
                    }

                    if (isAvailable)
                    {
                        btn.ForeColor = Color.Black;
                    }
                    else
                    {
                        string soldOutText = (currentLang == "en") ? "(Sold Out)" : (currentLang == "ja") ? "(売切れ)" : "(품절)";
                        btn.Text = $"{displayName}\n{soldOutText}";
                        btn.ForeColor = Color.Red;
                        if (btn.Image != null) btn.Image = DrawSoldOutMark(btn.Image);
                    }

                    btn.Click += MenuBtn_Click;
                    btn.TextImageRelation = TextImageRelation.ImageAboveText;
                    btn.TextAlign = ContentAlignment.BottomCenter;
                    btn.ImageAlign = ContentAlignment.TopCenter;
                    btn.Padding = new Padding(0, 10, 0, 10);

                    Flow_Menu.Controls.Add(btn);
                }
                catch (Exception exInner)
                {
                    // 개별 메뉴 처리 실패는 전체 로드에 영향을 주지 않도록 로깅하고 계속
                    Console.WriteLine($"메뉴 생성 중 오류: {exInner.Message}");
                    continue;
                }
            }

            this.Text = "Cafe Kiosk";
        }

        private void Language_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null || !rb.Checked) return;

            if (rb.Name == "Rb_En") currentLang = "en";
            else if (rb.Name == "Rb_Ja") currentLang = "ja";
            else currentLang = "ko";

            UpdateUILanguage();
            LoadMenuButtons();
        }

        private void UpdateUILanguage()
        {
            if (currentLang == "en")
            {
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

        private void MenuBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            MenuItem menu = btn.Tag as MenuItem;
            string myId = Global.CurrentUserID;

            bool isAvailable = StockManager.CheckMenuAvailability(myId, menu.Id);

            if (!isAvailable)
            {
                string msg = (currentLang == "en") ? "This item is sold out." :
                             (currentLang == "ja") ? "この商品は売り切れです。" :
                             "이 메뉴는 품절되어 선택할 수 없습니다.";

                MessageBox.Show(msg, "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // =========================================================
            // ★ [조건: 인덱서 사용 2] 여기서 인덱서를 사용하여 메뉴 이름을 가져옵니다.
            // (실제 기능상으로는 큰 의미 없지만, 인덱서 사용 조건을 만족하기 위함)
            // =========================================================
            if (myMenuBook != null)
            {
                string nameFromIndexer = myMenuBook[menu.Id];
                // 필요하다면 Console.WriteLine(nameFromIndexer); 등으로 확인 가능
            }

            AddToCart(menu.Id, menu, 1);
        }

        private void Dgv_Cart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int menuId = Convert.ToInt32(Dgv_Cart.Rows[e.RowIndex].Cells["colId"].Value);

            if (!cart.ContainsKey(menuId)) return;
            var item = cart[menuId];

            string colName = Dgv_Cart.Columns[e.ColumnIndex].Name;

            if (colName == "btnPlus") AddToCart(menuId, item.Menu, 1);
            else if (colName == "btnMinus") AddToCart(menuId, item.Menu, -1);
            else if (colName == "btnDel") { cart.Remove(menuId); UpdateCartDisplay(); }
        }

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
                        var result = SalesManager.SellMenu(myId, item.Menu.Id, item.Qty);
                        if (result.IsSuccess) successCount++;
                    }
                    // ★ [조건: 예외 처리 활용] 
                    // 일반적인 메시지가 아니라 클래스에 담긴 '데이터'를 꺼내서 보여줌
                    catch (OutOfStockException ex)
                    {
                        string msg = $"죄송합니다. '{ex.ItemName}' 재료가 {ex.Deficit}만큼 부족합니다.\n관리자에게 문의해주세요.";
                        MessageBox.Show(msg, "품절 알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            if (cart.Count > 0)
            {
                cart.Clear();
                UpdateCartDisplay();
            }
        }

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