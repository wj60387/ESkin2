using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BDUpdate
{
    public partial class FrmMain : Form
    {
         private bool isMouseDown = false;
        private Point FormLocation;     //form的location
        private Point mouseOffset;      //鼠标的按下位置
        public FrmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
        }
        string[] args ;
        public FrmMain(string [] Args)
        {
            args = Args;
            //this.MAC = MAC;
            //this.SN = SN;
            InitializeComponent();
            this.Load += FrmMain_Load;
        }
        string SN =  "90E52F4D-BCA5-422F-897A-A8D3CEF35DBF";//System.Configuration.ConfigurationManager.AppSettings["SN"];
        string MAC =   "20:47:47:C8:CB:42";//System.Configuration.ConfigurationManager.AppSettings["MAC"];
       
        void FrmMain_Load(object sender, EventArgs e)
        {
            using (OperationContextScope scope = new OperationContextScope(remoteService.InnerChannel))
            {
                MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", SN);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", MAC);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                string sql = @"SELECT  * FROM " + VersionMajor + " WHERE Enable=1";
                var ds = remoteService.ExecuteDataset(sql, null);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    var banben = ds.Tables[0].Rows[0]["Version"] + "";
                    var content = ds.Tables[0].Rows[0]["PubContent"] + "";
                    sql = @"SELECT Value FROM SysConst WHERE KeyName='" + Key + "'";
                    var Dir = remoteService.ExecuteScalar(sql, null);
                    //var majorDir = Dir + "\\" + banben;
                    var majorDir = Dir;
                    //sql = "select * from View_CurrentVersion ";
                    //var dsFile = remoteService.ExecuteDataset(sql, new string[] { });
                    //int i = 0;
                    lblVersion.Text = "版本:V" + banben;
                    lblConetnt.Text = "更新内容:" + content;
                    Down(majorDir);
                }
            }
           
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
        
       static string MainExeName = System.Configuration.ConfigurationManager.AppSettings["MainExeName"];
        public   AuscultationService.AuscultationServiceClient remoteService = new AuscultationService.AuscultationServiceClient("WSHttpBinding_IAuscultationService");



        string VersionMajor = isMainExe ? "VersionMajor" : "VersionMajor_Remote";
        string Key = isMainExe ? "VersionFileDir" : "VersionFileDir_Remote";
        string View_CurrentVersion = isMainExe ? "View_CurrentVersion" : "View_CurrentVersion_Remote";
        string VersionFile = isMainExe ? "VersionFile" : "VersionFile_Remote";
        static bool isMainExe
        {
            get { return MainExeName.Equals("BDAuscultation.exe"); }
        }
        
        void Down(string majorDir)
        {
            ExecuteProcess += FrmMain_ExecuteProcess;
            ToltlProcess += FrmMain_ToltlProcess;
            Thread thread = new Thread(() =>
            {
                using (OperationContextScope scope = new OperationContextScope(remoteService.InnerChannel))
                {
                    MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", SN);
                    OperationContext.Current.OutgoingMessageHeaders.Add(header);
                    header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", MAC);
                    OperationContext.Current.OutgoingMessageHeaders.Add(header);
                    string sql = "select * from " + View_CurrentVersion + " ";
                    var dsFile = remoteService.ExecuteDataset(sql, new string[] { });
                    int i = 0;
                    wacth.Start();
                    foreach (DataRow row in dsFile.Tables[0].Rows)
                    {
                        i++;
                        var version = row["Version"] + "";
                        var hash = row["FileHash"] + "";
                        var fileName = row["FileName"] + "";
                        var fileRelativePath = row["FileRelativePath"] + "";
                        if (ToltlProcess != null)
                        {
                            ToltlProcess(fileName);
                        }
                        var localFilePath = Path.Combine(Application.StartupPath, fileRelativePath);
                        var remoteFilePath = Path.Combine(majorDir, version+"\\"+fileRelativePath);
                        var fileSize = remoteService.GetFileLength(remoteFilePath);

                        if(File.Exists(localFilePath))
                        {
                            var hashcode = GetMD5HashFromFile(localFilePath);
                            if (hashcode.Equals(hash))
                                continue;
                        }
                        //下载文件
                        if (!Directory.Exists(Path.GetDirectoryName(localFilePath)))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(localFilePath));
                        }
                        using (var stream = new FileStream(localFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                        {
                            long position = 0;
                            while (position < fileSize)
                            {
                                var bytes = remoteService.DownLoadFile(remoteFilePath, position, 24 * 1024);
                                position += bytes.Length;
                                stream.Write(bytes, 0, bytes.Length);
                                DownBytes += bytes.Length;

                                if (ExecuteProcess != null)
                                    ExecuteProcess((int)(position * 100 / fileSize), 100, i, dsFile.Tables[0].Rows.Count);
                            }
                            stream.Close();

                        }
                    }
                }


            });
            thread.Start();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public event Action<int, int,int,int> ExecuteProcess;
        public event Action<string> ToltlProcess;
        private void btnDown_Click(object sender, EventArgs e)
        {
        }
        System.Diagnostics.Stopwatch wacth = new Stopwatch();
        long DownBytes = 0;
        void FrmMain_ExecuteProcess(int value,int maxvalue,  int tvalue, int total)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                this.processBarEx1.Value = maxvalue;
                this.processBarEx1.Value = value;
                this.lblProcess.Text = string.Format("当前进度:{0}/{1},总进度:{2}/{3}", value, maxvalue, tvalue,total);
                this.lblNet.Text = (int)(DownBytes / (double)wacth.ElapsedMilliseconds)+ "KB/S";
                if (value == maxvalue&&tvalue == total)
                {
                    lblgxz.Visible = false;
                    btnOK.Visible = true;
                    wacth.Stop();
                }
            }));
        }
        void FrmMain_ToltlProcess(string fileName)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                this.lblMsg.Text = string.Format("正在更新文件:{0}...",fileName);
               

            }));
        }
        private void btnMin_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(isMainExe)
            {
                var exe = Path.Combine(Application.StartupPath, MainExeName + ".exe");
                System.Diagnostics.Process.Start(exe);
            }
            else
            {
                var exe = Path.Combine(Application.StartupPath, MainExeName + ".exe");
                System.Diagnostics.Process.Start(exe, string.Join(" ", args));
            }
            this.Close();
            Application.Exit();
        }
        public static string GetMD5HashFromFile(string filePath)
        {
            try
            {
                FileStream file = new FileStream(filePath, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString().ToUpper();
            }

            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }

        }
         

        

         
    }
}
