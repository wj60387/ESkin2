using BDAuscultation.Devices;
using BDAuscultation.Utilities;
using ProtocalData.Protocol;
using ProtocalData.Protocol.Derive;
using ProtocalData.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Windows.Forms;

namespace BDAuscultation
{
    partial class FrmMain:
          IHandleMessage<RequestGetDeviceInfoCode>
     // , IHandleMessage<GetDownedAudioCode>
    {

        public void HandleMessage(RequestGetDeviceInfoCode message)
        {
            var resGetDeviceInfoCode = new ResGetDeviceInfoCode()
            {
                SrcMac = Setting.authorizationInfo.MachineCode,
                PCName = CommonUtil.GetMachineName(),
                ToSessionID = message.SessionID,
                StetNames = StethoscopeManager.StethoscopeList.Select(s => s.Name).ToArray(),
                isConnected = StethoscopeManager.StethoscopeList.Select(s => s.IsConnected).ToArray(),
                StetOwners = StethoscopeManager.StethoscopeList.Select(s => Setting.GetStetInfoByStetName(s.Name).Owner ?? string.Empty).ToArray(),
                StetChineseNames = StethoscopeManager.StethoscopeList.Select(s => Setting.GetStetInfoByStetName(s.Name).StetChineseName ?? string.Empty).ToArray()

            };
            var bytes = ProtocalData.Utilities.SerializaHelper.Serialize(resGetDeviceInfoCode);
            Mediator.SuperSocket.Send(bytes);
        }
        /// <summary>
        /// 接收到请求远程邀请
        /// </summary>
        /// <param name="message"></param>
        


        void InitSocket()
        {
            Mediator.SuperSocket.OpenSocket(Setting.authorizationInfo.AuthorizationNum, Setting.authorizationInfo.MachineCode);
            Mediator.SuperSocket.Opened += new EventHandler(SuperSocket_Opened);
            Mediator.SuperSocket.Closed += new EventHandler(SuperSocket_Closed);
            Mediator.SuperSocket.DataReceived += new EventHandler<WebSocket4Net.DataReceivedEventArgs>(SuperSocket_DataReceived);
            Mediator.SuperSocket.MessageReceived += new EventHandler<WebSocket4Net.MessageReceivedEventArgs>(SuperSocket_MessageReceived);
            Mediator.SuperSocket.Error += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(SuperSocket_Error);
        }

        void SuperSocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            Mediator.ShowMsg("套接字通信发生异常:" + e.Exception.ToString());

        }

        void SuperSocket_MessageReceived(object sender, WebSocket4Net.MessageReceivedEventArgs e)
        {
            Mediator.ShowMsg("系统消息:" + e.Message);
        }

