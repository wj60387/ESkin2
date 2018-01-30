using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBArgTest
{
    public partial class Form1 : Form
    {
        public Form1(string [] args)
        {
            InitializeComponent();
            if(args!=null)
            {
                textBox1.Text = "一共有" + args.Length + "个参数\r\n";
                for (int i = 0; i < args.Length; i++)
                {
                    textBox1.Text += "第" + (i + 1) + "个参数是:" + args[i] + "\r\n";
                }
            }
        }
    }
}
