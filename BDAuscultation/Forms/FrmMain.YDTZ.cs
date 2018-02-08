using BDAuscultation.Devices;
using BDAuscultation.Forms;
using BDAuscultation.IGetAudioInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Windows.Forms;

namespace BDAuscultation
{
    /// <summary>
    /// 听诊录音
    /// </summary>
    partial class FrmMain
    {
        void InitdgvYDTZ()
        { 
            cbBoxYDTZ.DropDown += cbBoxYDTZ_DropDown;
            cbBoxYDTZ.SelectedIndexChanged += cbBoxYDTZ_SelectedIndexChanged;
            this.btnUpload.Click += btnUpload_Click;
            this.btnShare.Click += btnShare_Click;
            LoadYDTZStet();
            //列点击事件
            dgvYDTZUpLoad.CellClick += dgvYDTZUpLoad_CellClick;
            dgvYDTZShare.CellClick += dgvYDTZShare_CellClick;
            //列设置
            //dgvYDTZUpLoad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dgvYDTZShare.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            var btnDownUpLoadColumn = new DataGridViewButtonExColumn("",
               BDAuscultation.Properties.Resources.下载点击状态, BDAuscultation.Properties.Resources.下载)
            {
                Name = "dgvYDTZUpLoadDown",
                HeaderText = "下载",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 70
            };
            this.dgvYDTZUpLoad.Columns.Add(btnDownUpLoadColumn);
            var btnShareUpLoadColumn = new DataGridViewButtonExColumn("",
              BDAuscultation.Properties.Resources.分享点击状态, BDAuscultation.Properties.Resources.分享未点击)
            {
                Name = "dgvYDTZUpLoadShare",
                HeaderText = "分享",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 70
            };
            this.dgvYDTZUpLoad.Columns.Add(btnShareUpLoadColumn);

            var btnDetailUpLoadColumn = new DataGridViewButtonExColumn("",
               BDAuscultation.Properties.Resources.详情点击状态, BDAuscultation.Properties.Resources.详情未点击) 
               { Name = "dgvYDTZLoaclDetail", HeaderText = "详情",
               AutoSizeMode= DataGridViewAutoSizeColumnMode.None,Width=70};
            this.dgvYDTZUpLoad.Columns.Add(btnDetailUpLoadColumn);
            //var btnDelUpLoadColumn = new DataGridViewButtonExColumn("",
            //    BDAuscultation.Properties.Resources.删除点击状态, BDAuscultation.Properties.Resources.删除未点击)
            //    { Name = "dgvYDTZLoaclDelete", HeaderText = "删除" };
            //this.dgvYDTZUpLoad.Columns.Add(btnDelUpLoadColumn);

            dgvYDTZUpLoad.ListColumnImage.Add(null);
            dgvYDTZUpLoad.ListColumnImage.Add(BDAuscultation.Properties.Resources.患者类型);
            dgvYDTZUpLoad.ListColumnImage.Add(BDAuscultation.Properties.Resources.患者姓名);
            dgvYDTZUpLoad.ListColumnImage.Add(BDAuscultation.Properties.Resources.医生姓名);
            dgvYDTZUpLoad.ListColumnImage.Add(BDAuscultation.Properties.Resources.初步诊断);
            dgvYDTZUpLoad.ListColumnImage.Add(BDAuscultation.Properties.Resources.备注);
            dgvYDTZUpLoad.ListColumnImage.Add(BDAuscultation.Properties.Resources.上传时间);
            dgvYDTZUpLoad.ListColumnImage.Add(BDAuscultation.Properties.Resources.下载);
            dgvYDTZUpLoad.ListColumnImage.Add(BDAuscultation.Properties.Resources.分享);
            dgvYDTZUpLoad.ListColumnImage.Add(BDAuscultation.Properties.Resources.详情);


            //列头图标
            

