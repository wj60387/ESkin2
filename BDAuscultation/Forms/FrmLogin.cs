using BDAuscultation.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class FrmLogin : Form
    {

        string file = "security.txt";
        public FrmLogin()
        {
            InitializeComponent();
            this.txtPwd.OnEnterKeyDown += txtPwd_KeyDown;
            this.txtUserName.OnTextChanged += TxtUserName_OnTextChanged;
            this.Load += FrmLogin_Load;

#if DEBUG
            //this.txtUserName.Text = "test";
            //this.txtPwd.Text = "111111";
#endif
        }

        private void TxtUserName_OnTextChanged(string txt)
        {
            var lines = File.ReadAllLines(file);
            foreach (var line in lines)
            {
                var json = CommonUtil.Decode(line);
                var userIno = JsonConvert.DeserializeObject<UserIno>(json);
                if(txt.Trim().Equals(userIno.UserName))
                {
                    this.txtUserName.Text = userIno.UserName;
                    this.txtPwd.Text = userIno.Pwd;
                }
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines(file);
            foreach (var line in lines)
            {
                var json = CommonUtil.Decode(line);
                 var userIno = JsonConvert.DeserializeObject<UserIno>(json);
                 this.txtUserName.AutoCompleteCustomSource.Add(userIno.UserName);
                this.txtUserName.Text = userIno.UserName;
                this.txtPwd.Text = userIno.Pwd;
            }
        }

        void txtPwd_KeyDown()
        {
            btnLogin_Click(null, null);
        }
        // public string SN = string.Empty;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()) || string.IsNullOrEmpty(txtPwd.Text.Trim()))
            {
                lbMsg.Text = "用户名和密码不能为空！";
                return;
            }
            if (Setting.authorizationInfo != null)
                using (OperationContextScope scope = new OperationContextScope(Mediator.remoteService.InnerChannel))
                {
                    MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", Setting.authorizationInfo.AuthorizationNum);
                    OperationContext.Current.OutgoingMessageHeaders.Add(header);
                    header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", Setting.authorizationInfo.MachineCode);
                    OperationContext.Current.OutgoingMessageHeaders.Add(header);
                    string sql = "select 1 from UserInfo where   UserName={0} and PWD={1} and SN={2}";
                    var r = Mediator.remoteService.ExecuteScalar(sql, new string[] { txtUserName.Text.Trim(), txtPwd.Text.Trim(), Setting.authorizationInfo.AuthorizationNum });
                    if (!string.IsNullOrEmpty(r))
                    {
                        lbMsg.Text = "登录成功";
                        var userInfo = new { UserName = txtUserName.Text.Trim(), Pwd = checkBoxEx1.Checked ? txtPwd.Text.Trim() : string.Empty };
                        var json = JsonConvert.SerializeObject(userInfo);
                        var txt = CommonUtil.Encode(json);
                        if (File.Exists(file))
                        {
                            var lines = File.ReadAllLines(file);
                            if (!lines.Contains(txt))
                                File.AppendAllText(file, txt);
                        }
                        else
                        {
                            File.WriteAllLines(file, new string[] { txt }, Encoding.UTF8);
                        }
                       
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                }
            lbMsg.Text = "用户名或者密码错误";
        }


        private bool isMouseDown = false;
        private Point FormLocation;     //form的location
        private Point mouseOffset;      //鼠标的按下位置
        protected override void OnMouseDown(MouseEventArgs e)
        {
            var point = PointToScreen(MousePosition);
            this.MaximumSize = Screen.FromPoint(point).WorkingArea.Size;
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = this.Location;
                mouseOffset = Control.MousePosition;
            }

        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            int _x = 0;
            int _y = 0;
            if (isMouseDown)
            {
                Point pt = Control.MousePosition;
                _x = mouseOffset.X - pt.X;
                _y = mouseOffset.Y - pt.Y;

                this.Location = new Point(FormLocation.X - _x, FormLocation.Y - _y);
            }

        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }


        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public class UserIno
        {
            public string UserName { get; set; }
            public string Pwd { get; set; }
        }
        


    }
}
