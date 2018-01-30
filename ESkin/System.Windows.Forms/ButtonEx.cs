using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace  System.Windows.Forms
{
    public class ButtonEx : Button
    {

        //bool isRadiusButton = false;
        //public bool IsRadiusButton
        //{
        //    get { return isRadiusButton; }
        //    set { isRadiusButton = value; this.Invalidate(); }
        //}
          int radius=16;
        public int Radius
        {
            get{return radius;}
             set { radius = value; this.Invalidate(); }
        }
       
        //  public Color RadiusColor
        //{
        //    get { return color; }
        //    set { color = value; this.Invalidate(); }
        //}
        Color pressColor = Color.FromArgb(80, 105, 251);
          public Color PressColor
          {
              get { return pressColor; }
              set { pressColor = value; this.Invalidate(); }
          }
          Color hoverColor = Color.FromArgb(60, 85, 230);
          public Color HoverColor
          {
              get { return hoverColor; }
              set { hoverColor = value; this.Invalidate(); }
          }
          Color normalColor = Color.FromArgb(60, 135, 251);
          public Color NormalColor
          {
              get { return normalColor; }
              set { normalColor = value; this.Invalidate(); }
          }

        ControlState ControlState = ControlState.Normal;
        public ButtonEx()
        {
            this.SetStyle(
               ControlStyles.UserPaint |  //控件自行绘制，而不使用操作系统的绘制
               ControlStyles.AllPaintingInWmPaint | //忽略擦出的消息，减少闪烁。
               ControlStyles.OptimizedDoubleBuffer |//在缓冲区上绘制，不直接绘制到屏幕上，减少闪烁。
               ControlStyles.ResizeRedraw | //控件大小发生变化时，重绘。                  
               ControlStyles.SupportsTransparentBackColor, true);//支持透明背景颜色
            this.BackColor = Color.Transparent;
            this.FlatStyle = Forms.FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if(e.Button!= Forms.MouseButtons.Left)
                ControlState = Forms.ControlState.Hover;
            this.Invalidate();
        }
        

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            ControlState = Forms.ControlState.Normal;
            this.Invalidate();
        }
       
        protected override void OnMouseDown(MouseEventArgs e)
        {
           
            base.OnMouseDown(e);
            if (e.Button == Forms.MouseButtons.Left)
            {
                ControlState = Forms.ControlState.Pressed;
                this.Invalidate();
            }

        }
         
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            ControlState = Forms.ControlState.Normal;
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            Color color;
            switch (ControlState)
            {
                case  Forms.ControlState.Pressed:
                    color = PressColor;
                    break;
                case Forms.ControlState.Hover:
                    color = HoverColor;
                    break;
                default:
                    color = NormalColor;
                    break;
            }
            base.OnPaintBackground(e);
            base.OnPaint(e);
            if (BackgroundImage == null)
            {
                using (var brush = new SolidBrush(color))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                    e.Graphics.FillPath(brush, DrawRoundRect(e.ClipRectangle.X, e.ClipRectangle.Y,
                        e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 1, radius));
                }
                using (var brush = new SolidBrush(this.ForeColor))
                {
                    e.Graphics.DrawString(this.Text, this.Font, brush, e.ClipRectangle,
                        new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
            }

        }
        public int LeftTop{get;set;}

        public int RightTop{get;set;}

        public int LeftBottom{get;set;}

        public int RightBottom { get; set; }

        private ArcRadius ArcRadius
        {
            get
            {
                return new ArcRadius(LeftTop, RightTop, LeftBottom, RightBottom);
            }
        }
         
        public   GraphicsPath DrawRoundRect(int x, int y, int width, int height, int radius)
        {
             var rect = new Rectangle(x, y, width, height);
            //GraphicsPath gp = new GraphicsPath();
            //gp.AddArc(x, y, radius, radius, 180, 90);
            //gp.AddArc(width - radius, y, radius, radius, 270, 90);
            //gp.AddArc(width - radius, height - radius, radius, radius, 0, 90);
            //gp.AddArc(x, height - radius, radius, radius, 90, 90);
            //gp.CloseAllFigures();
            //return gp;
            return GraphicsPathHelper.CreateRoundPath(rect,ArcRadius );
        }
    }
     
    public class ArcRadius
    {
        private int _RightBottom=0;
        private int _RightTop=0;
        private int _LeftBottom = 0;
        private int _LeftTop = 0;
        public ArcRadius(int leftTop, int rightTop, int leftBottom, int rightBottom)
        {
            this._RightBottom = rightBottom;
            this._RightTop = rightTop;
            this._LeftBottom = leftBottom;
            this._LeftTop = leftTop;
        }

         
        public int LeftTop
        {
            get
            {
                return this._LeftTop;
            }
            set
            {

                this._LeftTop = value;
            }
        }

        public int RightTop
        {
            get
            {
                return this._RightTop;
            }
            set
            {


                this._RightTop = value;
            }
        }

        public int LeftBottom
        {
            get
            {
                return this._LeftBottom;
            }
            set
            {

                this._LeftBottom = value;
            }
        }

        public int RightBottom
        {
            get
            {
                return this._RightBottom;
            }
            set
            {

                this._RightBottom = value;
            }
        }

       
    }
    public static class GraphicsPathHelper
    {
        public static GraphicsPath CreateRoundPath(Rectangle rect, ArcRadius arcRadius)
        {
            var path = new GraphicsPath();

            if (rect.Width == 0 || rect.Height == 0)
            {
                return path;
            }

            if (arcRadius.LeftTop > 0)
            {
                path.AddArc(
                    rect.Left, rect.Top, arcRadius.LeftTop, arcRadius.LeftTop, 180, 90);
            }

            path.AddLine(new Point(rect.Left + arcRadius.LeftTop, rect.Top),
                         new Point(rect.Right - arcRadius.RightTop, rect.Top));

            if (arcRadius.RightTop > 0)
            {
                path.AddArc(rect.Right - arcRadius.RightTop, rect.Top,
                    arcRadius.RightTop, arcRadius.RightTop, -90, 90);
            }

            path.AddLine(new Point(rect.Right, rect.Top + arcRadius.RightTop),
                         new Point(rect.Right, rect.Bottom - arcRadius.RightBottom));

            if (arcRadius.RightBottom > 0)
            {
                path.AddArc(rect.Right - arcRadius.RightBottom, rect.Bottom - arcRadius.RightBottom,
                    arcRadius.RightBottom, arcRadius.RightBottom, 0, 90);
            }

            path.AddLine(new Point(rect.Right - arcRadius.RightBottom, rect.Bottom),
                         new Point(rect.Left + arcRadius.LeftBottom, rect.Bottom));

            if (arcRadius.LeftBottom > 0)
            {
                path.AddArc(rect.Left, rect.Bottom - arcRadius.LeftBottom,
                    arcRadius.LeftBottom, arcRadius.LeftBottom, 90, 90);
            }

            path.AddLine(new Point(rect.Left, rect.Bottom - arcRadius.LeftBottom),
                         new Point(rect.Left, rect.Top + arcRadius.LeftTop));

            path.CloseFigure();

            return path;
        }
    }
}
