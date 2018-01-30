using BDAuscultation.Commucation;
using BDRemote.Forms;
using BDRemote.Properties;
using MMM.HealthCare.Scopes.Device;
using ProtocalData.Protocol;
using ProtocalData.Protocol.Derive;
using ProtocalData.Utilities;
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

namespace BDRemote
{

    //消息 Code
    //事件 就绪 开启音频 接收音频 关闭音频 

    public partial class FrmMain : Form
        , IHandleMessage<RYHDLCode>
        , IHandleMessage<RYHXXCode>
        , IHandleMessage<RMessageCode>
        , IHandleMessage<RReadyCode>
        , IHandleMessage<RStartAudioCode>
        , IHandleMessage<RTransAudioCode>
        , IHandleMessage<RStopAudioCode>
        , IHandleMessage<RExitCode>
    {
        /// <summary>
        /// 记录录音
        /// </summary>
        public MemoryStream memoryStream = new MemoryStream();

        public void HandleMessage(RMessageCode message)
        {
            ShowMsg(message.Msg);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {

        }
        System.Timers.Timer timer = new System.Timers.Timer(500);
        public void HandleMessage(RReadyCode message)
        {
            if (isOrder)//发起方
            {
                if(!message.isReady)
                {
                    ShowMsg("发起远程听诊失败(请确认对方已连接听诊器)");
                    Invoke(new MethodInvoker(() =>
                    {
                        btnPresss.Enabled = false;
                    }));
                
                }
                else
                {
                    
                    ShowMsg("对方设备就绪,可以发起听诊了");

                    //ShowMsg("远程听诊进行中");
                    Invoke(new MethodInvoker(() =>
                    {
                        btnPresss.Enabled = true;
                    }));
                }



            }
            else
            {
                if (isConnect())
                {
                    Thread thread = new Thread(() =>
                    {
                        //Thread.Sleep(200);
                        SuperSocket.Send(new RStartAudioCode());
                        Current.StartAudioInput();
                        timer.Start();
                        Invoke(new MethodInvoker(() =>
                        {
                            gifBox1.StartAnimate();
                            //processBarEx1.Visible = true;
                        }));
                        //Thread.Sleep(200);
                        while (!isStop)
                        {
                            byte[] packet = new byte[128];
                            int bytesRead = Current.AudioInputStream.Read(packet, 0, packet.Length);
                            if (bytesRead <= 0)
                            {
                                Thread.Sleep(100);
                                continue;
                            }
                            var code = new RTransAudioCode();
                            memoryStream.Write(packet, 0, bytesRead);
                            code.Bytes = packet.Take(bytesRead).ToArray();
                            SuperSocket.Send(code);
                            Thread.Sleep(1);
                        }
                        Current.StopAudioInput();
                    });
                    thread.Start();
                }
                else
                {
                    SuperSocket.Send(new RReadyCode() { isReady=false});
                }
            }
        }
        static Stethoscope Current { get; set; }
        public void HandleMessage(RStartAudioCode message)
        {
            ShowMsg(string.Format("远程听诊开始接收数据..."));
            Current.StartAudioOutput();
            timer.Start();
            this.Invoke(new MethodInvoker(() => {
                gifBox1.StartAnimate();
              //  processBarEx1.Visible = true;
            }));
           
        }
        public void HandleMessage(RTransAudioCode message)
        {
            //ThreadPool.QueueUserWorkItem((obj) =>
            //{
            Current.AudioOutputStream.Write(message.Bytes, 0, message.Bytes.Length);
            //});


        }
        public void HandleMessage(RStopAudioCode message)
        {
            isStop = true;
            this.Invoke(new MethodInvoker(() => {
                gifBox1.StopAnimate();
            }));
        }
        public void HandleMessage(RExitCode message)
        {
            
        }
        
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
             Application.Exit();
            
        }
        private bool isMouseDown = false;
        private Point FormLocation;     //form的location
        private Point mouseOffset;      //鼠标的按下位置
        public static string serverUrl = System.Configuration.ConfigurationManager.AppSettings["serverUrl"];
        public SupSocket SuperSocket = new SupSocket(serverUrl);
        bool isRequest = false;
        public FrmMain(string remoteID, bool isRequest)
        {
            base.SetStyle(
                    ControlStyles.UserPaint |                      // 控件将自行绘制，而不是通过操作系统来绘制
                    ControlStyles.OptimizedDoubleBuffer |          // 该控件首先在缓冲区中绘制，而不是直接绘制到屏幕上，这样可以减少闪烁
                    ControlStyles.AllPaintingInWmPaint |           // 控件将忽略 WM_ERASEBKGND 窗口消息以减少闪烁
                    ControlStyles.ResizeRedraw |                   // 在调整控件大小时重绘控件
                    ControlStyles.SupportsTransparentBackColor,    // 控件接受 alpha 组件小于 255 的 BackColor 以模拟透明
                    true);                                         // 设置以上值为 true
            base.UpdateStyles();
            InitializeComponent();
            this.Load += FrmMain_Load;
            this.LocationChanged += FrmMain_LocationChanged;
            SuperSocket.MessageReceived += SuperSocket_MessageReceived;
            SuperSocket.DataReceived += SuperSocket_DataReceived;
            SuperSocket.Closed += SuperSocket_Closed;
            SuperSocket.Opened += SuperSocket_Opened;

            SuperSocket.OpenSocket(remoteID);
            this.isRequest = isRequest;
            foreach (var item in StethoscopeManager.StethoscopeList)
            {
                stetList.Items.Add(item.Name);
            }
            if(stetList.Items.Count>0)
            stetList.SelectedIndex = 0;
            if (isRequest)
                btnPresss.Enabled = false;
            else
               btnPresss.Visible = false;
            gifBox1.StopAnimate();
            label1.Text = "";
        }

        void SuperSocket_Opened(object sender, EventArgs e)
        {
            ShowMsg("服务器连接成功...", false);
        }

        void SuperSocket_Closed(object sender, EventArgs e)
        {
            ShowMsg("服务器连接失败...", true);
        }

        void SuperSocket_DataReceived(object sender, WebSocket4Net.DataReceivedEventArgs e)
        {
            try
            {
                var code = SerializaHelper.DeSerialize<CodeBase>(e.Data);
                if (code == null) ShowMsg("无法处理的未知消息类型");
                //消息分发处理
                var interFaces = this.GetType().GetInterfaces().Where(iface => iface.Name == "IHandleMessage`1");
                foreach (var interFace in interFaces)
                {
                    var codeType = code.GetType();
                    var argTypes = interFace.GetGenericArguments();
                    if (argTypes != null && argTypes.Length == 1 && argTypes[0].Name == codeType.Name)
                    {
                        System.Reflection.MethodInfo methodInfo = interFace.GetMethod("HandleMessage");
                        var result = methodInfo.Invoke(this, new object[] { code });
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        void SuperSocket_MessageReceived(object sender, WebSocket4Net.MessageReceivedEventArgs e)
        {
            //ShowMsg(e.Message, false);
        }

        void FrmMain_LocationChanged(object sender, EventArgs e)
        {
            stetList.Invalidate();
            btnConn.Invalidate();

        }
        void FrmMain_Load(object sender, EventArgs e)
        {
            timer.Elapsed += timer_Elapsed;
            timer.Interval = 1000;
            timer.Enabled = false;
            OnSetehoscopeConnect += FrmMain_OnSetehoscopeConnect;

        }
        int count = 0;
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (isStop)
            {
                timer.Stop();
                return;
            } 
            count+=1000;
            Invoke(new MethodInvoker(() => {
                label1.Text = count / 1000f + "秒";
            }));
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
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

        private void btnConn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(stetList.Text))
                return;
            if (isConnect())
            {

                CloseStethoscope(stetList.Text);
                Invoke(new MethodInvoker(() =>
                {
                   
                    //btnConn.BackgroundImage = Resources.已连接状态;
                    //btnConn.ForeColor = Color.Red;
                    //btnConn.Text = "断开";
                }));
            }
            else
            {
               if(OpenStethoscope(stetList.Text))
                Invoke(new MethodInvoker(delegate()
                {
                    btnConn.Text = "连接成功";
                    //btnConn.BackgroundImage = global::BDRemote.Properties.Resources.已连接状态;
                    btnConn.Enabled = false;
                    stetList.Enabled = false;
                }));
                
            }
        }
        /// <summary>
        ///设备连接成功事件
        /// </summary>
        event Action OnSetehoscopeConnect;
        bool OpenStethoscope(string stethoscopeName)
        {
            var stethoscopes = StethoscopeManager.StethoscopeList.Where(s => s.Name == stethoscopeName);
            if (!stethoscopes.Any()) return false;
            var stethoscope = stethoscopes.First();
            var formProcessBar = new FrmProcessBar(false, string.Format("正在开启设备{0}连接！", stethoscopeName))
            {
                CancelBtnVisible = false
            }; ;
            Thread pairThread = new Thread(() =>
            {
                try
                {
                    if (!stethoscope.IsConnected)
                    {
                        stethoscope.Connect();
                        ShowMsg(string.Format("听诊器 {0} 连接成功...", stethoscopeName), false);
                        
                        if (OnSetehoscopeConnect != null)
                        {
                            OnSetehoscopeConnect();
                        }
                        Current = stethoscope;
                        //Mediator.ShowMsg(string.Format("听诊器{0}连接成功", stethoscope.Name));
                    }

                }
                catch (Exception ex)
                {
                    ShowMsg(string.Format("听诊器 {0} 连接失败...", stethoscopeName));

                }
                finally
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        formProcessBar.Close();
                    }));

                }

            });
            pairThread.Start();
            formProcessBar.ShowDialog();
            return stethoscope.IsConnected;
        }
        void ShowMsg(string Msg, bool isError = true)
        {
            Invoke(new MethodInvoker(() =>
            {
                richTextBox1.Select(richTextBox1.TextLength, 0);
                //滚动到控件光标处   
                richTextBox1.ScrollToCaret();
                richTextBox1.AppendText(Msg + "\r\n");
                //this.lblMsg.Text = Msg;
            }));
        }
        bool CloseStethoscope(string stethoscopeName)
        {
            var stethoscopes = StethoscopeManager.StethoscopeList.Where(s => s.Name == stethoscopeName);
            if (!stethoscopes.Any()) return false;
            var stethoscope = stethoscopes.First();

            var formProcessBar = new FrmProcessBar(false, string.Format("正在断设备 {0} 连接！", stethoscopeName))
            {
                CancelBtnVisible = false
            };
            Thread pairThread = new Thread(() =>
            {
                try
                {
                    if (stethoscope.IsConnected)
                    {
                        stethoscope.Disconnect();
                        ShowMsg(string.Format("听诊器 {0} 断开连接...", stethoscopeName), false);
                        
                    }
                }
                catch (Exception ex)
                {
                    //好像从来没有进来过
                }
                finally
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        formProcessBar.Close();
                    }));
                }
            });
            pairThread.Start();
            formProcessBar.ShowDialog();
            return stethoscope.IsConnected;
        }

        bool isStop = false;
        /// <summary>
        /// 设备连接事件
        /// </summary>
        void FrmMain_OnSetehoscopeConnect()
        {
            if (isConnect() && !isOrder)
            {
                ShowMsg("等待远程听诊");
                //告诉对方
                var code = new RReadyCode();
                SuperSocket.Send(code);
            }

           
        }
        /// <summary>
        /// 发起方
        /// </summary>
        bool isOrder
        {
            get
            {
                return isRequest;
            }
        }

        bool isOnline = false;

        /// <summary>
        /// 用户上线,触发发起远程
        /// </summary>
        /// <param name="message"></param>
        public void HandleMessage(RYHDLCode message)
        {

            isOnline = true;
            //ShowMsg("你的小伙伴上线了", false);
            //if (isOrder)
            //{
            //    ShowMsg("我们是发起方,正在向他发起远程听诊了...", false);
            //    //ShowMsg("请先连接你的听诊设备...", false);

            //}
            //else
            //{
            //    ShowMsg("我们是被叫方,正在等待小伙伴发起远程听诊...", false);
            //    //ShowMsg("在等待的过程中,请先连接你的听诊设备 ...", false);
            //}
            //发起
        }
        bool isConnect()
        {
            return StethoscopeManager.StethoscopeList.Where(s => s.IsConnected).Any();
        }

        public void HandleMessage(RYHXXCode message)
        {
            this.Close();
            Application.Exit();
            //ShowMsg("你的小伙伴退出了,你可以关闭程序了...");
            isStop = true;
            if (isConnect())
            {
                if (isOrder)
                {
                    //Current.StopAudioInput();
                }
                else
                {
                    Current.StopAudioOutput();
                }
            }
            Application.Exit();
        }

        private void btnPresss_Click(object sender, EventArgs e)
        {
            if ("请求声音" == btnPresss.Text)
            {
                if (isOnline)
                {
                    if (isRequest && isConnect())
                    {
                        //btnPresss.Enabled = false;
                        var code = new RReadyCode();
                        SuperSocket.Send(code);
                        ShowMsg("本端已发起远程听诊");
                        //btnPresss.Enabled = false;
                        btnPresss.Text = "停止";
                    }
                }
                else
                {
                    ShowMsg("发起远程听诊失败（对方未启动客户端）");
                }
            }
            else
            {

                this.Close();
                Application.Exit();
                if (isConnect())
                {
                    
                    gifBox1.StopAnimate();
                    if (isOrder)
                    {
                        btnPresss.Enabled = true;
                        Current.StopAudioOutput();
                    }
                    SuperSocket.Send(new RStopAudioCode());
                }
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            //gifBox1.StartAnimate();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //gifBox1.StopAnimate();
        }

        

        
    }
}
