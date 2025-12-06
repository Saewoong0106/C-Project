namespace Project
{
    partial class SalesStockForm
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
            this.Label_Main = new System.Windows.Forms.Label();
            this.Box_StockView = new CafeStockSystem.RoundGroupBox();
            this.Dgv_Stock = new System.Windows.Forms.DataGridView();
            this.Label_Now = new System.Windows.Forms.Label();
            this.Box_Transaction = new CafeStockSystem.RoundGroupBox();
            this.Btn_Action = new System.Windows.Forms.Button();
            this.Num_Qty = new System.Windows.Forms.NumericUpDown();
            this.Label_Sales = new System.Windows.Forms.Label();
            this.Cbo_Item = new System.Windows.Forms.ComboBox();
            this.Label_Selceted = new System.Windows.Forms.Label();
            this.Rb_Out = new System.Windows.Forms.RadioButton();
            this.Rb_In = new System.Windows.Forms.RadioButton();
            this.Rb_Sell = new System.Windows.Forms.RadioButton();
            this.Label_Transaction = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.Box_StockView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Stock)).BeginInit();
            this.Box_Transaction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Qty)).BeginInit();
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
            // Label_Main
            // 
            this.Label_Main.AutoSize = true;
            this.Label_Main.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_Main.Location = new System.Drawing.Point(7, 57);
            this.Label_Main.Name = "Label_Main";
            this.Label_Main.Size = new System.Drawing.Size(104, 30);
            this.Label_Main.TabIndex = 4;
            this.Label_Main.Text = "재고 처리";
            // 
            // Box_StockView
            // 
            this.Box_StockView.BackColor = System.Drawing.Color.White;
            this.Box_StockView.BorderColor = System.Drawing.Color.White;
            this.Box_StockView.BorderRadius = 20;
            this.Box_StockView.Controls.Add(this.Dgv_Stock);
            this.Box_StockView.Controls.Add(this.Label_Now);
            this.Box_StockView.Location = new System.Drawing.Point(12, 378);
            this.Box_StockView.Name = "Box_StockView";
            this.Box_StockView.Size = new System.Drawing.Size(1560, 471);
            this.Box_StockView.TabIndex = 3;
            this.Box_StockView.TabStop = false;
            // 
            // Dgv_Stock
            // 
            this.Dgv_Stock.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_Stock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgv_Stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Stock.Location = new System.Drawing.Point(6, 41);
            this.Dgv_Stock.Name = "Dgv_Stock";
            this.Dgv_Stock.RowTemplate.Height = 23;
            this.Dgv_Stock.Size = new System.Drawing.Size(1548, 424);
            this.Dgv_Stock.TabIndex = 4;
            // 
            // Label_Now
            // 
            this.Label_Now.AutoSize = true;
            this.Label_Now.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_Now.Location = new System.Drawing.Point(6, 17);
            this.Label_Now.Name = "Label_Now";
            this.Label_Now.Size = new System.Drawing.Size(118, 21);
            this.Label_Now.TabIndex = 3;
            this.Label_Now.Text = "현재 재고 현황";
            // 
            // Box_Transaction
            // 
            this.Box_Transaction.BackColor = System.Drawing.Color.White;
            this.Box_Transaction.BorderColor = System.Drawing.Color.LightGray;
            this.Box_Transaction.BorderRadius = 20;
            this.Box_Transaction.Controls.Add(this.Btn_Action);
            this.Box_Transaction.Controls.Add(this.Num_Qty);
            this.Box_Transaction.Controls.Add(this.Label_Sales);
            this.Box_Transaction.Controls.Add(this.Cbo_Item);
            this.Box_Transaction.Controls.Add(this.Label_Selceted);
            this.Box_Transaction.Controls.Add(this.Rb_Out);
            this.Box_Transaction.Controls.Add(this.Rb_In);
            this.Box_Transaction.Controls.Add(this.Rb_Sell);
            this.Box_Transaction.Controls.Add(this.Label_Transaction);
            this.Box_Transaction.Location = new System.Drawing.Point(12, 88);
            this.Box_Transaction.Name = "Box_Transaction";
            this.Box_Transaction.Size = new System.Drawing.Size(1560, 284);
            this.Box_Transaction.TabIndex = 2;
            this.Box_Transaction.TabStop = false;
            // 
            // Btn_Action
            // 
            this.Btn_Action.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Btn_Action.FlatAppearance.BorderSize = 0;
            this.Btn_Action.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Action.ForeColor = System.Drawing.Color.White;
            this.Btn_Action.Location = new System.Drawing.Point(6, 238);
            this.Btn_Action.Name = "Btn_Action";
            this.Btn_Action.Size = new System.Drawing.Size(1548, 40);
            this.Btn_Action.TabIndex = 16;
            this.Btn_Action.Text = "🛒 판매 처리";
            this.Btn_Action.UseVisualStyleBackColor = false;
            this.Btn_Action.Click += new System.EventHandler(this.Btn_Action_Click);
            // 
            // Num_Qty
            // 
            this.Num_Qty.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Num_Qty.Location = new System.Drawing.Point(10, 189);
            this.Num_Qty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Num_Qty.Name = "Num_Qty";
            this.Num_Qty.Size = new System.Drawing.Size(1544, 30);
            this.Num_Qty.TabIndex = 9;
            this.Num_Qty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Label_Sales
            // 
            this.Label_Sales.AutoSize = true;
            this.Label_Sales.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_Sales.Location = new System.Drawing.Point(6, 166);
            this.Label_Sales.Name = "Label_Sales";
            this.Label_Sales.Size = new System.Drawing.Size(74, 20);
            this.Label_Sales.TabIndex = 8;
            this.Label_Sales.Text = "판매 수량";
            // 
            // Cbo_Item
            // 
            this.Cbo_Item.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Item.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Cbo_Item.FormattingEnabled = true;
            this.Cbo_Item.Location = new System.Drawing.Point(6, 120);
            this.Cbo_Item.Name = "Cbo_Item";
            this.Cbo_Item.Size = new System.Drawing.Size(1548, 29);
            this.Cbo_Item.TabIndex = 7;
            // 
            // Label_Selceted
            // 
            this.Label_Selceted.AutoSize = true;
            this.Label_Selceted.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_Selceted.Location = new System.Drawing.Point(6, 97);
            this.Label_Selceted.Name = "Label_Selceted";
            this.Label_Selceted.Size = new System.Drawing.Size(74, 20);
            this.Label_Selceted.TabIndex = 6;
            this.Label_Selceted.Text = "메뉴 선택";
            // 
            // Rb_Out
            // 
            this.Rb_Out.Appearance = System.Windows.Forms.Appearance.Button;
            this.Rb_Out.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Rb_Out.Location = new System.Drawing.Point(1354, 41);
            this.Rb_Out.Name = "Rb_Out";
            this.Rb_Out.Size = new System.Drawing.Size(200, 40);
            this.Rb_Out.TabIndex = 5;
            this.Rb_Out.Text = "🗑 폐기";
            this.Rb_Out.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Rb_Out.UseVisualStyleBackColor = true;
            this.Rb_Out.CheckedChanged += new System.EventHandler(this.Rb_Mode_CheckedChanged);
            // 
            // Rb_In
            // 
            this.Rb_In.Appearance = System.Windows.Forms.Appearance.Button;
            this.Rb_In.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Rb_In.Location = new System.Drawing.Point(682, 41);
            this.Rb_In.Name = "Rb_In";
            this.Rb_In.Size = new System.Drawing.Size(200, 40);
            this.Rb_In.TabIndex = 4;
            this.Rb_In.Text = "📦 입고";
            this.Rb_In.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Rb_In.UseVisualStyleBackColor = true;
            this.Rb_In.CheckedChanged += new System.EventHandler(this.Rb_Mode_CheckedChanged);
            // 
            // Rb_Sell
            // 
            this.Rb_Sell.Appearance = System.Windows.Forms.Appearance.Button;
            this.Rb_Sell.Checked = true;
            this.Rb_Sell.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Rb_Sell.Location = new System.Drawing.Point(10, 41);
            this.Rb_Sell.Name = "Rb_Sell";
            this.Rb_Sell.Size = new System.Drawing.Size(200, 40);
            this.Rb_Sell.TabIndex = 3;
            this.Rb_Sell.TabStop = true;
            this.Rb_Sell.Text = "🛒 판매";
            this.Rb_Sell.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Rb_Sell.UseVisualStyleBackColor = true;
            this.Rb_Sell.CheckedChanged += new System.EventHandler(this.Rb_Mode_CheckedChanged);
            // 
            // Label_Transaction
            // 
            this.Label_Transaction.AutoSize = true;
            this.Label_Transaction.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_Transaction.Location = new System.Drawing.Point(6, 17);
            this.Label_Transaction.Name = "Label_Transaction";
            this.Label_Transaction.Size = new System.Drawing.Size(112, 21);
            this.Label_Transaction.TabIndex = 2;
            this.Label_Transaction.Text = "재고 트랙재션";
            // 
            // SalesStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.Label_Main);
            this.Controls.Add(this.Box_StockView);
            this.Controls.Add(this.Box_Transaction);
            this.Controls.Add(this.panelTop);
            this.Name = "SalesStockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SalesStockForm";
            this.Load += new System.EventHandler(this.SalesStockForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.Box_StockView.ResumeLayout(false);
            this.Box_StockView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Stock)).EndInit();
            this.Box_Transaction.ResumeLayout(false);
            this.Box_Transaction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Qty)).EndInit();
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
        private CafeStockSystem.RoundGroupBox Box_Transaction;
        private CafeStockSystem.RoundGroupBox Box_StockView;
        private System.Windows.Forms.Label Label_Main;
        private System.Windows.Forms.Label Label_Transaction;
        private System.Windows.Forms.Label Label_Now;
        private System.Windows.Forms.DataGridView Dgv_Stock;
        private System.Windows.Forms.RadioButton Rb_Out;
        private System.Windows.Forms.RadioButton Rb_In;
        private System.Windows.Forms.RadioButton Rb_Sell;
        private System.Windows.Forms.Label Label_Selceted;
        private System.Windows.Forms.ComboBox Cbo_Item;
        private System.Windows.Forms.NumericUpDown Num_Qty;
        private System.Windows.Forms.Label Label_Sales;
        private System.Windows.Forms.Button Btn_Action;
    }
}