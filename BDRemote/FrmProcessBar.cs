using System;
using System.Collections.Generic;
using System.ComponentModel;
 
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProtocalData.Utilities;
using ProtocalData.Protocol;
using System.IO;
using ProtocalData.Protocol.Derive;

namespace BDRemote.Forms
{
    public delegate void TimerCallBack();
    public partial class FrmProcessBar : Form
    {
        public FrmProcessBar(bool IsStartTimer = true, string Title = "")
        {
            IsAutoClose = false;
            InitializeComponent();
            lblMessage.Text = Title;
            if (IsStartTimer)
            {
                timer1.Interval = 1000;
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Start();
            }
            this.FormClosing += new FormClosingEventHandler(FormProcessBar_FormClosing);
        }

        void FormProcessBar_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }
        public event TimerCallBack TimerCallBackEvent;
        #region pbProgress
        public ProgressBarStyle ProgressBarStyle
        {
            get { return this.pbProgress.Style; }
            set { this.pbProgress.Style = value; }
        }
        public int ProgressBarMaxValue
        {
            get { return this.pbProgress.Maximum; }
            set { this.pbProgress.Maximum = value; }
        }
        public int ProgressBarValue
        {
            get { return this.pbProgress.Value; }
            set { this.pbProgress.Value = value; }
        }
        #endregion
        public bool IsAutoClose { get; set; }
        public int  AutoCloseTime { get; set; }
        public bool IsStartTimer { get; set; }
        public bool TimerEnable
        {
            get
            {
                return timer1.Enabled;
            }
            set
            {
                timer1.Enabled = value;
            }
        }
        public bool CancelBtnVisible
        {
            get { return btnCancel.Visible; }
            set { btnCancel.Visible = value; }
        }
        public string Title
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }
        public string BtnText
        {
            get { return btnCancel.Text; }
            set { btnCancel.Text = value; }
        }

        private int times = 0;
        public int Times
        {
            get
            {
                return times  ;
            }
            set
            {
                times = value;
            }
        }
        void timer1_Tick(object sender, EventArgs e)
        {
             
            if (base.Disposing)
            {
                timer1.Stop();
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                return;
            }
            
            
            if (TimerCallBackEvent != null && !base.Disposing)
            {
                TimerCallBackEvent();
            }
            times++;
            if (IsAutoClose && AutoCloseTime < Times)
            {
                this.Close();
            }
        }
        public event Action OnActiveClose;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (OnActiveClose != null)
            {
                OnActiveClose();
            }
            timer1.Stop();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        public void Stop()
        {
            timer1.Stop();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

         
    }
}
