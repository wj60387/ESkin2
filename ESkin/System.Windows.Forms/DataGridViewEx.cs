using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms.VisualStyles;

namespace  System.Windows.Forms
{


    public class DataGridViewEx:DataGridView
    {
        public DataGridViewEx()
        {
            SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor, true);
            this.BackgroundColor = Color.White;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.BorderStyle = Forms.BorderStyle.None;
            this.CellBorderStyle = DataGridViewCellBorderStyle.None;

            this.DefaultCellStyle.BackColor = DefaultCellStyle.SelectionBackColor = Color.White;
            this.DefaultCellStyle.SelectionForeColor = Color.FromArgb(100, 200, 250);
             
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            //行头样式消除
            this.EnableHeadersVisualStyles = false;


            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ColumnHeadersHeight = 24;
            this.ColumnHeadersDefaultCellStyle.BackColor = ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            this.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(100, 200, 250);
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.RowHeadersDefaultCellStyle.BackColor = RowHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            this.RowHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(100, 200, 250);
            //去掉小三角
            this.RowHeadersDefaultCellStyle.Padding = new Padding(this.RowHeadersWidth);

            this.ReadOnly = true;
            //固定行列高度
            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.RowHeadersWidth = 70;

            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ColumnHeadersHeight = 40;
                
        }

          Image xhImage = ESkin.Properties.Resources.序号;

        HitTestInfo CurCellInfo = HitTestInfo.Nowhere;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            CurCellInfo = this.HitTest(e.X, e.Y);
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            System.Drawing.Rectangle xh = this.GetCellDisplayRectangle(-1, -1, true);
            var fSize = TextRenderer.MeasureText("序号", this.Font);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString("序号", this.Font, new SolidBrush(this.ForeColor), xh, sf);
            e.Graphics.DrawImage(xhImage, xh.X + fSize.Width, this.ColumnHeadersHeight / 2 - xhImage.Height/2, xhImage.Width, xhImage.Height);


         //   e.Graphics.DrawRectangle(Pens.Red, xh);
          //  e.Graphics.DrawRectangle(Pens.Green, new Rectangle(0,0,RowHeadersWidth,ColumnHeadersHeight));

            if (ListColumnImage.Count == this.Columns.Count)
                for (int i = 0; i < this.Columns.Count; i++)
                {
                    if (ListColumnImage[i] == null) continue;
                    System.Drawing.Rectangle rect = this.GetCellDisplayRectangle(i, -1, true);

                    var cloumnText=this.Columns[i].HeaderText;
                    var textRect=TextRenderer.MeasureText(cloumnText,this.Font);
                    e.Graphics.DrawImage(ListColumnImage[i], rect.X + rect.Width / 2 + textRect.Width/2-4,   rect.Height / 2 - ListColumnImage[i].Height / 2+2, ListColumnImage[i].Width, ListColumnImage[i].Height);
                   //  e.Graphics.DrawRectangle(  Pens.Red, rect);
                }
            //if (CurCellInfo.RowIndex >= 0 && CurCellInfo.ColumnIndex >= 0)
            //{
               

            //    var rowRect = this.GetRowDisplayRectangle(CurCellInfo.RowIndex, false);
            //    var rowBounds = new Rectangle(rowRect.X - 1, rowRect.Y, rowRect.Width, rowRect.Height - 1);
            //    e.Graphics.DrawRectangle(new Pen(Color.Red), rowBounds);

