namespace Project
{
    partial class LoginFrom
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Button_Login = new System.Windows.Forms.Button();
            this.roundGroupBox1 = new CafeStockSystem.RoundGroupBox();
            this.Chk_Kiosk = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Text_PW = new CafeStockSystem.RoundTextBox();
            this.Text_ID = new CafeStockSystem.RoundTextBox();
            this.Button_Calncell = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Label_Word = new System.Windows.Forms.Label();
            this.Label_PW = new System.Windows.Forms.Label();
            this.Label_ID = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.roundGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.roundGroupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.75494F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 861F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1584, 861);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Button_Login
            // 
            this.Button_Login.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Button_Login.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Button_Login.ForeColor = System.Drawing.Color.White;
            this.Button_Login.Location = new System.Drawing.Point(50, 319);
            this.Button_Login.Name = "Button_Login";
            this.Button_Login.Size = new System.Drawing.Size(210, 40);
            this.Button_Login.TabIndex = 6;
            this.Button_Login.Text = "로그인";
            this.Button_Login.UseVisualStyleBackColor = false;
            this.Button_Login.Click += new System.EventHandler(this.Button_Login_Click);
            // 
            // roundGroupBox1
            // 
            this.roundGroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.roundGroupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.roundGroupBox1.BorderColor = System.Drawing.Color.Black;
            this.roundGroupBox1.BorderRadius = 20;
            this.roundGroupBox1.Controls.Add(this.Chk_Kiosk);
            this.roundGroupBox1.Controls.Add(this.pictureBox1);
            this.roundGroupBox1.Controls.Add(this.Text_PW);
            this.roundGroupBox1.Controls.Add(this.Text_ID);
            this.roundGroupBox1.Controls.Add(this.Button_Calncell);
            this.roundGroupBox1.Controls.Add(this.Button_Login);
            this.roundGroupBox1.Controls.Add(this.label1);
            this.roundGroupBox1.Controls.Add(this.Label_Word);
            this.roundGroupBox1.Controls.Add(this.Label_PW);
            this.roundGroupBox1.Controls.Add(this.Label_ID);
            this.roundGroupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.roundGroupBox1.Location = new System.Drawing.Point(517, 230);
            this.roundGroupBox1.Name = "roundGroupBox1";
            this.roundGroupBox1.Size = new System.Drawing.Size(550, 400);
            this.roundGroupBox1.TabIndex = 0;
            this.roundGroupBox1.TabStop = false;
            // 
            // Chk_Kiosk
            // 
            this.Chk_Kiosk.AutoSize = true;
            this.Chk_Kiosk.BackColor = System.Drawing.Color.White;
            this.Chk_Kiosk.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Chk_Kiosk.ForeColor = System.Drawing.Color.Black;
            this.Chk_Kiosk.Location = new System.Drawing.Point(50, 288);
            this.Chk_Kiosk.Name = "Chk_Kiosk";
            this.Chk_Kiosk.Size = new System.Drawing.Size(185, 25);
            this.Chk_Kiosk.TabIndex = 11;
            this.Chk_Kiosk.Text = "키오스크 모드로 실행";
            this.Chk_Kiosk.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Project.Properties.Resources.free_icon_sign_in_7655802;
            this.pictureBox1.Location = new System.Drawing.Point(243, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Text_PW
            // 
            this.Text_PW.BackColor = System.Drawing.Color.LightGray;
            this.Text_PW.BorderColor = System.Drawing.Color.LightGray;
            this.Text_PW.BorderRadius = 10;
            this.Text_PW.BorderSize = 1;
            this.Text_PW.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Text_PW.ForeColor = System.Drawing.Color.Black;
            this.Text_PW.Location = new System.Drawing.Point(50, 242);
            this.Text_PW.Name = "Text_PW";
            this.Text_PW.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.Text_PW.PasswordChar = '＊';
            this.Text_PW.PlaceholderText = "비밀번호를 입력하세요";
            this.Text_PW.Size = new System.Drawing.Size(450, 40);
            this.Text_PW.TabIndex = 9;
            this.Text_PW.UseSystemPasswordChar = false;
            // 
            // Text_ID
            // 
            this.Text_ID.BackColor = System.Drawing.Color.LightGray;
            this.Text_ID.BorderColor = System.Drawing.Color.LightGray;
            this.Text_ID.BorderRadius = 10;
            this.Text_ID.BorderSize = 1;
            this.Text_ID.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Text_ID.ForeColor = System.Drawing.Color.Black;
            this.Text_ID.Location = new System.Drawing.Point(50, 175);
            this.Text_ID.Name = "Text_ID";
            this.Text_ID.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.Text_ID.PasswordChar = '\0';
            this.Text_ID.PlaceholderText = "아이디를 입력하세요";
            this.Text_ID.Size = new System.Drawing.Size(450, 40);
            this.Text_ID.TabIndex = 8;
            this.Text_ID.UseSystemPasswordChar = false;
            // 
            // Button_Calncell
            // 
            this.Button_Calncell.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Button_Calncell.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Button_Calncell.Location = new System.Drawing.Point(290, 319);
            this.Button_Calncell.Name = "Button_Calncell";
            this.Button_Calncell.Size = new System.Drawing.Size(210, 40);
            this.Button_Calncell.TabIndex = 7;
            this.Button_Calncell.Text = "취소";
            this.Button_Calncell.UseVisualStyleBackColor = true;
            this.Button_Calncell.Click += new System.EventHandler(this.Button_Calncell_Click);
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕 Semilight", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(146, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "로그인하여 시스템에 접속하세요";
            // 
            // Label_Word
            // 
            this.Label_Word.AllowDrop = true;
            this.Label_Word.AutoSize = true;
            this.Label_Word.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_Word.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label_Word.Location = new System.Drawing.Point(188, 86);
            this.Label_Word.Name = "Label_Word";
            this.Label_Word.Size = new System.Drawing.Size(175, 23);
            this.Label_Word.TabIndex = 4;
            this.Label_Word.Text = "카페 재고 관리시스탬";
            // 
            // Label_PW
            // 
            this.Label_PW.AutoSize = true;
            this.Label_PW.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_PW.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label_PW.Location = new System.Drawing.Point(46, 218);
            this.Label_PW.Name = "Label_PW";
            this.Label_PW.Size = new System.Drawing.Size(114, 21);
            this.Label_PW.TabIndex = 3;
            this.Label_PW.Text = "비밀번호 (PW)";
            // 
            // Label_ID
            // 
            this.Label_ID.AutoSize = true;
            this.Label_ID.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_ID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label_ID.Location = new System.Drawing.Point(46, 151);
            this.Label_ID.Name = "Label_ID";
            this.Label_ID.Size = new System.Drawing.Size(89, 21);
            this.Label_ID.TabIndex = 2;
            this.Label_ID.Text = "아이디 (ID)";
            // 
            // LoginFrom
            // 
            this.AcceptButton = this.Button_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LoginFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.roundGroupBox1.ResumeLayout(false);
            this.roundGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CafeStockSystem.RoundGroupBox roundGroupBox1;
        private System.Windows.Forms.Label Label_ID;
        private System.Windows.Forms.Label Label_PW;
        private System.Windows.Forms.Label Label_Word;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_Calncell;
        private System.Windows.Forms.Button Button_Login;
        private CafeStockSystem.RoundTextBox Text_PW;
        private CafeStockSystem.RoundTextBox Text_ID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox Chk_Kiosk;
    }
}

