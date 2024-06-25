namespace MoveIT
{
    partial class LoginView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            this.pswTxtBx = new System.Windows.Forms.TextBox();
            this.mailTxtBx = new System.Windows.Forms.TextBox();
            this.btn_CreateAccount = new System.Windows.Forms.Button();
            this.loginBtn = new System.Windows.Forms.Button();
            this.viewPswBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.logoPcBx = new System.Windows.Forms.PictureBox();
            this.showMessageLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPcBx)).BeginInit();
            this.SuspendLayout();
            // 
            // pswTxtBx
            // 
            this.pswTxtBx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pswTxtBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pswTxtBx.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pswTxtBx.ForeColor = System.Drawing.Color.Gray;
            this.pswTxtBx.Location = new System.Drawing.Point(311, 361);
            this.pswTxtBx.Multiline = true;
            this.pswTxtBx.Name = "pswTxtBx";
            this.pswTxtBx.Size = new System.Drawing.Size(308, 36);
            this.pswTxtBx.TabIndex = 3;
            this.pswTxtBx.Text = "Mot de passe";
            this.pswTxtBx.Enter += new System.EventHandler(this.TextBox_Enter);
            this.pswTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.pswTxtBx.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // mailTxtBx
            // 
            this.mailTxtBx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mailTxtBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mailTxtBx.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mailTxtBx.ForeColor = System.Drawing.Color.Gray;
            this.mailTxtBx.Location = new System.Drawing.Point(311, 302);
            this.mailTxtBx.Multiline = true;
            this.mailTxtBx.Name = "mailTxtBx";
            this.mailTxtBx.Size = new System.Drawing.Size(342, 36);
            this.mailTxtBx.TabIndex = 2;
            this.mailTxtBx.Text = "Adresse mail";
            this.mailTxtBx.Enter += new System.EventHandler(this.TextBox_Enter);
            this.mailTxtBx.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // btn_CreateAccount
            // 
            this.btn_CreateAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(51)))), ((int)(((byte)(42)))));
            this.btn_CreateAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CreateAccount.FlatAppearance.BorderSize = 0;
            this.btn_CreateAccount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(51)))), ((int)(((byte)(42)))));
            this.btn_CreateAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(51)))), ((int)(((byte)(42)))));
            this.btn_CreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CreateAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CreateAccount.ForeColor = System.Drawing.Color.White;
            this.btn_CreateAccount.Location = new System.Drawing.Point(311, 420);
            this.btn_CreateAccount.Name = "btn_CreateAccount";
            this.btn_CreateAccount.Size = new System.Drawing.Size(130, 35);
            this.btn_CreateAccount.TabIndex = 1;
            this.btn_CreateAccount.Text = "S\'inscrire";
            this.btn_CreateAccount.UseVisualStyleBackColor = false;
            this.btn_CreateAccount.Click += new System.EventHandler(this.btn_CreateAccount_Click);
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.Navy;
            this.loginBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.loginBtn.FlatAppearance.BorderSize = 0;
            this.loginBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.loginBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.ForeColor = System.Drawing.Color.White;
            this.loginBtn.Location = new System.Drawing.Point(523, 420);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(130, 35);
            this.loginBtn.TabIndex = 4;
            this.loginBtn.Text = "Se connecter";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // viewPswBtn
            // 
            this.viewPswBtn.BackColor = System.Drawing.Color.White;
            this.viewPswBtn.BackgroundImage = global::MoveIT.Properties.Resources.closedEye;
            this.viewPswBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.viewPswBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.viewPswBtn.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.viewPswBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.viewPswBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.viewPswBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewPswBtn.Location = new System.Drawing.Point(618, 362);
            this.viewPswBtn.Name = "viewPswBtn";
            this.viewPswBtn.Size = new System.Drawing.Size(35, 35);
            this.viewPswBtn.TabIndex = 5;
            this.viewPswBtn.UseVisualStyleBackColor = true;
            this.viewPswBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.viewPswBtn_MouseDown);
            this.viewPswBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.viewPswBtn_MouseUp);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(346, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 28);
            this.label1.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(585, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 236);
            this.label3.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(337, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 236);
            this.label4.TabIndex = 18;
            // 
            // logoPcBx
            // 
            this.logoPcBx.Image = global::MoveIT.Properties.Resources.moveitLogo;
            this.logoPcBx.Location = new System.Drawing.Point(393, 40);
            this.logoPcBx.Name = "logoPcBx";
            this.logoPcBx.Size = new System.Drawing.Size(186, 237);
            this.logoPcBx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPcBx.TabIndex = 20;
            this.logoPcBx.TabStop = false;
            // 
            // showMessageLbl
            // 
            this.showMessageLbl.AutoSize = true;
            this.showMessageLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showMessageLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showMessageLbl.Location = new System.Drawing.Point(922, 9);
            this.showMessageLbl.Name = "showMessageLbl";
            this.showMessageLbl.Size = new System.Drawing.Size(30, 17);
            this.showMessageLbl.TabIndex = 21;
            this.showMessageLbl.Text = "Info";
            this.showMessageLbl.Click += new System.EventHandler(this.showMessageLbl_Click);
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(964, 511);
            this.Controls.Add(this.showMessageLbl);
            this.Controls.Add(this.mailTxtBx);
            this.Controls.Add(this.logoPcBx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewPswBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.pswTxtBx);
            this.Controls.Add(this.btn_CreateAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MoveIT - Login";
            ((System.ComponentModel.ISupportInitialize)(this.logoPcBx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button btn_CreateAccount;
        private System.Windows.Forms.Button viewPswBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox logoPcBx;
        public System.Windows.Forms.TextBox pswTxtBx;
        public System.Windows.Forms.TextBox mailTxtBx;
        private System.Windows.Forms.Label showMessageLbl;
    }
}