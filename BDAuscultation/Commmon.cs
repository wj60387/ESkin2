using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using BDAuscultation.SQLite;
using BDAuscultation.Commucation;
using System.IO;

namespace BDAuscultation
{
    public delegate void StethcopeConnectChanged(string StetName,bool isConnect);
    public delegate void ShowMessage(string Msg);
     
    public class Mediator
    {
        public static AuscultationService.AuscultationServiceClient remoteService = new AuscultationService.AuscultationServiceClient("WSHttpBinding_IAuscultationService");
        public static void Init()
        {
            using (OperationContextScope scope = new OperationContextScope(remoteService.InnerChannel))
            {
                MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
              
            }
        }
        public static bool isUpdate()
        {
            using (OperationContextScope scope = new OperationContextScope(remoteService.InnerChannel))
            {
                MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                string sql = @"SELECT  Version FROM VersionMajor WHERE Enable=1";
                var ds = remoteService.ExecuteDataset(sql, null);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    var major = ds.Tables[0].Rows[0][0] + "";
                    return !major.Equals(Setting.Version);
                }
                   
            }
            return false;
        }
        public static void Update()
        {
            using (OperationContextScope scope = new OperationContextScope(remoteService.InnerChannel))
            {
                MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                var sql = @"SELECT Value,CreateTime FROM SysConst WHERE KeyName='UpdatePath'";
                var dt = remoteService.ExecuteDataset(sql, null);
                var ct = DateTime.Parse(dt.Tables[0].Rows[0]["CreateTime"] + "");
                var path = dt.Tables[0].Rows[0]["Value"] + "" ;
                var info = new FileInfo(Path.Combine(Application.StartupPath, "BDUpdate.exe"));
                if (info.LastWriteTime < ct)
                {
                    var localFilePath = Path.Combine(Application.StartupPath, "BDUpdate.exe");
                    var remoteFilePath = Path.Combine(path, "BDUpdate.exe");
                    var fileSize = remoteService.GetFileLength(remoteFilePath);
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
                        }
                        stream.Close();
                    }
                }
            }
        }
        public static bool isBusy = false;
      
        public static SqliteHelper sqliteHelper = new SqliteHelper(Setting.localSqliteConnectstring);
       // public static SqliteHelper sqliteHelper2 = new SqliteHelper(Setting.localSqliteConnectstring2);
        public static SupSocket SuperSocket = new SupSocket(Setting.serverUrl);
        public static event ShowMessage ShowMessageEvent;
        public static event Action ClearMessageEvent;
        /// <summary>
        /// 听诊器连接状态变化事件
        /// </summary>
        public static event StethcopeConnectChanged StethcopeConnectChangedEvent;

        public static void OnStethcopeConnectChanged(string StetName, bool isConnect)
        {
            if (Mediator.StethcopeConnectChangedEvent != null)
            {
                Mediator.StethcopeConnectChangedEvent(StetName, isConnect);
            }
        }
        public static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
           ShowMsg(e.Exception.ToString());
        }
        public static void ShowMsg(string Msg)
        {
            if (ShowMessageEvent != null)
            {
                ShowMessageEvent(Msg);
                 
            }
        }
        public static void ClearInfo()
        {
            if (ClearMessageEvent != null)
            {
                ClearMessageEvent();
            }
        }
        public static void WriteLog(string FormName,string Message)
        {
            if (!Setting.isConnected) return;
            using (OperationContextScope scope = new OperationContextScope(remoteService.InnerChannel))
            {
                MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
            var endpoint = remoteService.GetEndPoint();
            string sql = "insert into UserOperLog(SN, MAC, FormName, EndPoint, Message) select {0},{1},{2},{3},{4}";
            Mediator.remoteService.ExecuteNonQuery(sql, new string[]{Setting.authorizationInfo.AuthorizationNum,
                Setting.authorizationInfo.MachineCode, FormName, endpoint, Message});
            }
        }
    }
    
}
