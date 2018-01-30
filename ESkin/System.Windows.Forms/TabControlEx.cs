using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace System.Windows.Forms
{
    public class TabControlEx : TabControl
    {
        public List<Image> ListImage = new List<Image>();
        public TabControlEx()
        {
            base.SetStyle(
     ControlStyles.UserPaint |                      // 控件将自行绘制，而不是通过操作系统来绘制  
     ControlStyles.OptimizedDoubleBuffer |          // 该控件首先在缓冲区中绘制，而不是直接绘制到屏幕上，这样可以减少闪烁  
     ControlStyles.AllPaintingInWmPaint |           // 控件将忽略 WM_ERASEBKGND 窗口消息以减少闪烁  
     ControlStyles.ResizeRedraw |                   // 在调整控件大小时重绘控件  
     ControlStyles.SupportsTransparentBackColor,    // 控件接受 alpha 组件小于 255 的 BackColor 以模拟透明  
     true);                                         // 设置以上值为 true  
            base.UpdateStyles();
            this.SizeMode = TabSizeMode.Fixed;  // 大小模式为固定  
            this.ItemSize = new Size(120, 100);   // 设定每个标签的尺寸 
            this.DrawMode = TabDrawMode.OwnerDrawFixed;

            
        }

        
        Point mPoint = Point.Empty;


        int EmptyLen = 100;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
           // e = new MouseEventArgs(e.Button, e.Clicks, e.X, e.Y + EmptyLen, e.Delta);
            mPoint = e.Location;
            //this.Invalidate(new Rectangle(0, 0, ItemSize.Width, this.Height));
            this.Invalidate();
        }
         
        protected override void OnMouseDown(MouseEventArgs e)
        {
           // e = new MouseEventArgs(e.Button, e.Clicks, e.X, e.Y - EmptyLen, e.Delta);
            mPoint = e.Location;
            base.OnMouseDown(e);
        }
        string getString(Point point)
        {

            return string.Format("{0},{1}：{2}", point.X, point.Y, this.Height);
        }
        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle rect = base.DisplayRectangle;
                return new Rectangle(rect.Left - 4, rect.Top - 4, rect.Width + 6, rect.Height + 6);
            }
        }
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, height, specified);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            switch (Alignment)
            {
                case TabAlignment.Left:
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 147, 202)), new Rectangle(0, 0, ItemSize.Width, this.Height));
                    break;
                case TabAlignment.Top:
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 147, 202)), new Rectangle(0, 0, ItemSize.Height, this.Width));
                    break;
            }
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 147, 202)), new Rectangle(0, 0, ItemSize.Width, this.Height));
            // e.Graphics.DrawRectangle(Pens.Red, new Rectangle(0, 0, ItemSize.Width, this.Height));
            for (int i = 0; i < this.TabCount; i++)
            {
                //e.Graphics.DrawRectangle(Pens.Red, this.GetTabRect(i));
                 this.TabPages[i].BorderStyle = BorderStyle.None;

                 this.TabPages[i].Bounds = new Rectangle(88, 88, 600, 600);
                //this.TabPages[i].SetBounds(0, 0, 100,100, BoundsSpecified.Y);



                // （略）  
                // Calculate text position  
                Rectangle bounds = this.GetTabRect(i);
                PointF textPoint = new PointF();
               // bounds.Y += EmptyLen;
                if (bounds.Contains(mPoint))
                {
                    var rect = new Rectangle(bounds.X - 2, bounds.Y - 1, bounds.Width, bounds.Height);
                    var _rect = new Rectangle(bounds.X - 2 + bounds.Width - 10, bounds.Y - 1, 10, bounds.Height);
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(9, 161, 133)), rect);
                    e.Graphics.FillRectangle(new SolidBrush(Color.DarkGoldenrod), _rect);
                }
                if (this.SelectedIndex == i)
                {
                    var rect = new Rectangle(bounds.X - 2, bounds.Y - 1, bounds.Width, bounds.Height);
                    var _rect = new Rectangle(bounds.X - 2 + bounds.Width - 10, bounds.Y - 1, 10, bounds.Height);
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(9, 61, 133)), rect);
                    e.Graphics.FillRectangle(new SolidBrush(Color.DarkGoldenrod), _rect);
                }
                SizeF textSize = TextRenderer.MeasureText(this.TabPages[i].Text, this.Font);
                // 注意要加上每个标签的左偏移量X  
                textPoint.X
                    = bounds.X + (bounds.Width - textSize.Width) / 2;
                textPoint.Y
                    = bounds.Bottom - textSize.Height - this.Padding.Y;
                // Draw highlights  
                //e.Graphics.DrawString(
                //    this.TabPages[i].Text,
                //    this.Font,
                //    SystemBrushes.ControlLightLight,    // 高光颜色  
                //    textPoint.X,
                //    textPoint.Y);
                // 绘制正常文字  
                textPoint.Y--;
                e.Graphics.DrawString(this.TabPages[i].Text, this.Font, new SolidBrush(this.TabPages[i].ForeColor),    // 正常颜色  
                    textPoint.X,
                    textPoint.Y);
                if (ListImage.Count > i)
                    e.Graphics.DrawImage(ListImage[i],
                        bounds.X + bounds.Width / 4
                        , bounds.Y + bounds.Height / 4 - textSize.Height / 2
                        , bounds.Width / 2
                        , bounds.Height / 2 - textSize.Height / 2
                        );
            }
            // e.Graphics.DrawString("LOGO", new Font("微软雅黑", 16f, FontStyle.Bold), Brushes.Black, new RectangleF(0, 0, ItemSize.Width, ItemSize.Height), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            //e.Graphics.DrawString(getString(mPoint), new Font("微软雅黑", 16f, FontStyle.Bold), Brushes.Black, new RectangleF(0, 500, ItemSize.Width, ItemSize.Height), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

        }
    }
}