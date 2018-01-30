using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Windows.Forms
{
    public class WaterTextBox : TextBox
    {
        string waterText = string.Empty;
        [Description("设置水印文本")]
        [DefaultValue(typeof(String), "提示文字")]
        public string WaterText
        {
            get { return waterText; }
            set
            {
                waterText = value;
                this.Invalidate();
            }
        }
        public WaterTextBox()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BorderStyle = Forms.BorderStyle.None;
            this.SuspendLayout();
            this.Font = new System.Drawing.Font("微软雅黑", 9f);
            this.ResumeLayout(false);
            this.WaterText = "水印文字";
            
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0xf || m.Msg == 0x133)
            {
                using (Graphics g = this.CreateGraphics())
                {
                    if (string.IsNullOrEmpty(this.Text))
                    {
                        StringFormat sf = new StringFormat()
                        {
                            Alignment = StringAlignment.Near,
                            LineAlignment = StringAlignment.Near
                        };
                        g.DrawString(waterText, new Font("微软雅黑", 9.0f), new SolidBrush(Color.Gray), 1.5f,3.5f);
                    }
                   g.Dispose();
                }
            }
        }
       
        
         
    }
}
 
