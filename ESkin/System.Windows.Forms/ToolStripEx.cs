using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    public class ToolStripEx:ToolStrip
    {
        public ToolStripEx()
        {
            base.SetStyle(
    ControlStyles.UserPaint |                      // 控件将自行绘制，而不是通过操作系统来绘制  
    ControlStyles.OptimizedDoubleBuffer |          // 该控件首先在缓冲区中绘制，而不是直接绘制到屏幕上，这样可以减少闪烁  
    ControlStyles.AllPaintingInWmPaint |           // 控件将忽略 WM_ERASEBKGND 窗口消息以减少闪烁  
    ControlStyles.ResizeRedraw |                   // 在调整控件大小时重绘控件  
    ControlStyles.SupportsTransparentBackColor,    // 控件接受 alpha 组件小于 255 的 BackColor 以模拟透明  
    true);                                         // 设置以上值为 true  
            base.UpdateStyles();
            this.AutoSize = false;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(249)))));
             this.Dock = System.Windows.Forms.DockStyle.None;
            this.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "toolStripEx1";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.Size = new System.Drawing.Size(100, 48);
            this.TabIndex = 0;
            this.Text = "toolStripEx1";
            this.Renderer = new MyMenuRender();
            this.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.SizeChanged += ToolStripEx_SizeChanged;
           // 232, 241, 249
        }

        void ToolStripEx_SizeChanged(object sender, EventArgs e)
        {
            this.ImageScalingSize = new System.Drawing.Size(this.Width/2 - 10 / 2, this.Width/2 - 10 / 2);
            foreach (ToolStripItem item in this.Items)
            {
                item.Invalidate();
            }
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            //Rectangle r = new Rectangle(0, 0, this.Width  , this.Height );
            //this.Region = new Drawing.Region(r);
        }
        public ToolStripItem PressItem { get; set; }
        public ToolStripItem MouseMoveItem { get; set; }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            PressItem = this.GetItemAt(e.Location);
            if (PressItem != null)
            {
                this.Invalidate();
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            //base.OnMouseMove(e);
            MouseMoveItem = this.GetItemAt(e.Location);
            if (MouseMoveItem != null)
            {
                this.Invalidate();
            }
        }
        protected override void OnClick(EventArgs e)
        {
            //base.OnClick(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            //base.OnMouseDown(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            if (PressItem != null && PressItem.Name!="navLOGO")
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(9, 61, 133)), PressItem.Bounds);
                var rect = new Rectangle(PressItem.Bounds.X + PressItem.Bounds.Width - 9
                , PressItem.Bounds.Y
                , 10
                , PressItem.Bounds.Height);
                e.Graphics.FillRectangle(new SolidBrush(Color.DarkGoldenrod), rect);
            }
            if (MouseMoveItem != null && MouseMoveItem.Name != "navLOGO")
            {
                if (PressItem != null && MouseMoveItem != PressItem)
                {
                    var rect = new Rectangle(MouseMoveItem.Bounds.X + MouseMoveItem.Bounds.Width - 9
             , MouseMoveItem.Bounds.Y
             , 10
             , MouseMoveItem.Bounds.Height);
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(9, 161, 133)),
                        MouseMoveItem.Bounds);
                    e.Graphics.FillRectangle(new SolidBrush(Color.DarkGoldenrod), rect);

                }
            }
            base.OnPaint(e);

        }
    }
    class MenuBarColor : ProfessionalColorTable
    {
        Color ManuBarCommonColor = Color.Brown;
        Color SelectedHighlightColor = Color.BurlyWood;
        Color MenuBorderColor = Color.Chartreuse;
        Color MenuItemBorderColor = Color.Coral;
        /// <summary> 
        /// Initialize a new instance of the Visual Studio MenuBarColor class. 
        /// </summary> 
        public MenuBarColor()
        {
        }
        #region
        public override Color MenuItemPressedGradientBegin
        {
            get
            {
                return ManuBarCommonColor;
            }
        }
        public override Color MenuItemPressedGradientEnd
        {
            get
            {
                return ManuBarCommonColor;
            }
        }
        public override Color MenuItemPressedGradientMiddle
        {
            get
            {
                return ManuBarCommonColor;
            }
        }
        public override Color ButtonSelectedHighlight
        {
            get
            {
                return ManuBarCommonColor;
            }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return ManuBarCommonColor;
            }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return ManuBarCommonColor;
            }
        }
        public override Color MenuBorder
        {
            get
            {
                return MenuBorderColor;
            }
        }
        public override Color MenuItemBorder
        {
            get
            {
                return MenuItemBorderColor;
            }
        }
        #endregion
    }
     public class ColorConfig  
    {  
        private Color _fontcolor = Color.White;  
        /// <summary>  
        /// 菜单字体颜色  
        /// </summary>  
        public Color FontColor  
        {  
            get { return this._fontcolor; }  
            set { this._fontcolor = value; }  
        }  
        private Color _marginstartcolor = Color.FromArgb(113, 113, 113);  
        /// <summary>  
        /// 下拉菜单坐标图标区域开始颜色  
        /// </summary>  
        public Color MarginStartColor  
        {  
            get { return this._marginstartcolor; }  
            set { this._marginstartcolor = value; }  
        }  
        private Color _marginendcolor = Color.FromArgb(58, 58, 58);  
        /// <summary>  
        /// 下拉菜单坐标图标区域结束颜色  
        /// </summary>  
        public Color MarginEndColor  
        {  
            get { return this._marginendcolor; }  
            set { this._marginendcolor = value; }  
        }  
        private Color _dropdownitembackcolor = Color.FromArgb(34, 34, 34);  
        /// <summary>  
        /// 下拉项背景颜色  
        /// </summary>  
        public Color DropDownItemBackColor  
        {  
            get { return this._dropdownitembackcolor; }  
            set { this._dropdownitembackcolor = value; }  
        }  
        private Color _dropdownitemstartcolor = Color.Orange;  
        /// <summary>  
        /// 下拉项选中时开始颜色  
        /// </summary>  
        public Color DropDownItemStartColor  
        {  
            get { return this._dropdownitemstartcolor; }  
            set { this._dropdownitemstartcolor = value; }  
        }  
        private Color _dorpdownitemendcolor = Color.FromArgb(160,100,20);  
        /// <summary>  
        /// 下拉项选中时结束颜色  
        /// </summary>  
        public Color DropDownItemEndColor  
        {  
            get { return this._dorpdownitemendcolor; }  
            set { this._dorpdownitemendcolor = value; }  
        }  
        private Color _menuitemstartcolor = Color.FromArgb(52, 106, 159);  
        /// <summary>  
        /// 主菜单项选中时的开始颜色  
        /// </summary>  
        public Color MenuItemStartColor  
        {  
            get { return this._menuitemstartcolor; }  
            set { this._menuitemstartcolor = value; }  
        }  
        private Color _menuitemendcolor = Color.FromArgb(73, 124, 174);  
        /// <summary>  
        /// 主菜单项选中时的结束颜色  
        /// </summary>  
        public Color MenuItemEndColor  
        {  
            get { return this._menuitemendcolor; }  
            set { this._menuitemendcolor = value; }  
        }  
        private Color _separatorcolor = Color.Gray;  
        /// <summary>  
        /// 分割线颜色  
        /// </summary>  
        public Color SeparatorColor  
        {  
            get { return this._separatorcolor; }  
            set { this._separatorcolor = value; }  
        }  
        private Color _mainmenubackcolor = Color.Black;  
        /// <summary>  
        /// 主菜单背景色  
        /// </summary>  
        public Color MainMenuBackColor  
        {  
            get { return this._mainmenubackcolor; }  
            set { this._mainmenubackcolor = value; }  
        }  
        private Color _mainmenustartcolor = Color.FromArgb(93, 93, 93);  
        /// <summary>  
        /// 主菜单背景开始颜色  
        /// </summary>  
        public Color MainMenuStartColor  
        {  
            get { return this._mainmenustartcolor; }  
            set { this._mainmenustartcolor = value; }  
        }  
        private Color _mainmenuendcolor = Color.FromArgb(34, 34, 34);  
        /// <summary>  
        /// 主菜单背景结束颜色  
        /// </summary>  
        public Color MainMenuEndColor  
        {  
            get { return this._mainmenuendcolor; }  
            set { this._mainmenuendcolor = value; }  
        }  
        private Color _dropdownborder = Color.FromArgb(40, 96, 151);  
        /// <summary>  
        /// 下拉区域边框颜色  
        /// </summary>  
        public Color DropDownBorder  
        {  
            get { return this._dropdownborder; }  
            set { this._dropdownborder = value; }  
        }  
    }

     public class MyMenuRender : ToolStripProfessionalRenderer
     {
         //ColorConfig colorconfig = new ColorConfig();//创建颜色配置类 

         public MyMenuRender()
            : base(new MenuBarColor()) 
        {
        }
         /// <summary>
         /// 重绘图标位置可以在这改
         /// </summary>
         /// <param name="e"></param>
         protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
         {
             if(e.Image!=null)
             e.Graphics.DrawImage(e.Image, e.ImageRectangle);
            // base.OnRenderItemImage(e);
         }
         /// <summary>  
         /// 渲染整个背景  
         /// </summary>  
         /// <param name="e"></param>  
         protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
         {
             e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 147, 202)), e.AffectedBounds);
            // e.Graphics.DrawImage(ESkin.Properties.Resources., e.AffectedBounds);  
         }

         
         /// <summary>  
         /// 渲染鼠标停靠项的背景  
         /// </summary>  
         /// <param name="e"></param>  
         protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
         {
             base.OnRenderButtonBackground(e);
             //var toolStrip = e.ToolStrip as ToolStripEx;

             //if (toolStrip != null && toolStrip.PressItem != null && toolStrip.PressItem == e.Item)
             //{
             //    return;
             //}
             //if (e.Item.Selected)
             //{

             //    var rect = new Rectangle(e.Item.Bounds.X + e.Item.Bounds.Width - 9
             //  , e.Item.Bounds.Y
             //  , 10
             //  , e.Item.Bounds.Height);
             //    e.Graphics.FillRectangle(new SolidBrush(Color.DarkGoldenrod), rect);
             //    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(9, 161, 133)),
             //        //new Rectangle(0, 0, e.Item.Size.Width, e.Item.Size.Height));
             //        e.Item.Bounds);


             //}
             //if(e.Item.Pressed)
             //{
             //    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(9, 61, 133)), new Rectangle(0, 0, e.Item.Size.Width, e.Item.Size.Height));
             //}
         }
         /// <summary>  
         /// 渲染菜单项的分隔线  
         /// </summary>  
         /// <param name="e"></param>  
         //protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
         //{
         //    e.Graphics.DrawLine(new Pen(colorconfig.SeparatorColor), 0, 2, e.Item.Width, 2);
         //}
         /// <summary>  
         /// 渲染边框  
         /// </summary>  
         /// <param name="e"></param>  
         protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
         {
             
             //ToolStrip toolStrip = e.ToolStrip;
             //e.Graphics.SmoothingMode = SmoothingMode.HighQuality;//抗锯齿
             ////e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;//抗锯齿
             //Rectangle bounds = e.AffectedBounds;
             //Rectangle rect = new Rectangle(Point.Empty, toolStrip.Size);
             //e.Graphics.DrawRectangle(Pens.Red, 0, 0, toolStrip.Width - 1, toolStrip.Height - 1);  
             //e.Graphics.SetClip(bounds);
              base.OnRenderToolStripBorder(e);
         }
         /// <summary>  
         /// 渲染箭头  
         /// </summary>  
         /// <param name="e"></param>  
         protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
         {
             //e.ArrowColor = Color.Red;//设置为红色，当然还可以 画出各种形状  
             //base.OnRenderArrow(e);
         }
         /// <summary>  
         /// 填充线性渐变  
         /// </summary>  
         /// <param name="g">画布</param>  
         /// <param name="rect">填充区域</param>  
         /// <param name="startcolor">开始颜色</param>  
         /// <param name="endcolor">结束颜色</param>  
         /// <param name="angle">角度</param>  
         /// <param name="blend">对象的混合图案</param>  
         private void FillLineGradient(Graphics g, Rectangle rect, Color startcolor, Color endcolor, float angle, Blend blend)
         {
             LinearGradientBrush linebrush = new LinearGradientBrush(rect, startcolor, endcolor, angle);
             if (blend != null)
             {
                 linebrush.Blend = blend;
             }
             GraphicsPath path = new GraphicsPath();
             path.AddRectangle(rect);
             g.SmoothingMode = SmoothingMode.AntiAlias;
             g.FillPath(linebrush, path);
         }
     }
}  
 
