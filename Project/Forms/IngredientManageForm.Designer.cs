namespace Project
{
    partial class IngredientManageForm
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
            this.Label_Id = new System.Windows.Forms.Label();
            this.Box_information = new CafeStockSystem.RoundGroupBox();
            this.Btn_Delete = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Btn_New = new System.Windows.Forms.Button();
            this.Label_Min = new System.Windows.Forms.Label();
            this.Txt_Min = new CafeStockSystem.RoundTextBox();
            this.Label_Current = new System.Windows.Forms.Label();
            this.Txt_Current = new CafeStockSystem.RoundTextBox();
            this.Label_Unit = new System.Windows.Forms.Label();
            this.Txt_Unit = new CafeStockSystem.RoundTextBox();
            this.Label_Name = new System.Windows.Forms.Label();
            this.Txt_Name = new CafeStockSystem.RoundTextBox();
            this.Label_information = new System.Windows.Forms.Label();
            this.Box_inventory = new CafeStockSystem.RoundGroupBox();
            this.Dgv_Ingredients = new System.Windows.Forms.DataGridView();
            this.Label_inventory = new System.Windows.Forms.Label();
            this.Label_Main = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.Box_information.SuspendLayout();
            this.Box_inventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Ingredients)).BeginInit();
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
            // Label_Id
            // 
            this.Label_Id.AutoSize = true;
            this.Label_Id.Location = new System.Drawing.Point(1534, 840);
            this.Label_Id.Name = "Label_Id";
            this.Label_Id.Size = new System.Drawing.Size(0, 12);
            this.Label_Id.TabIndex = 3;
            this.Label_Id.Visible = false;
            // 
            // Box_information
            // 
            this.Box_information.BackColor = System.Drawing.Color.White;
            this.Box_information.BorderColor = System.Drawing.Color.LightGray;
            this.Box_information.BorderRadius = 20;
            this.Box_information.Controls.Add(this.Btn_Delete);
            this.Box_information.Controls.Add(this.Btn_Save);
            this.Box_information.Controls.Add(this.Btn_New);
            this.Box_information.Controls.Add(this.Label_Min);
            this.Box_information.Controls.Add(this.Txt_Min);
            this.Box_information.Controls.Add(this.Label_Current);
            this.Box_information.Controls.Add(this.Txt_Current);
            this.Box_information.Controls.Add(this.Label_Unit);
            this.Box_information.Controls.Add(this.Txt_Unit);
            this.Box_information.Controls.Add(this.Label_Name);
            this.Box_information.Controls.Add(this.Txt_Name);
            this.Box_information.Controls.Add(this.Label_information);
            this.Box_information.Location = new System.Drawing.Point(1050, 110);
            this.Box_information.Name = "Box_information";
            this.Box_information.Size = new System.Drawing.Size(460, 450);
            this.Box_information.TabIndex = 0;
            this.Box_information.TabStop = false;
            // 
            // Btn_Delete
            // 
            this.Btn_Delete.BackColor = System.Drawing.Color.Crimson;
            this.Btn_Delete.FlatAppearance.BorderSize = 0;
            this.Btn_Delete.ForeColor = System.Drawing.Color.White;
            this.Btn_Delete.Location = new System.Drawing.Point(354, 397);
            this.Btn_Delete.Name = "Btn_Delete";
            this.Btn_Delete.Size = new System.Drawing.Size(100, 40);
            this.Btn_Delete.TabIndex = 12;
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
            this.Btn_Save.Location = new System.Drawing.Point(182, 398);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(100, 40);
            this.Btn_Save.TabIndex = 11;
            this.Btn_Save.Text = "💾 저장";
            this.Btn_Save.UseVisualStyleBackColor = false;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Btn_New
            // 
            this.Btn_New.FlatAppearance.BorderSize = 0;
            this.Btn_New.Location = new System.Drawing.Point(10, 398);
            this.Btn_New.Name = "Btn_New";
            this.Btn_New.Size = new System.Drawing.Size(100, 40);
            this.Btn_New.TabIndex = 3;
            this.Btn_New.Text = "+ 신규";
            this.Btn_New.UseVisualStyleBackColor = true;
            this.Btn_New.Click += new System.EventHandler(this.Btn_New_Click);
            // 
            // Label_Min
            // 
            this.Label_Min.AutoSize = true;
            this.Label_Min.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_Min.Location = new System.Drawing.Point(6, 305);
            this.Label_Min.Name = "Label_Min";
            this.Label_Min.Size = new System.Drawing.Size(74, 20);
            this.Label_Min.TabIndex = 10;
            this.Label_Min.Text = "최소 재고";
            // 
            // Txt_Min
            // 
            this.Txt_Min.BackColor = System.Drawing.Color.White;
            this.Txt_Min.BorderColor = System.Drawing.Color.DarkGray;
            this.Txt_Min.BorderRadius = 8;
            this.Txt_Min.BorderSize = 2;
            this.Txt_Min.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.Txt_Min.Location = new System.Drawing.Point(5, 328);
            this.Txt_Min.Name = "Txt_Min";
            this.Txt_Min.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Txt_Min.PasswordChar = '\0';
            this.Txt_Min.PlaceholderText = "5";
            this.Txt_Min.Size = new System.Drawing.Size(450, 35);
            this.Txt_Min.TabIndex = 9;
            this.Txt_Min.UseSystemPasswordChar = false;
            // 
            // Label_Current
            // 
            this.Label_Current.AutoSize = true;
            this.Label_Current.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_Current.Location = new System.Drawing.Point(6, 230);
            this.Label_Current.Name = "Label_Current";
            this.Label_Current.Size = new System.Drawing.Size(74, 20);
            this.Label_Current.TabIndex = 8;
            this.Label_Current.Text = "현재 재고";
            // 
            // Txt_Current
            // 
            this.Txt_Current.BackColor = System.Drawing.Color.White;
            this.Txt_Current.BorderColor = System.Drawing.Color.DarkGray;
            this.Txt_Current.BorderRadius = 8;
            this.Txt_Current.BorderSize = 2;
            this.Txt_Current.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.Txt_Current.Location = new System.Drawing.Point(5, 253);
            this.Txt_Current.Name = "Txt_Current";
            this.Txt_Current.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Txt_Current.PasswordChar = '\0';
            this.Txt_Current.PlaceholderText = "0";
            this.Txt_Current.Size = new System.Drawing.Size(450, 35);
            this.Txt_Current.TabIndex = 7;
            this.Txt_Current.UseSystemPasswordChar = false;
            // 
            // Label_Unit
            // 
            this.Label_Unit.AutoSize = true;
            this.Label_Unit.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_Unit.Location = new System.Drawing.Point(6, 153);
            this.Label_Unit.Name = "Label_Unit";
            this.Label_Unit.Size = new System.Drawing.Size(39, 20);
            this.Label_Unit.TabIndex = 6;
            this.Label_Unit.Text = "단위";
            // 
            // Txt_Unit
            // 
            this.Txt_Unit.BackColor = System.Drawing.Color.White;
            this.Txt_Unit.BorderColor = System.Drawing.Color.DarkGray;
            this.Txt_Unit.BorderRadius = 8;
            this.Txt_Unit.BorderSize = 2;
            this.Txt_Unit.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Txt_Unit.Location = new System.Drawing.Point(5, 176);
            this.Txt_Unit.Name = "Txt_Unit";
            this.Txt_Unit.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Txt_Unit.PasswordChar = '\0';
            this.Txt_Unit.PlaceholderText = "예 : Kg, L";
            this.Txt_Unit.Size = new System.Drawing.Size(450, 35);
            this.Txt_Unit.TabIndex = 5;
            this.Txt_Unit.UseSystemPasswordChar = false;
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_Name.Location = new System.Drawing.Point(6, 85);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(69, 20);
            this.Label_Name.TabIndex = 4;
            this.Label_Name.Text = "원재료명";
            // 
            // Txt_Name
            // 
            this.Txt_Name.BackColor = System.Drawing.Color.White;
            this.Txt_Name.BorderColor = System.Drawing.Color.DarkGray;
            this.Txt_Name.BorderRadius = 8;
            this.Txt_Name.BorderSize = 2;
            this.Txt_Name.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Txt_Name.Location = new System.Drawing.Point(5, 108);
            this.Txt_Name.Name = "Txt_Name";
            this.Txt_Name.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Txt_Name.PasswordChar = '\0';
            this.Txt_Name.PlaceholderText = "예 : 커피 원두";
            this.Txt_Name.Size = new System.Drawing.Size(450, 35);
            this.Txt_Name.TabIndex = 3;
            this.Txt_Name.UseSystemPasswordChar = false;
            // 
            // Label_information
            // 
            this.Label_information.AutoSize = true;
            this.Label_information.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_information.Location = new System.Drawing.Point(6, 17);
            this.Label_information.Name = "Label_information";
            this.Label_information.Size = new System.Drawing.Size(96, 21);
            this.Label_information.TabIndex = 1;
            this.Label_information.Text = "원재료 정보";
            // 
            // Box_inventory
            // 
            this.Box_inventory.BackColor = System.Drawing.Color.White;
            this.Box_inventory.BorderColor = System.Drawing.Color.LightGray;
            this.Box_inventory.BorderRadius = 20;
            this.Box_inventory.Controls.Add(this.Dgv_Ingredients);
            this.Box_inventory.Controls.Add(this.Label_inventory);
            this.Box_inventory.Location = new System.Drawing.Point(69, 110);
            this.Box_inventory.Name = "Box_inventory";
            this.Box_inventory.Size = new System.Drawing.Size(892, 739);
            this.Box_inventory.TabIndex = 2;
            this.Box_inventory.TabStop = false;
            // 
            // Dgv_Ingredients
            // 
            this.Dgv_Ingredients.AllowUserToAddRows = false;
            this.Dgv_Ingredients.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_Ingredients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgv_Ingredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Ingredients.Location = new System.Drawing.Point(6, 85);
            this.Dgv_Ingredients.Name = "Dgv_Ingredients";
            this.Dgv_Ingredients.RowTemplate.Height = 23;
            this.Dgv_Ingredients.Size = new System.Drawing.Size(880, 648);
            this.Dgv_Ingredients.TabIndex = 3;
            this.Dgv_Ingredients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Ingredients_CellClick);
            // 
            // Label_inventory
            // 
            this.Label_inventory.AutoSize = true;
            this.Label_inventory.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_inventory.Location = new System.Drawing.Point(6, 17);
            this.Label_inventory.Name = "Label_inventory";
            this.Label_inventory.Size = new System.Drawing.Size(96, 21);
            this.Label_inventory.TabIndex = 0;
            this.Label_inventory.Text = "원재료 목록";
            // 
            // Label_Main
            // 
            this.Label_Main.AutoSize = true;
            this.Label_Main.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_Main.Location = new System.Drawing.Point(12, 57);
            this.Label_Main.Name = "Label_Main";
            this.Label_Main.Size = new System.Drawing.Size(125, 30);
            this.Label_Main.TabIndex = 5;
            this.Label_Main.Text = "원재료 처리";
            // 
            // IngredientManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.Label_Main);
            this.Controls.Add(this.Label_Id);
            this.Controls.Add(this.Box_information);
            this.Controls.Add(this.Box_inventory);
            this.Controls.Add(this.panelTop);
            this.Name = "IngredientManageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IngredientManageForm";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.Box_information.ResumeLayout(false);
            this.Box_information.PerformLayout();
            this.Box_inventory.ResumeLayout(false);
            this.Box_inventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Ingredients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button Btn_Sales;
        private System.Windows.Forms.Button Btn_Stock;
        private System.Windows.Forms.Button Btn_Menu;
        private System.Windows.Forms.Button Btn_Ingredient;
        private System.Windows.Forms.Button Btn_Main;
        private System.Windows.Forms.Button Btn_Logout;
        private CafeStockSystem.RoundGroupBox Box_inventory;
        private CafeStockSystem.RoundGroupBox Box_information;
        private System.Windows.Forms.Label Label_inventory;
        private System.Windows.Forms.DataGridView Dgv_Ingredients;
        private CafeStockSystem.RoundTextBox Txt_Name;
        private System.Windows.Forms.Label Label_information;
        private System.Windows.Forms.Label Label_Min;
        private CafeStockSystem.RoundTextBox Txt_Min;
        private System.Windows.Forms.Label Label_Current;
        private CafeStockSystem.RoundTextBox Txt_Current;
        private System.Windows.Forms.Label Label_Unit;
        private CafeStockSystem.RoundTextBox Txt_Unit;
        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.Button Btn_Delete;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Button Btn_New;
        private System.Windows.Forms.Label Label_Id;
        private System.Windows.Forms.Label Label_Main;
    }
}