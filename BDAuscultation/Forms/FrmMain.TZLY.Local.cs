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
        void InitdgvTZLY()
        {
            this.btnTZLY.Click += btnTZLY_Click;
            this.cbBoxTZLY.SelectedIndexChanged += cbBoxTZLY_SelectedIndexChanged;
            this.cbBoxTZLY.DropDown += cbBoxTZLY_DropDown;
            this.btnLYLocal.Click += btnLYLocal_Click;
            this.btnLYDown.Click += btnLYDown_Click;

            this.tabLY.SelectedIndexChanged += tabLY_SelectedIndexChanged;

            //列点击事件
            dgvTZLY_Local.CellClick += dgvTZLY_Local_CellClick;
            dgvTZLY_Down.CellClick += dgvTZLY_Down_CellClick;
            //列设置
            //dgvTZLY_Local.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dgvTZLY_Down.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            var btnDetailLocalColumn = new DataGridViewButtonExColumn("",
               BDAuscultation.Properties.Resources.详情点击状态, BDAuscultation.Properties.Resources.详情未点击) 
               { Name = "dgvTZLYLoaclDetail", HeaderText = "详情" };
            this.dgvTZLY_Local.Columns.Add(btnDetailLocalColumn);
            var btnDelLoaclColumn = new DataGridViewButtonExColumn("",
                BDAuscultation.Properties.Resources.删除点击状态, BDAuscultation.Properties.Resources.删除未点击)
                { Name = "dgvTZLYLoaclDelete", HeaderText = "删除" };
            this.dgvTZLY_Local.Columns.Add(btnDelLoaclColumn);
             dgvTZLY_Local.ListColumnImage.Add(null);
            dgvTZLY_Local.ListColumnImage.Add(BDAuscultation.Properties.Resources.患者类型);
            dgvTZLY_Local.ListColumnImage.Add(BDAuscultation.Properties.Resources.患者姓名);
            dgvTZLY_Local.ListColumnImage.Add(BDAuscultation.Properties.Resources.医生姓名);
            dgvTZLY_Local.ListColumnImage.Add(BDAuscultation.Properties.Resources.初步诊断);
            dgvTZLY_Local.ListColumnImage.Add(BDAuscultation.Properties.Resources.备注);
            dgvTZLY_Local.ListColumnImage.Add(BDAuscultation.Properties.Resources.下载时间);
            dgvTZLY_Local.ListColumnImage.Add(BDAuscultation.Properties.Resources.详情未点击);
            dgvTZLY_Local.ListColumnImage.Add(BDAuscultation.Properties.Resources.删除未点击);

            var btnDetailDownColumn = new DataGridViewButtonExColumn("",
              BDAuscultation.Properties.Resources.详情点击状态, BDAuscultation.Properties.Resources.详情未点击)
              { Name = "dgvTZLYDwonDetail", HeaderText = "详情" ,Width=70};
            this.dgvTZLY_Down.Columns.Add(btnDetailDownColumn);
            var btnDelDownColumn = new DataGridViewButtonExColumn("",
                BDAuscultation.Properties.Resources.删除点击状态, BDAuscultation.Properties.Resources.删除未点击) 
                { Name = "dgvTZLYDownDelete", HeaderText = "删除", Width = 70 };
            this.dgvTZLY_Down.Columns.Add(btnDelDownColumn);
            dgvTZLY_Down.ListColumnImage.Add(null);
            dgvTZLY_Down.ListColumnImage.Add(BDAuscultation.Properties.Resources.患者类型);
            dgvTZLY_Down.ListColumnImage.Add(BDAuscultation.Properties.Resources.患者姓名);
            dgvTZLY_Down.ListColumnImage.Add(BDAuscultation.Properties.Resources.医生姓名);
            dgvTZLY_Down.ListColumnImage.Add(BDAuscultation.Properties.Resources.初步诊断);
            dgvTZLY_Down.ListColumnImage.Add(BDAuscultation.Properties.Resources.备注);
            dgvTZLY_Down.ListColumnImage.Add(BDAuscultation.Properties.Resources.分享者);
            dgvTZLY_Down.ListColumnImage.Add(BDAuscultation.Properties.Resources.分享时间);
            dgvTZLY_Down.ListColumnImage.Add(BDAuscultation.Properties.Resources.下载时间);
            dgvTZLY_Down.ListColumnImage.Add(BDAuscultation.Properties.Resources.详情未点击);
            dgvTZLY_Down.ListColumnImage.Add(BDAuscultation.Properties.Resources.删除未点击);


            cbBoxTZLY.Items.Clear();
            foreach (var item in StethoscopeManager.StethoscopeList)
            {
                var stetInfo = Setting.GetStetInfoByStetName(item.Name);
#if !DEBUG
                  if (item.IsConnected)
#endif
                cbBoxTZLY.Items.Add(item.Name);
            }
            if (cbBoxTZLY.Items.Count > 0)
                cbBoxTZLY.SelectedIndex = 0;

        }

        void dgvTZLY_Down_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                var PGUID = dgvTZLY_Down.Rows[e.RowIndex].Cells[0].Value + "";
                switch (dgvTZLY_Down.Columns[e.ColumnIndex].Name)
                {
                    case "dgvTZLYDwonDetail":
                        {
                            var dt = Mediator.sqliteHelper.ExecuteDatatable("select * from PatientInfoDown where PatientGUID={0} and Downer={1}", PGUID, this.cbBoxTZLY.Text);
                            var row = dt.Rows[0];
                            var formAudioDetail = new FrmAudioDetail()
                            {

                                StetName = this.cbBoxTZLY.Text,
                                PatientGUID = row["PatientGUID"] + "",
                                PatientID = row["PatientID"] + "",
                                PatientName = row["PatientName"] + "",
                                DocName = row["DocName"] + "",
                                PatientSex = row["PatientSex"] + "",
                                PatientAge = int.Parse(("0"+row["PatientAge"])),
                                DocDiagnose = row["DocDiagnose"] + "",
                                DocRemark = row["DocRemark"] + "",
                                His = row["Flag"] + "",
                                IInfo = new LocalDown()
                            };
                            formAudioDetail.ShowDialog();
                        }
                        break;
                    case "dgvTZLYDownDelete":
                        {
                            if (DialogResult.OK == MessageBox.Show("你确定要删除该记录及其文件吗", "删除录音提示", MessageBoxButtons.OKCancel))
                            {
                                var k = Mediator.sqliteHelper.ExecuteNonQuery("delete from PatientInfoDown where PatientGUID={0} and Downer={1}", PGUID, this.cbBoxTZLY.Text);
                                var dt = Mediator.sqliteHelper.ExecuteDatatable("select * from AudioInfoDown where PGUID={0}", PGUID);
                                foreach (DataRow row in dt.Rows)
                                {
                                    var guid = row["GUID"] + "";
                                    var recordTime = (DateTime)row["RecordTime"];
                                    string filePath = Path.Combine(Setting.localData, @"DevicesData\DowmLoad\" + recordTime.Year
                      + "\\" + recordTime.Month + "\\" + recordTime.Day + "\\" + guid + ".MP3");
                                    if (File.Exists(filePath))
                                        File.Delete(filePath);
                                }
                                k = Mediator.sqliteHelper.ExecuteNonQuery("delete from AudioInfoDown where PGUID={0}", PGUID);
                                MessageBox.Show("删除成功");
                            }
                            LoadStetInfoTZLYDown();
                        }
                        break;
                }
            }
        }
        void dgvTZLY_Local_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var PatientInfo = new
                {
                    PatientGUID = dgvTZLY_Local.Rows[e.RowIndex].Cells[0].Value + ""
       ,
                    PatientType = dgvTZLY_Local.Rows[e.RowIndex].Cells[1].Value + ""
       ,
                    PatientName = dgvTZLY_Local.Rows[e.RowIndex].Cells[2].Value + ""
       ,
                    DocName = dgvTZLY_Local.Rows[e.RowIndex].Cells[3].Value + ""
      ,
                    DocDiagnose = dgvTZLY_Local.Rows[e.RowIndex].Cells[4].Value + ""
      ,
                    DocRemark = dgvTZLY_Local.Rows[e.RowIndex].Cells[5].Value + ""
                    
                };

                switch (dgvTZLY_Local.Columns[e.ColumnIndex].Name)
                {
                    case "dgvTZLYLoaclDetail":
                        {
                            var formAudioRecord = new FrmAudioRecord()
                            {
                                PatientType = Setting.GetPatientTypeByName(PatientInfo.PatientType.ToString())
                                ,
                                StetName = this.cbBoxTZLY.Text,
                                PatientGUID = PatientInfo.PatientGUID,
                                PatientName = PatientInfo.PatientName,
                                DocName = PatientInfo.DocName,
                                DocDiagnose = PatientInfo.DocDiagnose,
                                DocRemark = PatientInfo.DocRemark,
                                CanEdit = false
                            };
                            formAudioRecord.ShowDialog();
                            LoadLocalPatientInfo();
                        }
                        break;
                    case "dgvTZLYLoaclDelete":
                        {
                            if (DialogResult.OK == MessageBox.Show("你确定要删除该记录及其文件吗", "删除录音提示", MessageBoxButtons.OKCancel))
                            {
                                string sqlDelP = "delete from PatientInfo where PatientGUID={0}";
                                var k = Mediator.sqliteHelper.ExecuteNonQuery(sqlDelP, PatientInfo.PatientGUID);
                                if (k > 0)
                                {
                                    Mediator.ShowMsg(string.Format("删除患者{0}信息成功...", Path.GetFileName(PatientInfo.PatientName)));
                                    string sqlQueryAudio = "select GUID ,RecordTime from AudioInfo where PGUID={0}";
                                    var dt = Mediator.sqliteHelper.ExecuteDatatable(sqlQueryAudio, PatientInfo.PatientGUID);
                                    string sqlDelAudio = "delete from AudioInfo where PGUID={0}";
                                    var n = Mediator.sqliteHelper.ExecuteNonQuery(sqlDelAudio, PatientInfo.PatientGUID);
                                    if (n > 0)
                                    {
                                        foreach (DataRow row in dt.Rows)
                                        {
                                            string guid = row["GUID"] + "";
                                            DateTime recordTime = (DateTime)row["RecordTime"];
                                            string filePath = Path.Combine(Setting.localData, @"DevicesData\AudioFiles\" + recordTime.Year
                  + "\\" + recordTime.Month + "\\" + recordTime.Day + "\\" + guid + ".MP3");
                                            if (File.Exists(filePath))
                                            {
                                                File.Delete(filePath);
                                                Mediator.ShowMsg(string.Format("删除文件{0}成功...", Path.GetFileName(filePath)));
                                            }
                                        }
                                    }
                                }
                            }
                            LoadLocalPatientInfo();
                        }
                        break;
                }
            }
        }

        void tabLY_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbBoxTZLY.SelectedItem + "") && tabLY.SelectedTab != null)
            {
                UpdateDataTZLY(cbBoxTZLY.SelectedItem + "", tabLY.SelectedTab.Name);
            }
        }

        void btnLYDown_Click(object sender, EventArgs e)
        {
            this.tabLY.SelectedTab = tabLYDown;
            btnLYDown.HoverColor = btnLYDown.PressColor = btnLYDown.NormalColor = Color.Gray;
            btnLYLocal.HoverColor = btnLYLocal.PressColor = btnLYLocal.NormalColor = Color.FromArgb(200, 200, 200);
        }

        void btnLYLocal_Click(object sender, EventArgs e)
        {
            this.tabLY.SelectedTab = tabLYLocal;
            btnLYLocal.HoverColor = btnLYLocal.PressColor = btnLYLocal.NormalColor = Color.Gray;
            btnLYDown.HoverColor = btnLYDown.PressColor = btnLYDown.NormalColor = Color.FromArgb(200, 200, 200);
        }

        void cbBoxTZLY_DropDown(object sender, EventArgs e)
        {
            cbBoxTZLY.Items.Clear();
            foreach (var item in StethoscopeManager.StethoscopeList)
            {
                var stetInfo = Setting.GetStetInfoByStetName(item.Name);
#if !DEBUG
                if (item.IsConnected)
#endif
                cbBoxTZLY.Items.Add(item.Name);
            }
        }
        
        void cbBoxTZLY_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(cbBoxTZLY.SelectedItem + "") && tabLY.SelectedTab != null)
            {
                UpdateDataTZLY(cbBoxTZLY.SelectedItem + "", tabLY.SelectedTab.Name);
            }
        }
        public void UpdateDataTZLY(string stetName, string tabPageName)
        {
            if (string.IsNullOrEmpty(stetName)) return;
            switch (tabPageName)
            {
                case "tabLYLocal":
                    {

                        LoadLocalPatientInfo();
                        //LoadLocalAudio();
                    }
                    break;
                case "tabLYDown":
                    {
                        LoadStetInfoTZLYDown();
                    }
                    break;
            }
        }
        void btnTZLY_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cbBoxTZLY.Text))
            {
                MessageBox.Show("请选择一个听诊器..");
                return;
            }
            var stetInfo = Setting.GetStetInfoByStetName(this.cbBoxTZLY.Text);
            var frmAudioRecord = new FrmAudioRecord()
            {
                PatientType = stetInfo.StetType,
                StetName = this.cbBoxTZLY.Text
            };
            frmAudioRecord.ShowDialog();
            LoadLocalPatientInfo();
        }
        void LoadStetInfoTZLYDown()
        {
            dgvTZLY_Down.Rows.Clear();
            string querySql = @"select PatientGUID,PatientType,PatientID,PatientName,DocName,DocDiagnose,DocRemark,Sharer,ShareTime,DownTime from PatientInfoDown where Downer={0} order by DownTime desc ";
            var dt = Mediator.sqliteHelper.ExecuteDatatable(querySql, this.cbBoxTZLY.Text);
            dgvTZLY_Down.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                dgvTZLY_Down.Rows.Add(
                    dr[0], Setting.GetPatientNameByType((int)dr[1]),  dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9]
                    );
            }
            
        }

        void LoadLocalPatientInfo()
        {
            
            string sqlQuery = @"select * from PatientInfo where StetName={0} order by rowid desc";
            var dt = Mediator.sqliteHelper.ExecuteDatatable(sqlQuery, this.cbBoxTZLY.Text);
            dgvTZLY_Local.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                dgvTZLY_Local.Rows.Add(dr[0],
                    Setting.GetPatientNameByType(int.Parse(dr["PatientType"] + ""))
                    ,  dr["PatientName"],
                     dr["DocName"], dr["DocDiagnose"], dr["DocRemark"], dr["CreateTime"]);
            }

        }
         
    }

}
