using System.Windows.Forms;
namespace BDAuscultation.Forms
{
    partial class FrmAudioRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAudioRecord));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDocRemark = new System.Windows.Forms.UCTextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDocDiagnose = new System.Windows.Forms.UCTextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDocName = new System.Windows.Forms.UCTextBoxEx();
            this.radioButtonEx2 = new System.Windows.Forms.RadioButtonEx();
            this.radioButtonEx1 = new System.Windows.Forms.RadioButtonEx();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.UCTextBoxEx();
            this.panelImages = new System.Windows.Forms.Panel();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.btnUpLoad = new System.Windows.Forms.ButtonEx();
            this.btnSave = new System.Windows.Forms.ButtonEx();
            this.btnEdit = new System.Windows.Forms.ButtonEx();
            this.dataGridViewEx1 = new System.Windows.Forms.DataGridViewEx();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtDocRemark);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtDocDiagnose);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtDocName);
            this.panel2.Controls.Add(this.radioButtonEx2);
            this.panel2.Controls.Add(this.radioButtonEx1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtPatientName);
            this.panel2.Controls.Add(this.panelImages);
            this.panel2.Controls.Add(this.numAge);
            this.panel2.Controls.Add(this.btnUpLoad);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 370);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(886, 160);
            this.panel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Image = global::BDAuscultation.Properties.Resources.附件;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(556, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 25);
            this.label6.TabIndex = 50;
            this.label6.Text = "检查报告：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Image = global::BDAuscultation.Properties.Resources.年龄;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(556, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 25);
            this.label7.TabIndex = 49;
            this.label7.Text = "患者年龄：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDocRemark
            // 
            this.txtDocRemark.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.txtDocRemark.BackColor = System.Drawing.Color.White;
            this.txtDocRemark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtDocRemark.BorderColor = System.Drawing.Color.Black;
            this.txtDocRemark.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDocRemark.ForeColor = System.Drawing.Color.Black;
            this.txtDocRemark.Location = new System.Drawing.Point(95, 95);
            this.txtDocRemark.Multiline = true;
            this.txtDocRemark.Name = "txtDocRemark";
            this.txtDocRemark.PasswordChar = '\0';
            this.txtDocRemark.Radius = 24;
            this.txtDocRemark.ReadOnly = false;
            this.txtDocRemark.Size = new System.Drawing.Size(448, 50);
            this.txtDocRemark.TabIndex = 48;
            this.txtDocRemark.WaterText = "备注";
            // 
            // label3
            // 
            this.label3.Image = global::BDAuscultation.Properties.Resources.备注;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 25);
            this.label3.TabIndex = 47;
            this.label3.Text = "备注";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Image = global::BDAuscultation.Properties.Resources.性别;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(282, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 25);
            this.label5.TabIndex = 46;
            this.label5.Text = "患者性别：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDocDiagnose
            // 
            this.txtDocDiagnose.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.txtDocDiagnose.BackColor = System.Drawing.Color.White;
            this.txtDocDiagnose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtDocDiagnose.BorderColor = System.Drawing.Color.Black;
            this.txtDocDiagnose.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDocDiagnose.ForeColor = System.Drawing.Color.Black;
            this.txtDocDiagnose.Location = new System.Drawing.Point(364, 56);
            this.txtDocDiagnose.Multiline = false;
            this.txtDocDiagnose.Name = "txtDocDiagnose";
            this.txtDocDiagnose.PasswordChar = '\0';
            this.txtDocDiagnose.Radius = 24;
            this.txtDocDiagnose.ReadOnly = false;
            this.txtDocDiagnose.Size = new System.Drawing.Size(179, 24);
            this.txtDocDiagnose.TabIndex = 45;
            this.txtDocDiagnose.WaterText = "初步诊断";
            // 
            // label1
            // 
            this.label1.Image = global::BDAuscultation.Properties.Resources.初步诊断;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(284, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 25);
            this.label1.TabIndex = 44;
            this.label1.Text = "初步诊断：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Image = global::BDAuscultation.Properties.Resources.患者姓名;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "医生姓名：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDocName
            // 
            this.txtDocName.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.txtDocName.BackColor = System.Drawing.Color.White;
            this.txtDocName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtDocName.BorderColor = System.Drawing.Color.Black;
            this.txtDocName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDocName.ForeColor = System.Drawing.Color.Black;
            this.txtDocName.Location = new System.Drawing.Point(95, 56);
            this.txtDocName.Multiline = false;
            this.txtDocName.Name = "txtDocName";
            this.txtDocName.PasswordChar = '\0';
            this.txtDocName.Radius = 24;
            this.txtDocName.ReadOnly = false;
            this.txtDocName.Size = new System.Drawing.Size(179, 24);
            this.txtDocName.TabIndex = 42;
            this.txtDocName.WaterText = "医生姓名";
            // 
            // radioButtonEx2
            // 
            this.radioButtonEx2.AutoSize = true;
            this.radioButtonEx2.Location = new System.Drawing.Point(433, 18);
            this.radioButtonEx2.Name = "radioButtonEx2";
            this.radioButtonEx2.Size = new System.Drawing.Size(38, 21);
            this.radioButtonEx2.TabIndex = 41;
            this.radioButtonEx2.Text = "女";
            this.radioButtonEx2.UseVisualStyleBackColor = true;
            // 
            // radioButtonEx1
            // 
            this.radioButtonEx1.AutoSize = true;
            this.radioButtonEx1.Checked = true;
            this.radioButtonEx1.Location = new System.Drawing.Point(375, 18);
            this.radioButtonEx1.Name = "radioButtonEx1";
            this.radioButtonEx1.Size = new System.Drawing.Size(38, 21);
            this.radioButtonEx1.TabIndex = 40;
            this.radioButtonEx1.TabStop = true;
            this.radioButtonEx1.Text = "男";
            this.radioButtonEx1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Image = global::BDAuscultation.Properties.Resources.患者姓名;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(6, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 25);
            this.label4.TabIndex = 39;
            this.label4.Text = "患者姓名：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPatientName
            // 
            this.txtPatientName.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.txtPatientName.BackColor = System.Drawing.Color.White;
            this.txtPatientName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtPatientName.BorderColor = System.Drawing.Color.Black;
            this.txtPatientName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPatientName.ForeColor = System.Drawing.Color.Black;
            this.txtPatientName.Location = new System.Drawing.Point(95, 15);
            this.txtPatientName.Multiline = false;
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.PasswordChar = '\0';
            this.txtPatientName.Radius = 24;
            this.txtPatientName.ReadOnly = false;
            this.txtPatientName.Size = new System.Drawing.Size(179, 24);
            this.txtPatientName.TabIndex = 38;
            this.txtPatientName.WaterText = "患者姓名";
            // 
            // panelImages
            // 
            this.panelImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelImages.Location = new System.Drawing.Point(649, 63);
            this.panelImages.Name = "panelImages";
            this.panelImages.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelImages.Size = new System.Drawing.Size(227, 32);
            this.panelImages.TabIndex = 37;
            // 
            // numAge
            // 
            this.numAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numAge.Location = new System.Drawing.Point(649, 16);
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(53, 23);
            this.numAge.TabIndex = 25;
            this.numAge.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // btnUpLoad
            // 
            this.btnUpLoad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUpLoad.BackColor = System.Drawing.Color.Transparent;
            this.btnUpLoad.FlatAppearance.BorderSize = 0;
            this.btnUpLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpLoad.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpLoad.ForeColor = System.Drawing.Color.White;
            this.btnUpLoad.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnUpLoad.LeftBottom = 0;
            this.btnUpLoad.LeftTop = 0;
            this.btnUpLoad.Location = new System.Drawing.Point(665, 115);
            this.btnUpLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpLoad.Name = "btnUpLoad";
            this.btnUpLoad.NormalColor = System.Drawing.Color.Fuchsia;
            this.btnUpLoad.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnUpLoad.Radius = 16;
            this.btnUpLoad.RightBottom = 0;
            this.btnUpLoad.RightTop = 0;
            this.btnUpLoad.Size = new System.Drawing.Size(60, 23);
            this.btnUpLoad.TabIndex = 14;
            this.btnUpLoad.Text = "保存";
            this.btnUpLoad.UseVisualStyleBackColor = false;
            this.btnUpLoad.Click += new System.EventHandler(this.btnUpLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSave.LeftBottom = 0;
            this.btnSave.LeftTop = 0;
            this.btnSave.Location = new System.Drawing.Point(798, 115);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.NormalColor = System.Drawing.Color.Lime;
            this.btnSave.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSave.Radius = 16;
            this.btnSave.RightBottom = 0;
            this.btnSave.RightTop = 0;
            this.btnSave.Size = new System.Drawing.Size(60, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(105)))), ((int)(((byte)(251)))));
            this.btnEdit.LeftBottom = 0;
            this.btnEdit.LeftTop = 0;
            this.btnEdit.Location = new System.Drawing.Point(566, 115);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(135)))), ((int)(((byte)(251)))));
            this.btnEdit.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(145)))), ((int)(((byte)(251)))));
            this.btnEdit.Radius = 16;
            this.btnEdit.RightBottom = 0;
            this.btnEdit.RightTop = 0;
            this.btnEdit.Size = new System.Drawing.Size(60, 23);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
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
            this.dataGridViewEx1.Size = new System.Drawing.Size(886, 370);
            this.dataGridViewEx1.TabIndex = 39;
            // 
            // FrmAudioRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 530);
            this.Controls.Add(this.dataGridViewEx1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAudioRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "听诊录音详情";
            this.Load += new System.EventHandler(this.FrmAudioRecord_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private  ButtonEx btnUpLoad;
        private  ButtonEx btnSave;
        private ButtonEx btnEdit;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.Panel panelImages;
        private DataGridViewEx dataGridViewEx1;
        private UCTextBoxEx txtPatientName;
        private Label label4;
        private RadioButtonEx radioButtonEx2;
        private RadioButtonEx radioButtonEx1;
        private Label label5;
        private UCTextBoxEx txtDocDiagnose;
        private Label label1;
        private Label label2;
        private UCTextBoxEx txtDocName;
        private UCTextBoxEx txtDocRemark;
        private Label label3;
        private Label label6;
        private Label label7;
    }
}