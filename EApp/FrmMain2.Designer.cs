namespace EApp
{
    partial class FrmMain2
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
            this.btnClose = new System.Windows.Forms.ButtonEx();
            this.tabControlEx1 = new System.Windows.Forms.TabControlEx();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBoxEx1 = new System.Windows.Forms.CheckBoxEx();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBoxEx2 = new System.Windows.Forms.CheckBoxEx();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.checkBoxEx3 = new System.Windows.Forms.CheckBoxEx();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.checkBoxEx4 = new System.Windows.Forms.CheckBoxEx();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControlEx1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::EApp.Properties.Resources.系统按钮关闭;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.Location = new System.Drawing.Point(757, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(12, 12);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControlEx1
            // 
            this.tabControlEx1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlEx1.Controls.Add(this.tabPage1);
            this.tabControlEx1.Controls.Add(this.tabPage2);
            this.tabControlEx1.Controls.Add(this.tabPage3);
            this.tabControlEx1.Controls.Add(this.tabPage5);
            this.tabControlEx1.Controls.Add(this.tabPage4);
            this.tabControlEx1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlEx1.ItemSize = new System.Drawing.Size(88, 88);
            this.tabControlEx1.Location = new System.Drawing.Point(0, 0);
            this.tabControlEx1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlEx1.Multiline = true;
            this.tabControlEx1.Name = "tabControlEx1";
            this.tabControlEx1.Padding = new System.Drawing.Point(0, 0);
            this.tabControlEx1.SelectedIndex = 0;
            this.tabControlEx1.ShowToolTips = true;
            this.tabControlEx1.Size = new System.Drawing.Size(655, 624);
            this.tabControlEx1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlEx1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.checkBoxEx1);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage1.Location = new System.Drawing.Point(88, 0);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(565, 622);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "听诊器配置";
            // 
            // checkBoxEx1
            // 
            this.checkBoxEx1.AutoSize = true;
            this.checkBoxEx1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.checkBoxEx1.Checked = true;
            this.checkBoxEx1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEx1.ForeColor = System.Drawing.Color.Red;
            this.checkBoxEx1.Location = new System.Drawing.Point(125, 61);
            this.checkBoxEx1.Name = "checkBoxEx1";
            this.checkBoxEx1.Size = new System.Drawing.Size(84, 24);
            this.checkBoxEx1.TabIndex = 0;
            this.checkBoxEx1.Text = "听诊配置";
            this.checkBoxEx1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBoxEx2);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage2.Location = new System.Drawing.Point(88, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(565, 433);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "听诊教学";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBoxEx2
            // 
            this.checkBoxEx2.AutoSize = true;
            this.checkBoxEx2.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.checkBoxEx2.Checked = true;
            this.checkBoxEx2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEx2.ForeColor = System.Drawing.Color.Yellow;
            this.checkBoxEx2.Location = new System.Drawing.Point(112, 90);
            this.checkBoxEx2.Name = "checkBoxEx2";
            this.checkBoxEx2.Size = new System.Drawing.Size(84, 24);
            this.checkBoxEx2.TabIndex = 1;
            this.checkBoxEx2.Text = "听诊配置";
            this.checkBoxEx2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.checkBoxEx3);
            this.tabPage3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage3.Location = new System.Drawing.Point(88, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(565, 622);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "听诊录音";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // checkBoxEx3
            // 
            this.checkBoxEx3.AutoSize = true;
            this.checkBoxEx3.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.checkBoxEx3.Checked = true;
            this.checkBoxEx3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEx3.ForeColor = System.Drawing.Color.Navy;
            this.checkBoxEx3.Location = new System.Drawing.Point(155, 135);
            this.checkBoxEx3.Name = "checkBoxEx3";
            this.checkBoxEx3.Size = new System.Drawing.Size(84, 24);
            this.checkBoxEx3.TabIndex = 1;
            this.checkBoxEx3.Text = "听诊配置";
            this.checkBoxEx3.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.checkBoxEx4);
            this.tabPage5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage5.Location = new System.Drawing.Point(88, 0);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(565, 433);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "云端听诊";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // checkBoxEx4
            // 
            this.checkBoxEx4.AutoSize = true;
            this.checkBoxEx4.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.checkBoxEx4.Checked = true;
            this.checkBoxEx4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEx4.ForeColor = System.Drawing.Color.Lime;
            this.checkBoxEx4.Location = new System.Drawing.Point(114, 132);
            this.checkBoxEx4.Name = "checkBoxEx4";
            this.checkBoxEx4.Size = new System.Drawing.Size(84, 24);
            this.checkBoxEx4.TabIndex = 1;
            this.checkBoxEx4.Text = "听诊配置";
            this.checkBoxEx4.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button3);
            this.tabPage4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage4.Location = new System.Drawing.Point(176, 0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(477, 433);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "远程教学";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(260, 203);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 33);
            this.button3.TabIndex = 0;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // FrmMain2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(782, 549);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControlEx1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain2";
            this.ShowIcon = false;
            this.Text = "窗体2";
            this.tabControlEx1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControlEx tabControlEx1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ButtonEx btnClose;
        private System.Windows.Forms.CheckBoxEx checkBoxEx1;
        private System.Windows.Forms.CheckBoxEx checkBoxEx2;
        private System.Windows.Forms.CheckBoxEx checkBoxEx3;
        private System.Windows.Forms.CheckBoxEx checkBoxEx4;
        private System.Windows.Forms.TabPage tabPage1;

    }
}