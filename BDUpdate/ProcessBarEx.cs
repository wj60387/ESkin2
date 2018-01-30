using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace  System.Windows.Forms
{
    public class ProcessBarEx:Control
    {
        int value = 30;
        public  int Value
        {
            get { return value; }
            set { this.value = value; this.Invalidate(); }
        }
        int maxValue = 100;
        public int MaxValue
        {
            get { return maxValue; }
            set { this.maxValue = value; this.Invalidate(); }
        }
        public ProcessBarEx()
        {
            this.Size = new  Size(100,3);
            this.SetStyle(
              ControlStyles.UserPaint |  //控件自行绘制，而不使用操作系统的绘制
              ControlStyles.AllPaintingInWmPaint | //忽略擦出的消息，减少闪烁。
              ControlStyles.OptimizedDoubleBuffer |//在缓冲区上绘制，不直接绘制到屏幕上，减少闪烁。
              ControlStyles.ResizeRedraw | //控件大小发生变化时，重绘。                  
              ControlStyles.SupportsTransparentBackColor, true);//支持透明背景颜色
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var boderRect = new Rectangle(e.ClipRectangle.X + 1, e.ClipRectangle.Y+1, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 2);
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(200, 227, 255),2f), boderRect);
            base.OnPaint(e);
            //var brush = new LinearGradientBrush(
            //   new Point(0, 0), new Point(this.Width, this.Height),
            //   Color.Gold, Color.GreenYellow);

            var brush = new SolidBrush(Color.FromArgb(200, 227, 255));
            var rect = new Rectangle(0, 0, this.Width * value / maxValue, this.Height);
            e.Graphics.FillRectangle(brush, rect);
            string text = string.Format("{0}/{1}",value,maxValue);
            var textRect = TextRenderer.MeasureText(text,this.Font);
           
           // e.Graphics.DrawString(text, this.Font, brush, this.Width / 2 - textRect.Width / 2, -3);
        }
    }
}
