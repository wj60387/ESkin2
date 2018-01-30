using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace  System.Windows.Forms
{
     [ToolboxBitmap(typeof(RadioButton))]
    public class RadioButtonEx: RadioButton
    {
        private Color _baseColor = Color.FromArgb(51, 161, 224);
        private static readonly ContentAlignment RightAlignment =
            ContentAlignment.TopRight |
            ContentAlignment.BottomRight |
            ContentAlignment.MiddleRight;
        private static readonly ContentAlignment LeftAligbment =
            ContentAlignment.TopLeft |
            ContentAlignment.BottomLeft |
            ContentAlignment.MiddleLeft;
         public RadioButtonEx()
            : base()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor, true);
        }
         protected  virtual int DefaultCheckButtonWidth
         {
             get { return 16; }
         }
         public Image image = ESkin.Properties.Resources.单选框未选中;
         protected override void OnPaint(PaintEventArgs e)
         {
             base.OnPaint(e);
             base.OnPaintBackground(e);
             Graphics g = e.Graphics;
             Rectangle checkButtonRect;
             Rectangle textRect;
             CalculateRect(out checkButtonRect, out textRect);
             g.SmoothingMode = SmoothingMode.AntiAlias;

             Color backColor = ControlPaint.Light(_baseColor);

             //if (Enabled)
             //{
                  
                 image = !Checked?ESkin.Properties.Resources.单选框未选中:
                         
                          ESkin.Properties.Resources.单选框选中;
             //}
             DrawCheckedFlag(g, checkButtonRect, image);
             Color textColor = Enabled ? ForeColor : SystemColors.GrayText;
             TextRenderer.DrawText(
                 g,
                 Text,
                 Font,
                 textRect,
                 textColor,
                 GetTextFormatFlags(TextAlign, RightToLeft == RightToLeft.Yes));
         }

         private void CalculateRect(
           out Rectangle checkButtonRect, out Rectangle textRect)
         {
             checkButtonRect = new Rectangle(
                 0, 0, DefaultCheckButtonWidth, DefaultCheckButtonWidth);
             textRect = Rectangle.Empty;
             bool bCheckAlignLeft = (int)(LeftAligbment & CheckAlign) != 0;
             bool bCheckAlignRight = (int)(RightAlignment & CheckAlign) != 0;
             bool bRightToLeft = RightToLeft == RightToLeft.Yes;

             if ((bCheckAlignLeft && !bRightToLeft) ||
                 (bCheckAlignRight && bRightToLeft))
             {
                 switch (CheckAlign)
                 {
                     case ContentAlignment.TopRight:
                     case ContentAlignment.TopLeft:
                         checkButtonRect.Y = 2;
                         break;
                     case ContentAlignment.MiddleRight:
                     case ContentAlignment.MiddleLeft:
                         checkButtonRect.Y = (Height - DefaultCheckButtonWidth) / 2;
                         break;
                     case ContentAlignment.BottomRight:
                     case ContentAlignment.BottomLeft:
                         checkButtonRect.Y = Height - DefaultCheckButtonWidth - 2;
                         break;
                 }

                 checkButtonRect.X = 1;

                 textRect = new Rectangle(
                     checkButtonRect.Right + 2,
                     0,
                     Width - checkButtonRect.Right - 4,
                     Height);
             }
             else if ((bCheckAlignRight && !bRightToLeft)
                 || (bCheckAlignLeft && bRightToLeft))
             {
                 switch (CheckAlign)
                 {
                     case ContentAlignment.TopLeft:
                     case ContentAlignment.TopRight:
                         checkButtonRect.Y = 2;
                         break;
                     case ContentAlignment.MiddleLeft:
                     case ContentAlignment.MiddleRight:
                         checkButtonRect.Y = (Height - DefaultCheckButtonWidth) / 2;
                         break;
                     case ContentAlignment.BottomLeft:
                     case ContentAlignment.BottomRight:
                         checkButtonRect.Y = Height - DefaultCheckButtonWidth - 2;
                         break;
                 }

                 checkButtonRect.X = Width - DefaultCheckButtonWidth - 1;

                 textRect = new Rectangle(
                     2, 0, Width - DefaultCheckButtonWidth - 6, Height);
             }
             else
             {
                 switch (CheckAlign)
                 {
                     case ContentAlignment.TopCenter:
                         checkButtonRect.Y = 2;
                         textRect.Y = checkButtonRect.Bottom + 2;
                         textRect.Height = Height - DefaultCheckButtonWidth - 6;
                         break;
                     case ContentAlignment.MiddleCenter:
                         checkButtonRect.Y = (Height - DefaultCheckButtonWidth) / 2;
                         textRect.Y = 0;
                         textRect.Height = Height;
                         break;
                     case ContentAlignment.BottomCenter:
                         checkButtonRect.Y = Height - DefaultCheckButtonWidth - 2;
                         textRect.Y = 0;
                         textRect.Height = Height - DefaultCheckButtonWidth - 6;
                         break;
                 }

                 checkButtonRect.X = (Width - DefaultCheckButtonWidth) / 2;

                 textRect.X = 2;
                 textRect.Width = Width - 4;
             }
         }

         private void DrawCheckedFlag(Graphics graphics, Rectangle rect, Image image)
         {
             graphics.DrawImage(image, rect);
         }
         internal static TextFormatFlags GetTextFormatFlags(
             ContentAlignment alignment,
             bool rightToleft)
         {
             TextFormatFlags flags = TextFormatFlags.WordBreak |
                 TextFormatFlags.SingleLine;
             if (rightToleft)
             {
                 flags |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
             }

             switch (alignment)
             {
                 case ContentAlignment.BottomCenter:
                     flags |= TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                     break;
                 case ContentAlignment.BottomLeft:
                     flags |= TextFormatFlags.Bottom | TextFormatFlags.Left;
                     break;
                 case ContentAlignment.BottomRight:
                     flags |= TextFormatFlags.Bottom | TextFormatFlags.Right;
                     break;
                 case ContentAlignment.MiddleCenter:
                     flags |= TextFormatFlags.HorizontalCenter |
                         TextFormatFlags.VerticalCenter;
                     break;
                 case ContentAlignment.MiddleLeft:
                     flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
                     break;
                 case ContentAlignment.MiddleRight:
                     flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Right;
                     break;
                 case ContentAlignment.TopCenter:
                     flags |= TextFormatFlags.Top | TextFormatFlags.HorizontalCenter;
                     break;
                 case ContentAlignment.TopLeft:
                     flags |= TextFormatFlags.Top | TextFormatFlags.Left;
                     break;
                 case ContentAlignment.TopRight:
                     flags |= TextFormatFlags.Top | TextFormatFlags.Right;
                     break;
             }
             return flags;
         }
    }
    
}
