using BDAuscultation.Devices;
using BDAuscultation.Forms;
using BDAuscultation.IGetAudioInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Windows.Forms;

namespace BDAuscultation
{
    partial class FrmMain
    {

        void InitdgvXY()
        {
            // 事件
            this.cbBoxXY.SelectedIndexChanged += cbBoxXY_SelectedIndexChanged;
            this.cbBoxXY.DropDown += cbBoxXY_DropDown;
            this.dgvXY.CellClick += dgvXY_CellClick;

            this.btnLocalXY.Click += btnLocalXY_Click;
            this.btnShareXY.Click += btnShareXY_Click;
            // 按钮
            var btnDetailColumn = new DataGridViewButtonExColumn("",
              BDAuscultation.Properties.Resources.详情点击状态, BDAuscultation.Properties.Resources.详情未点击)
            { Name = "dgvXYDetail", HeaderText = "详情", Width = 70 };
            this.dgvXY.Columns.Add(btnDetailColumn);

            dgvXY.ListColumnImage.Add(null);
            dgvXY.ListColumnImage.Add(BDAuscultation.Properties.Resources.听诊器编号);
            dgvXY.ListColumnImage.Add(BDAuscultation.Properties.Resources.患者类型);
            dgvXY.ListColumnImage.Add(BDAuscultation.Properties.Resources.患者姓名);
            dgvXY.ListColumnImage.Add(BDAuscultation.Properties.Resources.医生姓名);
            dgvXY.ListColumnImage.Add(BDAuscultation.Properties.Resources.初步诊断);
            dgvXY.ListColumnImage.Add(BDAuscultation.Properties.Resources.备注);
            dgvXY.ListColumnImage.Add(BDAuscultation.Properties.Resources.下载时间);
            dgvXY.ListColumnImage.Add(BDAuscultation.Properties.Resources.详情);
        }
        void btnLocalXY_Click(object sender, EventArgs e)
        {
            this.tabXYSub.SelectedTab = tabXYLocal;
            btnLocalXY.HoverColor = btnLocalXY.PressColor = btnLocalXY.NormalColor = Color.Gray;
            btnShareXY.HoverColor = btnShareXY.PressColor = btnShareXY.NormalColor = Color.FromArgb(200, 200, 200);
        }

        void btnShareXY_Click(object sender, EventArgs e)
        {
             this.tabXYSub.SelectedTab = tabXYShare;
            btnShareXY.HoverColor = btnShareXY.PressColor = btnShareXY.NormalColor = Color.Gray;
            btnLocalXY.HoverColor = btnLocalXY.PressColor = btnLocalXY.NormalColor = Color.FromArgb(200, 200, 200);
        }

        void dgvXY_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var PGUID = dgvXY.Rows[e.RowIndex].Cells[0].Value + "";
                switch (dgvXY.Columns[e.ColumnIndex].Name)
                {
                    case "dgvXYDetail":
                        {
                            //var dt = Mediator.sqliteHelper.ExecuteDatatable("select * from PatientInfoDown where PatientGUID={0} and Downer={1}", PGUID, this.cbBoxXY.Text);
                            var  dt = GetPatientInfoByPGuid(PGUID);
                            if (dt!=null && dt.Rows.Count>0)
                            {
                                var row = dt.Rows[0];
                                var formAudioDetail = new FrmAudioDetail_XY()
                                {
                                    //StetName = this.cbBoxXY.Text,
                                    StetName = row["StetName"] + "",
                                    PatientGUID = row["PatientGUID"] + "",
                                    PatientID = row["PatientID"] + "",
                                    PatientName = row["PatientName"] + "",
                                    DocName = row["DocName"] + "",
                                    PatientSex = row["PatientSex"] + "",
                                    PatientAge = int.Parse(("0" + row["PatientAge"])),
                                    DocDiagnose = row["DocDiagnose"] + "",
                                    DocRemark = row["DocRemark"] + "",
                                    His = row["Flag"] + "",
                                    IInfo = new CloudUpload()
                                };
                                formAudioDetail.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("录音信息已不存在，请重新刷新界面.");
                            }
                        }
                        break;
                }
            }
        }

        void cbBoxXY_DropDown(object sender, EventArgs e)
        {
            load_cbBoxInit_XY();
        }

        void load_cbBoxInit_XY()
        {
            cbBoxXY.Items.Clear();

            var stetFromRemote = GetStetCollByCurrentGroup();
            foreach (DataRow stetinfo in stetFromRemote.Rows)
            {
                var stetInfo = Setting.GetStetInfoByStetName(stetinfo["StetName"].ToString());
                cbBoxXY.Items.Add(stetinfo["StetName"].ToString());
            }
        }

        void cbBoxXY_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(cbBoxXY.SelectedItem + ""))
            {
                UpdateDataXY(cbBoxXY.SelectedItem + "");
            }
        }

        public void UpdateDataXY(string stetName)
        {
            if (string.IsNullOrEmpty(stetName)) return;
            LoadXYPatientInfo();
        }

        void LoadXYPatientInfo()
        {
            var dt = GetPatientCollByStetName(this.cbBoxXY.Text);
            dgvXY.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                dgvXY.Rows.Add(dr["PatientGUID"], dr["StetName"],
                    Setting.GetPatientNameByType(int.Parse(dr["PatientType"] + ""))
                    , dr["PatientName"],
                     dr["DocName"], dr["DocDiagnose"], dr["DocRemark"], dr["CreateTime"]);
            }

        }

        DataTable GetStetCollByCurrentGroup()
        {
            using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
            {
                MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);

                string sqlQuery = @"SELECT DISTINCT StetName FROM PatientInfo(nolock) WHERE PatientGroupID={0} order by StetName desc";
                var ds = Mediator.remoteService.ExecuteDataset(sqlQuery, new string[] { Setting.authorizationInfo.GroupID.ToString() });
                return ds != null ? ds.Tables.Count > 0 ? ds.Tables[0] : null : null;
            }
        }

        DataTable GetPatientCollByStetName(string stetName)
        {
            using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
            {
                MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);

                string sqlQuery = @"select * from PatientInfo where StetName={0} order by CreateTime desc";
//                string sqlQuery = @"select d.StetName,  a. * from PatientInfo a   join
// (select distinct b.StetName from StethoscopeManager  b 
//  join  AccountAuthCustomInfo c on b.SN=c.AuthorizationNum  where c.GroupID={0}
//) d
//on a.StetName=d.StetName
//  order by a.CreateTime desc";
//                string sqlQuery = @"select  c.GroupID, b.SN,a. * from PatientInfo a left join StethoscopeManager b 
//on a.StetName=b.StetName 
//left join  AccountAuthCustomInfo c
//on b.SN=c.AuthorizationNum 
// where  c.GroupID={0} order by a.CreateTime desc";
                var ds = Mediator.remoteService.ExecuteDataset(sqlQuery, new string[] { stetName });
                return ds != null ? ds.Tables.Count > 0 ? ds.Tables[0] : null : null;
            }
        }

        DataTable GetPatientInfoByPGuid(string pguid)
        {
            using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
            {
                MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);

                string sqlQuery = @"select * from PatientInfo where PatientGuid={0}";
                var ds = Mediator.remoteService.ExecuteDataset(sqlQuery, new string[] { pguid });
                return ds != null ? ds.Tables.Count > 0 ? ds.Tables[0] : null : null;
            }
        }
    }
}
