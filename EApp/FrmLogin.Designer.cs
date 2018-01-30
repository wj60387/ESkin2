namespace EApp
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.btnLogin = new System.Windows.Forms.ButtonEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucTextBox2 = new System.Windows.Forms.UCTextBox();
            this.ucTextBox1 = new System.Windows.Forms.UCTextBox();
            this.btnClose = new System.Windows.Forms.ButtonEx();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackgroundImage = global::EApp.Properties.Resources.登入框登录200x40;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLogin.Location = new System.Drawing.Point(60, 290);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(220, 40);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::EApp.Properties.Resources.奔达听诊平台;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(45, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 45);
            this.panel1.TabIndex = 4;
            // 
            // ucTextBox2
            // 
            this.ucTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.ucTextBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucTextBox2.BackgroundImage")));
            this.ucTextBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ucTextBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucTextBox2.ImageDrawRect = new System.Drawing.Rectangle(25, 10, 20, 20);
            this.ucTextBox2.Location = new System.Drawing.Point(60, 230);
            this.ucTextBox2.Name = "ucTextBox2";
            this.ucTextBox2.PasswordChar = '*';
            this.ucTextBox2.Size = new System.Drawing.Size(220, 40);
            this.ucTextBox2.TabIndex = 3;
            this.ucTextBox2.TextBoxLocation = new System.Drawing.Point(50, 10);
            this.ucTextBox2.TextImage = global::EApp.Properties.Resources.密码图标;
            this.ucTextBox2.WaterText = "密码";
            // 
            // ucTextBox1
            // 
            this.ucTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.ucTextBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucTextBox1.BackgroundImage")));
            this.ucTextBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ucTextBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucTextBox1.ImageDrawRect = new System.Drawing.Rectangle(25, 10, 20, 20);
            this.ucTextBox1.Location = new System.Drawing.Point(60, 170);
            this.ucTextBox1.Name = "ucTextBox1";
            this.ucTextBox1.PasswordChar = '\0';
            this.ucTextBox1.Size = new System.Drawing.Size(220, 40);
            this.ucTextBox1.TabIndex = 2;
            this.ucTextBox1.TextBoxLocation = new System.Drawing.Point(50, 10);
            this.ucTextBox1.TextImage = ((System.Drawing.Image)(resources.GetObject("ucTextBox1.TextImage")));
            this.ucTextBox1.WaterText = "用户名";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::EApp.Properties.Resources.系统按钮关闭;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(582, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(12, 12);
            this.btnClose.TabIndex = 6;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EApp.Properties.Resources.背景;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucTextBox2);
            this.Controls.Add(this.ucTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.UCTextBox ucTextBox1;
        private System.Windows.Forms.UCTextBox ucTextBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ButtonEx btnLogin;
        private System.Windows.Forms.ButtonEx btnClose;
    }
}