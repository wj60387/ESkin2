using BDAuscultation.Devices;
using BDAuscultation.Forms;
using BDAuscultation.Utilities;
using ProtocalData.Protocol.Derive;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BDAuscultation
{
    /// <summary>
    /// 听诊录音
    /// </summary>
    partial class FrmMain:   
        IHandleMessage<RequestRemoteAuscultateCode>
        , IHandleMessage<ResGetDeviceInfoCode>
      // , IHandleMessage<ResRemoteAuscultateCode>
    {
        void InitdgvYCTZ()
        {
            this.cbBoxYCTZ.DropDown += cbBoxYCTZ_DropDown;
            this.cbBoxYCTZ.SelectedIndexChanged += cbBoxYCTZ_SelectedIndexChanged;
            LoadYCTZStet();


            var ycjxBtnCheckColumn = new DataGridViewCheckBoxExColumn() {
                Name = "dgvYCTZAccept",
                HeaderText = "选择", Text = "选择", AutoSizeMode = DataGridViewAutoSizeColumnMode.None, Width = 60 };
            dgvYCTZ.Columns.Add(ycjxBtnCheckColumn);

            dgvYCTZ.ListColumnImage.Add(BDAuscultation.Properties.Resources.听诊器名字);
            dgvYCTZ.ListColumnImage.Add(BDAuscultation.Properties.Resources.听诊器编号);
            dgvYCTZ.ListColumnImage.Add(BDAuscultation.Properties.Resources.计算机名);
            dgvYCTZ.ListColumnImage.Add(BDAuscultation.Properties.Resources.MAC);
            dgvYCTZ.ListColumnImage.Add(BDAuscultation.Properties.Resources.听诊器名字);
            dgvYCTZ.ListColumnImage.Add(BDAuscultation.Properties.Resources.听诊器所属人);
            dgvYCTZ.ListColumnImage.Add(BDAuscultation.Properties.Resources.连接状态);
             dgvYCTZ.ListColumnImage.Add(BDAuscultation.Properties.Resources.选择);

            this.btnStart.Click += btnStart_Click;
        }

        void btnStart_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.cbBoxYCTZ.Text))
            {
                MessageBox.Show("请选择一个听诊器！");
                return;
            }
            if (!StethoscopeManager.StethoscopeList.Where(s => s.Name == this.cbBoxYCTZ.Text && s.IsConnected).Any())
            {
                MessageBox.Show(string.Format("听诊器{0}尚未连接", this.cbBoxYCTZ.Text));
                return;
            }
            if (!DgvTable.Select().Where(r => r["dgvYCTZAccept"].ToString() == "True").Any())
            {
                MessageBox.Show("请选择听诊器！");
                return;
            }
            while (true)
            {
                
                bool isHas = false;
                for (int i = 0; i < dgvYCTZ.Rows.Count; i++)
                {
                    if (!(bool)dgvYCTZ.Rows[i].Cells[6].Value)
                    {
                        isHas = true;
                        dgvYCTZ.Rows.RemoveAt(i);
                        break;
                    }
                }
                if (!isHas) break;
            }
            var macs = DgvTable.Select().Where(r => r["dgvYCTZAccept"].ToString() == "True")
                .GroupBy(row => row["dgvYCTZMAC"]).Select(g => g.Key.ToString()).ToArray();
            var guid = Guid.NewGuid().ToString();
            foreach (var mac in macs)
            {
                var rows = DgvTable.Select("dgvYCTZMAC='" + mac + "' and dgvYCTZAccept='True'");
                if (rows.Length > 0)
                {
                    var code = new RequestRemoteAuscultateCode()
                    {
                        Guid = guid,
                        SrcMac = Setting.authorizationInfo.MachineCode,
                        SrcPCName = CommonUtil.GetMachineName(),
                        SrcStetName = this.cbBoxYCTZ.Text,
                        SrcStetOwner = Setting.GetStetInfoByStetName(this.cbBoxYCTZ.Text).Owner,
                        DestMac = mac,
                        DestStetNames = rows.Select(r => r["dgvYCTZStetNO"].ToString()).ToArray(),
                        InvestList = DgvTable

                    };
                    var bytes = ProtocalData.Utilities.SerializaHelper.Serialize(code);
                    Mediator.SuperSocket.Send(bytes);
                    Mediator.ShowMsg(string.Format("{0}向{1}发起远程听诊请求...", cbBoxYCTZ.Text, mac));
                }
            }
            var formAuscultation = new FrmAuscultation()
            {
                InvestList = DgvTable,
                Sender = this.cbBoxYCTZ.Text,
                Guid = guid,
                isSender = true
            };
            using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
            {
                MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                string sqlInsert = "insert into RemoteAuscultateList(SrcGUID,Acceptor,MAC) select {0},{1},{2}";
                foreach (DataRow dr in DgvTable.Rows)
                {

                    int count = Mediator.remoteService.ExecuteNonQuery(sqlInsert, new string[] { guid, dr["dgvYCTZStetNO"] + "", dr["dgvYCTZMAC"] + "" });
                    if (count <= 0)
                    {
                        MessageBox.Show("远程听诊创建失败...");
                        return;
                    }

                }
                //write record
                string sql = " insert into RemoteAuscultate(GUID,Createor,SN,MAC) select {0},{1},{2},{3}";
                if (Mediator.remoteService.ExecuteNonQuery(sql, new string[] { guid, this.cbBoxYCTZ.Text, Setting.authorizationInfo.AuthorizationNum, Setting.authorizationInfo.MachineCode }) > 0)
                {
                    // formAuscultation.LoadMettingList(DgvTable);
                    Mediator.isBusy = true;
                    formAuscultation.ShowDialog();
                    //关闭了此次听诊会议
                    string sqlClose = "update RemoteAuscultate set  OverTime=getdate(),Status =2 where GUID={0}";
                    Mediator.remoteService.ExecuteNonQuery(sqlClose, new string[] { guid });
                    Mediator.ShowMsg(string.Format("远程听诊结束，编号{0}", formAuscultation.Guid));
                    foreach (var mac in formAuscultation.DgvTable.Select().Select(r => r["MAC"] + "").ToArray().Distinct())
                    {
                        var code = new RemoteExitCode()
                        {
                            Guid = guid,
                            SrcMac = Setting.authorizationInfo.MachineCode,
                            DestMac = mac,
                            ExitMac = Setting.authorizationInfo.MachineCode
                        };
                        var bytes = ProtocalData.Utilities.SerializaHelper.Serialize(code);
                        Mediator.SuperSocket.Send(bytes);
                    }
                    Mediator.isBusy = false;
                }
            }
        }
        public DataTable DgvTable
        {
            get
            {
                DataTable dt = new DataTable();
                for (int count = 0; count < dgvYCTZ.Columns.Count; count++)
                {
                    DataColumn dc = new DataColumn(dgvYCTZ.Columns[count].Name.ToString());
                    dt.Columns.Add(dc);
                }
                for (int count = 0; count < dgvYCTZ.Rows.Count; count++)
                {
                    DataRow dr = dt.NewRow();
                    for (int countsub = 0; countsub < dgvYCTZ.Columns.Count; countsub++)
                    {
                        dr[countsub] = dgvYCTZ.Rows[count].Cells[countsub].Value.ToString();
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
        }
        void LoadYCTZStet()
        {
            cbBoxYCTZ.Items.Clear();
            foreach (var item in StethoscopeManager.StethoscopeList)
            {
                var stetInfo = Setting.GetStetInfoByStetName(item.Name);
#if !DEBUG
                if (item.IsConnected)
#endif
                cbBoxYCTZ.Items.Add(item.Name);
            }
            if (cbBoxYCTZ.Items.Count > 0)
                cbBoxYCTZ.SelectedIndex = 0;
        }
        void cbBoxYCTZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbBoxYCTZ.Text))
            {
                MessageBox.Show("请选择一个听诊器");
                return;
            }
            
            RequestGetDeviceInfoCode requsetGetDeviceInfoCode = new RequestGetDeviceInfoCode();
            var bytes = ProtocalData.Utilities.SerializaHelper.Serialize(requsetGetDeviceInfoCode);
            Mediator.SuperSocket.Send(bytes);
            dgvYCTZ.Rows.Clear();
            Mediator.ShowMsg("刷新在线的听诊器...");
            Mediator.WriteLog(this.Name, string.Format("远程听诊,{0}刷新在线的听诊器...", cbBoxYCTZ.Text));

        }

        void cbBoxYCTZ_DropDown(object sender, EventArgs e)
        {
            LoadYCTZStet();
        }
        public void HandleMessage(ResGetDeviceInfoCode message)
        {
            if (message.StetNames != null)
            {
                Invoke(new MethodInvoker(() =>
                {
                    for (int i = 0; i < message.StetNames.Length; i++)
                    {
#if DEBUG
                        if (message.StetNames[i] != this.cbBoxYCTZ.Text)
#endif
#if !DEBUG
                        if (message.StetNames[i] != this.cbBoxYCTZ.Text && message.isConnected[i])
#endif
                        {
                            if (!isExistDeviceInfo(message.SrcMac, message.StetNames[i]))
                            {

                                dgvYCTZ.Rows.Add(
                                    message.StetChineseNames[i]
                                    , message.StetNames[i]
                                    , message.PCName
                                    , message.SrcMac
                                    , message.StetOwners[i],
                                    message.isConnected[i] ? "已连接" : "未连接"
                                    ,false);
                            }
                        }

                    }
                }));


            }


        }
        bool isExistDeviceInfo(string Mac, string StetName)
        {
            for (int i = 0; i < dgvYCTZ.Rows.Count; i++)
            {
                var mac = dgvYCTZ.Rows[i].Cells["dgvYCTZMAC"].Value.ToString();
                var stetName = dgvYCTZ.Rows[i].Cells["dgvYCTZStetNO"].Value.ToString();
                if (stetName.Equals(StetName) && Mac.Equals(mac))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 接收到请求远程邀请
        /// </summary>
        /// <param name="message"></param>
        public void HandleMessage(RequestRemoteAuscultateCode message)
        {

            Invoke(new MethodInvoker(() =>
            {
               
                Mediator.WriteLog(this.Name, string.Format("处理来自{0}的听诊器{1}处理远程邀请请求...", message.SrcMac, message.SrcStetName));
                //非本机，接收到远程请求,但本机有其他设备在使用中,自动拒绝
                if (message.SrcMac != Setting.authorizationInfo.MachineCode && Mediator.isBusy)
                {
                    var msg = string.Format("设备忙,自动拒绝了{0}的{1}远程听诊请求...", message.SrcMac, message.SrcStetName);
                    var _resRemoteAuscultateCode = new ResRemoteAuscultateCode()
                    {
                        Guid = message.Guid,
                        SrcPCName = CommonUtil.GetMachineName(),
                        SrcMac = Setting.authorizationInfo.MachineCode,
                        DestMac = message.SrcMac,
                        isAccept = false,
                        Comment = msg
                    };
                    var _bytes = ProtocalData.Utilities.SerializaHelper.Serialize(_resRemoteAuscultateCode);
                    Mediator.SuperSocket.Send(_bytes);
                    Mediator.ShowMsg(msg);
                    using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
                    {
                        MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                        OperationContext.Current.OutgoingMessageHeaders.Add(header);
                        header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                        OperationContext.Current.OutgoingMessageHeaders.Add(header);
                        foreach (var stetName in message.DestStetNames)
                        {
                            string sql = "update RemoteAuscultateList set Comment={0} where SrcGUID={1} and Acceptor={2}";
                            var count = Mediator.remoteService.ExecuteNonQuery(sql, new string[] { msg, message.Guid, stetName });
                            if (count < 0)
                            {

                            }
                        }

                    }
                    return;
                }
                //本机
                if (message.SrcMac == Setting.authorizationInfo.MachineCode)
                {
                    var resRemoteAuscultateCode = new ResRemoteAuscultateCode()
                    {
                        Guid = message.Guid,
                        SrcPCName = CommonUtil.GetMachineName(),
                        SrcMac = Setting.authorizationInfo.MachineCode,
                        DestMac = message.SrcMac,
                        isAccept = true,
                        Comment = "本机远程邀请自动接受..."
                    };
                    var bytes = ProtocalData.Utilities.SerializaHelper.Serialize(resRemoteAuscultateCode);
                    Mediator.SuperSocket.Send(bytes);
                    using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
                    {
                        MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                        OperationContext.Current.OutgoingMessageHeaders.Add(header);
                        header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                        OperationContext.Current.OutgoingMessageHeaders.Add(header);
                        foreach (var stetName in message.DestStetNames)
                        {
                            string sql = "update RemoteAuscultateList set isAccept=1,Comment={0} where SrcGUID={1} and Acceptor={2}";
                            var count = Mediator.remoteService.ExecuteNonQuery(sql, new string[] { "本机远程邀请自动接受...", message.Guid, stetName });
                            if (count < 0)
                            {

                            }
                        }

                    }
                    return;
                }
                this.tabControlYDTZ.SelectedTab = tabYCTZ;

                var stetNames = string.Join(",", message.DestStetNames);
                if (!StethoscopeManager.StethoscopeList.Where(s => message.DestStetNames.Contains(s.Name) && s.IsConnected).Any())
                {
                    Mediator.ShowMsg(string.Format("来自{3}的听诊器{0} {1}邀请您远程听诊,邀请的听诊器{2},都处于未连接状态，自动拒绝！", message.SrcStetName, string.IsNullOrEmpty(message.SrcStetOwner) ? "" : ",(" + message.SrcStetOwner + ")", stetNames, message.SrcPCName));
                    var resRemoteAuscultateCode = new ResRemoteAuscultateCode()
                    {
                        Guid = message.Guid,
                        SrcPCName = CommonUtil.GetMachineName(),
                        SrcMac = Setting.authorizationInfo.MachineCode,
                        DestMac = message.SrcMac,
                        isAccept = false,
                        Comment = "邀请的听诊器都处于未连接状态，自动拒绝..."
                    };
                    var bytes = ProtocalData.Utilities.SerializaHelper.Serialize(resRemoteAuscultateCode);
                    Mediator.SuperSocket.Send(bytes);
                    using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
                    {
                        MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                        OperationContext.Current.OutgoingMessageHeaders.Add(header);
                        header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                        OperationContext.Current.OutgoingMessageHeaders.Add(header);
                        foreach (var stetName in message.DestStetNames)
                        {
                            string sql = "update RemoteAuscultateList set isAccept=1,Comment={0} where SrcGUID={1} and Acceptor={2}";
                            var count = Mediator.remoteService.ExecuteNonQuery(sql, new string[] { "邀请的听诊器都处于未连接状态，自动拒绝...", message.Guid, stetName });
                            if (count < 0)
                            {

                            }
                        }

                    }
                    return;
                }

                Mediator.ShowMsg(string.Format("来自{3}的听诊器{0} {1}邀请您远程听诊,邀请的听诊器有{2},是否接受?", message.SrcStetName, string.IsNullOrEmpty(message.SrcStetOwner) ? "" : ",(" + message.SrcStetOwner + ")", stetNames, message.SrcPCName));
                //非本机,同意请求请求,但得知道当前远程回话是否还在
                if (DialogResult.OK == MessageBox.Show(string.Format("来自{3}的听诊器{0} {1}邀请您远程听诊,邀请的听诊器有{2},是否接受?", message.SrcStetName, string.IsNullOrEmpty(message.SrcStetOwner) ? "" : ",(" + message.SrcStetOwner + ")", stetNames, message.SrcPCName)
                    , "远程听诊提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    //1.同意远程请求,但得知道当前远程回话是否还在
                    using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
                    {
                        MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                        OperationContext.Current.OutgoingMessageHeaders.Add(header);
                        header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                        OperationContext.Current.OutgoingMessageHeaders.Add(header);
                        string sql = "select Status from RemoteAuscultate where GUID={0}";
                        // Status默认为0 -就绪 1-进行中 2-结束
                        var status = int.Parse("" + Mediator.remoteService.ExecuteScalar(sql, new string[] { message.Guid }));
                        if (status == 2)
                        {
                            var _msg = string.Format("此次远程听诊已经结束...远程听诊编号{0}", message.Guid);
                            Mediator.ShowMsg(_msg);
                            return;
                        }
                        else if (status == 1)
                        {
                            var _msg = string.Format("此次远程听诊正在进行中您来晚了...远程听诊编号{0}", message.Guid);
                            Mediator.ShowMsg(_msg);
                            return;
                            // 已经开始
                        }
                    }


                    var msg = string.Format("{2}接受了{0}的{1}远程听诊请求...", message.SrcMac, message.SrcStetName, CommonUtil.GetMachineName());
                    var resRemoteAuscultateCode = new ResRemoteAuscultateCode()
                    {
                        Guid = message.Guid,
                        SrcPCName = CommonUtil.GetMachineName(),
                        SrcMac = Setting.authorizationInfo.MachineCode,
                        DestMac = message.SrcMac,
                        isAccept = true,
                        Comment = msg //Mediator.isBusy ? string.Format("设备忙,拒绝了{0},{1}远程听诊请求...", message.SrcMac, message.SrcStetName):

                    };
                    var bytes = ProtocalData.Utilities.SerializaHelper.Serialize(resRemoteAuscultateCode);
                    Mediator.SuperSocket.Send(bytes);

                    using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
                    {
                        MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                        OperationContext.Current.OutgoingMessageHeaders.Add(header);
                        header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                        OperationContext.Current.OutgoingMessageHeaders.Add(header);
                        foreach (var stetName in message.DestStetNames)
                        {
                            var isAccept = StethoscopeManager.StethoscopeList.Where(s => s.Name == stetName && s.IsConnected).Any() ? "1" : "0";
                            string sql = "update RemoteAuscultateList set AcceptTime=getdate(), isAccept={3},Comment={0} where SrcGUID={1} and Acceptor={2}";
                            var count = Mediator.remoteService.ExecuteNonQuery(sql, new string[] { msg, message.Guid, stetName, isAccept });
                            if (count < 0)
                            {

                            }
                        }

                    }

                    //2.实时更新听诊器连接状态
                    Mediator.StethcopeConnectChangedEvent += (name, b) =>
                    {
                        if (message.DestStetNames.Contains(name))
                        {
                            var code = new RefleshStatusCode()
                            {
                                SrcMac = Setting.authorizationInfo.MachineCode,
                                SrcStetName = name,
                                DestMac = message.SrcMac,
                                isConnect = b
                            };
                            var _bytes = ProtocalData.Utilities.SerializaHelper.Serialize(code);
                            Mediator.SuperSocket.Send(_bytes);
                        }
                    };
                    Mediator.ShowMsg(string.Format("接受了{0}的{1}远程听诊请求...", message.SrcMac, message.SrcStetName));
                    //3.进入会议室
                    Thread thread = new Thread(() =>
                    {
                        this.Invoke(new MethodInvoker(() =>
                        {
                            var formAuscultation = new FrmAuscultation()
                            {
                                Sender = message.SrcStetName,
                                Guid = message.Guid,
                                isSender = false
                            };
                            Mediator.isBusy = true;
                            //发进入消息
                            {
                                var code = new RemoteEnterCode()
                                {
                                    Guid = message.Guid,
                                    SrcMac = Setting.authorizationInfo.MachineCode,
                                    DestMac = message.SrcMac
                                };
                                var _bytes = ProtocalData.Utilities.SerializaHelper.Serialize(code);
                                Mediator.SuperSocket.Send(_bytes);
                            }
                            formAuscultation.ShowDialog();
                            //写离开状态
                            using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
                            {
                                MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                                header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                                foreach (var stetName in message.DestStetNames)
                                {
                                    string sql = "update RemoteAuscultateList set ExitTime=getdate(), isExit=1,Comment={0} where SrcGUID={1} and Acceptor={2}";
                                    var count = Mediator.remoteService.ExecuteNonQuery(sql, new string[] { msg, message.Guid, stetName });
                                    if (count < 0)
                                    {

                                    }
                                }

                            }
                            Mediator.ShowMsg(string.Format("远程听诊结束，编号{0}", message.Guid));
                            //发退出消息
                            Mediator.isBusy = false;
                            foreach (var stetName in message.DestStetNames)
                            {
                                var code = new RemoteExitCode()
                                {
                                    Guid = message.Guid,
                                    SrcMac = Setting.authorizationInfo.MachineCode,
                                    DestMac = message.SrcMac,
                                    ExitMac = Setting.authorizationInfo.MachineCode
                                };
                                var _bytes = ProtocalData.Utilities.SerializaHelper.Serialize(code);
                                Mediator.SuperSocket.Send(_bytes);
                            }
                        }));

                    });
                    thread.Start();


                }
                else
                {
                    var msg = string.Format("主动拒绝了{0}的{1}远程听诊请求...", message.SrcMac, message.SrcStetName);
                    var resRemoteAuscultateCode = new ResRemoteAuscultateCode()
                    {
                        Guid = message.Guid,
                        SrcPCName = CommonUtil.GetMachineName(),
                        SrcMac = Setting.authorizationInfo.MachineCode,
                        DestMac = message.SrcMac,
                        isAccept = false
                        ,
                        Comment = msg //Mediator.isBusy ? string.Format("设备忙,拒绝了{0},{1}远程听诊请求...", message.SrcMac, message.SrcStetName):

                    };
                    var bytes = ProtocalData.Utilities.SerializaHelper.Serialize(resRemoteAuscultateCode);
                    Mediator.SuperSocket.Send(bytes);

                    using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
                    {
                        MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                        OperationContext.Current.OutgoingMessageHeaders.Add(header);
                        header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                        OperationContext.Current.OutgoingMessageHeaders.Add(header);
                        foreach (var stetName in message.DestStetNames)
                        {
                            string sql = "update RemoteAuscultateList set Comment={0} where SrcGUID={1} and Acceptor={2}";
                            var count = Mediator.remoteService.ExecuteNonQuery(sql, new string[] { msg, message.Guid, stetName });
                            if (count < 0)
                            {

                            }
                        }

                    }
                }

            }));
        }

        //public void HandleMessage(RefleshStatusCode message)
        //{
        //    foreach (DataGridViewRow row in dgvYCTZ.Rows)
        //    {
        //        if (row.Cells["dgvYCTZAccept"].Value.ToString() == "否") continue;
        //        if (row.Cells["dgvYCTZStetName"].Value.ToString() == message.SrcStetName)
        //        {
        //            row.Cells["dgvYCTZStetConn"].Value = message.isConnect ? "已连接" : "未连接";
        //            // row.DefaultCellStyle.BackColor = message.isConnect ? Color.Green : Color.White;
        //            Mediator.ShowMsg(message.SrcMac + ",的" + message.SrcStetName + "听诊器" + (message.isConnect ? "连接上了..." : "断开连接..."));
        //        }
        //    }
        //}
        //public void HandleMessage(ResRemoteAuscultateCode message)
        //{
        //    Invoke(new MethodInvoker(delegate()
        //    {
        //        //Mediator.WriteLog(this.Name, string.Format("处理来自{0}远程邀请请求的回应...", message.SrcPCName));
        //        Mediator.WriteLog(this.Name, message.Comment);
        //        foreach (DataGridViewRow row in dgvYCTZ.Rows)
        //        {
        //            if (row.Cells["dgvYCTZStetMAC"].Value.ToString() == message.SrcMac && (bool)row.Cells[0].Value)
        //            {
        //                row.Cells["dgvYCTZAccept"].Value = message.isAccept ? "是" : "否";
        //                Mediator.ShowMsg(string.Format("{0}的{1}{2}了远程听诊请求", message.SrcPCName, row.Cells["StetName"].Value, message.isAccept ? "接受" : "拒绝"));
        //            }
        //        }
        //    }));
        //}
    }

}
