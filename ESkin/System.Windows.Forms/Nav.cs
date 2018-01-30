using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System.Windows.Forms
{


    public class Nav : Control
    {
        public event Action<NavItem> OnItemClick;
        public event Action OnXTClick;
        public event Action OnGYClick;
        public Nav()
        {
            this.Size = new Size(120, 400);
            //this.navItems = new NavItemCollection(this);
            this.BackColor = Color.White;
            this.ForeColor = Color.DarkOrange;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackgroundImage = ESkin.Properties.Resources.导航栏;
             
        }

        int logoHeight = 110;
        public int LogoHeight
        {
            get { return logoHeight; }
            set { logoHeight = value; }
        }

        public List<NavItem> NavItemList = new List<NavItem>();
         static Image GetImage(Image image, float scale = 1.0f)
        {
            return image.GetThumbnailImage((int)(image.Width * scale), (int)(image.Height * scale), () => { return true; }, IntPtr.Zero);
        }
        //private int itemHeight = 0;
        //public int ItemHeight
        //{
        //    get
        //    {
        //        return itemHeight;

        //    }
        //    set
        //    {
        //        itemHeight = value;
        //    }
        //}
        private int padding = 0;
        public int Pading
        {
            get
            {
                return padding;

            }
            set
            {
                padding = value;
            }
        }
        NavItem ActiveItem = null;
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }
        public Rectangle SysBtnRect
        {
            get
            {
                var height = LogoHeight;
                foreach (var item in NavItemList)
                {
                    height += item.Height;
                }
                return new Rectangle(0, height + 16, this.Width, 21);
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            ActiveItem = GetItemByPoint(e.Location);
            if (ActiveItem != null && OnItemClick != null)
            {
                OnItemClick(ActiveItem);
            }
            var height = LogoHeight;
            foreach (var item in NavItemList)
            {
                height += item.Height;
            }
            Rectangle sysBtnRect = new Rectangle(0, height + 16, this.Width, 21);
            Rectangle xtRect = new Rectangle(sysBtnRect.X, sysBtnRect.Y, sysBtnRect.Width / 2, sysBtnRect.Height);
            Rectangle gyRect = new Rectangle(sysBtnRect.X + sysBtnRect.Width / 2, sysBtnRect.Y, sysBtnRect.Width / 2, sysBtnRect.Height);

            if (xtRect.Contains(e.Location))
            {
                if (OnXTClick != null)
                {
                    OnXTClick();
                }
            }
            if (gyRect.Contains(e.Location))
            {
                if (OnGYClick != null)
                {
                    OnGYClick();
                }
            }

        }
        NavItem GetItemByPoint(Point clientPoint)
        {
            var height = LogoHeight;
            for (int i = 0; i < NavItemList.Count; i++)
            {
                var boundItem = new Rectangle(0, height, this.Width, NavItemList[i].Height);
                height += NavItemList[i].Height;
                if (boundItem.Contains(clientPoint))
                {
                    return NavItemList[i];
                }
            }
            return null;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.Invalidate();
        }

        Size ImageSize = new Size(64, 64);

        Image imageXT = GetImage( ESkin.Properties.Resources.系统设置,0.8f);
        Image imageGY = GetImage(ESkin.Properties.Resources.系统关于, 0.8f);
        //public Image ImageXT
        //{
        //    get { return imageXT; }
        //    set { imageXT = value; this.Invalidate(); }
        //}
        //public Image ImageGY
        //{
        //    get { return imageGY; }
        //    set { imageGY = value; this.Invalidate(); }
        //}
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //
            //foreach (var item in NavItems)
            //{

            //}
            var logoRect = new Rectangle(0, 0, this.Width, LogoHeight);

            //var image = ESkin.Properties.Resources.布迪亨LOGO;
            e.Graphics.DrawImage(ESkin.Properties.Resources.布迪亨LOGO, logoRect);
            //e.Graphics.DrawString("LOGO", new Font("微软雅黑", 16f), Brushes.Black, logoRect, new StringFormat()
            //{
            //    Alignment = StringAlignment.Center,
            //    LineAlignment = StringAlignment.Center
            //});
            int height = LogoHeight;
            for (int i = 0; i < NavItemList.Count; i++)
            {
                //  if (!NavItemList[i].ISNomal) continue;
                var boundItem = new Rectangle(0, height, this.Width, NavItemList[i].Height);
                height += NavItemList[i].Height;
                if (ActiveItem == NavItemList[i])
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(9, 61, 133)), boundItem);
                    var _rect = new Rectangle(boundItem.X + boundItem.Width - 5, boundItem.Y, 6, boundItem.Height);
                    e.Graphics.FillRectangle(new SolidBrush(Color.DarkGoldenrod), _rect);
                }

                var curpoint = this.PointToClient(MousePosition);
                if (ActiveItem != NavItemList[i] && boundItem.Contains(curpoint))
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(9, 161, 133)), boundItem);
                    var _rect = new Rectangle(boundItem.X + boundItem.Width - 5, boundItem.Y, 6, boundItem.Height);
                    e.Graphics.FillRectangle(new SolidBrush(Color.DarkGoldenrod), _rect);
                }


                // e.Graphics.DrawRectangle(Pens.Red, boundItem);

                var image = NavItemList[i].Image;

                var rectImage = new Rectangle(boundItem.X + Pading, boundItem.Y + 10, ImageSize.Width, ImageSize.Height);
                if (image != null)
                    //e.Graphics.DrawImage(image, rectImage, new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
                    e.Graphics.DrawImage(image, rectImage.X + rectImage.Width / 2 - image.Width / 2, rectImage.Y);
                var text = NavItemList[i].Text ?? string.Empty;
                var rect = new Rectangle(0, boundItem.Y + 10 + NavItemList[i].Image.Height, this.Width, boundItem.Height - 10 - NavItemList[i].Image.Height);
                using (var brush = new SolidBrush(this.ForeColor))
                {
                    e.Graphics.DrawString(text, this.Font, brush, rect, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                // e.Graphics.DrawImage(image, boundItem.X  - Pading + itemHeight / 2 - image.Width/2, boundItem.Y + Pading);

            }

            {
                var rect = new Rectangle(0, height + 60, this.Width, 40);
                var point = this.PointToClient(MousePosition);
                var text = string.Format("{0}:{1}", point.X, point.Y);
                using (var brush = new SolidBrush(this.ForeColor))
                {
                   // e.Graphics.DrawString(text, this.Font, brush, rect, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    Rectangle sysBtnRect = new Rectangle(0, 16 + height, this.Width, 21);
                    Rectangle xtRect = new Rectangle(sysBtnRect.X + imageXT.Width, sysBtnRect.Y, sysBtnRect.Width / 2, sysBtnRect.Height);
                    Rectangle gyRect = new Rectangle(sysBtnRect.X + sysBtnRect.Width / 2 + imageGY.Width, sysBtnRect.Y, sysBtnRect.Width / 2, sysBtnRect.Height);

                    e.Graphics.DrawImage(imageXT, 0, sysBtnRect.Y + 21 / 2 - imageXT.Height/2);
                    e.Graphics.DrawString("系统", new Font("微软雅黑", 9f), brush, xtRect, new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });
                    e.Graphics.DrawImage(imageGY, sysBtnRect.Width / 2, sysBtnRect.Y + 21 / 2 - imageXT.Height / 2);
                    e.Graphics.DrawString("关于", new Font("微软雅黑",9f), brush, gyRect, new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });

                    // e.Graphics.DrawRectangle(Pens.Red, sysBtnRect);
                }
            }
        }
        private NavItemCollection navItems;
        /// <summary>
        /// 获取当前列表项所有子项的集合
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public NavItemCollection NavItems
        {
            get
            {
                if (navItems == null)
                    navItems = new NavItemCollection(this);
                return navItems;
            }
        }
    }
    public class NavItemCollection : IList, ICollection, IEnumerable
    {
        private int count = 0;
        public int Count { get { return count; } }
        public NavItem[] m_arrNavItems;
        //private ChatListBox owner;
         private Nav owner;
         public NavItemCollection(Nav owner)
        { this.owner = owner; }
        /// <summary>
        /// 分配项
        /// </summary>
        /// <param name="elements"></param>
        private void EnsureSpace(int elements)
        {
            if (m_arrNavItems == null)
                m_arrNavItems = new NavItem[Math.Max(elements, 1)];
            else if (elements + this.count > m_arrNavItems.Length)
            {
                NavItem[] arrTemp = new NavItem[Math.Max(m_arrNavItems.Length * 2, elements + this.count)];
                m_arrNavItems.CopyTo(arrTemp, 0);
                m_arrNavItems = arrTemp;
            }
        }
        public int IndexOf(NavItem navItem)
        {
            return Array.IndexOf<NavItem>(m_arrNavItems, navItem);
        }
        public void Add(NavItem navItem)
        {
            if (navItem == null)
                throw new ArgumentNullException("navItem cannot be null");
            this.EnsureSpace(1);
            if (-1 == IndexOf(navItem))
            {
                navItem.OwnerNav = this.owner;
                m_arrNavItems[this.count++] = navItem;
                if (this.owner != null)
                    this.owner.Invalidate();
            }
        }
        public void AddRange(NavItem[] navItems)
        {
            if (navItems == null)
                throw new ArgumentNullException("NavItems cannot be null");
            this.EnsureSpace(navItems.Length);
            try
            {
                foreach (NavItem navItem in navItems)
                {
                    if (navItem == null)
                        throw new ArgumentNullException("navItem cannot be null");
                    if (-1 == this.IndexOf(navItem))
                    {
                        navItem.OwnerNav = this.owner;
                        m_arrNavItems[this.count++] = navItem;
                    }
                }
            }
            finally
            {
                if (this.owner != null)
                    this.owner.Invalidate();
            }
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.count)
                throw new IndexOutOfRangeException("Index was outside the bounds of the array");
            this.count--;
            for (int i = index, Len = this.count; i < Len; i++)
                m_arrNavItems[i] = m_arrNavItems[i + 1];
            NavItem[] arrTempSubItem = new NavItem[count];
            Array.Copy(m_arrNavItems, arrTempSubItem, count);
            m_arrNavItems = arrTempSubItem;
            if (this.owner != null)
                this.owner.Invalidate();
        }
        public void Remove(NavItem navItem)
        {
            int index = this.IndexOf(navItem);
            if (-1 != index)
                RemoveAt(index);
        }
        void IList.Remove(object value)
        {
            if (value == null)
                throw new ArgumentNullException("value cannot be null");
            this.Remove((NavItem)value);
        }
        int IList.Add(object value)
        {
            if (!(value is NavItem))
                throw new ArgumentException("Value cannot convert to NavItem");
            this.Add((NavItem)value);
            return this.IndexOf((NavItem)value);
        }
        void IList.Clear()
        {
            this.count = 0;
            m_arrNavItems = null;
            if (this.owner != null)
                this.owner.Invalidate();
        }
        public bool Contains(NavItem subItem)
        {
            return this.IndexOf(subItem) != -1;
        }
        bool IList.Contains(object value)
        {
            if (!(value is NavItem))
                throw new ArgumentException("Value cannot convert to ListSubItem");
            return this.Contains((NavItem)value);
        }

        int IList.IndexOf(object value)
        {
            if (!(value is NavItem))
                throw new ArgumentException("Value cannot convert to ListSubItem");
            return this.IndexOf((NavItem)value);
        }

        public void Insert(int index, NavItem navItem)
        {
            if (index < 0 || index >= this.count)
                throw new IndexOutOfRangeException("Index was outside the bounds of the array");
            if (navItem == null)
                throw new ArgumentNullException("SubItem cannot be null");
            this.EnsureSpace(1);
            for (int i = this.count; i > index; i--)
                m_arrNavItems[i] = m_arrNavItems[i - 1];
            navItem.OwnerNav = this.owner;
            m_arrNavItems[index] = navItem;
            this.count++;
            if (this.owner != null)
                this.owner.Invalidate();
        }
        void IList.Insert(int index, object value)
        {
            if (!(value is NavItem))
                throw new ArgumentException("Value cannot convert to ListSubItem");
            this.Insert(index, (NavItem)value);
            if (this.owner != null)
                this.owner.Invalidate();
        }
        bool IList.IsFixedSize
        {
            get { return false; }
        }

        bool IList.IsReadOnly
        {
            get { return false; }
        }



        public object this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                if (!(value is NavItem))
                    throw new ArgumentException("ValuecannotconverttoNavItem");
                this[index] = (NavItem)value;
            }
        }


        void CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException("Array cannot be null");
            m_arrNavItems.CopyTo(array, index);
        }
        void ICollection.CopyTo(Array array, int index)
        {
            this.CopyTo(array, index);
        }

        int ICollection.Count
        {
            get { return this.count; }
        }

        bool ICollection.IsSynchronized
        {
            get { return true; }
        }

        object ICollection.SyncRoot
        {
            get { return this; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0, Len = this.count; i < Len; i++)
                yield return m_arrNavItems[i];
        }
    }
    //public class NavItemCollection : IList, ICollection, IEnumerable
    //{ 
    //     private int count;      //元素个数
    //    public int Count { get { return count; } }
    //    public NavItem[] m_arrItem;
    //    private ChatListBox owner;  //所属的控件
    //    public NavItemCollection(ChatListBox owner) { this.owner = owner; }
    //    //确认存储空间
    //    private void EnsureSpace(int elements)
    //    {
    //        if (m_arrItem == null)
    //            m_arrItem = new NavItem[Math.Max(elements, 1)];
    //        else if (this.count + elements > m_arrItem.Length)
    //        {
    //            NavItem[] arrTemp = new NavItem[Math.Max(this.count + elements, m_arrItem.Length * 2)];
    //            m_arrItem.CopyTo(arrTemp, 0);
    //            m_arrItem = arrTemp;
    //        }
    //    }
    //    /// <summary>
    //    /// 获取列表项所在的索引位置
    //    /// </summary>
    //    /// <param name="item">要获取的列表项</param>
    //    /// <returns>索引位置</returns>
    //    public int IndexOf(NavItem item)
    //    {
    //        return Array.IndexOf<NavItem>(m_arrItem, item);
    //    }
    //    /// <summary>
    //    /// 添加一个列表项
    //    /// </summary>
    //    /// <param name="item">要添加的列表项</param>
    //    public void Add(NavItem item)
    //    {
    //        if (item == null)       //空引用不添加
    //            throw new ArgumentNullException("Item cannot be null");
    //        this.EnsureSpace(1);
    //        if (-1 == this.IndexOf(item))
    //        {         //进制添加重复对象
    //            item.ownerNav = this.owner;
    //            m_arrItem[this.count++] = item;
    //            this.owner.Invalidate();            //添加进去是 进行重绘
    //        }
    //    }
    //}



    public class NavItem : IComparable
    {
        private Nav ownerNav;
        /// <summary>
        /// 获取列表项所在的控件
        /// </summary>
        [Browsable(false)]
        public Nav OwnerNav
        {
            get { return ownerNav; }
            internal set { ownerNav = value; }
        }
        public NavItem()
        {
            this.image = null;
            this.text = string.Empty;
        }
        public NavItem(Image Image)
        {
            this.image = Image;
            this.text = Text;
        }
        public NavItem(Image Image, string Text = "")
        {
            this.image = Image;
            this.text = Text;
        }
        Image image;
        public Image Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }
        string text = string.Empty;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }
        int height = 88;
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        public int CompareTo(object obj)
        {
            if (!(obj is NavItem))
                throw new NotImplementedException("obj is not NavItem");
            NavItem subItem = obj as NavItem;
            return (this.Text).CompareTo(subItem.Text);
        }
    }


    public class NavItemConverter : ExpandableObjectConverter
    {
    }
}
