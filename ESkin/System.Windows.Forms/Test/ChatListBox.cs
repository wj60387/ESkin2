using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Collections;
using System.Threading;

namespace System.Windows.Forms
{
    public class ChatListBox : Control
    {
         public event Action<ChatListItem> OnItemClick;
        public event Action OnXTClick;
        public event Action OnGYClick;
        public ChatListBox()
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
            this.itemHeight = 100;
        }

        int logoHeight = 110;
        public int LogoHeight
        {
            get { return logoHeight; }
            set { logoHeight = value; }
        }

      //  public List<NavItem> NavItemList = new List<NavItem>();

        private int itemHeight = 0;
        public int ItemHeight
        {
            get
            {
                return itemHeight;

            }
            set
            {
                itemHeight = value;
            }
        }
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
        ChatListItem ActiveItem = null;
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            this.Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            ActiveItem = GetItemByPoint(e.Location);
            if (ActiveItem != null && OnItemClick!=null)
            {
                OnItemClick(ActiveItem);
            }
            Rectangle sysBtnRect = new Rectangle(0, this.itemHeight * Items.Count + 16 + LogoHeight, this.Width, 21);
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
            this.Invalidate();
        }
        ChatListItem GetItemByPoint(Point clientPoint)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                var boundItem = new Rectangle(0, i * itemHeight + LogoHeight, this.Width, this.itemHeight);

                if (boundItem.Contains(clientPoint))
                {
                    return Items[i];
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

        Image imageXT = ESkin.Properties.Resources.系统设置;
        Image imageGY = ESkin.Properties.Resources.系统关于;
        public Image ImageXT
        {
            get { return imageXT; }
            set { imageXT = value; this.Invalidate(); }
        }
        public Image ImageGY
        {
            get { return imageGY; }
            set { imageGY = value; this.Invalidate(); }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
             
            var logoRect = new Rectangle(0, 0, this.Width, LogoHeight);
            e.Graphics.DrawString("LOGO", new Font("微软雅黑", 16f), Brushes.Black, logoRect, new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
            for (int i = 0; i < Items.Count; i++)
            {
                //  if (!NavItemList[i].ISNomal) continue;
                var boundItem = new Rectangle(0, i * itemHeight + LogoHeight, this.Width, this.itemHeight);
                if (ActiveItem == Items[i])
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(9, 61, 133)), boundItem);
                    var _rect = new Rectangle(boundItem.X + boundItem.Width - 5, boundItem.Y, 6, boundItem.Height);
                    e.Graphics.FillRectangle(new SolidBrush(Color.DarkGoldenrod), _rect);
                }

                var curpoint = this.PointToClient(MousePosition);
                if (ActiveItem != Items[i] && boundItem.Contains(curpoint))
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(9, 161, 133)), boundItem);
                    var _rect = new Rectangle(boundItem.X + boundItem.Width - 5, boundItem.Y, 6, boundItem.Height);
                    e.Graphics.FillRectangle(new SolidBrush(Color.DarkGoldenrod), _rect);
                }
                // e.Graphics.DrawRectangle(Pens.Red, boundItem);
                var image = Items[i].Image;

                var rectImage = new Rectangle(boundItem.X + Pading, boundItem.Y + 10, ImageSize.Width, ImageSize.Height);
                if (image != null)
                    e.Graphics.DrawImage(image, rectImage, new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

                var text = Items[i].Text ?? string.Empty;
                var rect = new Rectangle(0, boundItem.Y + +10 + 64, this.Width, boundItem.Height - 10 - 64);
                using (var brush = new SolidBrush(this.ForeColor))
                {
                    e.Graphics.DrawString(text, this.Font, brush, rect, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                // e.Graphics.DrawImage(image, boundItem.X  - Pading + itemHeight / 2 - image.Width/2, boundItem.Y + Pading);

            }

            {
                var rect = new Rectangle(0, this.itemHeight * Items.Count + 60 + LogoHeight, this.Width, 40);
                var point = this.PointToClient(MousePosition);
                var text = string.Format("{0}:{1}", point.X, point.Y);
                using (var brush = new SolidBrush(this.ForeColor))
                {
                    e.Graphics.DrawString(text, this.Font, brush, rect, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    Rectangle sysBtnRect = new Rectangle(0, this.itemHeight * Items.Count + 16 + LogoHeight, this.Width, 21);
                    Rectangle xtRect = new Rectangle(sysBtnRect.X + 21, sysBtnRect.Y, sysBtnRect.Width / 2, sysBtnRect.Height);
                    Rectangle gyRect = new Rectangle(sysBtnRect.X + sysBtnRect.Width / 2 + 21, sysBtnRect.Y, sysBtnRect.Width / 2, sysBtnRect.Height);

                    e.Graphics.DrawImage(imageXT, 0, sysBtnRect.Y);
                    e.Graphics.DrawString("系统", this.Font, brush, xtRect, new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });
                    e.Graphics.DrawImage(imageGY, sysBtnRect.Width / 2, sysBtnRect.Y);
                    e.Graphics.DrawString("关于", this.Font, brush, gyRect, new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });

                    // e.Graphics.DrawRectangle(Pens.Red, sysBtnRect);
                }
            }
        }
        private ChatListItemCollection items;
        /// <summary>
        /// 获取列表中所有列表项的集合
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ChatListItemCollection Items
        {
            get
            {
                if (items == null)
                    items = new ChatListItemCollection(this);
                return items;
            }
        }
    }
    //自定义列表项集合
    public class ChatListItemCollection : IList, ICollection, IEnumerable
    {
        private int count;      //元素个数
        public int Count { get { return count; } }
        public ChatListItem[] m_arrItem;
        private ChatListBox owner;  //所属的控件
        public ChatListItemCollection(ChatListBox owner) { this.owner = owner; }
        //确认存储空间
        private void EnsureSpace(int elements)
        {
            if (m_arrItem == null)
                m_arrItem = new ChatListItem[Math.Max(elements, 1)];
            else if (this.count + elements > m_arrItem.Length)
            {
                ChatListItem[] arrTemp = new ChatListItem[Math.Max(this.count + elements, m_arrItem.Length * 2)];
                m_arrItem.CopyTo(arrTemp, 0);
                m_arrItem = arrTemp;
            }
        }
        /// <summary>
        /// 获取列表项所在的索引位置
        /// </summary>
        /// <param name="item">要获取的列表项</param>
        /// <returns>索引位置</returns>
        public int IndexOf(ChatListItem item)
        {
            return Array.IndexOf<ChatListItem>(m_arrItem, item);
        }
        /// <summary>
        /// 添加一个列表项
        /// </summary>
        /// <param name="item">要添加的列表项</param>
        public void Add(ChatListItem item)
        {
            if (item == null)       //空引用不添加
                throw new ArgumentNullException("Item cannot be null");
            this.EnsureSpace(1);
            if (-1 == this.IndexOf(item))
            {         //进制添加重复对象
                item.OwnerChatListBox = this.owner;
                m_arrItem[this.count++] = item;
                this.owner.Invalidate();            //添加进去是 进行重绘
            }
        }
        /// <summary>
        /// 添加一个列表项的数组
        /// </summary>
        /// <param name="items">要添加的列表项的数组</param>
        public void AddRange(ChatListItem[] items)
        {
            if (items == null)
                throw new ArgumentNullException("Items cannot be null");
            this.EnsureSpace(items.Length);
            try
            {
                foreach (ChatListItem item in items)
                {
                    if (item == null)
                        throw new ArgumentNullException("Item cannot be null");
                    if (-1 == this.IndexOf(item))
                    {     //重复数据不添加
                        item.OwnerChatListBox = this.owner;
                        m_arrItem[this.count++] = item;
                    }
                }
            }
            finally
            {
                this.owner.Invalidate();
            }
        }
        /// <summary>
        /// 移除一个列表项
        /// </summary>
        /// <param name="item">要移除的列表项</param>
        public void Remove(ChatListItem item)
        {
            int index = this.IndexOf(item);
            if (-1 != index)        //如果存在元素 那么根据索引移除
                this.RemoveAt(index);
        }
        /// <summary>
        /// 根据索引位置删除一个列表项
        /// </summary>
        /// <param name="index">索引位置</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.count)
                throw new IndexOutOfRangeException("Index was outside the bounds of the array");
            lock (delLock)
            {
                m_arrItem[index] = null;
                m_arrItem = m_arrItem.Where(a => a != null).ToArray();
                this.count--;
                this.owner.Invalidate();
            }
        }
        public object delLock = new object();
        /// <summary>
        /// 清空所有列表项
        /// </summary>
        public void Clear()
        {
            this.count = 0;
            m_arrItem = null;
            this.owner.Invalidate();
        }
        /// <summary>
        /// 根据索引位置插入一个列表项
        /// </summary>
        /// <param name="index">索引位置</param>
        /// <param name="item">要插入的列表项</param>
        public void Insert(int index, ChatListItem item)
        {
            if (index < 0 || index >= this.count)
                throw new IndexOutOfRangeException("Index was outside the bounds of the array");
            if (item == null)
                throw new ArgumentNullException("Item cannot be null");
            this.EnsureSpace(1);
            for (int i = this.count; i > index; i--)
                m_arrItem[i] = m_arrItem[i - 1];
            item.OwnerChatListBox = this.owner;
            m_arrItem[index] = item;
            this.count++;
            this.owner.Invalidate();
        }
        /// <summary>
        /// 判断一个列表项是否在集合内
        /// </summary>
        /// <param name="item">要判断的列表项</param>
        /// <returns>是否在列表项</returns>
        public bool Contains(ChatListItem item)
        {
            return this.IndexOf(item) != -1;
        }
        /// <summary>
        /// 将列表项的集合拷贝至一个数组
        /// </summary>
        /// <param name="array">目标数组</param>
        /// <param name="index">拷贝的索引位置</param>
        public void CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException("array cannot be null");
            m_arrItem.CopyTo(array, index);
        }
        /// <summary>
        /// 根据索引获取一个列表项
        /// </summary>
        /// <param name="index">索引位置</param>
        /// <returns>列表项</returns>
        public ChatListItem this[int index]
        {
            get
            {
                if (index < 0 || index >= this.count)
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array");
                return m_arrItem[index];
            }
            set
            {
                if (index < 0 || index >= this.count)
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array");
                m_arrItem[index] = value;
            }
        }

        //实现接口
        int IList.Add(object value)
        {
            if (!(value is ChatListItem))
                throw new ArgumentException("Value cannot convert to ListItem");
            this.Add((ChatListItem)value);
            return this.IndexOf((ChatListItem)value);
        }

        void IList.Clear()
        {
            this.Clear();
        }

        bool IList.Contains(object value)
        {
            if (!(value is ChatListItem))
                throw new ArgumentException("Value cannot convert to ListItem");
            return this.Contains((ChatListItem)value);
        }

        int IList.IndexOf(object value)
        {
            if (!(value is ChatListItem))
                throw new ArgumentException("Value cannot convert to ListItem");
            return this.IndexOf((ChatListItem)value);
        }

        void IList.Insert(int index, object value)
        {
            if (!(value is ChatListItem))
                throw new ArgumentException("Value cannot convert to ListItem");
            this.Insert(index, (ChatListItem)value);
        }

        bool IList.IsFixedSize
        {
            get { return false; }
        }

        bool IList.IsReadOnly
        {
            get { return false; }
        }

        void IList.Remove(object value)
        {
            if (!(value is ChatListItem))
                throw new ArgumentException("Value cannot convert to ListItem");
            this.Remove((ChatListItem)value);
        }

        void IList.RemoveAt(int index)
        {
            this.RemoveAt(index);
        }

        object IList.this[int index]
        {
            get { return this[index]; }
            set
            {
                if (!(value is ChatListItem))
                    throw new ArgumentException("Value cannot convert to ListItem");
                this[index] = (ChatListItem)value;
            }
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
                yield return m_arrItem[i];
        }
    }

}
