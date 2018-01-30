using System.Windows.Forms;
namespace BDAuscultation.Forms
{
    partial class FrmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSure = new System.Windows.Forms.ButtonEx();
            this.waterTextBox3 = new System.Windows.Forms.UCTextBoxEx();
            this.waterTextBox1 = new System.Windows.Forms.UCTextBoxEx();
            this.waterTextBox4 = new System.Windows.Forms.UCTextBoxEx();
            this.waterTextBox5 = new System.Windows.Forms.UCTextBoxEx();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "激活码:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "激活时间:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "有效天数:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "版本:";
            // 
            // btnSure
            // 
            this.btnSure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSure.BackColor = System.Drawing.Color.Transparent;
            this.btnSure.FlatAppearance.BorderSize = 0;
            this.btnSure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSure.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSure.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(230)))));
            this.btnSure.LeftBottom = 0;
            this.btnSure.LeftTop = 0;
            this.btnSure.Location = new System.Drawing.Point(299, 132);
            this.btnSure.Name = "btnSure";
            this.btnSure.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(135)))), ((int)(((byte)(251)))));
            this.btnSure.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(105)))), ((int)(((byte)(251)))));
            this.btnSure.Radius = 16;
            this.btnSure.RightBottom = 0;
            this.btnSure.RightTop = 0;
            this.btnSure.Size = new System.Drawing.Size(75, 24);
            this.btnSure.TabIndex = 10;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = false;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // waterTextBox3
            // 
            this.waterTextBox3.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.waterTextBox3.BackColor = System.Drawing.Color.White;
            this.waterTextBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.waterTextBox3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.waterTextBox3.Location = new System.Drawing.Point(79, 93);
            this.waterTextBox3.Multiline = false;
            this.waterTextBox3.Name = "waterTextBox3";
            this.waterTextBox3.PasswordChar = '\0';
            this.waterTextBox3.Radius = 16;
            this.waterTextBox3.ReadOnly = true;
            this.waterTextBox3.Size = new System.Drawing.Size(193, 24);
            this.waterTextBox3.TabIndex = 11;
            this.waterTextBox3.WaterText = "水印文字";
            // 
            // waterTextBox1
            // 
            this.waterTextBox1.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.waterTextBox1.BackColor = System.Drawing.Color.White;
            this.waterTextBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.waterTextBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.waterTextBox1.Location = new System.Drawing.Point(79, 54);
            this.waterTextBox1.Multiline = false;
            this.waterTextBox1.Name = "waterTextBox1";
            this.waterTextBox1.PasswordChar = '\0';
            this.waterTextBox1.Radius = 16;
            this.waterTextBox1.ReadOnly = true;
            this.waterTextBox1.Size = new System.Drawing.Size(312, 24);
            this.waterTextBox1.TabIndex = 12;
            this.waterTextBox1.WaterText = "水印文字";
            // 
            // waterTextBox4
            // 
            this.waterTextBox4.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.waterTextBox4.BackColor = System.Drawing.Color.White;
            this.waterTextBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.waterTextBox4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.waterTextBox4.Location = new System.Drawing.Point(79, 132);
            this.waterTextBox4.Multiline = false;
            this.waterTextBox4.Name = "waterTextBox4";
            this.waterTextBox4.PasswordChar = '\0';
            this.waterTextBox4.Radius = 16;
            this.waterTextBox4.ReadOnly = true;
            this.waterTextBox4.Size = new System.Drawing.Size(193, 24);
            this.waterTextBox4.TabIndex = 13;
            this.waterTextBox4.WaterText = "水印文字";
            // 
            // waterTextBox5
            // 
            this.waterTextBox5.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.waterTextBox5.BackColor = System.Drawing.Color.White;
            this.waterTextBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.waterTextBox5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.waterTextBox5.Location = new System.Drawing.Point(79, 16);
            this.waterTextBox5.Multiline = false;
            this.waterTextBox5.Name = "waterTextBox5";
            this.waterTextBox5.PasswordChar = '\0';
            this.waterTextBox5.Radius = 16;
            this.waterTextBox5.ReadOnly = true;
            this.waterTextBox5.Size = new System.Drawing.Size(312, 24);
            this.waterTextBox5.TabIndex = 14;
            this.waterTextBox5.WaterText = "水印文字";
            // 
            // FrmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(396, 172);
            this.Controls.Add(this.waterTextBox5);
            this.Controls.Add(this.waterTextBox4);
            this.Controls.Add(this.waterTextBox1);
            this.Controls.Add(this.waterTextBox3);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.Text = "关于软件";
            this.Load += new System.EventHandler(this.FormAbout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private  ButtonEx btnSure;
        private UCTextBoxEx waterTextBox3;
        private UCTextBoxEx waterTextBox1;
        private UCTextBoxEx waterTextBox4;
        private UCTextBoxEx waterTextBox5;
    }
}