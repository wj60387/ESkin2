using System.Windows.Forms;
namespace BDAuscultation.Forms
{
    partial class FrmAuscultation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExit = new System.Windows.Forms.ButtonEx();
            this.ucTextBoxEx1 = new System.Windows.Forms.UCTextBoxEx();
            this.btnAuscultate = new System.Windows.Forms.ButtonEx();
            this.dgvRemote = new System.Windows.Forms.DataGridViewEx();
            this.StetChineseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StetOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StetStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isAccept = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.ButtonEx();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemote)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(230)))));
            this.btnExit.LeftBottom = 30;
            this.btnExit.LeftTop = 30;
            this.btnExit.Location = new System.Drawing.Point(328, 38);
            this.btnExit.Name = "btnExit";
            this.btnExit.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(135)))), ((int)(((byte)(251)))));
            this.btnExit.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(105)))), ((int)(((byte)(251)))));
            this.btnExit.Radius = 16;
            this.btnExit.RightBottom = 30;
            this.btnExit.RightTop = 30;
            this.btnExit.Size = new System.Drawing.Size(86, 30);
            this.btnExit.TabIndex = 14;
            this.btnExit.Tag = "start";
            this.btnExit.Text = "退出会诊";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ucTextBoxEx1
            // 
            this.ucTextBoxEx1.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.ucTextBoxEx1.BackColor = System.Drawing.SystemColors.Control;
            this.ucTextBoxEx1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ucTextBoxEx1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucTextBoxEx1.Location = new System.Drawing.Point(112, 38);
            this.ucTextBoxEx1.Multiline = false;
            this.ucTextBoxEx1.Name = "ucTextBoxEx1";
            this.ucTextBoxEx1.PasswordChar = '\0';
            this.ucTextBoxEx1.Radius = 16;
            this.ucTextBoxEx1.ReadOnly = true;
            this.ucTextBoxEx1.Size = new System.Drawing.Size(210, 24);
            this.ucTextBoxEx1.TabIndex = 18;
            this.ucTextBoxEx1.WaterText = "水印文字";
            // 
            // btnAuscultate
            // 
            this.btnAuscultate.BackColor = System.Drawing.Color.Transparent;
            this.btnAuscultate.FlatAppearance.BorderSize = 0;
            this.btnAuscultate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuscultate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAuscultate.ForeColor = System.Drawing.Color.White;
            this.btnAuscultate.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(230)))));
            this.btnAuscultate.LeftBottom = 30;
            this.btnAuscultate.LeftTop = 30;
            this.btnAuscultate.Location = new System.Drawing.Point(328, 38);
            this.btnAuscultate.Name = "btnAuscultate";
            this.btnAuscultate.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(135)))), ((int)(((byte)(251)))));
            this.btnAuscultate.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(105)))), ((int)(((byte)(251)))));
            this.btnAuscultate.Radius = 16;
            this.btnAuscultate.RightBottom = 30;
            this.btnAuscultate.RightTop = 30;
            this.btnAuscultate.Size = new System.Drawing.Size(86, 30);
            this.btnAuscultate.TabIndex = 16;
            this.btnAuscultate.Text = "进入会诊";
            this.btnAuscultate.UseVisualStyleBackColor = false;
            this.btnAuscultate.Click += new System.EventHandler(this.btnAuscultate_Click);
            // 
            // dgvRemote
            // 
            this.dgvRemote.AllowUserToAddRows = false;
            this.dgvRemote.AllowUserToDeleteRows = false;
            this.dgvRemote.AllowUserToResizeRows = false;
            this.dgvRemote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRemote.BackgroundColor = System.Drawing.Color.White;
            this.dgvRemote.BoderPad = 4;
            this.dgvRemote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRemote.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvRemote.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRemote.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRemote.ColumnHeadersHeight = 40;
            this.dgvRemote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRemote.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StetChineseName,
            this.StetName,
            this.PCName,
            this.MAC,
            this.StetOwner,
            this.StetStatus,
            this.isAccept});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRemote.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRemote.EnableHeadersVisualStyles = false;
            this.dgvRemote.IndexSize = 24;
            this.dgvRemote.Location = new System.Drawing.Point(9, 74);
            this.dgvRemote.MultiSelect = false;
            this.dgvRemote.Name = "dgvRemote";
            this.dgvRemote.ReadOnly = true;
            this.dgvRemote.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(41);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRemote.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRemote.RowHeadersWidth = 70;
            this.dgvRemote.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRemote.RowTemplate.Height = 32;
            this.dgvRemote.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRemote.Size = new System.Drawing.Size(884, 383);
            this.dgvRemote.TabIndex = 8;
            // 
            // StetChineseName
            // 
            this.StetChineseName.HeaderText = "医院/科室";
            this.StetChineseName.Name = "StetChineseName";
            this.StetChineseName.ReadOnly = true;
            this.StetChineseName.Width = 125;
            // 
            // StetName
            // 
            this.StetName.HeaderText = "听诊器序号";
            this.StetName.Name = "StetName";
            this.StetName.ReadOnly = true;
            this.StetName.Width = 220;
            // 
            // PCName
            // 
            this.PCName.HeaderText = "计算机名";
            this.PCName.Name = "PCName";
            this.PCName.ReadOnly = true;
            this.PCName.Width = 125;
            // 
            // MAC
            // 
            this.MAC.HeaderText = "MAC";
            this.MAC.Name = "MAC";
            this.MAC.ReadOnly = true;
            this.MAC.Width = 125;
            // 
            // StetOwner
            // 
            this.StetOwner.HeaderText = "所属人";
            this.StetOwner.Name = "StetOwner";
            this.StetOwner.ReadOnly = true;
            this.StetOwner.Width = 125;
            // 
            // StetStatus
            // 
            this.StetStatus.HeaderText = "连接状态";
            this.StetStatus.Name = "StetStatus";
            this.StetStatus.ReadOnly = true;
            this.StetStatus.Width = 125;
            // 
            // isAccept
            // 
            this.isAccept.HeaderText = "checked";
            this.isAccept.Name = "isAccept";
            this.isAccept.ReadOnly = true;
            this.isAccept.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "远程教学室";
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
            this.btnClose.Location = new System.Drawing.Point(887, 7);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 42;
            this.label2.Text = "源听诊器：";
            // 
            // FrmAuscultation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 484);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucTextBoxEx1);
            this.Controls.Add(this.dgvRemote);
            this.Controls.Add(this.btnAuscultate);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAuscultation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "远程教学室";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAuscultation_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ButtonEx btnExit;
        private ButtonEx btnAuscultate;
        private DataGridViewEx dgvRemote;
        private System.Windows.Forms.UCTextBoxEx ucTextBoxEx1;
        private Label label1;
        private ButtonEx btnClose;
        private ToolTip toolTip1;
        private DataGridViewTextBoxColumn StetChineseName;
        private DataGridViewTextBoxColumn StetName;
        private DataGridViewTextBoxColumn PCName;
        private DataGridViewTextBoxColumn MAC;
        private DataGridViewTextBoxColumn StetOwner;
        private DataGridViewTextBoxColumn StetStatus;
        private DataGridViewCheckBoxColumn isAccept;
        private Label label2;
    }
}