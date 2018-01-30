using BDAuscultation.Devices;
using BDAuscultation.Forms;
using MMM.HealthCare.Scopes.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
#if DEBUG
using MockDevices = BDAuscultation.Devices.Mock;
#endif

namespace BDAuscultation
{
    /// <summary>
    /// 听诊教学
    /// </summary>
    partial class FrmMain
    {

        void InitdgvTZJX()
        {
            dgvTZJXTZQNO.FillWeight = 200;
            
            dgvTZJX.ListColumnImage.Add(BDAuscultation.Properties.Resources.听诊器编号);
            dgvTZJX.ListColumnImage.Add(BDAuscultation.Properties.Resources.听诊器名字);
            dgvTZJX.ListColumnImage.Add(BDAuscultation.Properties.Resources.听诊器所属人);
            dgvTZJX.ListColumnImage.Add(BDAuscultation.Properties.Resources.连接状态);
            dgvTZJX.ListColumnImage.Add(null);
            var tzjxBtnCheckColumn = new DataGridViewCheckBoxExColumn() { HeaderText = "选择学生听诊器", Text = "选择学生听诊器", AutoSizeMode = DataGridViewAutoSizeColumnMode.None, Width = 200 };
            dgvTZJX.Columns.Add(tzjxBtnCheckColumn);
            LoadStetInfoTZJX();

            btnTeach.Click += btnTeach_Click;
            this.cbBoxTZJX.DropDown += cbBoxTZJX_DropDown;
            cbBoxTZJX.SelectedIndexChanged += cbBoxTZJX_SelectedIndexChanged;
            //this.btnTZPZ.Click += new System.EventHandler(this.btnTZPZ_Click);
            dgvTZJX.CellClick += dgvTZJX_CellClick;
            foreach (DataGridViewColumn column in dgvTZQPZ.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        void cbBoxTZJX_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvTZJX.Rows.Clear();
            foreach (var item in StethoscopeManager.StethoscopeList.Where(s => s.Name != this.cbBoxTZJX.Text))
            {
#if !DEBUG
                  if (!item.IsConnected) 
                continue;
#endif
                var stetInfo = Setting.GetStetInfoByStetName(item.Name);
                dgvTZJX.Rows.Add( item.Name,
                    stetInfo == null ? "" : stetInfo.StetChineseName,
                    stetInfo == null ? "" : stetInfo.Owner,
                    item.IsConnected?"已连接":"未连接",
                    false
                 );
            }
        }

        void cbBoxTZJX_DropDown(object sender, EventArgs e)
        {
            cbBoxTZJX.Items.Clear();
            foreach (var item in StethoscopeManager.StethoscopeList)
            {
                var stetInfo = Setting.GetStetInfoByStetName(item.Name);
#if !DEBUG
                  if (item.IsConnected)
#endif
                cbBoxTZJX.Items.Add(item.Name);
            }
            //if (cbBoxTZJX.Items.Count > 0)
            //    cbBoxTZJX.SelectedIndex = 0;
        }
//#if DEBUG
       // IEnumerable<Devices.Mock.Stethoscope> GetStethoscope()
//#else
        IEnumerable<Stethoscope> GetStethoscope()
//#endif
        {
            List<string> listStetName = new List<string>();
            for (int i = 0; i < dgvTZJX.Rows.Count; i++)
            {
                if ((bool)dgvTZJX.Rows[i].Cells[4].Value)
                {
                    listStetName.Add(dgvTZJX.Rows[i].Cells[0].Value.ToString());
                }
            }
            return StethoscopeManager.StethoscopeList.Where(s => s.Name != cbBoxTZJX.Text && listStetName.Contains(s.Name)).ToArray();
        }
        void btnTeach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbBoxTZJX.Text))
            {
                MessageBox.Show("请选择一个已连接的听诊器，如果列表为空,请先连接本地听诊器！");
                return;
            }
            var arrRecvStethoscope = GetStethoscope();
            if (arrRecvStethoscope.Where(s=>!s.IsConnected).Any())
            {
                MessageBox.Show("设备尚未全部准备就绪！");
                return;
            }
            if (!arrRecvStethoscope.Any())
            {
                MessageBox.Show("请选择听诊器！");
                return;
            }
            //1.判断所有勾选的听诊器处于蓝牙连接成功状态
            //2.开启源听诊设备
            var stethoscopeArr = StethoscopeManager.StethoscopeList.Where(s => s.Name == cbBoxTZJX.Text);
            if (stethoscopeArr.Count() == 0)
                throw new Exception("目前没有检测到听诊器,请检测设备设置！");
            var stethoscope = stethoscopeArr.First();
            if (!stethoscope.IsConnected)
            {
                Mediator.ShowMsg(string.Format("听诊器 {0} 尚未连接", stethoscope.Name));
                MessageBox.Show(string.Format("听诊器 {0} 尚未连接", stethoscope.Name));
                return;
            }
            //var arrRecvStethoscope=ucStetManager1.GetStethoscope().Where(item=>item.IsConnected);
            var formProcessBar = new FrmProcessBar(true)
            {
                BtnText = "停止教学"
            };
            Thread pairThread = new Thread(() =>
            {
                Mediator.isBusy = true;
                formProcessBar.TimerCallBackEvent += () =>
                {
                    Invoke(new MethodInvoker(delegate()
                    {
                        formProcessBar.Title = string.Format("音频教学中... {0} 秒", formProcessBar.Times);
                    }));
                };
                byte[] packet = new byte[128];
                stethoscope.StartAudioInput();
                foreach (var recvStethoscope in arrRecvStethoscope)
                {
                    if (recvStethoscope.IsConnected)
                        recvStethoscope.StartAudioOutput();
                }
                Mediator.ShowMsg(string.Format("听诊器 {0} 开始教学...", stethoscope.Name));
                // Stream audio from the stethoscope to the computer.
                while (formProcessBar.DialogResult != System.Windows.Forms.DialogResult.Cancel)
                {
                    int bytesRead = stethoscope.AudioInputStream.Read(packet, 0, packet.Length);
                    foreach (var recvStethoscope in arrRecvStethoscope)
                    {
                        if (recvStethoscope.IsConnected)
                            recvStethoscope.AudioOutputStream.Write(packet, 0, bytesRead);
                    }
                }
                Mediator.ShowMsg(string.Format("听诊器 {0} 教学完毕，时长 {1} 秒", stethoscope.Name, formProcessBar.Times));

            });
            pairThread.Start();
            formProcessBar.ShowDialog();
            formProcessBar.TimerEnable = false;
            stethoscope.StopAudioInput();
            foreach (var recvStethoscope in arrRecvStethoscope)
            {
                if (recvStethoscope.IsConnected)
                recvStethoscope.StopAudioOutput();
            }
            Mediator.ShowMsg("音频教学完毕...");
            Mediator.isBusy = false;
        }
        void LoadStetInfoTZJX()
        {
            cbBoxTZJX.Items.Clear();
            dgvTZJX.Rows.Clear();
            foreach (var item in StethoscopeManager.StethoscopeList)
            {
                var stetInfo = Setting.GetStetInfoByStetName(item.Name);
#if !DEBUG
                  if (item.IsConnected)
#endif
                cbBoxTZJX.Items.Add(item.Name);
            }
            if (cbBoxTZJX.Items.Count > 0)
                cbBoxTZJX.SelectedIndex = 0;
            //Mediator.ShowMsg("下拉count"+cbBoxTZJX.Items.Count);
            //Mediator.ShowMsg("ddd" + cbBoxTZJX.SelectedIndex);

        }
        void dgvTZJX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }
    }
}
