using Project.Managers; // 매니저 클래스 참조
using Project.Models;   // 데이터 모델 참조
using System;
using System.Collections.Generic;
using System.Windows.Forms;

// [필수] MenuItem 이름 충돌 방지 (System.Windows.Forms vs Project.Models)
using MenuItem = Project.Models.MenuItem;

namespace Project
{
    // [조건: Form 4개 이상] 메뉴 및 레시피 관리 화면 클래스
    public partial class MenuManageForm : Form
    {
        // 생성자: 화면 구성요소 초기화
        public MenuManageForm()
        {
            InitializeComponent();

            // 1. 메뉴바 UI 설정
            // [조건: 클래스 사용] MenuManager를 통한 상단 메뉴 제어
            MenuManager.HighlightMenu(panelTop, Btn_Menu);
            MenuManager.AttachNavigation(this, panelTop);

            // 2. 그리드 스타일 적용
            // [조건: 클래스 사용] StyleManager를 통한 디자인 통일
            StyleManager.ApplyGridStyle(Dgv_Menu);
            StyleManager.ApplyGridStyle(Dgv_Recipe);

            // 3. 초기 데이터 로드
            SetupGridColumns();
            LoadMenuList();
            LoadIngredientCombo(); // 콤보박스 데이터 바인딩

            // 초기 상태 설정
            ToggleRecipePanel(false); // 레시피 패널 숨김
            Label_Id.Visible = false; // ID 라벨 숨김
        }

        // --- 초기 설정 영역 ---

        // 그리드 컬럼 정의
        private void SetupGridColumns()
        {
            // [왼쪽] 메뉴 그리드 구성
            Dgv_Menu.Columns.Clear();
            Dgv_Menu.Columns.Add("colId", "ID");
            Dgv_Menu.Columns.Add("colName", "메뉴명");
            Dgv_Menu.Columns.Add("colPrice", "가격");

            Dgv_Menu.Columns["colId"].Visible = false;
            Dgv_Menu.Columns["colName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // [오른쪽] 레시피 그리드 구성
            Dgv_Recipe.Columns.Clear();
            Dgv_Recipe.Columns.Add("colRName", "재료명");
            Dgv_Recipe.Columns.Add("colRAmount", "소모량");

            // 삭제 버튼 컬럼 추가
            DataGridViewButtonColumn btnDel = new DataGridViewButtonColumn();
            btnDel.HeaderText = "삭제";
            btnDel.Text = "X";
            btnDel.UseColumnTextForButtonValue = true;
            btnDel.Width = 40;
            Dgv_Recipe.Columns.Add(btnDel);

            Dgv_Recipe.Columns["colRName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        // 메뉴 목록 조회 (Read)
        private void LoadMenuList()
        {
            Dgv_Menu.Rows.Clear();

            // [조건: 파일 처리/DB] ProductManager를 통해 메뉴 목록 조회
            // [조건: 제네릭 사용] List<MenuItem> 반환
            List<MenuItem> list = ProductManager.GetMenus();

            foreach (var m in list)
            {
                Dgv_Menu.Rows.Add(m.Id, m.Name, m.Price.ToString("#,##0") + "원");
            }
            ClearInput();
        }

        // 원재료 콤보박스 데이터 로드
        private void LoadIngredientCombo()
        {
            // [조건: 파일 처리/DB] StockManager를 통해 재료 목록 조회
            Dictionary<int, string> ingredients = StockManager.GetAllIngredients();

            if (ingredients.Count > 0)
            {
                Cbo_Ingredient.DataSource = new BindingSource(ingredients, null);
                Cbo_Ingredient.DisplayMember = "Value"; // 표시: 재료명
                Cbo_Ingredient.ValueMember = "Key";     // 값: ID
            }
        }

        // 우측 레시피 패널 표시 제어
        private void ToggleRecipePanel(bool show)
        {
            foreach (Control c in Box_Recipe.Controls)
            {
                if (c.Name == "Lbl_RecipePlaceholder") continue;
                c.Visible = show;
            }
            // 안내 문구 토글
            if (Label_RecipePlaceholder != null)
                Label_RecipePlaceholder.Visible = !show;
        }

        // 입력 필드 초기화
        private void ClearInput()
        {
            Label_Id.Text = "";
            Txt_Name.Text = "";
            Txt_Price.Text = "0";

            ToggleRecipePanel(false);
            Dgv_Recipe.Rows.Clear();
        }

        // --- 이벤트 핸들러 영역 ---

        // [신규] 버튼 클릭: 입력창 초기화
        private void Btn_New_Click(object sender, EventArgs e)
        {
            ClearInput();
            Txt_Name.Focus();
        }

        // [저장] 버튼 클릭: 메뉴 추가 및 수정 (Create / Update)
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txt_Name.Text)) return;

            int id = (Label_Id.Text == "") ? 0 : int.Parse(Label_Id.Text);
            string name = Txt_Name.Text;
            int price = int.Parse(Txt_Price.Text);

            // [조건: 파일 처리/DB] ProductManager 저장 요청
            var result = ProductManager.SaveMenu(id, name, price);

            if (result.IsSuccess)
            {
                MessageBox.Show(result.Message);
                LoadMenuList(); // 목록 갱신
            }
        }

