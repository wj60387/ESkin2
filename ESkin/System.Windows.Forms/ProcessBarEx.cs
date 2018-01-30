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

        ProgressBarStyle progressBarStyle = ProgressBarStyle.Continuous;
        public ProgressBarStyle ProgressBarStyle
        {
            get { return this.progressBarStyle; }
            set { this.progressBarStyle = value;
            this.Invalidate();
            }
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
                System.Timers.Timer timer = new Timers.Timer(40);
                timer.Elapsed += timer_Elapsed;
                timer.Start();
                this.Disposed += ((s, e) => { timer.Stop(); });
        }
        int takeTime = 0;
        void timer_Elapsed(object sender, Timers.ElapsedEventArgs e)
        {
            //takeTime += 40;
            position += 10;
            if (position >= this.Width)
                position = 0;
            this.Invalidate();
        }
        int position = 0;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (progressBarStyle == Forms.ProgressBarStyle.Blocks)
            {
                var brush = new LinearGradientBrush(
                   new Point(0, 0), new Point(this.Width, this.Height),
                   Color.Gold, Color.GreenYellow);
                var rect = new Rectangle(position, 0, this.Width / 5, this.Height);
                e.Graphics.FillRectangle(brush, rect);
                //if (takeTime % 1000 == 0)
                //{
                //    string text = string.Format("{0}", takeTime / 1000);
                //    var textRect = TextRenderer.MeasureText(text, this.Font);
                //    e.Graphics.DrawString(text, this.Font, Brushes.Red, this.Width / 2 - textRect.Width / 2, -3);
                //}
            }
            else
            {
                var brush = new LinearGradientBrush(
                  new Point(0, 0), new Point(this.Width, this.Height),
                  Color.Gold, Color.GreenYellow);
                var rect = new Rectangle(0, 0, this.Width * value / maxValue, this.Height);
                e.Graphics.FillRectangle(brush, rect);
            }
           
            //string text = string.Format("{0}/{1}",value,maxValue);
            //var textRect = TextRenderer.MeasureText(text,this.Font);
           
           // e.Graphics.DrawString(text, this.Font, brush, this.Width / 2 - textRect.Width / 2, -3);
        }
    }
}
