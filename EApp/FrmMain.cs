using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EApp
{
    public partial class FrmMain : FormEx
    {
        public FrmMain()
        {
            InitializeComponent();
            //this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            this.Load += FrmMain_Load;
        }

        void FrmMain_Load(object sender, EventArgs e)
        {

            this.nav1.NavItemList.Add(new NavItem(null, "LOGO")  );
            this.nav1.NavItemList.Add(new NavItem(EApp.Properties.Resources.听诊配置, "听诊配置"));
            this.nav1.NavItemList.Add(new NavItem(EApp.Properties.Resources.听诊教学, "听诊教学"));
            this.nav1.NavItemList.Add(new NavItem(EApp.Properties.Resources.听诊录音, "听诊录音"));
            this.nav1.NavItemList.Add(new NavItem(EApp.Properties.Resources.云端听诊, "云端听诊"));
            this.nav1.NavItemList.Add(new NavItem(EApp.Properties.Resources.远程教学, "远程教学"));
            nav1.OnItemClick += nav1_OnItemClick;
            nav1.OnXTClick += nav1_OnXTClick;
            nav1.OnGYClick += nav1_OnGYClick;

            var column = new DataGridViewCheckBoxExColumn() { Text="选择"};
            this.dataGridViewEx1.Columns.Add(column);

            for (int i = 0; i < 5; i++)
            {
                this.dataGridViewEx1.Rows.Add("DRF","DRF","DRF",i%2==0);
            }
        }

        void nav1_OnXTClick()
        {
            MessageBox.Show("系统");
        }
        void nav1_OnGYClick()
        {
            MessageBox.Show("关于");
        }
        void nav1_OnItemClick(NavItem obj)
        {
            MessageBox.Show(obj.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