        // [삭제] 버튼 클릭: 메뉴 삭제 (Delete)
        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (Label_Id.Text == "") return;

            if (MessageBox.Show("정말 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = int.Parse(Label_Id.Text);

                // [조건: 파일 처리/DB] ProductManager 삭제 요청
                ProductManager.DeleteMenu(id);
                LoadMenuList();
            }
        }

        // [그리드 클릭] 메뉴 선택 및 레시피 로드
        private void Dgv_Menu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                // [조건: 예외 처리] 데이터 변환 오류 방지
                DataGridViewRow row = Dgv_Menu.Rows[e.RowIndex];

                string menuId = row.Cells["colId"].Value?.ToString() ?? "";
                string menuName = row.Cells["colName"].Value?.ToString() ?? "";

                if (menuId == "") return;

                // 1. 좌측 입력창 데이터 바인딩
                Label_Id.Text = menuId;
                Txt_Name.Text = menuName;

                // 가격 문자열 숫자 변환 (콤마, '원' 제거)
                string rawPrice = row.Cells["colPrice"].Value.ToString().Replace("원", "").Replace(",", "");
                Txt_Price.Text = rawPrice.Replace("원", "").Replace(",", "").Trim();

                // 2. 우측 레시피 패널 활성화
                ToggleRecipePanel(true);

                // 3. 우측 라벨 갱신
                if (Label_Selected != null)
                {
                    Label_Selected.Text = menuName;
                }

                // 4. 레시피 목록 로드
                LoadRecipeList(int.Parse(menuId));
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 발생: " + ex.Message);
            }
        }

        // 레시피 목록 조회 및 그리드 출력
        private void LoadRecipeList(int menuId)
        {
            Dgv_Recipe.Rows.Clear();

            // [조건: 파일 처리/DB] 해당 메뉴의 레시피 상세 조회
            List<RecipeItem> recipes = ProductManager.GetRecipes(menuId);

            foreach (var r in recipes)
            {
                Dgv_Recipe.Rows.Add(r.IngredientName, r.Amount);
            }
        }

        // [레시피 추가] 버튼 클릭
        private void Btn_AddRecipe_Click(object sender, EventArgs e)
        {
            if (Label_Id.Text == "") return;

            try
            {
                int menuId = int.Parse(Label_Id.Text);
                int ingId = (int)Cbo_Ingredient.SelectedValue;
                double amount = (double)Num_Amount.Value;

                if (amount <= 0)
                {
                    MessageBox.Show("수량을 입력하세요.");
                    return;
                }

                // [조건: 파일 처리/DB] ProductManager 레시피 추가 요청
                ProductManager.AddRecipe(menuId, ingId, amount);
                LoadRecipeList(menuId); // 목록 갱신
            }
            catch (Exception ex)
            {
                MessageBox.Show("추가 실패: " + ex.Message);
            }
        }

        // [레시피 그리드 클릭] 삭제 버튼 처리
        private void Dgv_Recipe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 삭제 버튼(2번 컬럼) 클릭 시 동작
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                string ingName = Dgv_Recipe.Rows[e.RowIndex].Cells[0].Value.ToString();
                int menuId = int.Parse(Label_Id.Text);

                if (MessageBox.Show($"{ingName}을(를) 레시피에서 뺄까요?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // [조건: 파일 처리/DB] 레시피 삭제 요청
                    ProductManager.DeleteRecipe(menuId, ingName);
                    LoadRecipeList(menuId);
                }
            }
        }
    }
}