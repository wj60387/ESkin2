using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using System.Drawing;
using System.ComponentModel;

namespace System.Windows.Forms
{
    public class ChatListItem
    {



        private ChatListBox ownerChatListBox;
        /// <summary>
        /// 获取列表项所在的控件
        /// </summary>
        [Browsable(false)]
        public ChatListBox OwnerChatListBox {
            get { return ownerChatListBox; }
            internal set { ownerChatListBox = value; }
        }

        Image image=ESkin.Properties.Resources.听诊配置;
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
    }
}
