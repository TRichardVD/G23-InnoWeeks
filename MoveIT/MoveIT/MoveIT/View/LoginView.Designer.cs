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
            this.idTxtBx = new System.Windows.Forms.TextBox();
            this.btn_CreateAccount = new System.Windows.Forms.Button();
            this.loginBtn = new System.Windows.Forms.Button();
            this.viewPswBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // idTxtBx
            // 
            this.idTxtBx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.idTxtBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.idTxtBx.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idTxtBx.ForeColor = System.Drawing.Color.Gray;
            this.idTxtBx.Location = new System.Drawing.Point(311, 302);
            this.idTxtBx.Multiline = true;
            this.idTxtBx.Name = "idTxtBx";
            this.idTxtBx.Size = new System.Drawing.Size(342, 36);
            this.idTxtBx.TabIndex = 2;
            this.idTxtBx.Text = "Identifiant";
            this.idTxtBx.Enter += new System.EventHandler(this.TextBox_Enter);
            this.idTxtBx.Leave += new System.EventHandler(this.TextBox_Leave);
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
            this.viewPswBtn.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.viewPswBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.viewPswBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.viewPswBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewPswBtn.Location = new System.Drawing.Point(618, 362);
            this.viewPswBtn.Name = "viewPswBtn";
            this.viewPswBtn.Size = new System.Drawing.Size(35, 35);
            this.viewPswBtn.TabIndex = 5;
            this.viewPswBtn.UseVisualStyleBackColor = false;
            this.viewPswBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.viewPswBtn_MouseDown);
            this.viewPswBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.viewPswBtn_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::MoveIT.Properties.Resources.moveitLogo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(376, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 247);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(964, 511);
            this.Controls.Add(this.viewPswBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pswTxtBx);
            this.Controls.Add(this.idTxtBx);
            this.Controls.Add(this.btn_CreateAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MoveIT - Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox pswTxtBx;
        private System.Windows.Forms.TextBox idTxtBx;
        private System.Windows.Forms.Button btn_CreateAccount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button viewPswBtn;
    }
}