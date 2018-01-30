using System.Windows.Forms;
namespace BDAuscultation.Forms
{
    partial class FrmStetInfo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStetInfo));
            this.buttonEx1 = new System.Windows.Forms.ButtonEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtStetName = new System.Windows.Forms.UCTextBoxEx();
            this.btnCancel = new System.Windows.Forms.ButtonEx();
            this.btnSure = new System.Windows.Forms.ButtonEx();
            this.txtStetRemark = new System.Windows.Forms.UCTextBoxEx();
            this.label11 = new System.Windows.Forms.Label();
            this.txtStetFunc = new System.Windows.Forms.UCTextBoxEx();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStetOwner = new System.Windows.Forms.UCTextBoxEx();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStetChineseName = new System.Windows.Forms.UCTextBoxEx();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButtonEx2 = new System.Windows.Forms.RadioButtonEx();
            this.radioButtonEx1 = new System.Windows.Forms.RadioButtonEx();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.ButtonEx();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonEx1
            // 
            this.buttonEx1.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx1.BackgroundImage = global::BDAuscultation.Properties.Resources.按钮;
            this.buttonEx1.FlatAppearance.BorderSize = 0;
            this.buttonEx1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonEx1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonEx1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonEx1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(230)))));
            this.buttonEx1.LeftBottom = 0;
            this.buttonEx1.LeftTop = 0;
            this.buttonEx1.Location = new System.Drawing.Point(18, 11);
            this.buttonEx1.Name = "buttonEx1";
            this.buttonEx1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(135)))), ((int)(((byte)(251)))));
            this.buttonEx1.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(105)))), ((int)(((byte)(251)))));
            this.buttonEx1.Radius = 16;
            this.buttonEx1.RightBottom = 0;
            this.buttonEx1.RightTop = 0;
            this.buttonEx1.Size = new System.Drawing.Size(104, 35);
            this.buttonEx1.TabIndex = 17;
            this.buttonEx1.Text = "听诊器信息";
            this.buttonEx1.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtStetName);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSure);
            this.panel1.Controls.Add(this.txtStetRemark);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtStetFunc);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtStetOwner);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtStetChineseName);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.radioButtonEx2);
            this.panel1.Controls.Add(this.radioButtonEx1);
            this.panel1.Location = new System.Drawing.Point(7, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 237);
            this.panel1.TabIndex = 11;
            // 
            // txtStetName
            // 
            this.txtStetName.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.txtStetName.BackColor = System.Drawing.Color.White;
            this.txtStetName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtStetName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStetName.ForeColor = System.Drawing.Color.Black;
            this.txtStetName.Location = new System.Drawing.Point(139, 25);
            this.txtStetName.Multiline = false;
            this.txtStetName.Name = "txtStetName";
            this.txtStetName.PasswordChar = '\0';
            this.txtStetName.Radius = 24;
            this.txtStetName.ReadOnly = true;
            this.txtStetName.Size = new System.Drawing.Size(246, 24);
            this.txtStetName.TabIndex = 31;
            this.txtStetName.WaterText = "听诊器编号";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.LeftBottom = 30;
            this.btnCancel.LeftTop = 30;
            this.btnCancel.Location = new System.Drawing.Point(281, 191);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.Radius = 16;
            this.btnCancel.RightBottom = 30;
            this.btnCancel.RightTop = 30;
            this.btnCancel.Size = new System.Drawing.Size(104, 33);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSure
            // 
            this.btnSure.BackColor = System.Drawing.Color.Transparent;
            this.btnSure.FlatAppearance.BorderSize = 0;
            this.btnSure.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSure.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSure.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSure.ForeColor = System.Drawing.Color.White;
            this.btnSure.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnSure.LeftBottom = 30;
            this.btnSure.LeftTop = 30;
            this.btnSure.Location = new System.Drawing.Point(137, 191);
            this.btnSure.Name = "btnSure";
            this.btnSure.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.btnSure.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSure.Radius = 16;
            this.btnSure.RightBottom = 30;
            this.btnSure.RightTop = 30;
            this.btnSure.Size = new System.Drawing.Size(104, 33);
            this.btnSure.TabIndex = 29;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = false;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // txtStetRemark
            // 
            this.txtStetRemark.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.txtStetRemark.BackColor = System.Drawing.Color.White;
            this.txtStetRemark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtStetRemark.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStetRemark.ForeColor = System.Drawing.Color.Black;
            this.txtStetRemark.Location = new System.Drawing.Point(245, 238);
            this.txtStetRemark.Multiline = true;
            this.txtStetRemark.Name = "txtStetRemark";
            this.txtStetRemark.PasswordChar = '\0';
            this.txtStetRemark.Radius = 24;
            this.txtStetRemark.ReadOnly = false;
            this.txtStetRemark.Size = new System.Drawing.Size(88, 25);
            this.txtStetRemark.TabIndex = 28;
            this.txtStetRemark.WaterText = "听诊器备注";
            // 
            // label11
            // 
            this.label11.Image = global::BDAuscultation.Properties.Resources.听诊器备注;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Location = new System.Drawing.Point(116, 238);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 25);
            this.label11.TabIndex = 27;
            this.label11.Text = "听诊器备注：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStetFunc
            // 
            this.txtStetFunc.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.txtStetFunc.BackColor = System.Drawing.Color.White;
            this.txtStetFunc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtStetFunc.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStetFunc.ForeColor = System.Drawing.Color.Black;
            this.txtStetFunc.Location = new System.Drawing.Point(339, 238);
            this.txtStetFunc.Multiline = false;
            this.txtStetFunc.Name = "txtStetFunc";
            this.txtStetFunc.PasswordChar = '\0';
            this.txtStetFunc.Radius = 24;
            this.txtStetFunc.ReadOnly = false;
            this.txtStetFunc.Size = new System.Drawing.Size(86, 24);
            this.txtStetFunc.TabIndex = 26;
            this.txtStetFunc.WaterText = "听诊器描述";
            // 
            // label10
            // 
            this.label10.Image = global::BDAuscultation.Properties.Resources.听诊器描述;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(8, 237);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 25);
            this.label10.TabIndex = 25;
            this.label10.Text = "听诊器描述：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStetOwner
            // 
            this.txtStetOwner.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.txtStetOwner.BackColor = System.Drawing.Color.White;
            this.txtStetOwner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtStetOwner.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStetOwner.ForeColor = System.Drawing.Color.Black;
            this.txtStetOwner.Location = new System.Drawing.Point(139, 144);
            this.txtStetOwner.Multiline = false;
            this.txtStetOwner.Name = "txtStetOwner";
            this.txtStetOwner.PasswordChar = '\0';
            this.txtStetOwner.Radius = 24;
            this.txtStetOwner.ReadOnly = false;
            this.txtStetOwner.Size = new System.Drawing.Size(246, 24);
            this.txtStetOwner.TabIndex = 24;
            this.txtStetOwner.WaterText = "所属人";
            // 
            // label9
            // 
            this.label9.Image = global::BDAuscultation.Properties.Resources.听诊器所属人;
            this.label9.Location = new System.Drawing.Point(2, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 25);
            this.label9.TabIndex = 23;
            this.label9.Text = "所属人：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Image = global::BDAuscultation.Properties.Resources.听诊器名字;
            this.label8.Location = new System.Drawing.Point(24, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 25);
            this.label8.TabIndex = 22;
            this.label8.Text = "科室：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStetChineseName
            // 
            this.txtStetChineseName.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.txtStetChineseName.BackColor = System.Drawing.Color.White;
            this.txtStetChineseName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtStetChineseName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStetChineseName.ForeColor = System.Drawing.Color.Black;
            this.txtStetChineseName.Location = new System.Drawing.Point(139, 106);
            this.txtStetChineseName.Multiline = false;
            this.txtStetChineseName.Name = "txtStetChineseName";
            this.txtStetChineseName.PasswordChar = '\0';
            this.txtStetChineseName.Radius = 24;
            this.txtStetChineseName.ReadOnly = false;
            this.txtStetChineseName.Size = new System.Drawing.Size(246, 24);
            this.txtStetChineseName.TabIndex = 21;
            this.txtStetChineseName.WaterText = "医院/科室";
            // 
            // label7
            // 
            this.label7.Image = global::BDAuscultation.Properties.Resources.听诊器序列号;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(26, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "听诊器编号：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Image = global::BDAuscultation.Properties.Resources.听诊器用途;
            this.label6.Location = new System.Drawing.Point(25, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 25);
            this.label6.TabIndex = 19;
            this.label6.Text = "用途：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioButtonEx2
            // 
            this.radioButtonEx2.AutoSize = true;
            this.radioButtonEx2.Location = new System.Drawing.Point(209, 67);
            this.radioButtonEx2.Name = "radioButtonEx2";
            this.radioButtonEx2.Size = new System.Drawing.Size(50, 21);
            this.radioButtonEx2.TabIndex = 16;
            this.radioButtonEx2.Text = "儿科";
            this.radioButtonEx2.UseVisualStyleBackColor = true;
            // 
            // radioButtonEx1
            // 
            this.radioButtonEx1.AutoSize = true;
            this.radioButtonEx1.Checked = true;
            this.radioButtonEx1.Location = new System.Drawing.Point(142, 67);
            this.radioButtonEx1.Name = "radioButtonEx1";
            this.radioButtonEx1.Size = new System.Drawing.Size(50, 21);
            this.radioButtonEx1.TabIndex = 15;
            this.radioButtonEx1.TabStop = true;
            this.radioButtonEx1.Text = "成人";
            this.radioButtonEx1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = " ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = " ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = " ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = " ";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::BDAuscultation.Properties.Resources.系统按钮关闭;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(230)))));
            this.btnClose.LeftBottom = 0;
            this.btnClose.LeftTop = 0;
            this.btnClose.Location = new System.Drawing.Point(424, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(135)))), ((int)(((byte)(251)))));
            this.btnClose.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(105)))), ((int)(((byte)(251)))));
            this.btnClose.Radius = 16;
            this.btnClose.RightBottom = 0;
            this.btnClose.RightTop = 0;
            this.btnClose.Size = new System.Drawing.Size(12, 12);
            this.btnClose.TabIndex = 41;
            this.toolTip1.SetToolTip(this.btnClose, "关闭");
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmStetInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 314);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.buttonEx1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStetInfo";
            this.Text = "听诊器配置";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private RadioButtonEx radioButtonEx1;
        private RadioButtonEx radioButtonEx2;
        private ButtonEx buttonEx1;
        private Label label7;
        private Label label6;
        private UCTextBoxEx txtStetChineseName;
        private UCTextBoxEx txtStetFunc;
        private Label label10;
        private UCTextBoxEx txtStetOwner;
        private Label label9;
        private Label label8;
        private UCTextBoxEx txtStetRemark;
        private Label label11;
        private ButtonEx btnCancel;
        private ButtonEx btnSure;
        private UCTextBoxEx txtStetName;
        private ButtonEx btnClose;
        private ToolTip toolTip1;
    }
}