            //}
        }
        protected override void OnScroll(ScrollEventArgs e)
        {
             
            base.OnScroll(e);
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            
        }
        public List<Image> ListColumnImage = new List<Image>();
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            base.OnRowPostPaint(e);
            var rowIdx = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,

                
            };
            var color = this.Rows[e.RowIndex].Selected ? Color.FromArgb(100, 200, 250) : Color.Black;
            var rowBounds = new Rectangle(e.RowBounds.X, e.RowBounds.Y, e.RowBounds.Width, e.RowBounds.Height - 1);
           
           
            //var _color = this.SelectedRows[0].Index == e.RowIndex ?
            //       this.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor :
            //       this.Rows[e.RowIndex].DefaultCellStyle.ForeColor;

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, this.RowHeadersWidth, e.RowBounds.Height);
            using (var brush = new SolidBrush(color))
            {
               // var g = e.Graphics;
                //g.SmoothingMode = SmoothingMode.AntiAlias;
              //  e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                var eRect = new Rectangle(e.RowBounds.Left + headerBounds.Width / 2 - indexSize / 2, e.RowBounds.Top + headerBounds.Height / 2 - indexSize / 2, indexSize, indexSize);
                if (this.Rows[e.RowIndex].Selected)
                    e.Graphics.DrawImage(ESkin.Properties.Resources.圆亮, eRect);
                else
                    e.Graphics.DrawImage(ESkin.Properties.Resources.圆黑, eRect);
                    // e.Graphics.DrawEllipse(new Pen(color,2f), eRect);
                var textRect = new Rectangle(eRect.X, eRect.Y, eRect.Width-1, eRect.Height);
                e.Graphics.DrawString(rowIdx, new Font(this.Font.FontFamily, (e.RowIndex >= 999?6f:(e.RowIndex >= 99 ? 8f : 9f))), brush, textRect, centerFormat);
                //e.Graphics.DrawRectangle(new Pen(color, 1f), new Rectangle(eRect.X + this.RowHeadersWidth - 2, e.RowBounds.Top, 2, this.RowTemplate.Height));
                e.Graphics.FillRectangle(brush, new Rectangle(e.RowBounds.Left + this.RowHeadersWidth -10, eRect.Y, 2, indexSize));
                if (this.Rows[e.RowIndex].Selected)
                    e.Graphics.DrawRectangle(new Pen(color), new Rectangle(e.RowBounds.X - 1, e.RowBounds.Y + boderPad, e.RowBounds.Width + 1, headerBounds.Height - 2 * boderPad));
            }
            
        }
        int boderPad = 4;
        public int BoderPad
        {
            get { return boderPad; }
            set { boderPad = value; }
        }
        int indexSize = 23;
        public int IndexSize {
            get { return indexSize; }
            set { indexSize = value; }
        }
        protected override void OnRowPrePaint(DataGridViewRowPrePaintEventArgs e)
        {
            base.OnRowPrePaint(e);
        }
        protected override void OnDataError(bool displayErrorDialogIfNoHandler, DataGridViewDataErrorEventArgs e)
        {
            //base.OnDataError(displayErrorDialogIfNoHandler, e);
        }
    }

    #region   扩展的复选框列
    class DataGridViewCheckBoxExControl : CheckBoxEx, IDataGridViewEditingControl
    {
        /// <summary>
        /// 当前所在表格
        /// </summary>
        private DataGridView MyDataGridView { set; get; }
        /// <summary>
        /// 值是否发生更改
        /// </summary>
        private bool ValueChanged { set; get; }
        /// <summary>
        /// 当前所在行
        /// </summary>
        private int RowIndex { set; get; }

        protected override void OnCheckedChanged(EventArgs e)
        {
            ValueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnCheckedChanged(e);
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
            ForeColor = dataGridViewCellStyle.ForeColor;
            BackColor = dataGridViewCellStyle.BackColor;
        }

        public DataGridView EditingControlDataGridView
        {
            get
            {
                return MyDataGridView;
            }
            set
            {
                MyDataGridView = value;
            }
        }

        public object EditingControlFormattedValue
        {
            get
            {
                return GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting);
            }
            set
            {
                Checked = value == null ? false : (bool)value;
            }
        }

        public int EditingControlRowIndex
        {
            get
            {
                return RowIndex;
            }
            set
            {
                RowIndex = value;
            }
        }

        public bool EditingControlValueChanged
        {
            get
            {
                return ValueChanged;
            }
            set
            {
                ValueChanged = value;
            }
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.LButton:
                    return !dataGridViewWantsInputKey;
            }
            return !dataGridViewWantsInputKey;
        }

        public Cursor EditingPanelCursor
        {
            get { return Cursors.Default; }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return this.Checked;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {

        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }
    }
    public class DataGridViewCheckBoxExCell : DataGridViewCell
    {
        Image image = ESkin.Properties.Resources._16x16_没勾选;

        public DataGridViewCheckBoxExCell()
            : base()
        {
             
        }

        private static Type defaultEditType = typeof(DataGridViewCheckBoxExControl);
        private static Type defaultValueType = typeof(System.Boolean);

        public override Type EditType
        {
            get { return defaultEditType; }
        }

        /// <summary>
        /// 单元格边框颜色
        /// </summary>
       // private Color CellBorderColor { get { return Color.Transparent; } }
        private Color CellBorderColor { get { return Color.FromArgb(100,200,250); } }
       // private Color CellBorderColor { get { return Color.Transparent; } }


        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {

            var boundRect = new Rectangle(cellBounds.X, cellBounds.Y, cellBounds.Width, cellBounds.Height - 1);

            var check = (bool)(value ?? false);
            if (paintParts == DataGridViewPaintParts.Background || paintParts == DataGridViewPaintParts.All)
            {
                graphics.FillRectangle(new SolidBrush(Color.White), boundRect);
                // graphics.FillRectangle(new SolidBrush(cellStyle.BackColor), boundRect);
            }
            if (paintParts == DataGridViewPaintParts.Border || paintParts == DataGridViewPaintParts.All)
            {
                // var color = cellState == DataGridViewElementStates.Selected ? Color.Red : Color.Transparent;
                // graphics.DrawLine(new Pen(CellBorderColor), cellBounds.X, cellBounds.Y, cellBounds.X + cellBounds.Width,  cellBounds.Y);
                graphics.DrawRectangle(new Pen(Color.White), boundRect);
            }
            if (paintParts == DataGridViewPaintParts.SelectionBackground || Selected)
            {
                //graphics.FillRectangle(new SolidBrush(cellStyle.SelectionBackColor), cellBounds);
            }
            //var col = OwningColumn as DataGridViewCheckBoxTextColumn;
            //if (col != null && !string.IsNullOrEmpty(col.Text))
            //{
            //graphics.DrawString(check ? "TRUE" : "FALSE", cellStyle.Font, new SolidBrush(Selected ?
            //    cellStyle.SelectionForeColor : cellStyle.ForeColor),
            //    new Point(cellBounds.X + 25, cellBounds.Y + cellBounds.Height / 4));
            //}
            //this.OwningRow.Height
            //this.OwningColumn.Width
            if ((cellState & DataGridViewElementStates.Selected) != 0)
            {
                image = check ? ESkin.Properties.Resources._16x16勾选点击状态 : ESkin.Properties.Resources._16x16_没勾选点击状态;
            }
            else
            {
                image = check ? ESkin.Properties.Resources._16x16勾选 : ESkin.Properties.Resources._16x16_没勾选;
            }
            var rect = new Rectangle(cellBounds.X + 24, cellBounds.Y + cellBounds.Height / 2 - image.Height / 2, image.Width, image.Height);
            //  image = check ? ESkin.Properties.Resources._16x16勾选点击状态 : ESkin.Properties.Resources._16x16_没勾选点击状态;
            graphics.DrawImage(image, rect);
           // graphics.DrawImage(image, cellBounds.X + cellBounds.X / 2 - image.Width / 2, cellBounds.Y + 4);
            //CheckBoxRenderer.DrawCheckBox(graphics, new Point(cellBounds.X + 4, cellBounds.Y + cellBounds.Height / 4), CheckState);
            // base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        }

        /// <summary>
        /// <summary>
        /// 当前复选框的状态
        /// </summary>
        private CheckBoxState CheckState { set; get; }


        protected override void OnMouseDown(DataGridViewCellMouseEventArgs e)
        {
            var check = (bool)Value;
            CheckState = check ? CheckBoxState.CheckedPressed : CheckBoxState.UncheckedPressed;
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(DataGridViewCellMouseEventArgs e)
        {
            var check = (bool)Value;
            Value = !check;
            SetValue(RowIndex, Value);
            CheckState = check ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal;
            base.OnMouseUp(e);
        }

        public override Type ValueType
        {
            get
            {
                Type valueType = base.ValueType;
                if (valueType != null)
                {
                    return valueType;
                }
                return defaultValueType;
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                return true;
            }
        }
    }
    public class DataGridViewCheckBoxExColumn : DataGridViewColumn
    {
        
        
        public DataGridViewCheckBoxExColumn()
            : base()
        {
            CellTemplate = new DataGridViewCheckBoxExCell();
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewCheckBoxExCell)))
                {
                    throw new Exception("这个列里面必须绑定MyDataGridViewCheckBoxCell");
                }
                base.CellTemplate = value;
            }
        }

        public override object Clone()
        {
            DataGridViewCheckBoxExColumn col = (DataGridViewCheckBoxExColumn)base.Clone();
            col.Text = Text;
            return col;
        }

        public string Text { set; get; }


    }

    #endregion

    #region   扩展的按钮列
      class DataGridViewButtonExControl : ButtonEx, IDataGridViewEditingControl
    {
        private DataGridView MyDataGridView { set; get; }
        private int RowIndex { set; get; }

        

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
            ForeColor = dataGridViewCellStyle.ForeColor;
            BackColor = dataGridViewCellStyle.BackColor;
        }

        public DataGridView EditingControlDataGridView
        {
            get
            {
                return MyDataGridView;
            }
            set
            {
                MyDataGridView = value;
            }
        }

        public object EditingControlFormattedValue
        {
            get
            {
                return GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting);
            }
            set
            {
                this.Text = value +"";
            }
        }
        

        public int EditingControlRowIndex
        {
            get
            {
                return RowIndex;
            }
            set
            {
                RowIndex = value;
            }
        }
        
        private bool valueChanged = false;
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.LButton:
                    return !dataGridViewWantsInputKey;
            }
            return !dataGridViewWantsInputKey;
        }

        public Cursor EditingPanelCursor
        {
            get { return Cursors.Default; }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return this.Text;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {

        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }
    }

      public class DataGridViewButtonExCell : DataGridViewCell
      {
         
         
           
          public DataGridViewButtonExCell()
              : base()
          {
          }
          private static Type defaultEditType = typeof(DataGridViewButtonExControl);
          private static Type defaultValueType = typeof(System.String);

          public override Type EditType
          {
              get { return defaultEditType; }
          }
          public override Type ValueType
          {
              get
              {
                  Type valueType = base.ValueType;
                  if (valueType != null)
                  {
                      return valueType;
                  }
                  return defaultValueType;
              }
          }

          public override object DefaultNewRowValue
          {
              get
              {
                  return "按钮";
              }
          }


          protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
          {
              var boundRect = new Rectangle(cellBounds.X, cellBounds.Y, cellBounds.Width, cellBounds.Height - 1);
              if (paintParts == DataGridViewPaintParts.Background || paintParts == DataGridViewPaintParts.All)
              {
                  graphics.FillRectangle(new SolidBrush(Color.White), boundRect);
                  // graphics.FillRectangle(new SolidBrush(cellStyle.BackColor), boundRect);
              }
              if (paintParts == DataGridViewPaintParts.Border || paintParts == DataGridViewPaintParts.All)
              {
                  // var color = cellState == DataGridViewElementStates.Selected ? Color.Red : Color.Transparent;
                  // graphics.DrawLine(new Pen(CellBorderColor), cellBounds.X, cellBounds.Y, cellBounds.X + cellBounds.Width,  cellBounds.Y);
                  graphics.DrawRectangle(new Pen(Color.White), boundRect);
              }
              if (paintParts == DataGridViewPaintParts.SelectionBackground || Selected)
              {
                  //graphics.FillRectangle(new SolidBrush(cellStyle.SelectionBackColor), cellBounds);
              }
              Image image = null;
              var col = OwningColumn as DataGridViewButtonExColumn;
              if ((cellState & DataGridViewElementStates.Selected) != 0)
              {
                  image = col.HoverImage;
              }
              else
              {
                  image = col.NomalImage;
              }
              var sf = new StringFormat() {
                  Alignment =StringAlignment.Near,
                  LineAlignment= StringAlignment.Center
              };
              var text = col.Text;
              Size textSize = TextRenderer.MeasureText(text, cellStyle.Font);
              var exWidth = (cellBounds.Width - (image == null ? 0 : image.Width) - textSize.Width) / 2;
              var exHeight =   cellBounds.Height / 4;

              if (!string.IsNullOrEmpty(text))
              graphics.DrawString(text, cellStyle.Font, new SolidBrush(Selected ?
                cellStyle.SelectionForeColor : cellStyle.ForeColor),
                new Point(cellBounds.X + exWidth + image.Width, cellBounds.Y + exHeight-4));

              var rect = new Rectangle(cellBounds.X + cellBounds.Width / 2 - image.Width / 2, cellBounds.Y + cellBounds.Height / 2 - image.Height / 2, image.Width, image.Height);

              if (image!=null)
             // var rect = new Rectangle(cellBounds.X + 4, cellBounds.Y + cellBounds.Height / 2 - image.Height / 2, image.Width, image.Height);
                  graphics.DrawImage(image, rect);
          }
      }
      public class DataGridViewButtonExColumn : DataGridViewColumn
      {


          public Image HoverImage { get; set; }
          public Image NomalImage { get; set; }
          public string Text { get; set; }
          public DataGridViewButtonExColumn()
              : base()
          {
              CellTemplate = new DataGridViewButtonExCell();
               
          }
         // public Image Image { get; set; }
          public DataGridViewButtonExColumn(string Text,Image HoverImage,Image NomalImage)
              : base()
          {
              CellTemplate = new DataGridViewButtonExCell();
              this.Text = Text;
              this.HoverImage = HoverImage;
              this.NomalImage = NomalImage;
              
          }

          public override DataGridViewCell CellTemplate
          {
              get
              {
                  return base.CellTemplate;
              }
              set
              {
                  if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewButtonExCell)))
                  {
                      throw new Exception("这个列里面必须绑定MyDataGridViewButtonExCell");
                  }
                  base.CellTemplate = value;
              }
          }

          public override object Clone()
          {
              DataGridViewButtonExCell col = (DataGridViewButtonExCell)base.Clone();
             // col.text = HeaderText;
              return col;
          }
      }

    #endregion
}
