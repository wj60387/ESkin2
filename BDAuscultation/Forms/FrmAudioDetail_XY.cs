using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using BDAuscultation.IGetAudioInfo;
using BDAuscultation.Devices;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace BDAuscultation.Forms
{
    public partial class FrmAudioDetail_XY : Form
    {
        public FrmAudioDetail_XY()
        {
            InitializeComponent();
            this.Load += new EventHandler(FormAudioDetail_Load);
        }
        public string His { get; set; }
        public string PatientGUID { get; set; }
        public string StetName { get; set; }
        public int PatientType { get; set; }
        public int PatientGroupID { get { return Setting.authorizationInfo.GroupID; } }
        public string PatientID { get; set; }
        public string PatientName { get { return txtPatientName.Text; } set { txtPatientName.Text = value; } }
        public int PatientAge { get { return (int)numAge.Value; } set { numAge.Value = value; } }
        public string PatientSex
        {
            get { return radioButtonEx1.Checked ? "男" : "女"; }
            set
            {
                //if (!new string[] { "男", "女" }.Contains(value??"男")) throw new Exception("性别为男女,不能为" + value);
                radioButtonEx1.Checked = "男" == value;
                radioButtonEx2.Checked = "男" != value;
            }
        }
        public string DocName { get { return txtDocName.Text; } set { txtDocName.Text = value; } }
        public string DocDiagnose { get { return txtDocDiagnose.Text; } set { txtDocDiagnose.Text = value; } }
        public string DocRemark { get { return txtDocRemark.Text; } set { txtDocRemark.Text = value; } }
        void FormAudioDetail_Load(object sender, EventArgs e)
        {
            // var filePaths = Directory.GetFiles(@"Image\Part");
            dataGridViewEx1.Columns.Add(new DataGridViewImageColumn(false) { HeaderText = "缩略图" });
            dataGridViewEx1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Part", HeaderText = "部位", Width = 120 });
            dataGridViewEx1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "isRecord", HeaderText = "是否已录音", Width = 120, FillWeight = 200.0f });
            dataGridViewEx1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "RecordTime", HeaderText = "录制时间", Width = 140, FillWeight = 250.0f });
            dataGridViewEx1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TakeTime", HeaderText = "时长(秒)", Width = 40, FillWeight = 120.0f });

            dataGridViewEx1.RowTemplate.Height = 66;
            dataGridViewEx1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LoadAudio();
            dataGridViewEx1.ListColumnImage.Add(BDAuscultation.Properties.Resources.缩略图);
            dataGridViewEx1.ListColumnImage.Add(BDAuscultation.Properties.Resources.部位);
            dataGridViewEx1.ListColumnImage.Add(BDAuscultation.Properties.Resources.录音未点击状态);
            dataGridViewEx1.ListColumnImage.Add(BDAuscultation.Properties.Resources.录制时间);
            dataGridViewEx1.ListColumnImage.Add(BDAuscultation.Properties.Resources.时长);
            //if (IInfo.isPlay)
            //{
            var btnPlayColumn = new DataGridViewButtonExColumn("",
            BDAuscultation.Properties.Resources.播放点击状态, BDAuscultation.Properties.Resources.播放未点击状态)
            { Name = "btnPlay", HeaderText = "播放" };
            this.dataGridViewEx1.Columns.Add(btnPlayColumn);
            dataGridViewEx1.ListColumnImage.Add(BDAuscultation.Properties.Resources.播放未点击状态);
            //}
            LoadFile();
            dataGridViewEx1.CellClick += dataGridViewEx1_CellClick;
            //DownAudio();
            panelImages.Enabled = true;
        }

        void DownAudio()
        {
            using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
            {
                MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);

                var sqlDelLocal = "delete from AudioInfoDownXY where PGUID={0}";
                var c = Mediator.sqliteHelper.ExecuteNonQuery(sqlDelLocal, PatientGUID);
                var sqlReomte = "select * from AudioInfo where PGUID={0}";
                var dsAudioInfo = Mediator.remoteService.ExecuteDataset(sqlReomte, new string[] { PatientGUID });

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
                    string sqlInsert = @"insert into AudioInfoDownXY( GUID, PGUID, StetName , Part, TakeTime 
  , RecordTime ,UpLoadTime ) select {0},{1},{2} ,{3},{4}  ,{5},{6}";
                    var n = Mediator.sqliteHelper.ExecuteNonQuery(sqlInsert, audioInfo.GUID, audioInfo.PGUID, audioInfo.StetName, audioInfo.Part, audioInfo.TakeTime
    , audioInfo.RecordTime, audioInfo.UpLoadTime);
                    if (n > 0)
                    {
                        string fileLocalPath = Path.Combine(Setting.localData, @"DevicesData\XYDowmLoad\" + audioInfo.RecordTime.Year
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
                        Mediator.WriteLog(this.Name, string.Format("文件{0}文件下载成功", audioInfo.GUID));
                        Mediator.ShowMsg(string.Format("文件{0}下载成功...", audioInfo.GUID));
                    }
                }
                //删除本地所有
            }
        }

        void dataGridViewEx1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var part = dataGridViewEx1.Rows[e.RowIndex].Cells["Part"].Value + "";
                switch (dataGridViewEx1.Columns[e.ColumnIndex].Name)
                {

                    case "btnPlay":
                        {
                            if ((dataGridViewEx1.Rows[e.RowIndex].Cells["isRecord"].Value + "").Equals("否"))
                            {
                                MessageBox.Show("该部位未录音！");
                                return;
                            }
                            var recordTime = (DateTime)dataGridViewEx1.Rows[e.RowIndex].Cells["RecordTime"].Value;
                            var takeTime = (int)dataGridViewEx1.Rows[e.RowIndex].Cells["TakeTime"].Value;


                            var guid = getAudioGuid(part);
                           var fileRemotePath = Mediator.remoteService.GetFilePath2(recordTime, guid);
                            if(Mediator.remoteService.isExistFile(fileRemotePath))
                            {
                                var len = Mediator.remoteService.GetFileLength(fileRemotePath);
                                var bytes = Mediator.remoteService.DownLoadFile(fileRemotePath, 0, (int)len);
                                PlayAudio(bytes, takeTime);
                            }

                            //          var guid = Mediator.sqliteHelper.ExecuteScalar("select Guid from AudioInfoDownXY where PGUID={0} and Part={1}", PatientGUID, part) + "";
                            //          if (string.IsNullOrEmpty(guid))
                            //          {
                            //              MessageBox.Show("未找到录音");
                            //              return;
                            //          }
                            //          //string filePath = Path.Combine(Setting.localData, @"DevicesData\AudioFiles\" + stetName + "\\" + recordTime.Year
                            //          string filePath = Path.Combine(Setting.localData, @"DevicesData\XYDowmLoad\" + recordTime.Year
                            //+ "\\" + recordTime.Month + "\\" + recordTime.Day + "\\" + guid + ".MP3");
                            //          if (File.Exists(filePath))
                        }
                        break;
                    case "btnDelete":
                        MessageBox.Show("业务待确认,暂时不实现");
                        break;
                }

            }
        }
        string getAudioGuid(string Part)
        {
            using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
            {
                MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                var sqlReomte = "select GUID from AudioInfo where PGUID={0} and Part={1}";
                var dsAudioInfo = Mediator.remoteService.ExecuteScalar(sqlReomte, new string[] { PatientGUID,Part });
                return dsAudioInfo;
            }
                return string.Empty;
        }
        void LoadAudio()
        {
            dataGridViewEx1.Rows.Clear();
            var filePaths = Setting.PicOrder;// Directory.GetFiles(@"Image\Part");
            foreach (var file in filePaths)
            {
                dataGridViewEx1.Rows.Add(Image.FromFile(file).GetThumbnailImage(60, 66, () => { return true; }, IntPtr.Zero), Path.GetFileNameWithoutExtension(file), "否");
            }
            var dt = IInfo.GetAudioByHis(PatientGUID);
            foreach (DataGridViewRow row in dataGridViewEx1.Rows)
            {
                var part = row.Cells["Part"].Value + "";
                //var i = part.IndexOf("(");
                //if (i<0)
                //{
                //    i = part.IndexOf("（");
                //}
                var drs = dt.Select("Part='" + part + "'");
                if (drs.Length > 0)
                {
                    row.Cells["isRecord"].Value = "是";
                    row.Cells["RecordTime"].Value = drs[0]["RecordTime"];
                    row.Cells["TakeTime"].Value = drs[0]["TakeTime"];
                }
            }
        }
        public IGetInfo IInfo { get; set; }

        void PlayAudio(byte[] bytes, int TakeTime)
        {
            Mediator.isBusy = true;
            var stethoscopeArr = StethoscopeManager.StethoscopeList.Where(s => s.IsConnected);
            if (!stethoscopeArr.Any())
            {
                MessageBox.Show("目前没有检测到听诊器,请检测设备设置！");
                return;
            }
            var formProcessBar = new FrmProcessBar(true)
            {
                ProgressBarStyle = ProgressBarStyle.Continuous,
                ProgressBarMaxValue = TakeTime,
                BtnText = "停止播放"
            };
            Thread pairThread = new Thread(() =>
            {

                formProcessBar.TimerCallBackEvent += () =>
                {
                    if (this.IsHandleCreated && !this.Disposing && !this.IsDisposed)
                        Invoke(new MethodInvoker(delegate ()
                        {
                            formProcessBar.Title = string.Format("音频播放中... {0} 秒", formProcessBar.Times);
                            if (formProcessBar.Times <= formProcessBar.ProgressBarMaxValue)
                                formProcessBar.ProgressBarValue = formProcessBar.Times;
                            else
                                formProcessBar.Close();
                        }));
                };
                foreach (var stethoscope in stethoscopeArr)
                {
                    stethoscope.StartAudioOutput();
                    stethoscope.AudioOutputStream.Write(bytes, 0, bytes.Length);
                }

            });
            pairThread.Start();
            formProcessBar.ShowDialog();
            formProcessBar.TimerEnable = false;
            foreach (var stethoscope in stethoscopeArr)
            {
                stethoscope.StopAudioOutput();
            }
            Mediator.isBusy = false;
        }
        void PlayAudio(string filePath, int TakeTime)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show(string.Format("音频文件{0}不存在...", Path.GetFileName(filePath)));
                return;
            }
            Mediator.isBusy = true;
            //var stethoscopeArr = StethoscopeManager.StethoscopeList.Where(s => s.Name == StetName);
            var stethoscopeArr = StethoscopeManager.StethoscopeList.Where(s => s.IsConnected);
            if (!stethoscopeArr.Any())
                throw new Exception("目前没有检测到听诊器,请检测设备设置！");
            //var stethoscope = stethoscopeArr.First();
            //if (!stethoscope.IsConnected)
            //{
            //    MessageBox.Show(string.Format("听诊器 {0} 尚未连接!", stethoscope.Name));
            //    return;
            //}
            Mediator.ShowMsg("开始播放文件..." + Path.GetFileName(filePath));
            var formProcessBar = new FrmProcessBar(true)
            {
                ProgressBarStyle = ProgressBarStyle.Continuous,
                ProgressBarMaxValue = TakeTime,
                BtnText = "停止播放"
            };
            Thread pairThread = new Thread(() =>
            {

                formProcessBar.TimerCallBackEvent += () =>
                {
                    if (this.IsHandleCreated && !this.Disposing && !this.IsDisposed)
                        Invoke(new MethodInvoker(delegate ()
                        {
                            formProcessBar.Title = string.Format("音频播放中... {0} 秒", formProcessBar.Times);
                            if (formProcessBar.Times <= formProcessBar.ProgressBarMaxValue)
                                formProcessBar.ProgressBarValue = formProcessBar.Times;
                            else
                                formProcessBar.Close();
                        }));
                };
                var bytes = File.ReadAllBytes(filePath);
                foreach (var stethoscope in stethoscopeArr)
                {
                    stethoscope.StartAudioOutput();
                    stethoscope.AudioOutputStream.Write(bytes, 0, bytes.Length);
                }

            });
            pairThread.Start();
            formProcessBar.ShowDialog();
            formProcessBar.TimerEnable = false;
            foreach (var stethoscope in stethoscopeArr)
            {
                stethoscope.StopAudioOutput();
            }
            Mediator.ShowMsg("播放文件完毕..." + Path.GetFileName(filePath));
            Mediator.WriteLog(this.Name, string.Format("文件 {0} 播放成功...", Path.GetFileName(filePath)));
            Mediator.isBusy = false;
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            //var formFJ = new FormFJ(this.PatientGUID) { IFJ = getFJ(), isUpLoadVisable = false, isOpenFolderVisable = isOpenBtnVisable() };
            //formFJ.ShowDialog();
        }

        void LoadFile()
        {
            var imageList = IInfo.GetImage(this.PatientGUID);
            foreach (var image in imageList)
            {
                var thumbnailImage = image.GetThumbnailImage(panelImages.Height, panelImages.Height, () => { return true; }, IntPtr.Zero);
                Panel panel = new Panel() { BackgroundImage = thumbnailImage, Tag = image.Clone(), Size = thumbnailImage.Size };
                panel.DoubleClick += (sender, e) =>
                    {
                        var imageTag = ((Panel)sender).Tag as Image;
                        var guid = Guid.NewGuid().ToString();
                        var filePath = string.Format("Enclosure\\Temp\\{0}", guid + ".png");
                        if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                        }
                        imageTag.Save(filePath);
                        if (File.Exists(filePath))
                            System.Diagnostics.Process.Start(filePath);
                    };
                panel.Dock = DockStyle.Left;
                panelImages.Controls.Add(panel);
            }
        }


        IGetFJ getFJ()
        {
            if (IInfo is LocalDown)
                return new LoaclDown();
            if (IInfo is CloudUpload)
                return new CloudReocrd();
            return new CloudDown();

        }
        bool isOpenBtnVisable()
        {
            if (IInfo is LocalDown)
                return true;
            return false;
        }



    }
}
