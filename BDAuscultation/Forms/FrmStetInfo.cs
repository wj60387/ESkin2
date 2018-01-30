using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BDAuscultation.Forms
{
    public partial class FrmStetInfo : Form
    {
        public FrmStetInfo()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmStetInfo_Load);
        }
        private bool isMouseDown = false;
        private Point FormLocation;     //form的location
        private Point mouseOffset;      //鼠标的按下位置
        protected override void OnMouseDown(MouseEventArgs e)
        {
            var point = PointToScreen(MousePosition);
            this.MaximumSize = Screen.FromPoint(point).WorkingArea.Size;
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = this.Location;
                mouseOffset = Control.MousePosition;
            }

        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            int _x = 0;
            int _y = 0;
            if (isMouseDown)
            {
                Point pt = Control.MousePosition;
                _x = mouseOffset.X - pt.X;
                _y = mouseOffset.Y - pt.Y;

                this.Location = new Point(FormLocation.X - _x, FormLocation.Y - _y);
            }

        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }


        }
        void FrmStetInfo_Load(object sender, EventArgs e)
        {
        }
        public string StetName
        {
            get
            {
                return txtStetName.Text;
            }
            set
            {
                txtStetName.Text = value;
            }
        }
        public int StetType
        {
            get
            {
                return radioButtonEx2.Checked ? 2 : 1;
            }
            set
            {
                if (value == 1)
                {
                    radioButtonEx2.Checked = false;
                    radioButtonEx1.Checked = true;
                }
                else
                {
                    radioButtonEx1.Checked = false;
                    radioButtonEx2.Checked = true;
                }
            }
        }
        public string StetChineseName
        {
            get
            {
                return txtStetChineseName.Text;
            }
            set
            {
                txtStetChineseName.Text = value;
            }
        }
        public string StetOwner
        {
            get
            {
                return txtStetOwner.Text;
            }
            set
            {
                txtStetOwner.Text = value;
            }
        }
        public string StetFuncDescript
        {
            get
            {
                return txtStetFunc.Text;
            }
            set
            {
                txtStetFunc.Text = value;
            }
        }
        public string StetRemark
        {
            get
            {
                return txtStetRemark.Text;
            }
            set
            {
                txtStetRemark.Text = value;
            }
        }
        private void btnSure_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStetChineseName.Text))
            {
                MessageBox.Show("请为听诊器取一个名字");
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void txtStetRemark_TextChanged(object sender, EventArgs e)
        {

        }

         

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
