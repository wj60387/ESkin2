﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProtocalData.Protocol.Derive;
using System.IO;

namespace BDAuscultation.Forms
{
    public partial class FrmReg : Form 
    {
        public FrmReg(string Mac = "")
        {
            this.Mac = Mac;
            InitializeComponent();
        }
        public string Mac = "";

        public string License=string.Empty;
        private void btnRegistered_Click(object sender, EventArgs e)
        {
            if (!Setting.isConnected)
            {
                MessageBox.Show("未连接服务器,无法激活,请确保网络正常...");
                return;
            }
            if(string.IsNullOrEmpty(txtRegisteredCode.Text)) return;
            var code = Mediator.remoteService.AccountCredentials(Mac, txtRegisteredCode.Text);
            var RegistCode = Newtonsoft.Json.JsonConvert.DeserializeObject<RegistCode>(code);
            var path = Path.Combine(Application.StartupPath, "applicense.txt");
            System.IO.File.WriteAllText(path, RegistCode.License);
            License = RegistCode.License;
            if (RegistCode.isLegal)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
                return;
            }
            MessageBox.Show(string.Format("注册码 {0} 无效...", txtRegisteredCode.Text),"激活码无效", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       
    }
}
