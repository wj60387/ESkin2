using BDAuscultation.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BDAuscultation
{
    public partial class FrmMain : FormEx
    {
        public FrmMain()
        {
            //this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);  
            InitializeComponent();

            this.SizeChanged += FrmMain_SizeChanged;


            this.Load += FrmMain_Load;
        }

        void Mediator_ShowMessageEvent(string Msg)
        {
            Invoke(new MethodInvoker(() =>
            {
                var info = ">" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n" + Msg + "\r\n";
                // var msg = ">" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n使用的激活码:"+Setting.authorizationInfo.AuthorizationNum+"\r\n" + Msg + "\r\n";

                txtMessage.AppendText(info);

                var dir = Path.Combine(Application.StartupPath, "Logs" + "\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                var filePath = Path.Combine(dir, DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
                File.AppendAllText(filePath, info, Encoding.UTF8);
            }));
        }
        void Init()
        {
            this.btnBgTZJX.Image = this.btnBgTZPZ.Image = this.btnBgTZLY.Image = this.btnBgYCTZ.Image
                = this.btnBgYDTZ.Image =
                MyResouces.GetImage(BDAuscultation.Properties.Resources.听诊器图片, 0.85f);

            Mediator.ShowMessageEvent += Mediator_ShowMessageEvent;
            if (Setting.isConnected)
            {
                InitSocket();
                LoadStetInfo();
                Thread thread = new Thread(LoadAudioFile);
                thread.Start("DevicesData\\AudioFiles");
            }

            InitdgvTZPZ();
            InitdgvTZJX();
            InitdgvTZLY();
            InitdgvYDTZ();
            InitdgvYCTZ();
            InitdgvXY();
            this.timer1.Tick += timer1_Tick;
            timer1.Start();
            this.FormClosing += FrmMain_FormClosing;


            //this.nav1.NavItemList.Add(new NavItem(null, "LOGO") { ISNomal = false });
            this.nav1.NavItemList.Add(
                new NavItem(MyResouces.ImageTZPZ, "听诊配置") { Height = 90 });
            this.nav1.NavItemList.Add(
                new NavItem(MyResouces.ImageTZJX, "听诊教学") { Height = 90 });
            this.nav1.NavItemList.Add(
                new NavItem(MyResouces.ImageTZLY, "听诊录音") { Height = 100 });
            this.nav1.NavItemList.Add(
                new NavItem(MyResouces.ImageYDTZ, "云端听诊") { Height = 80 });
            this.nav1.NavItemList.Add(
                new NavItem(MyResouces.ImageYCTZ, "远程听诊") { Height = 90 });
            this.nav1.NavItemList.Add(
                new NavItem(MyResouces.ImageXY, "心肺音库") { Height = 90 });
            this.nav1.NavItemList.Add(
                new NavItem(MyResouces.ImageMNCS, "模拟测试") { Height = 90 });
            nav1.OnItemClick += nav1_OnItemClick;
            nav1.OnXTClick += nav1_OnXTClick;
            nav1.OnGYClick += nav1_OnGYClick;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            Times++;
            // lblCurTime.Text = "当前时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        }

        void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }
        void FrmMain_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            Init();
            this.Visible = true;
            this.Location = new Point(0, 0);
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }
        void nav1_OnXTClick()
        {
            this.contextMenuStrip1.Show(nav1, new Point(0, nav1.SysBtnRect.Y + nav1.SysBtnRect.Height));
        }
        void nav1_OnGYClick()
        {
            var formAbout = new FrmAbout();
            formAbout.StartPosition = FormStartPosition.CenterScreen;
            formAbout.ShowDialog();
        }
        void nav1_OnItemClick(NavItem obj)
        {
            switch (obj.Text)
            {
                case "听诊配置":
                    this.tabControlYDTZ.SelectedTab = tabTZPZ;
                    //InitdgvTZPZ();
                    break;
                case "听诊教学":
                    this.tabControlYDTZ.SelectedTab = tabTZJX;
                    //InitdgvTZJX();
                    break;
                case "听诊录音":
                    this.tabControlYDTZ.SelectedTab = tabTZLY;
                    //InitdgvTZLY();
                    break;
                case "云端听诊":
                    this.tabControlYDTZ.SelectedTab = tabYDTZ;
                    //InitdgvYDTZ();
                    break;
                case "远程听诊":
                    this.tabControlYDTZ.SelectedTab = tabYCTZ;
                    //InitdgvYCTZ();
                    break;
                case "心肺音库":
                    this.load_cbBoxInit_XY();
                    this.tabControlYDTZ.SelectedTab = tabXY;
                    //InitdgvXY();
                    break;
                case "模拟测试":
                    //InitdgvXY();
                    this.tabControlYDTZ.SelectedTab = tabMNCS;
                    break;
            }
        }
        void Nav_MouseLeave(object sender, EventArgs e)
        {
            var btn = sender as ButtonEx;
            btn.BackColor = Color.Transparent;
        }

        void Nav_MouseEnter(object sender, EventArgs e)
        {
            var btn = sender as ButtonEx;
            btn.BackColor = Color.Red;
        }

        void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            if (tabControlYDTZ.SelectedTab != null)
            {
                tabControlYDTZ.SelectedTab.Invalidate();
            }
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

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void 操作日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLog(DateTime.Now);
            this.tabControlYDTZ.SelectedTab = tabOperLog;
        }
        void ShowLog(DateTime Date)
        {
            var dir = Path.Combine(Application.StartupPath, "Logs" + "\\" + Date.Year + "\\" + Date.Month);
            var filePath = Path.Combine(dir, Date.ToString("yyyy-MM-dd") + ".txt");
            if (File.Exists(filePath))
            {
                var text = File.ReadAllText(filePath, Encoding.UTF8);
                this.txtLog.Text = text;
            }
            else
            {
                MessageBox.Show("今日无操作");
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ShowLog(dateTimePicker1.Value);
        }

    }
}
