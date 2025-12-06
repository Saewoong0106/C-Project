namespace Project
{
    partial class MenuManageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.Btn_Sales = new System.Windows.Forms.Button();
            this.Btn_Stock = new System.Windows.Forms.Button();
            this.Btn_Menu = new System.Windows.Forms.Button();
            this.Btn_Ingredient = new System.Windows.Forms.Button();
            this.Btn_Main = new System.Windows.Forms.Button();
            this.Btn_Logout = new System.Windows.Forms.Button();
            this.Box_Recipe = new CafeStockSystem.RoundGroupBox();
            this.Label_Selected = new System.Windows.Forms.Label();
            this.Label_RecipePlaceholder = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Num_Amount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Cbo_Ingredient = new System.Windows.Forms.ComboBox();
            this.Dgv_Recipe = new System.Windows.Forms.DataGridView();
            this.Label_Recipe = new System.Windows.Forms.Label();
            this.Box_Menu = new CafeStockSystem.RoundGroupBox();
            this.Label_Id = new System.Windows.Forms.Label();
            this.Btn_Delete = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Btn_New = new System.Windows.Forms.Button();
            this.Label_Price = new System.Windows.Forms.Label();
            this.Txt_Price = new CafeStockSystem.RoundTextBox();
            this.Label_MenuName = new System.Windows.Forms.Label();
            this.Txt_Name = new CafeStockSystem.RoundTextBox();
            this.Dgv_Menu = new System.Windows.Forms.DataGridView();
            this.Label_Menu = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.Box_Recipe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Recipe)).BeginInit();
            this.Box_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Menu)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.Btn_Sales);
            this.panelTop.Controls.Add(this.Btn_Stock);
            this.panelTop.Controls.Add(this.Btn_Menu);
            this.panelTop.Controls.Add(this.Btn_Ingredient);
            this.panelTop.Controls.Add(this.Btn_Main);
            this.panelTop.Controls.Add(this.Btn_Logout);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1584, 54);
            this.panelTop.TabIndex = 1;
            // 
            // Btn_Sales
            // 
            this.Btn_Sales.AutoSize = true;
            this.Btn_Sales.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Sales.Dock = System.Windows.Forms.DockStyle.Left;
            this.Btn_Sales.FlatAppearance.BorderSize = 0;
            this.Btn_Sales.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.Btn_Sales.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_Sales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Sales.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Sales.ForeColor = System.Drawing.Color.DarkGray;
            this.Btn_Sales.Location = new System.Drawing.Point(680, 0);
            this.Btn_Sales.Name = "Btn_Sales";
            this.Btn_Sales.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Btn_Sales.Size = new System.Drawing.Size(170, 54);
            this.Btn_Sales.TabIndex = 5;
            this.Btn_Sales.Text = "매출 조회";
            this.Btn_Sales.UseVisualStyleBackColor = false;
            // 
            // Btn_Stock
            // 
            this.Btn_Stock.AutoSize = true;
            this.Btn_Stock.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Stock.Dock = System.Windows.Forms.DockStyle.Left;
            this.Btn_Stock.FlatAppearance.BorderSize = 0;
            this.Btn_Stock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.Btn_Stock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_Stock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Stock.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Stock.ForeColor = System.Drawing.Color.DarkGray;
            this.Btn_Stock.Location = new System.Drawing.Point(510, 0);
            this.Btn_Stock.Name = "Btn_Stock";
            this.Btn_Stock.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Btn_Stock.Size = new System.Drawing.Size(170, 54);
            this.Btn_Stock.TabIndex = 4;
            this.Btn_Stock.Text = "재고 처리";
            this.Btn_Stock.UseVisualStyleBackColor = false;
            // 
            // Btn_Menu
            // 
            this.Btn_Menu.AutoSize = true;
            this.Btn_Menu.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.Btn_Menu.FlatAppearance.BorderSize = 0;
            this.Btn_Menu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.Btn_Menu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_Menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Menu.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Menu.ForeColor = System.Drawing.Color.DarkGray;
            this.Btn_Menu.Location = new System.Drawing.Point(340, 0);
            this.Btn_Menu.Name = "Btn_Menu";
            this.Btn_Menu.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Btn_Menu.Size = new System.Drawing.Size(170, 54);
            this.Btn_Menu.TabIndex = 3;
            this.Btn_Menu.Text = "메뉴 관리";
            this.Btn_Menu.UseVisualStyleBackColor = false;
            // 
            // Btn_Ingredient
            // 
            this.Btn_Ingredient.AutoSize = true;
            this.Btn_Ingredient.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Ingredient.Dock = System.Windows.Forms.DockStyle.Left;
            this.Btn_Ingredient.FlatAppearance.BorderSize = 0;
            this.Btn_Ingredient.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.Btn_Ingredient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_Ingredient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Ingredient.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Ingredient.ForeColor = System.Drawing.Color.DarkGray;
            this.Btn_Ingredient.Location = new System.Drawing.Point(170, 0);
            this.Btn_Ingredient.Name = "Btn_Ingredient";
            this.Btn_Ingredient.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Btn_Ingredient.Size = new System.Drawing.Size(170, 54);
            this.Btn_Ingredient.TabIndex = 2;
            this.Btn_Ingredient.Text = "원재료 관리";
            this.Btn_Ingredient.UseVisualStyleBackColor = false;
            // 
            // Btn_Main
            // 
            this.Btn_Main.AutoSize = true;
            this.Btn_Main.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Main.Dock = System.Windows.Forms.DockStyle.Left;
            this.Btn_Main.FlatAppearance.BorderSize = 0;
            this.Btn_Main.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.Btn_Main.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_Main.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Main.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Main.ForeColor = System.Drawing.Color.DarkGray;
            this.Btn_Main.Location = new System.Drawing.Point(0, 0);
            this.Btn_Main.Name = "Btn_Main";
            this.Btn_Main.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Btn_Main.Size = new System.Drawing.Size(170, 54);
            this.Btn_Main.TabIndex = 1;
            this.Btn_Main.Text = "메인 대시보드";
            this.Btn_Main.UseVisualStyleBackColor = false;
            // 
            // Btn_Logout
            // 
            this.Btn_Logout.AutoSize = true;
            this.Btn_Logout.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Logout.Dock = System.Windows.Forms.DockStyle.Right;
            this.Btn_Logout.FlatAppearance.BorderSize = 0;
            this.Btn_Logout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.Btn_Logout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_Logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Logout.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Logout.ForeColor = System.Drawing.Color.DarkGray;
            this.Btn_Logout.Location = new System.Drawing.Point(1414, 0);
            this.Btn_Logout.Name = "Btn_Logout";
            this.Btn_Logout.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Btn_Logout.Size = new System.Drawing.Size(170, 54);
            this.Btn_Logout.TabIndex = 0;
            this.Btn_Logout.Text = "로그아웃";
            this.Btn_Logout.UseVisualStyleBackColor = false;
            // 
            // Box_Recipe
            // 
            this.Box_Recipe.BackColor = System.Drawing.Color.White;
            this.Box_Recipe.BorderColor = System.Drawing.Color.LightGray;
            this.Box_Recipe.BorderRadius = 20;
            this.Box_Recipe.Controls.Add(this.Label_Selected);
            this.Box_Recipe.Controls.Add(this.Label_RecipePlaceholder);
            this.Box_Recipe.Controls.Add(this.button1);
            this.Box_Recipe.Controls.Add(this.Num_Amount);
            this.Box_Recipe.Controls.Add(this.label2);
            this.Box_Recipe.Controls.Add(this.label1);
            this.Box_Recipe.Controls.Add(this.Cbo_Ingredient);
            this.Box_Recipe.Controls.Add(this.Dgv_Recipe);
            this.Box_Recipe.Controls.Add(this.Label_Recipe);
            this.Box_Recipe.Location = new System.Drawing.Point(856, 60);
            this.Box_Recipe.Name = "Box_Recipe";
            this.Box_Recipe.Size = new System.Drawing.Size(716, 789);
            this.Box_Recipe.TabIndex = 0;
            this.Box_Recipe.TabStop = false;
            // 
            // Label_Selected
            // 
            this.Label_Selected.AutoSize = true;
            this.Label_Selected.BackColor = System.Drawing.Color.AliceBlue;
            this.Label_Selected.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_Selected.Location = new System.Drawing.Point(6, 62);
            this.Label_Selected.Name = "Label_Selected";
            this.Label_Selected.Size = new System.Drawing.Size(102, 20);
            this.Label_Selected.TabIndex = 5;
            this.Label_Selected.Text = "선택된 메뉴 : ";
            this.Label_Selected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_RecipePlaceholder
            // 
            this.Label_RecipePlaceholder.AutoSize = true;
            this.Label_RecipePlaceholder.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_RecipePlaceholder.ForeColor = System.Drawing.Color.DarkGray;
            this.Label_RecipePlaceholder.Location = new System.Drawing.Point(214, 384);
            this.Label_RecipePlaceholder.Name = "Label_RecipePlaceholder";
            this.Label_RecipePlaceholder.Size = new System.Drawing.Size(288, 21);
            this.Label_RecipePlaceholder.TabIndex = 16;
            this.Label_RecipePlaceholder.Text = "메뉴를 선택하여 레시피를 관리하세요.";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(6, 743);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(704, 40);
            this.button1.TabIndex = 15;
            this.button1.Text = "+ 레시피 추가";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Btn_AddRecipe_Click);
            // 
            // Num_Amount
            // 
            this.Num_Amount.DecimalPlaces = 2;
            this.Num_Amount.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Num_Amount.Location = new System.Drawing.Point(6, 693);
            this.Num_Amount.Name = "Num_Amount";
            this.Num_Amount.Size = new System.Drawing.Size(520, 29);
            this.Num_Amount.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(6, 664);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "수량";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(6, 599);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "원재료 선택";
            // 
            // Cbo_Ingredient
            // 
            this.Cbo_Ingredient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Ingredient.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Cbo_Ingredient.FormattingEnabled = true;
            this.Cbo_Ingredient.Location = new System.Drawing.Point(6, 628);
            this.Cbo_Ingredient.Name = "Cbo_Ingredient";
            this.Cbo_Ingredient.Size = new System.Drawing.Size(519, 29);
            this.Cbo_Ingredient.TabIndex = 6;
            // 
            // Dgv_Recipe
            // 
            this.Dgv_Recipe.AllowUserToAddRows = false;
            this.Dgv_Recipe.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_Recipe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgv_Recipe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Recipe.Location = new System.Drawing.Point(6, 110);
            this.Dgv_Recipe.Name = "Dgv_Recipe";
            this.Dgv_Recipe.RowTemplate.Height = 23;
            this.Dgv_Recipe.Size = new System.Drawing.Size(704, 673);
            this.Dgv_Recipe.TabIndex = 3;
            this.Dgv_Recipe.Visible = false;
            this.Dgv_Recipe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Recipe_CellClick);
            // 
            // Label_Recipe
            // 
            this.Label_Recipe.AutoSize = true;
            this.Label_Recipe.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_Recipe.Location = new System.Drawing.Point(6, 17);
            this.Label_Recipe.Name = "Label_Recipe";
            this.Label_Recipe.Size = new System.Drawing.Size(96, 21);
            this.Label_Recipe.TabIndex = 2;
            this.Label_Recipe.Text = "레시피 관리";
            // 
            // Box_Menu
            // 
            this.Box_Menu.BackColor = System.Drawing.Color.White;
            this.Box_Menu.BorderColor = System.Drawing.Color.LightGray;
            this.Box_Menu.BorderRadius = 20;
            this.Box_Menu.Controls.Add(this.Label_Id);
            this.Box_Menu.Controls.Add(this.Btn_Delete);
            this.Box_Menu.Controls.Add(this.Btn_Save);
            this.Box_Menu.Controls.Add(this.Btn_New);
            this.Box_Menu.Controls.Add(this.Label_Price);
            this.Box_Menu.Controls.Add(this.Txt_Price);
            this.Box_Menu.Controls.Add(this.Label_MenuName);
            this.Box_Menu.Controls.Add(this.Txt_Name);
            this.Box_Menu.Controls.Add(this.Dgv_Menu);
            this.Box_Menu.Controls.Add(this.Label_Menu);
            this.Box_Menu.Location = new System.Drawing.Point(12, 60);
            this.Box_Menu.Name = "Box_Menu";
            this.Box_Menu.Size = new System.Drawing.Size(838, 789);
            this.Box_Menu.TabIndex = 6;
            this.Box_Menu.TabStop = false;
            // 
            // Label_Id
            // 
            this.Label_Id.AutoSize = true;
            this.Label_Id.Location = new System.Drawing.Point(780, 17);
            this.Label_Id.Name = "Label_Id";
            this.Label_Id.Size = new System.Drawing.Size(0, 12);
            this.Label_Id.TabIndex = 16;
            this.Label_Id.Visible = false;
            // 
            // Btn_Delete
            // 
            this.Btn_Delete.BackColor = System.Drawing.Color.Crimson;
            this.Btn_Delete.FlatAppearance.BorderSize = 0;
            this.Btn_Delete.ForeColor = System.Drawing.Color.White;
            this.Btn_Delete.Location = new System.Drawing.Point(582, 743);
            this.Btn_Delete.Name = "Btn_Delete";
            this.Btn_Delete.Size = new System.Drawing.Size(250, 40);
            this.Btn_Delete.TabIndex = 15;
            this.Btn_Delete.Text = "🗑 삭제";
            this.Btn_Delete.UseVisualStyleBackColor = false;
            this.Btn_Delete.Click += new System.EventHandler(this.Btn_Delete_Click);
            // 
            // Btn_Save
            // 
            this.Btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Btn_Save.FlatAppearance.BorderSize = 0;
            this.Btn_Save.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Save.ForeColor = System.Drawing.Color.White;
            this.Btn_Save.Location = new System.Drawing.Point(294, 743);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(250, 40);
            this.Btn_Save.TabIndex = 14;
            this.Btn_Save.Text = "💾 저장";
            this.Btn_Save.UseVisualStyleBackColor = false;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Btn_New
            // 
            this.Btn_New.FlatAppearance.BorderSize = 0;
            this.Btn_New.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_New.Location = new System.Drawing.Point(6, 743);
            this.Btn_New.Name = "Btn_New";
            this.Btn_New.Size = new System.Drawing.Size(250, 40);
            this.Btn_New.TabIndex = 13;
            this.Btn_New.Text = "+ 신규";
            this.Btn_New.UseVisualStyleBackColor = true;
            this.Btn_New.Click += new System.EventHandler(this.Btn_New_Click);
            // 
            // Label_Price
            // 
            this.Label_Price.AutoSize = true;
            this.Label_Price.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_Price.Location = new System.Drawing.Point(7, 664);
            this.Label_Price.Name = "Label_Price";
            this.Label_Price.Size = new System.Drawing.Size(39, 20);
            this.Label_Price.TabIndex = 8;
            this.Label_Price.Text = "가격";
            // 
            // Txt_Price
            // 
            this.Txt_Price.BackColor = System.Drawing.Color.White;
            this.Txt_Price.BorderColor = System.Drawing.Color.DarkGray;
            this.Txt_Price.BorderRadius = 8;
            this.Txt_Price.BorderSize = 2;
            this.Txt_Price.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Txt_Price.Location = new System.Drawing.Point(6, 687);
            this.Txt_Price.Name = "Txt_Price";
            this.Txt_Price.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Txt_Price.PasswordChar = '\0';
            this.Txt_Price.PlaceholderText = "0";
            this.Txt_Price.Size = new System.Drawing.Size(826, 35);
            this.Txt_Price.TabIndex = 7;
            this.Txt_Price.UseSystemPasswordChar = false;
            // 
            // Label_MenuName
            // 
            this.Label_MenuName.AutoSize = true;
            this.Label_MenuName.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_MenuName.Location = new System.Drawing.Point(7, 599);
            this.Label_MenuName.Name = "Label_MenuName";
            this.Label_MenuName.Size = new System.Drawing.Size(54, 20);
            this.Label_MenuName.TabIndex = 6;
            this.Label_MenuName.Text = "메뉴명";
            // 
            // Txt_Name
            // 
            this.Txt_Name.BackColor = System.Drawing.Color.White;
            this.Txt_Name.BorderColor = System.Drawing.Color.DarkGray;
            this.Txt_Name.BorderRadius = 8;
            this.Txt_Name.BorderSize = 2;
            this.Txt_Name.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Txt_Name.Location = new System.Drawing.Point(6, 622);
            this.Txt_Name.Name = "Txt_Name";
            this.Txt_Name.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Txt_Name.PasswordChar = '\0';
            this.Txt_Name.PlaceholderText = "예 : 아메리카노";
            this.Txt_Name.Size = new System.Drawing.Size(826, 35);
            this.Txt_Name.TabIndex = 5;
            this.Txt_Name.UseSystemPasswordChar = false;
            // 
            // Dgv_Menu
            // 
            this.Dgv_Menu.AllowUserToAddRows = false;
            this.Dgv_Menu.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_Menu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgv_Menu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Menu.Location = new System.Drawing.Point(6, 41);
            this.Dgv_Menu.Name = "Dgv_Menu";
            this.Dgv_Menu.RowTemplate.Height = 23;
            this.Dgv_Menu.Size = new System.Drawing.Size(826, 502);
            this.Dgv_Menu.TabIndex = 2;
            this.Dgv_Menu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Menu_CellClick);
            // 
            // Label_Menu
            // 
            this.Label_Menu.AutoSize = true;
            this.Label_Menu.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_Menu.Location = new System.Drawing.Point(6, 17);
            this.Label_Menu.Name = "Label_Menu";
            this.Label_Menu.Size = new System.Drawing.Size(80, 21);
            this.Label_Menu.TabIndex = 1;
            this.Label_Menu.Text = "메뉴 관리";
            // 
            // MenuManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.Box_Recipe);
            this.Controls.Add(this.Box_Menu);
            this.Controls.Add(this.panelTop);
            this.Name = "MenuManageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuManageForm";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.Box_Recipe.ResumeLayout(false);
            this.Box_Recipe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Recipe)).EndInit();
            this.Box_Menu.ResumeLayout(false);
            this.Box_Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Menu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button Btn_Sales;
        private System.Windows.Forms.Button Btn_Stock;
        private System.Windows.Forms.Button Btn_Menu;
        private System.Windows.Forms.Button Btn_Ingredient;
        private System.Windows.Forms.Button Btn_Main;
        private System.Windows.Forms.Button Btn_Logout;
        private CafeStockSystem.RoundGroupBox Box_Menu;
        private CafeStockSystem.RoundGroupBox Box_Recipe;
        private System.Windows.Forms.DataGridView Dgv_Menu;
        private System.Windows.Forms.Label Label_Menu;
        private System.Windows.Forms.Label Label_Price;
        private CafeStockSystem.RoundTextBox Txt_Price;
        private System.Windows.Forms.Label Label_MenuName;
        private CafeStockSystem.RoundTextBox Txt_Name;
        private System.Windows.Forms.Button Btn_Delete;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Button Btn_New;
        private System.Windows.Forms.Label Label_Recipe;
        private System.Windows.Forms.Label Label_Id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cbo_Ingredient;
        private System.Windows.Forms.Label Label_Selected;
        private System.Windows.Forms.DataGridView Dgv_Recipe;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown Num_Amount;
        private System.Windows.Forms.Label Label_RecipePlaceholder;
    }
}