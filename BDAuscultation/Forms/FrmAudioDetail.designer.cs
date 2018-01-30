using System.Windows.Forms;
namespace BDAuscultation.Forms
{
    partial class FrmAudioDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAudioDetail));
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDocRemark = new System.Windows.Forms.UCTextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDocDiagnose = new System.Windows.Forms.UCTextBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDocName = new System.Windows.Forms.UCTextBoxEx();
            this.panelImages = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButtonEx2 = new System.Windows.Forms.RadioButtonEx();
            this.radioButtonEx1 = new System.Windows.Forms.RadioButtonEx();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.UCTextBoxEx();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewEx1 = new System.Windows.Forms.DataGridViewEx();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 425);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "诊断版本：";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtDocRemark);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtDocDiagnose);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtDocName);
            this.panel2.Controls.Add(this.panelImages);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.radioButtonEx2);
            this.panel2.Controls.Add(this.radioButtonEx1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtPatientName);
            this.panel2.Controls.Add(this.numAge);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 369);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(873, 173);
            this.panel2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Image = global::BDAuscultation.Properties.Resources.附件;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(557, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 25);
            this.label6.TabIndex = 64;
            this.label6.Text = "检查报告：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDocRemark
            // 
            this.txtDocRemark.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.txtDocRemark.BackColor = System.Drawing.Color.White;
            this.txtDocRemark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtDocRemark.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDocRemark.ForeColor = System.Drawing.Color.Black;
            this.txtDocRemark.Location = new System.Drawing.Point(96, 112);
            this.txtDocRemark.Multiline = true;
            this.txtDocRemark.Name = "txtDocRemark";
            this.txtDocRemark.PasswordChar = '\0';
            this.txtDocRemark.Radius = 24;
            this.txtDocRemark.ReadOnly = true;
            this.txtDocRemark.Size = new System.Drawing.Size(448, 50);
            this.txtDocRemark.TabIndex = 63;
            this.txtDocRemark.WaterText = "备注";
            // 
            // label3
            // 
            this.label3.Image = global::BDAuscultation.Properties.Resources.备注;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(18, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 25);
            this.label3.TabIndex = 62;
            this.label3.Text = "备注:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDocDiagnose
            // 
            this.txtDocDiagnose.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.txtDocDiagnose.BackColor = System.Drawing.Color.White;
            this.txtDocDiagnose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtDocDiagnose.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDocDiagnose.ForeColor = System.Drawing.Color.Black;
            this.txtDocDiagnose.Location = new System.Drawing.Point(372, 73);
            this.txtDocDiagnose.Multiline = false;
            this.txtDocDiagnose.Name = "txtDocDiagnose";
            this.txtDocDiagnose.PasswordChar = '\0';
            this.txtDocDiagnose.Radius = 24;
            this.txtDocDiagnose.ReadOnly = true;
            this.txtDocDiagnose.Size = new System.Drawing.Size(179, 24);
            this.txtDocDiagnose.TabIndex = 61;
            this.txtDocDiagnose.WaterText = "初步诊断";
            // 
            // label2
            // 
            this.label2.Image = global::BDAuscultation.Properties.Resources.初步诊断;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(292, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 25);
            this.label2.TabIndex = 60;
            this.label2.Text = "初步诊断：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Image = global::BDAuscultation.Properties.Resources.患者姓名;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(7, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 25);
            this.label8.TabIndex = 59;
            this.label8.Text = "医生姓名：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDocName
            // 
            this.txtDocName.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.txtDocName.BackColor = System.Drawing.Color.White;
            this.txtDocName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtDocName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDocName.ForeColor = System.Drawing.Color.Black;
            this.txtDocName.Location = new System.Drawing.Point(96, 73);
            this.txtDocName.Multiline = false;
            this.txtDocName.Name = "txtDocName";
            this.txtDocName.PasswordChar = '\0';
            this.txtDocName.Radius = 24;
            this.txtDocName.ReadOnly = true;
            this.txtDocName.Size = new System.Drawing.Size(179, 24);
            this.txtDocName.TabIndex = 58;
            this.txtDocName.WaterText = "医生姓名";
            // 
            // panelImages
            // 
            this.panelImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelImages.Location = new System.Drawing.Point(650, 80);
            this.panelImages.Name = "panelImages";
            this.panelImages.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelImages.Size = new System.Drawing.Size(216, 32);
            this.panelImages.TabIndex = 57;
            // 
            // label7
            // 
            this.label7.Image = global::BDAuscultation.Properties.Resources.年龄;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(557, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 25);
            this.label7.TabIndex = 56;
            this.label7.Text = "患者年龄：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Image = global::BDAuscultation.Properties.Resources.性别;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(292, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 25);
            this.label5.TabIndex = 55;
            this.label5.Text = "患者性别：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioButtonEx2
            // 
            this.radioButtonEx2.AutoSize = true;
            this.radioButtonEx2.Enabled = false;
            this.radioButtonEx2.Location = new System.Drawing.Point(451, 24);
            this.radioButtonEx2.Name = "radioButtonEx2";
            this.radioButtonEx2.Size = new System.Drawing.Size(38, 21);
            this.radioButtonEx2.TabIndex = 54;
            this.radioButtonEx2.Text = "女";
            this.radioButtonEx2.UseVisualStyleBackColor = true;
            // 
            // radioButtonEx1
            // 
            this.radioButtonEx1.AutoSize = true;
            this.radioButtonEx1.Checked = true;
            this.radioButtonEx1.Enabled = false;
            this.radioButtonEx1.Location = new System.Drawing.Point(393, 24);
            this.radioButtonEx1.Name = "radioButtonEx1";
            this.radioButtonEx1.Size = new System.Drawing.Size(38, 21);
            this.radioButtonEx1.TabIndex = 53;
            this.radioButtonEx1.TabStop = true;
            this.radioButtonEx1.Text = "男";
            this.radioButtonEx1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Image = global::BDAuscultation.Properties.Resources.患者姓名;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 25);
            this.label1.TabIndex = 52;
            this.label1.Text = "患者姓名：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPatientName
            // 
            this.txtPatientName.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.txtPatientName.BackColor = System.Drawing.Color.White;
            this.txtPatientName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtPatientName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPatientName.ForeColor = System.Drawing.Color.Black;
            this.txtPatientName.Location = new System.Drawing.Point(96, 22);
            this.txtPatientName.Multiline = false;
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.PasswordChar = '\0';
            this.txtPatientName.Radius = 24;
            this.txtPatientName.ReadOnly = true;
            this.txtPatientName.Size = new System.Drawing.Size(179, 24);
            this.txtPatientName.TabIndex = 51;
            this.txtPatientName.WaterText = "患者姓名";
            // 
            // numAge
            // 
            this.numAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numAge.Enabled = false;
            this.numAge.Location = new System.Drawing.Point(650, 24);
            this.numAge.Name = "numAge";
            this.numAge.ReadOnly = true;
            this.numAge.Size = new System.Drawing.Size(53, 23);
            this.numAge.TabIndex = 50;
            this.numAge.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // dataGridViewEx1
            // 
            this.dataGridViewEx1.AllowUserToAddRows = false;
            this.dataGridViewEx1.AllowUserToDeleteRows = false;
            this.dataGridViewEx1.AllowUserToResizeRows = false;
            this.dataGridViewEx1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEx1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewEx1.BoderPad = 1;
            this.dataGridViewEx1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewEx1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewEx1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEx1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewEx1.ColumnHeadersHeight = 40;
            this.dataGridViewEx1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEx1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.EnableHeadersVisualStyles = false;
            this.dataGridViewEx1.IndexSize = 24;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(41);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEx1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewEx1.RowHeadersWidth = 70;
            this.dataGridViewEx1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewEx1.RowTemplate.Height = 32;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(873, 369);
            this.dataGridViewEx1.TabIndex = 40;
            // 
            // FrmAudioDetail
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 542);
            this.Controls.Add(this.dataGridViewEx1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAudioDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "听诊录音详情";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label4;
        private Panel panel2;
        private DataGridViewEx dataGridViewEx1;
        private Label label7;
        private Label label5;
        private RadioButtonEx radioButtonEx2;
        private RadioButtonEx radioButtonEx1;
        private Label label1;
        private UCTextBoxEx txtPatientName;
        private NumericUpDown numAge;
        private Label label6;
        private UCTextBoxEx txtDocRemark;
        private Label label3;
        private UCTextBoxEx txtDocDiagnose;
        private Label label2;
        private Label label8;
        private UCTextBoxEx txtDocName;
        private Panel panelImages;

    }
}