            var btnDownShareColumn = new DataGridViewButtonExColumn("",
              BDAuscultation.Properties.Resources.下载点击状态, BDAuscultation.Properties.Resources.下载)
            {
                Name = "dgvYDTZShareDown",
                HeaderText = "下载",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 60
            };
            this.dgvYDTZShare.Columns.Add(btnDownShareColumn);
            var btnDetailShareColumn = new DataGridViewButtonExColumn("",
               BDAuscultation.Properties.Resources.详情点击状态, BDAuscultation.Properties.Resources.详情未点击)
            {
                Name = "dgvYDTZShareDetail",
                HeaderText = "详情",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 60
            };
            this.dgvYDTZShare.Columns.Add(btnDetailShareColumn);
            //var btnDelShareColumn = new DataGridViewButtonExColumn("",
            //    BDAuscultation.Properties.Resources.删除点击状态, BDAuscultation.Properties.Resources.删除未点击)
            //    { Name = "dgvYDTZShareDelete", HeaderText = "删除" };
            //this.dgvYDTZShare.Columns.Add(btnDelShareColumn);
            dgvYDTZShare.ListColumnImage.Add(null);
            dgvYDTZShare.ListColumnImage.Add(BDAuscultation.Properties.Resources.患者类型);
            dgvYDTZShare.ListColumnImage.Add(BDAuscultation.Properties.Resources.患者姓名);
            dgvYDTZShare.ListColumnImage.Add(BDAuscultation.Properties.Resources.医生姓名);
            dgvYDTZShare.ListColumnImage.Add(BDAuscultation.Properties.Resources.初步诊断);
            dgvYDTZShare.ListColumnImage.Add(BDAuscultation.Properties.Resources.备注);
            dgvYDTZShare.ListColumnImage.Add(BDAuscultation.Properties.Resources.患者姓名);
            dgvYDTZShare.ListColumnImage.Add(BDAuscultation.Properties.Resources.分享时间);
            dgvYDTZShare.ListColumnImage.Add(BDAuscultation.Properties.Resources.下载);
            dgvYDTZShare.ListColumnImage.Add(BDAuscultation.Properties.Resources.详情);

            


        }

