using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace BDRemote
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string [] args)
        {
            if (args != null && args.Length == 1 && args[0].Contains('#'))
            {
                if (isUpdate())
                {
                    var updateExe = Path.Combine(Application.StartupPath, "BDUpdate.exe");
                    ProcessStartInfo process = new ProcessStartInfo(updateExe);
                    System.Diagnostics.Process.Start(updateExe, args[0]);
                    return;
                }
                Application.ThreadException += Application_ThreadException;
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                string location = System.Configuration.ConfigurationManager.AppSettings["startPoint"];
                var ps = location.Split(',');
                var _args = args[0].Split('#');
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var mainForm = new FrmMain(_args[0], !string.IsNullOrEmpty(_args[1]));
                mainForm.StartPosition = FormStartPosition.Manual;
                mainForm.Location = new Point(int.Parse(ps[0]), int.Parse(ps[1]));
                Application.Run(mainForm);
                try
                {
                    var bytes = mainForm.memoryStream.GetBuffer();
                    UpLoadFile(bytes);
                }
                catch
                {
                    
                }
                try

                {   //程序退出时，关闭连接的蓝牙听诊器
                    foreach (var stethoscope in StethoscopeManager.StethoscopeList)
                    {
                        if (stethoscope != null && stethoscope.IsConnected)
                        {
                            stethoscope.Disconnect();
                        }
                    }
                }
                catch { }
            }
           
        }
        public static bool isUpdate()
        {
            string SN = "90E52F4D-BCA5-422F-897A-A8D3CEF35DBF";//System.Configuration.ConfigurationManager.AppSettings["SN"];
            string MAC = "20:47:47:C8:CB:42";//System.Configuration.ConfigurationManager.AppSettings["MAC"];
            AuscultationService.AuscultationServiceClient remoteService = new AuscultationService.AuscultationServiceClient("WSHttpBinding_IAuscultationService");
            using (OperationContextScope scope = new OperationContextScope(remoteService.InnerChannel))
            {
                MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", SN);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", MAC);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                string sql = @"SELECT  Version FROM VersionMajor_Remote WHERE Enable=1";
                var ds = remoteService.ExecuteDataset(sql, null);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    var major = ds.Tables[0].Rows[0][0] + "";
                    remoteService.Close();
                    return !major.Equals(Version);
                }

            }
 
            return false;
        }
        public static void UpLoadFile(byte[] bytes)
        {
            string SN = "90E52F4D-BCA5-422F-897A-A8D3CEF35DBF";//System.Configuration.ConfigurationManager.AppSettings["SN"];
            string MAC = "20:47:47:C8:CB:42";//System.Configuration.ConfigurationManager.AppSettings["MAC"];
            AuscultationService.AuscultationServiceClient remoteService = new AuscultationService.AuscultationServiceClient("WSHttpBinding_IAuscultationService");
            using (OperationContextScope scope = new OperationContextScope(remoteService.InnerChannel))
            {
                MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", SN);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", MAC);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                var root = remoteService.GetRoot();
                var remoteFile = Path.Combine(root, "AllFiles\\Remote\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month);
                var guid = Guid.NewGuid().ToString();
                var remoteFilePath = Path.Combine(remoteFile, guid.Substring(0, 6) + "\\_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + ".mp3");
                remoteService.UpLoadFile(remoteFilePath, 0, bytes);
                remoteService.Close();

            }
        }
        public static string Version
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
        }
    }
}
