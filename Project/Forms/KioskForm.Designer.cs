namespace Project
{
    partial class KioskForm
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
            this.Pnl_Right = new System.Windows.Forms.Panel();
            this.Dgv_Cart = new System.Windows.Forms.DataGridView();
            this.Pnl_Bottom = new System.Windows.Forms.Panel();
            this.Btn_Order = new System.Windows.Forms.Button();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.Lbl_TotalPrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Flow_Menu = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Rb_Ko = new System.Windows.Forms.RadioButton();
            this.Rb_En = new System.Windows.Forms.RadioButton();
            this.Rb_Ja = new System.Windows.Forms.RadioButton();
            this.Pnl_Right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Cart)).BeginInit();
            this.Pnl_Bottom.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pnl_Right
            // 
            this.Pnl_Right.Controls.Add(this.Dgv_Cart);
            this.Pnl_Right.Controls.Add(this.Pnl_Bottom);
            this.Pnl_Right.Controls.Add(this.label1);
            this.Pnl_Right.Dock = System.Windows.Forms.DockStyle.Right;
            this.Pnl_Right.Location = new System.Drawing.Point(1234, 0);
            this.Pnl_Right.Name = "Pnl_Right";
            this.Pnl_Right.Size = new System.Drawing.Size(350, 861);
            this.Pnl_Right.TabIndex = 0;
            // 
            // Dgv_Cart
            // 
            this.Dgv_Cart.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_Cart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Cart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv_Cart.Location = new System.Drawing.Point(0, 50);
            this.Dgv_Cart.Name = "Dgv_Cart";
            this.Dgv_Cart.RowTemplate.Height = 23;
            this.Dgv_Cart.Size = new System.Drawing.Size(350, 661);
            this.Dgv_Cart.TabIndex = 0;
            this.Dgv_Cart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Cart_CellContentClick);
            // 
            // Pnl_Bottom
            // 
            this.Pnl_Bottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Pnl_Bottom.Controls.Add(this.Btn_Order);
            this.Pnl_Bottom.Controls.Add(this.Btn_Clear);
            this.Pnl_Bottom.Controls.Add(this.Lbl_TotalPrice);
            this.Pnl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Pnl_Bottom.Location = new System.Drawing.Point(0, 711);
            this.Pnl_Bottom.Name = "Pnl_Bottom";
            this.Pnl_Bottom.Size = new System.Drawing.Size(350, 150);
            this.Pnl_Bottom.TabIndex = 1;
            // 
            // Btn_Order
            // 
            this.Btn_Order.BackColor = System.Drawing.Color.Black;
            this.Btn_Order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Order.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Order.ForeColor = System.Drawing.Color.White;
            this.Btn_Order.Location = new System.Drawing.Point(0, 40);
            this.Btn_Order.Name = "Btn_Order";
            this.Btn_Order.Size = new System.Drawing.Size(350, 70);
            this.Btn_Order.TabIndex = 5;
            this.Btn_Order.Text = "결제하기";
            this.Btn_Order.UseVisualStyleBackColor = false;
            this.Btn_Order.Click += new System.EventHandler(this.Btn_Order_Click);
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Btn_Clear.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Clear.Location = new System.Drawing.Point(0, 110);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(350, 40);
            this.Btn_Clear.TabIndex = 4;
            this.Btn_Clear.Text = "장바구니 비우기";
            this.Btn_Clear.UseVisualStyleBackColor = true;
            this.Btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // Lbl_TotalPrice
            // 
            this.Lbl_TotalPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.Lbl_TotalPrice.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lbl_TotalPrice.Location = new System.Drawing.Point(0, 0);
            this.Lbl_TotalPrice.Name = "Lbl_TotalPrice";
            this.Lbl_TotalPrice.Size = new System.Drawing.Size(350, 40);
            this.Lbl_TotalPrice.TabIndex = 2;
            this.Lbl_TotalPrice.Text = "총 결제금액: 0원";
            this.Lbl_TotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "주문 내역";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Flow_Menu
            // 
            this.Flow_Menu.AutoScroll = true;
            this.Flow_Menu.BackColor = System.Drawing.Color.White;
            this.Flow_Menu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Flow_Menu.Location = new System.Drawing.Point(0, 50);
            this.Flow_Menu.Name = "Flow_Menu";
            this.Flow_Menu.Size = new System.Drawing.Size(1234, 811);
            this.Flow_Menu.TabIndex = 0;
            this.Flow_Menu.Click += new System.EventHandler(this.MenuBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Rb_Ja);
            this.panel1.Controls.Add(this.Rb_En);
            this.panel1.Controls.Add(this.Rb_Ko);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1234, 50);
            this.panel1.TabIndex = 0;
            // 
            // Rb_Ko
            // 
            this.Rb_Ko.Appearance = System.Windows.Forms.Appearance.Button;
            this.Rb_Ko.AutoSize = true;
            this.Rb_Ko.Checked = true;
            this.Rb_Ko.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Rb_Ko.Location = new System.Drawing.Point(12, 10);
            this.Rb_Ko.Name = "Rb_Ko";
            this.Rb_Ko.Size = new System.Drawing.Size(68, 31);
            this.Rb_Ko.TabIndex = 0;
            this.Rb_Ko.TabStop = true;
            this.Rb_Ko.Text = "한국어";
            this.Rb_Ko.UseVisualStyleBackColor = true;
            this.Rb_Ko.CheckedChanged += new System.EventHandler(this.Language_CheckedChanged);
            // 
            // Rb_En
            // 
            this.Rb_En.Appearance = System.Windows.Forms.Appearance.Button;
            this.Rb_En.AutoSize = true;
            this.Rb_En.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.Rb_En.Location = new System.Drawing.Point(162, 10);
            this.Rb_En.Name = "Rb_En";
            this.Rb_En.Size = new System.Drawing.Size(74, 31);
            this.Rb_En.TabIndex = 1;
            this.Rb_En.Text = "English";
            this.Rb_En.UseVisualStyleBackColor = true;
            this.Rb_En.CheckedChanged += new System.EventHandler(this.Language_CheckedChanged);
            // 
            // Rb_Ja
            // 
            this.Rb_Ja.Appearance = System.Windows.Forms.Appearance.Button;
            this.Rb_Ja.AutoSize = true;
            this.Rb_Ja.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.Rb_Ja.Location = new System.Drawing.Point(318, 10);
            this.Rb_Ja.Name = "Rb_Ja";
            this.Rb_Ja.Size = new System.Drawing.Size(68, 31);
            this.Rb_Ja.TabIndex = 2;
            this.Rb_Ja.Text = "日本語";
            this.Rb_Ja.UseVisualStyleBackColor = true;
            this.Rb_Ja.CheckedChanged += new System.EventHandler(this.Language_CheckedChanged);
            // 
            // KioskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Flow_Menu);
            this.Controls.Add(this.Pnl_Right);
            this.Name = "KioskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KioskForm";
            this.Pnl_Right.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Cart)).EndInit();
            this.Pnl_Bottom.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Pnl_Right;
        private System.Windows.Forms.FlowLayoutPanel Flow_Menu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Pnl_Bottom;
        private System.Windows.Forms.DataGridView Dgv_Cart;
        private System.Windows.Forms.Label Lbl_TotalPrice;
        private System.Windows.Forms.Button Btn_Clear;
        private System.Windows.Forms.Button Btn_Order;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton Rb_Ja;
        private System.Windows.Forms.RadioButton Rb_En;
        private System.Windows.Forms.RadioButton Rb_Ko;
    }
}