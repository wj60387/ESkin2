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
    public partial class FrmMain2 : FormEx
    {
        public FrmMain2()
        {
            InitializeComponent();
            tabControlEx1.ListImage.Add(EApp.Properties.Resources.听诊配置);
            tabControlEx1.ListImage.Add(EApp.Properties.Resources.听诊教学);
            tabControlEx1.ListImage.Add(EApp.Properties.Resources.听诊录音);
            tabControlEx1.ListImage.Add(EApp.Properties.Resources.云端听诊);
            tabControlEx1.ListImage.Add(EApp.Properties.Resources.远程教学);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmLogin2 login = new FrmLogin2();
            login.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         
    }
}
