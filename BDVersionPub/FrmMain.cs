using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Windows.Forms;

namespace BDVersionPub
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
            
        }
        static string dirPath = System.Configuration.ConfigurationManager.AppSettings["Path"];
        static string SN = System.Configuration.ConfigurationManager.AppSettings["SN"];
        static string MAC = System.Configuration.ConfigurationManager.AppSettings["MAC"];
        static string MainExeName = System.Configuration.ConfigurationManager.AppSettings["MainExeName"];

        string VersionMajor = isMainExe ? "VersionMajor" : "VersionMajor_Remote";
        string Key = isMainExe ? "VersionFileDir" : "VersionFileDir_Remote";
        string View_CurrentVersion = isMainExe ? "View_CurrentVersion" : "View_CurrentVersion_Remote";
        string VersionFile = isMainExe ? "VersionFile" : "VersionFile_Remote";
        static bool isMainExe {
            get { return MainExeName.Equals("BDAuscultation.exe"); }
        }
        public AuscultationService.AuscultationServiceClient remoteService = new AuscultationService.AuscultationServiceClient("WSHttpBinding_IAuscultationService");
        void FrmMain_Load(object sender, EventArgs e)
        {
            using (OperationContextScope scope = new OperationContextScope(remoteService.InnerChannel))
            {
                MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", SN);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", MAC);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                string sql = @"SELECT  Version FROM " + VersionMajor + " WHERE Enable=1";
                var ds=remoteService.ExecuteDataset(sql,null);
                if(ds!=null && ds.Tables.Count>0&& ds.Tables[0].Rows.Count>0)
                    ucTextBoxEx1.Text = ds.Tables[0].Rows[0][0]+"";
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            //if (DialogResult.OK == folderDialog.ShowDialog())
            //{
                this.treeView1.Nodes.Clear();
                var folderPath = dirPath;//folderDialog.SelectedPath;
                TreeNode node = new TreeNode(Path.GetFileName(folderPath));
                node.Nodes.Add(new TreeNode() { Name="Test"});
                node.Tag = NodeType.Dir;
                treeView1.Tag = folderPath;
                this.treeView1.Nodes.Add(node);

                var mainExeName = Path.Combine(folderPath,MainExeName);
                var info=FileVersionInfo.GetVersionInfo(mainExeName);
                ucTextBoxEx2.Text = info.ProductVersion;
            //}
        }


        public string  Root
        {
            get
            {
                return Path.GetDirectoryName(treeView1.Tag+"");
            }
        }
        
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            string folderPath = Path.Combine(Root,e.Node.FullPath);
           var files = Directory.GetFiles(folderPath);
           var dirs = Directory.GetDirectories(folderPath);
           e.Node.Nodes.Clear();
           foreach (var dir in dirs)
           {
               TreeNode node = new TreeNode(Path.GetFileName(dir));
               node.Tag = NodeType.Dir;
               node.Nodes.Add(new TreeNode() { Name = "Test" });
               e.Node.Nodes.Add(node);
           }
           foreach (var file in files)
           {

               TreeNode node = new TreeNode(Path.GetFileName(file));
               node.Tag = NodeType.File;
               e.Node.Nodes.Add(node);
           }
        }
        enum NodeType
        {
            File,
            Dir
        }
        List<string> lstPath = new List<string>();
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
           if(e.Node.Nodes.Count==0)
           {
               string folderPath = Path.Combine(Root, e.Node.FullPath);

               if (e.Node.Checked)
               {
                   lstPath.Add(folderPath);
               }
               else
               {
                   if (lstPath.Contains(folderPath))
                   {
                       lstPath.Remove(folderPath);
                   }
               }
           }
        }

        private void btnPub_Click(object sender, EventArgs e)
        {
            if (ucTextBoxEx1.Text == ucTextBoxEx2.Text)
            {
                MessageBox.Show("请检查主程序版本，不能相同");
                return;

            }
            using (OperationContextScope scope = new OperationContextScope(remoteService.InnerChannel))
            {
                MessageHeader header = MessageHeader.CreateHeader("SN", "http://tempuri.org", SN);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                header = MessageHeader.CreateHeader("MAC", "http://tempuri.org", MAC);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                string sql = @"SELECT Value FROM SysConst WHERE KeyName='" + Key + "'";
                var Dir = remoteService.ExecuteScalar(sql, null);
                var majorDir = Dir + "\\" + ucTextBoxEx2.Text;
                sql = "update " + VersionMajor + " set Enable=0;insert into " + VersionMajor + "(Version,PubContent) select {0}, {1}";
                var n = remoteService.ExecuteNonQuery(sql, new string[] { ucTextBoxEx2.Text, ucTextBoxEx3.Text });

                foreach (var localFile in lstPath)
                {
                    var remoteFilePath = Path.Combine(majorDir,  localFile.Substring(this.treeView1.Tag.ToString().Length+1));
                    
                    using (var stream = new FileStream(localFile, FileMode.OpenOrCreate, FileAccess.Read))
                    {
                        while (true)
                        {
                            var readBytes = new byte[1024 * 24];
                            var readed = stream.Read(readBytes, 0, readBytes.Length);
                            if (readed <= 0) break;
                            remoteService.UpLoadFile(remoteFilePath, stream.Position - readed, readBytes);
                        }
                        stream.Close();
                    }
                    var hash = GetMD5HashFromFile(localFile);
                    sql = " insert into " + VersionFile + " (Version,FileRelativePath,FileName,FileHash) select {0},{1},{2},{3}";
                    var count = remoteService.ExecuteNonQuery(sql, new string[] { ucTextBoxEx2.Text, localFile.Substring(this.treeView1.Tag.ToString().Length+1)
                    ,Path.GetFileName(localFile) ,hash});
                }
                ucTextBoxEx1.Text = ucTextBoxEx2.Text;
                MessageBox.Show("发布成功！");
                
            }
           
        }


        public static string GetMD5HashFromFile(string filePath)
        {
            try
            {
                FileStream file = new FileStream(filePath, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString().ToUpper();
            }

            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }

        }
    }
}