        void SuperSocket_DataReceived(object sender, WebSocket4Net.DataReceivedEventArgs e)
        {
            try
            {
                var code = SerializaHelper.DeSerialize<CodeBase>(e.Data);
                if (code == null) Mediator.ShowMsg("无法处理的未知消息类型");
                //消息分发处理
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    var from = Application.OpenForms[i];
                    var interFaces = from.GetType().GetInterfaces().Where(iface => iface.Name == "IHandleMessage`1");
                    // var interFace = from.GetType().GetInterface("IHandleMessage`1");
                    foreach (var interFace in interFaces)
                    {
                        var codeType = code.GetType();
                        var argTypes = interFace.GetGenericArguments();
                        if (argTypes != null && argTypes.Length == 1 && argTypes[0].Name == codeType.Name)
                        {
                            System.Reflection.MethodInfo methodInfo = interFace.GetMethod("HandleMessage");
                            var result = methodInfo.Invoke(from, new object[] { code });

                        }
                    }
                }
            }
            catch
            {

            }
        }

        void SuperSocket_Closed(object sender, EventArgs e)
        {
            Setting.isConnected = false;
            Mediator.ShowMsg("网络异常,关闭套接字...");
        }
        void SuperSocket_Opened(object sender, EventArgs e)
        {
            Setting.isConnected = true;
            //Mediator.ShowMsg("连接服务器成功...");
        }
        void UpLoadStetInfo()
        {
            if (StethoscopeManager.StethoscopeList!=null)
            {
                foreach (var item in StethoscopeManager.StethoscopeList)
                {
                    var stetInfo = Setting.GetStetInfoByStetName(item.Name);
                    var code = Newtonsoft.Json.JsonConvert.SerializeObject(stetInfo);
                    using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
                    {
                        MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                        OperationContext.Current.OutgoingMessageHeaders.Add(header);
                        header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                        OperationContext.Current.OutgoingMessageHeaders.Add(header);
                        Mediator.remoteService.UpdateStetInfo(code);
                    }
                }
            }
            
        }
        void LoadAudioFile(object dirPath)
        {
            try
            {
                var dir = dirPath as string;
                if (!Directory.Exists(dir)) return;
                DateTime dt = DateTime.MinValue;
                if (File.Exists(Path.Combine(dir, "flag.txt")))
                {
                    dt = DateTime.Parse(File.ReadAllText(Path.Combine(dir, "flag.txt")));
                }
                var files = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);
                var needUploadFiles = files.Where(f => new FileInfo(f).CreationTime > dt).ToArray();
                File.WriteAllText(Path.Combine(dir, "flag.txt"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
                {
                    MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                    OperationContext.Current.OutgoingMessageHeaders.Add(header);
                    header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                    OperationContext.Current.OutgoingMessageHeaders.Add(header);
                    var root = Mediator.remoteService.GetRoot();
                    var remoteFile = Path.Combine(root, "AllFiles\\" + CommonUtil.GetMachineName());
                    foreach (var localFile in needUploadFiles)
                    {
                        var remoteFilePath = Path.Combine(remoteFile, Path.GetFileName(localFile));
                        if (Mediator.remoteService.isExistFile(remoteFilePath))
                        {
                            Mediator.remoteService.DeleteFile(remoteFilePath);
                        }
                        using (var stream = new FileStream(localFile, FileMode.OpenOrCreate, FileAccess.Read))
                        {
                            while (true)
                            {
                                var readBytes = new byte[1024 * 24];
                                var readed = stream.Read(readBytes, 0, readBytes.Length);
                                if (readed <= 0) break;
                                Mediator.remoteService.UpLoadFile(remoteFilePath, stream.Position - readed, readBytes);
                            }
                            stream.Close();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.ToString();
            }
        }

        /// <summary>
        /// 同步配置的听诊配置信息,不存在就下载，存在就上传
        /// </summary>
        void LoadStetInfo()
        {
            string sql = "select count(*) from StetInfo";
            var count = int.Parse(Mediator.sqliteHelper.ExecuteScalar(sql).ToString());
            if (count == 0)
            {
                string sqlQuery = " select * from StethoscopeManager where MAC={0} and IfDel=0";
                using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
                {
                    MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                    OperationContext.Current.OutgoingMessageHeaders.Add(header);
                    header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                    OperationContext.Current.OutgoingMessageHeaders.Add(header);
                    var ds = Mediator.remoteService.ExecuteDataset(sqlQuery, new string[] { Setting.authorizationInfo.MachineCode });
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var stetName = row["StetName"] + "";
                        var stetChineseName = row["StetChineseName"] + "";
                        var owner = row["Owner"] + "";
                        var funcDescript = row["FuncDescript"] + "";
                        var reMark = row["ReMark"] + "";
                        string sqlUpdate = @"update StetInfo set PCName={0},StetChineseName={1},Owner={2},FuncDescript={3},
                       ReMark={4} where StetName={5} ";
                        string sqlInsert = @"insert into StetInfo(StetName,SN,MAC,PCName,StetChineseName,Owner,FuncDescript,ReMark,RecordTime)
                        select {0},{1},{2},{3},{4},{5},{6},{7},{8}";
                        if (int.Parse(Mediator.sqliteHelper.ExecuteScalar("select count(*) from StetInfo where StetName={0}", stetName).ToString()) > 0)
                        {
                            var n = Mediator.sqliteHelper.ExecuteNonQuery(sqlUpdate, CommonUtil.GetMachineName(), stetChineseName
                          , owner, funcDescript, reMark, stetName);
                        }
                        else
                        {
                            var n = Mediator.sqliteHelper.ExecuteNonQuery(sqlInsert, stetName, Setting.authorizationInfo.AuthorizationNum, Setting.authorizationInfo.MachineCode, CommonUtil.GetMachineName()
                                , stetChineseName, owner, funcDescript, reMark, DateTime.Now);
                        }
                    }
                }
            }
            else
            {
                UpLoadStetInfo();
            }
        }

        public int Times = 0;
    }
}
