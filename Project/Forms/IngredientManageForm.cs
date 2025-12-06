using Project.Managers; // 매니저 클래스 참조
using Project.Models;   // 데이터 모델 참조
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Project
{
    // [조건: Form 4개 이상] 원재료 관리 화면 클래스
    public partial class IngredientManageForm : Form
    {
        // 생성자: 화면 구성요소 초기화 및 설정
        public IngredientManageForm()
        {
            InitializeComponent();

            // 1. 메뉴바 설정
            // [조건: 클래스 사용] MenuManager를 통한 상단 메뉴 색상 및 이동 기능 제어
            MenuManager.HighlightMenu(panelTop, Btn_Ingredient);
            MenuManager.AttachNavigation(this, panelTop);

            // 2. 그리드 스타일 설정
            // [조건: 클래스 사용] StyleManager를 통한 DataGridView 디자인 통일
            StyleManager.ApplyGridStyle(Dgv_Ingredients);

            // 3. 그리드 컬럼 동적 생성
            SetupGridColumns();

            // 4. 초기 데이터 로드 (DB 조회)
            LoadData();
        }

        // --- 초기 설정 영역 ---

        // DataGridView 컬럼 정의 및 설정
        private void SetupGridColumns()
        {
            Dgv_Ingredients.Columns.Clear();
            Dgv_Ingredients.Columns.Add("colId", "ID");
            Dgv_Ingredients.Columns.Add("colName", "원재료명");
            Dgv_Ingredients.Columns.Add("colUnit", "단위");
            Dgv_Ingredients.Columns.Add("colCurrent", "현재 재고");
            Dgv_Ingredients.Columns.Add("colMin", "최소 재고");

            // 사용자에게 불필요한 ID 컬럼 숨김 처리
            Dgv_Ingredients.Columns["colId"].Visible = false;

            // '원재료명' 컬럼 너비 자동 채움 설정
            Dgv_Ingredients.Columns["colName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        // 데이터 조회 및 그리드 출력 (Read 기능)
        private void LoadData()
        {
            Dgv_Ingredients.Rows.Clear();

            // [조건: 파일 처리/DB] StockManager를 통해 본사 및 내 재고 목록 조회
            // [조건: 제네릭 사용] List<Ingredient> 형태로 데이터 수신
            List<Ingredient> list = StockManager.GetMyStock(Global.CurrentUserID);

            // 조회된 데이터를 그리드 행으로 추가
            foreach (var item in list)
            {
                Dgv_Ingredients.Rows.Add(
                    item.Id,
                    item.Name,
                    item.Unit,
                    item.CurrentStock,
                    item.MinStock
                );
            }

            // 입력 필드 초기화 (신규 입력 대기 상태)
            ClearInput();
        }

        // 입력 필드 초기화 메서드
        private void ClearInput()
        {
            Label_Id.Text = ""; // ID 라벨 초기화 (신규/수정 구분 기준)
            Txt_Name.Text = "";
            Txt_Unit.Text = "";
            Txt_Current.Text = "0";
            Txt_Min.Text = "0";

            Txt_Name.Focus(); // 입력 편의를 위한 포커스 이동
        }

        // --- 이벤트 핸들러 영역 ---

        // [신규] 버튼 클릭 이벤트: 입력창 초기화
        private void Btn_New_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        // [저장] 버튼 클릭 이벤트: 데이터 추가 및 수정 (Create / Update 기능)
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            // 유효성 검사: 필수 항목(이름) 미입력 시 중단
            if (string.IsNullOrWhiteSpace(Txt_Name.Text))
            {
                MessageBox.Show("원재료명을 입력하세요.");
                return;
            }

            // ID 라벨 값 유무에 따른 신규(0) / 수정(ID) 구분
            int id = (Label_Id.Text == "") ? 0 : int.Parse(Label_Id.Text);

            // 입력 컨트롤에서 값 추출
            string name = Txt_Name.Text;
            string unit = Txt_Unit.Text;
            double current = double.Parse(Txt_Current.Text);
            double min = double.Parse(Txt_Min.Text);

            // [조건: 파일 처리/DB] StockManager에 저장 요청 (트랜잭션 처리됨)
            // [선택 조건: 제네릭 사용] 결과값 DbResult<int> 수신하여 성공 여부 확인
            var result = StockManager.SaveIngredient(Global.CurrentUserID, id, name, unit, current, min);

            if (result.IsSuccess)
            {
                MessageBox.Show(result.Message); // 성공 메시지 출력
                LoadData(); // 목록 새로고침 (반영 확인)
            }
            else
            {
                MessageBox.Show(result.Message); // 실패 메시지 출력
            }
        }

        // [삭제] 버튼 클릭 이벤트: 데이터 삭제 (Delete 기능)
        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            // 선택된 항목 유무 확인
            if (Label_Id.Text == "")
            {
                MessageBox.Show("삭제할 항목을 선택해주세요.");
                return;
            }

            // 사용자 실수 방지를 위한 확인 메시지 출력
            if (MessageBox.Show("정말 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = int.Parse(Label_Id.Text);

                // [조건: 파일 처리/DB] StockManager에 삭제 요청
                var result = StockManager.DeleteIngredient(id);

                if (result.IsSuccess)
                {
                    MessageBox.Show(result.Message);
                    LoadData(); // 목록 갱신
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
        }

        // [그리드 셀 클릭] 이벤트: 선택 행 데이터를 입력창에 표시
        private void Dgv_Ingredients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 헤더 클릭 시 동작 방지
            if (e.RowIndex < 0 || e.RowIndex >= Dgv_Ingredients.Rows.Count) return;

            try
            {
                // [조건: 예외 처리] 데이터 변환 중 발생 가능한 오류 방지

                // 선택된 행(Row) 객체 참조
                DataGridViewRow row = Dgv_Ingredients.Rows[e.RowIndex];

                // Null 병합 연산자(??)를 사용한 안전한 데이터 추출
                Label_Id.Text = row.Cells["colId"].Value?.ToString() ?? "";

                // 빈 행 클릭 시 로직 중단
                if (Label_Id.Text == "") return;

                // 각 입력 컨트롤에 그리드 데이터 바인딩
                Txt_Name.Text = row.Cells["colName"].Value?.ToString() ?? "";
                Txt_Unit.Text = row.Cells["colUnit"].Value?.ToString() ?? "";
                Txt_Current.Text = row.Cells["colCurrent"].Value?.ToString() ?? "0";
                Txt_Min.Text = row.Cells["colMin"].Value?.ToString() ?? "0";
            }
            catch (Exception ex)
            {
                // 예외 발생 시 사용자에게 알림
                MessageBox.Show("선택 중 오류 발생: " + ex.Message);
            }
        }
    }
}