        void dgvYDTZShare_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var PGUID = dgvYDTZShare.Rows[e.RowIndex].Cells[0].Value + "";
            var PatientType = Setting.GetPatientTypeByName(dgvYDTZShare.Rows[e.RowIndex].Cells[1].Value + "");
            var PatientID = dgvYDTZShare.Rows[e.RowIndex].Cells[2].Value + "";
            var PatientName = dgvYDTZShare.Rows[e.RowIndex].Cells[3].Value + "";
            switch (dgvYDTZShare.Columns[e.ColumnIndex].Name)
            {
                case "dgvYDTZShareDown":
                    {
                        using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
                        {
                            MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                            OperationContext.Current.OutgoingMessageHeaders.Add(header);
                            header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                            OperationContext.Current.OutgoingMessageHeaders.Add(header);
                            #region 下载患者信息
                            string sqlPatient = @" select a.*,b.SrcStetName,b.ToStetName,b.ShareTime from PatientInfo a inner join AudioShare b
  on a.PatientGUID=b.PatientGUID where a.PatientGUID={0} and b.ToStetName={1}";
                            var ds = Mediator.remoteService.ExecuteDataset(sqlPatient, new string[] { PGUID, this.cbBoxYDTZ.Text });
                            var r = ds.Tables[0].Rows[0];
                            var patientInfo = new
                            {
                                PatientGroupID = (int)r["PatientGroupID"],
                                DocName = r["DocName"] + "",
                                DocDiagnose = r["DocDiagnose"] + "",
                                DocRemark = r["DocRemark"] + "",
                                Flag = r["Flag"] + "",
                                Sharer = r["SrcStetName"] + "",
                                ShareTime = (DateTime)r["ShareTime"],
                            };
                            var sqlQueryDown = "select count(0) from PatientInfoDown where PatientGUID={0} and Downer={1}";
                            if (int.Parse(Mediator.sqliteHelper.ExecuteScalar(sqlQueryDown, PGUID, this.cbBoxYDTZ.Text).ToString()) == 0)
                            {
                                //下载别人分享的
                                var h = Mediator.sqliteHelper.ExecuteNonQuery(@"insert into PatientInfoDown(PatientGUID,PatientType,PatientGroupID ,PatientID,PatientName 
  ,DocName,DocDiagnose,DocRemark,Flag,Sharer,ShareTime,Downer ) select {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", PGUID, PatientType, patientInfo.PatientGroupID, PatientID, PatientName
 , patientInfo.DocName, patientInfo.DocDiagnose, patientInfo.DocRemark, patientInfo.Flag, patientInfo.Sharer, patientInfo.ShareTime, this.cbBoxYDTZ.Text);
                                if (h > 0) Mediator.ShowMsg(string.Format("患者{0}信息下载成功...", PatientName));
                                else return;
                            }
                            else
                            {
                                var h = Mediator.sqliteHelper.ExecuteNonQuery(@"update PatientInfoDown set DocName={0}, DocDiagnose={1},DocRemark={2}
  where PatientGUID={3}", patientInfo.DocName, patientInfo.DocDiagnose, patientInfo.DocRemark, PGUID);
                                // if (h > 0) Mediator.ShowMsg(string.Format("患者{0}信息更新成功...", PatientName));
                                if (h <= 0) return;
                            }
                            //写下载记录
                            string sqlInsertDownLog = "insert into AudioDownLoadInfo (GUID,Downer) select {0},{1}";
                            Mediator.remoteService.ExecuteNonQuery(sqlInsertDownLog, new string[] { PGUID, this.cbBoxYDTZ.Text });

                            #endregion
                            #region  下载录音信息 每次覆盖下载 保证最新
                            var sqlDelLocal = "delete from AudioInfoDown where PGUID={0} ";
                            var c = Mediator.sqliteHelper.ExecuteNonQuery(sqlDelLocal, PGUID);
                            var sqlReomte = "select * from AudioInfo where PGUID={0}  ";
                            var dsAudioInfo = Mediator.remoteService.ExecuteDataset(sqlReomte, new string[] { PGUID });
                            foreach (DataRow row in dsAudioInfo.Tables[0].Rows)
                            {
                                var audioInfo = new
                                {
                                    GUID = row["GUID"] + "",
                                    PGUID = row["PGUID"] + "",
                                    StetName = row["StetName"] + "",
                                    Part = row["Part"] + "",
                                    TakeTime = (int)row["TakeTime"],
                                    RecordTime = (DateTime)row["RecordTime"],
                                    UpLoadTime = (DateTime)row["CreateTime"],
                                };
                                string sqlInsert = @"insert into AudioInfoDown( GUID, PGUID, StetName , Part, TakeTime 
  , RecordTime, UpLoadTime ) select {0},{1},{2} ,{3},{4}  ,{5},{6}";
                                var n = Mediator.sqliteHelper.ExecuteNonQuery(sqlInsert, audioInfo.GUID, audioInfo.PGUID, audioInfo.StetName, audioInfo.Part, audioInfo.TakeTime
, audioInfo.RecordTime, audioInfo.UpLoadTime);
                                if (n > 0)
                                {
                                    string fileLocalPath = Path.Combine(Setting.localData, @"DevicesData\DowmLoad\" + audioInfo.RecordTime.Year
                  + "\\" + audioInfo.RecordTime.Month + "\\" + audioInfo.RecordTime.Day + "\\" + audioInfo.GUID + ".MP3");
                                    if (File.Exists(fileLocalPath))
                                    {
                                        File.Delete(fileLocalPath);
                                    }
                                    var fileRemotePath = Mediator.remoteService.GetFilePath2(audioInfo.RecordTime, audioInfo.GUID);
                                    var fileSize = Mediator.remoteService.GetFileLength(fileRemotePath);
                                    //下载文件
                                    if (!Directory.Exists(Path.GetDirectoryName(fileLocalPath)))
                                    {
                                        Directory.CreateDirectory(Path.GetDirectoryName(fileLocalPath));
                                    }
                                    using (var stream = new FileStream(fileLocalPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                                    {
                                        long position = 0;
                                        while (position < fileSize)
                                        {
                                            var bytes = Mediator.remoteService.DownLoadFile(fileRemotePath, position, 24 * 1024);
                                            position += bytes.Length;
                                            stream.Write(bytes, 0, bytes.Length);
                                        }
                                        stream.Close();

                                    }
                                    Mediator.WriteLog(this.Name, string.Format("文件{0}文件下载成功,下载的听诊器序号为{1}...", audioInfo.GUID, this.cbBoxYDTZ.Text));
                                    Mediator.ShowMsg(string.Format("文件{0}下载成功...", audioInfo.GUID));
                                }
                            }
                            #endregion

                            //下载附件
                            var remoteRoot = Mediator.remoteService.GetRoot();
                            var remoteDir = Path.Combine(remoteRoot, string.Format("Enclosure\\{0}", PGUID));
                            if (Mediator.remoteService.isExistFolder(remoteDir))
                            {
                                var remoteFiles = Mediator.remoteService.GetFolderFiles(remoteDir, "*.*", true);

                                var localFiles = Directory.GetFiles(string.Format("Enclosure\\Down\\{0}", PGUID));


                                if (remoteFiles != null)
                                {
                                    foreach (var file in localFiles)
                                    {
                                        if (!remoteFiles.Select(f => Path.GetFileName(f)).Contains(Path.GetFileName(file)))
                                        {
                                            File.Delete(file);
                                        }
                                    }
                                    foreach (var remoteFile in remoteFiles)
                                    {
                                        var fileSize = Mediator.remoteService.GetFileLength(remoteFile);
                                        var fileLocalPath = string.Format("Enclosure\\Down\\{0}\\{1}", PGUID, Path.GetFileName(remoteFile));
                                        if (!Directory.Exists(Path.GetDirectoryName(fileLocalPath)))
                                        {
                                            Directory.CreateDirectory(Path.GetDirectoryName(fileLocalPath));
                                        }
                                        if (File.Exists(fileLocalPath))
                                        {
                                            File.Delete(fileLocalPath);
                                        }
                                        using (var stream = new FileStream(fileLocalPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                                        {
                                            long position = 0;
                                            while (position < fileSize)
                                            {
                                                var bytes = Mediator.remoteService.DownLoadFile(remoteFile, position, 24 * 1024);
                                                position += bytes.Length;
                                                stream.Write(bytes, 0, bytes.Length);
                                            }
                                            stream.Close();

                                        }
                                    }
                                }
                                Mediator.ShowMsg("下载完毕！");
                            }

                        }
                    }
                    break;
                case "dgvYDTZShareDetail":
                    {
                        using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
                        {
                            MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                            OperationContext.Current.OutgoingMessageHeaders.Add(header);
                            header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                            OperationContext.Current.OutgoingMessageHeaders.Add(header);
                            var ds = Mediator.remoteService.ExecuteDataset("select * from PatientInfo where PatientGUID={0}", new string[] { PGUID });
                            var row = ds.Tables[0].Rows[0];
                            var formAudioDetail = new FrmAudioDetail()
                            {
                                PatientGUID = row["PatientGUID"] + "",
                                PatientID = row["PatientID"] + "",
                                PatientName = row["PatientName"] + "",
                                DocName = row["DocName"] + "",
                                PatientSex = row["PatientSex"] + "",
                                PatientAge = int.Parse("0"+row["PatientAge"]),
                                DocDiagnose = row["DocDiagnose"] + "",
                                DocRemark = row["DocRemark"] + "",
                                His = row["Flag"] + "",
                                IInfo = new CloudShare()
                            };
                            formAudioDetail.ShowDialog();
                        }
                    }
                    break;
                case "dgvYDTZShareDelete":
                    if (DialogResult.OK == MessageBox.Show("你确定要删除该分享记录吗", "删除分享记录提示", MessageBoxButtons.OKCancel))
                    {
                        using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
                        {
                            MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                            OperationContext.Current.OutgoingMessageHeaders.Add(header);
                            header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                            OperationContext.Current.OutgoingMessageHeaders.Add(header);
                            var k = Mediator.remoteService.ExecuteNonQuery("delete from AudioShare where PatientGUID={0} and ToStetName={1}", new string[] { PGUID, this.cbBoxYDTZ.Text });
                            if (k > 0)
                            {

                                dgvYDTZShare.Rows.RemoveAt(e.RowIndex);
                                MessageBox.Show("删除分享记录成功...");
                            }
                        }

                    }
                    break;
            }
        }

        void dgvYDTZUpLoad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!Setting.isConnected)
            {
                MessageBox.Show("网络连接异常...");
                return;
            }
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var PGUID = dgvYDTZUpLoad.Rows[e.RowIndex].Cells[0].Value + "";
                var PatientType = Setting.GetPatientTypeByName(dgvYDTZUpLoad.Rows[e.RowIndex].Cells[1].Value + "");
                var PatientName = dgvYDTZUpLoad.Rows[e.RowIndex].Cells[2].Value + "";
                //var CreateTime = (DateTime)dgvYDTZUpLoad.Rows[e.RowIndex].Cells[6].Value;
                switch (dgvYDTZUpLoad.Columns[e.ColumnIndex].Name)
                {

                    case "dgvYDTZUpLoadDown":
                        {
                            Mediator.ShowMsg("开始下载已上传的录音文件...");
                            using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
                            {
                                MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                                header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                                #region 下载患者信息
                                string sqlPatient = "select * from PatientInfo where PatientGUID={0}";
                                var ds = Mediator.remoteService.ExecuteDataset(sqlPatient, new string[] { PGUID });
                                if (ds.Tables[0].Rows.Count == 0)
                                {
                                    MessageBox.Show("分享信息 " + PGUID + " 被分享者删除了...");
                                    return;
                                }
                                var r = ds.Tables[0].Rows[0];
                                var patientInfo = new
                                {
                                    StetName = r["StetName"] + "",
                                    PatientGroupID = (int)r["PatientGroupID"],
                                    PatientID = r["PatientID"] + "",
                                    PatientName = r["PatientName"] + "",
                                    PatientSex = r["PatientSex"] + "",
                                    PatientAge = (int)r["PatientAge"],
                                    DocName = r["DocName"] + "",
                                    DocDiagnose = r["DocDiagnose"] + "",
                                    DocRemark = r["DocRemark"] + "",
                                    Flag = r["Flag"] + "",
                                };
                                var sqlQueryDown = "select count(0) from PatientInfoDown where PatientGUID={0} and Downer={1}";
                                if (int.Parse(Mediator.sqliteHelper.ExecuteScalar(sqlQueryDown, PGUID, this.cbBoxYDTZ.Text).ToString()) == 0)
                                {
                                    //下载自己上传的听诊  分享者=自己
                                    var h = Mediator.sqliteHelper.ExecuteNonQuery(@"insert into PatientInfoDown(PatientGUID,StetName,PatientType,PatientGroupID ,PatientID,PatientName ,PatientSex,PatientAge
  ,DocName,DocDiagnose,DocRemark,Flag,Sharer,ShareTime,Downer ) select {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", PGUID, patientInfo.StetName, PatientType, patientInfo.PatientGroupID, patientInfo.PatientID, patientInfo.PatientName, patientInfo.PatientSex, patientInfo.PatientAge
     , patientInfo.DocName, patientInfo.DocDiagnose, patientInfo.DocRemark, patientInfo.Flag, null, null, this.cbBoxYDTZ.Text);
                                    if (h > 0) Mediator.ShowMsg(string.Format("患者{0}信息下载成功...", patientInfo.PatientName));
                                    else return;
                                }
                                else
                                {
                                    var h = Mediator.sqliteHelper.ExecuteNonQuery(@"update PatientInfoDown set DocName={0}, DocDiagnose={1},DocRemark={2},PatientID={4},PatientName={5},Flag={6} ,PatientSex={7},PatientAge={8}
  where PatientGUID={3}", patientInfo.DocName, patientInfo.DocDiagnose, patientInfo.DocRemark, PGUID, patientInfo.PatientSex, patientInfo.PatientAge);
                                    // if (h > 0) Mediator.ShowMsg(string.Format("患者{0}信息更新成功...", PatientName));
                                    if (h <= 0) return;
                                }
                                //写下载记录
                                string sqlInsertDownLog = "insert into AudioDownLoadInfo (GUID,Downer) select {0},{1}";
                                Mediator.remoteService.ExecuteNonQuery(sqlInsertDownLog, new string[] { PGUID, this.cbBoxYDTZ.Text });

                                #endregion
                                #region  下载录音信息 每次覆盖下载 保证最新
                                var sqlDelLocal = "delete from AudioInfoDown where PGUID={0}";
                                var c = Mediator.sqliteHelper.ExecuteNonQuery(sqlDelLocal, PGUID);
                                var sqlReomte = "select * from AudioInfo where PGUID={0}";
                                var dsAudioInfo = Mediator.remoteService.ExecuteDataset(sqlReomte, new string[] { PGUID });

                                foreach (DataRow row in dsAudioInfo.Tables[0].Rows)
                                {
                                    var audioInfo = new
                                    {
                                        GUID = row["GUID"] + "",
                                        PGUID = row["PGUID"] + "",
                                        StetName = row["StetName"] + "",
                                        Part = row["Part"] + "",
                                        TakeTime = (int)row["TakeTime"],
                                        RecordTime = (DateTime)row["RecordTime"],
                                        UpLoadTime = (DateTime)row["CreateTime"],
                                    };
                                    string sqlInsert = @"insert into AudioInfoDown( GUID, PGUID, StetName , Part, TakeTime 
  , RecordTime ,UpLoadTime ) select {0},{1},{2} ,{3},{4}  ,{5},{6}";
                                    var n = Mediator.sqliteHelper.ExecuteNonQuery(sqlInsert, audioInfo.GUID, audioInfo.PGUID, audioInfo.StetName, audioInfo.Part, audioInfo.TakeTime
  , audioInfo.RecordTime, audioInfo.UpLoadTime);
                                    if (n > 0)
                                    {
                                        string fileLocalPath = Path.Combine(Setting.localData, @"DevicesData\DowmLoad\" + audioInfo.RecordTime.Year
                      + "\\" + audioInfo.RecordTime.Month + "\\" + audioInfo.RecordTime.Day + "\\" + audioInfo.GUID + ".MP3");
                                        if (File.Exists(fileLocalPath))
                                        {
                                            File.Delete(fileLocalPath);
                                        }
                                        var fileRemotePath = Mediator.remoteService.GetFilePath2(audioInfo.RecordTime, audioInfo.GUID);
                                        var fileSize = Mediator.remoteService.GetFileLength(fileRemotePath);
                                        //下载文件
                                        if (!Directory.Exists(Path.GetDirectoryName(fileLocalPath)))
                                        {
                                            Directory.CreateDirectory(Path.GetDirectoryName(fileLocalPath));
                                        }
                                        using (var stream = new FileStream(fileLocalPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                                        {
                                            long position = 0;
                                            while (position < fileSize)
                                            {
                                                var bytes = Mediator.remoteService.DownLoadFile(fileRemotePath, position, 24 * 1024);
                                                position += bytes.Length;
                                                stream.Write(bytes, 0, bytes.Length);
                                            }
                                            stream.Close();

                                        }
                                        Mediator.WriteLog(this.Name, string.Format("文件{0}文件下载成功,下载的听诊器序号为{1}...", audioInfo.GUID, this.cbBoxYDTZ.Text));
                                        Mediator.ShowMsg(string.Format("文件{0}下载成功...", audioInfo.GUID));
                                    }
                                }
                                //删除本地所有
                                #endregion
                                #region 更新下载记录

                                #endregion

                                //下载附件
                                var remoteRoot = Mediator.remoteService.GetRoot();
                                var remoteDir = Path.Combine(remoteRoot, string.Format("Enclosure\\{0}", PGUID));
                                if (Mediator.remoteService.isExistFolder(remoteDir))
                                {
                                    var remoteFiles = Mediator.remoteService.GetFolderFiles(remoteDir, "*.*", true);
                                    if (remoteFiles != null)
                                    {
                                        foreach (var remoteFile in remoteFiles)
                                        {
                                            var fileSize = Mediator.remoteService.GetFileLength(remoteFile);
                                            var fileLocalPath = string.Format("Enclosure\\Down\\{0}\\{1}", PGUID, Path.GetFileName(remoteFile));
                                            if (!Directory.Exists(Path.GetDirectoryName(fileLocalPath)))
                                            {
                                                Directory.CreateDirectory(Path.GetDirectoryName(fileLocalPath));
                                            }
                                            using (var stream = new FileStream(fileLocalPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                                            {
                                                long position = 0;
                                                while (position < fileSize)
                                                {
                                                    var bytes = Mediator.remoteService.DownLoadFile(remoteFile, position, 24 * 1024);
                                                    position += bytes.Length;
                                                    stream.Write(bytes, 0, bytes.Length);
                                                }
                                                stream.Close();

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "dgvYDTZUpLoadShare":
                        {
                            using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
                            {
                                MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                                header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                                var formShare = new FrmShare(this.cbBoxYDTZ.Text);
                                if (formShare.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    var selectStets = formShare.SelectedStethoscope;
                                    string sql = "SELECT * from  AudioShare where SrcStetName={0} and PatientGUID={1}";
                                    var ds = Mediator.remoteService.ExecuteDataset(sql, new string[] { this.cbBoxYDTZ.Text, PGUID, });
                                    string insertSql = "insert into AudioShare(PatientGUID,PatientType,PatientName,SrcStetName,ToStetName) select {0},{1},{2},{3},{4}";
                                    foreach (var toName in formShare.SelectedStethoscope)
                                    {
                                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Select("ToStetName='" + toName + "'").Length > 0)
                                        {
                                            Mediator.ShowMsg(string.Format("患者{0}听诊记录已经被{1}分享过给{2}了...", PatientName, this.cbBoxYDTZ.Text, toName));
                                            continue;
                                        }
                                        int n = Mediator.remoteService.ExecuteNonQuery(insertSql, new string[] { PGUID, PatientType + "", PatientName, this.cbBoxYDTZ.Text, toName });
                                        if (n > 0)
                                            Mediator.ShowMsg(string.Format("患者{0}听诊记录成功被{1}分享给{2}...", PatientName, this.cbBoxYDTZ.Text, toName));
                                        Mediator.WriteLog(this.Name, string.Format("患者{0}听诊记录被{1}分享给{2}...", PatientName, this.cbBoxYDTZ.Text, toName));

                                    }

                                }
                            }
                        }
                        break;

                    case "dgvYDTZLoaclDetail":
                        {
                            using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
                            {
                                MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                                header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                                var ds = Mediator.remoteService.ExecuteDataset("select * from PatientInfo where PatientGUID={0}", new string[] { PGUID });
                                var row = ds.Tables[0].Rows[0];
                                var formAudioDetail = new FrmAudioDetail()
                                {
                                    PatientGUID = row["PatientGUID"] + "",
                                    PatientID = row["PatientID"] + "",
                                    PatientName = row["PatientName"] + "",
                                    PatientSex = row["PatientSex"] + "",
                                    PatientAge = (int)row["PatientAge"],
                                    DocName = row["DocName"] + "",
                                    DocDiagnose = row["DocDiagnose"] + "",
                                    DocRemark = row["DocRemark"] + "",
                                    His = row["Flag"] + "",

                                    IInfo = new CloudUpload()
                                };
                                formAudioDetail.ShowDialog();
                            }
                        }
                        break;
                    case "dgvYDTZLoaclDelete":
                        if (DialogResult.OK == MessageBox.Show("你确定要删除该记录及其文件吗", "删除录音提示", MessageBoxButtons.OKCancel))
                        {
                            using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
                            {
                                MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                                header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                                var k = Mediator.remoteService.ExecuteNonQuery("delete from PatientInfo where PatientGUID={0}", new string[] { PGUID });
                                if (k > 0)
                                {
                                    dgvYDTZUpLoad.Rows.RemoveAt(e.RowIndex);
                                    MessageBox.Show("删除上传记录成功...");
                                }
                            }
                        }
                        break;
                }
            }
        }

        void cbBoxYDTZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbBoxYDTZ.Text))
            {
                if (tabControlYDTZMain.SelectedTab != null)
                {
                    UpdateDataYDTZ(cbBoxYDTZ.Text, tabControlYDTZMain.SelectedTab.Name);
                    Mediator.ShowMsg(string.Format("刷新听诊器{0}   数据", cbBoxYDTZ.Text));
                }
            }
        }
        
        public void UpdateDataYDTZ(string stetName, string tabPageName)
        {
            if (string.IsNullOrEmpty(stetName)) return;
             
            switch (tabPageName)
            {

                case "tabYDTZUpLoad":
                    {
                        if (!Setting.isConnected)
                        {
                            MessageBox.Show("网络连接异常...");
                            return;
                        }

                        dgvYDTZUpLoad.Rows.Clear();
                        string sql = @"select * from PatientInfo where StetName={0} order by CreateTime desc";
                        using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
                        {
                            MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                            OperationContext.Current.OutgoingMessageHeaders.Add(header);
                            header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                            OperationContext.Current.OutgoingMessageHeaders.Add(header);
                            var ds = Mediator.remoteService.ExecuteDataset(sql, new string[] { cbBoxYDTZ.Text });
                            if (ds != null && ds.Tables.Count > 0)
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    dgvYDTZUpLoad.Rows.Add(dr["PatientGUID"] + ""
                                    , Setting.GetPatientNameByType(int.Parse(dr["PatientType"] + ""))
                                    , dr["PatientName"] + ""
                                    ,dr["DocName"], dr["DocDiagnose"], dr["DocRemark"]
                                    , dr["CreateTime"]
                                    );
                                }

                            Mediator.WriteLog(this.Name, string.Format("刷新已上载数据,执行的sql语句是{0},参数是:{1}...", sql, cbBoxYDTZ.Text));


                        }
                    }
                    break;
                case "tabYDTZShare":
                    {
                        if (!Setting.isConnected)
                        {
                            MessageBox.Show("网络连接异常...");
                            return;
                        }

                        dgvYDTZShare.Rows.Clear();
                        //                      string sql = @"select b.*,a.PatientID,a.Flag from AudioShare b left join PatientInfo a
                        //on a.PatientGUID=b.PatientGUID  where b.ToStetName={0} order by b.ShareTime desc";
                        string sql = @"select b.*,a.PatientID,a.Flag,a.DocName,a.DocDiagnose,a.DocRemark from AudioShare b left join PatientInfo a
  on a.PatientGUID=b.PatientGUID  where b.ToStetName={0} order by b.ShareTime desc";
                        using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
                        {
                            MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                            OperationContext.Current.OutgoingMessageHeaders.Add(header);
                            header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                            OperationContext.Current.OutgoingMessageHeaders.Add(header);
                            var ds = Mediator.remoteService.ExecuteDataset(sql, new string[] { cbBoxYDTZ.Text });
                            if (ds != null && ds.Tables.Count > 0)
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    dgvYDTZShare.Rows.Add(
                                        dr["PatientGUID"] + ""
                                    , Setting.GetPatientNameByType(int.Parse(dr["PatientType"] + ""))
                                    , dr["PatientName"] + ""
                                    , dr["DocName"], dr["DocDiagnose"], dr["DocRemark"]
                                    , dr["SrcStetName"] + ""
                                    , dr["ShareTime"]
                                    );
                                }
                            Mediator.WriteLog(this.Name, string.Format("刷新分享给我数据数据,执行的sql语句是{0},参数是:{1}...", sql, cbBoxYDTZ.Text));

                        }
                    }
                    break;

            }
        }
        void LoadYDTZStet()
        {
            cbBoxYDTZ.Items.Clear();
            foreach (var item in StethoscopeManager.StethoscopeList)
            {
                var stetInfo = Setting.GetStetInfoByStetName(item.Name);
#if !DEBUG
                if (item.IsConnected)
#endif
                cbBoxYDTZ.Items.Add(item.Name);
            }
            if (cbBoxYDTZ.Items.Count > 0)
                cbBoxYDTZ.SelectedIndex = 0;
        }
        void cbBoxYDTZ_DropDown(object sender, EventArgs e)
        {
            LoadYDTZStet();
        }

        void btnShare_Click(object sender, EventArgs e)
        {
            this.tabControlYDTZMain.SelectedTab = tabYDTZShare;

            btnShare.HoverColor = btnShare.PressColor = btnShare.NormalColor = Color.Gray;
            btnUpload.HoverColor = btnUpload.PressColor = btnUpload.NormalColor = Color.FromArgb(200, 200, 200);
            UpdateDataYDTZ(cbBoxYDTZ.Text, tabControlYDTZMain.SelectedTab.Name);
        }

        void btnUpload_Click(object sender, EventArgs e)
        {
            this.tabControlYDTZMain.SelectedTab = tabYDTZUpLoad;
            btnUpload.HoverColor = btnUpload.PressColor = btnUpload.NormalColor = Color.Gray;
            btnShare.HoverColor = btnShare.PressColor = btnShare.NormalColor = Color.FromArgb(200, 200, 200);
            UpdateDataYDTZ(cbBoxYDTZ.Text, tabControlYDTZMain.SelectedTab.Name);
        }

         
         
    }

}
