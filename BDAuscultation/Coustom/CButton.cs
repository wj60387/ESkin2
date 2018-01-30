using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BDAuscultation.Coustom
{
    public class CButton:ButtonEx
    {
        public CButton()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CButton
            // 
            this.BackgroundImage = global::BDAuscultation.Properties.Resources.听诊器配置;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Size = new System.Drawing.Size(152, 42);
            this.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ResumeLayout(false);
            this.Image = MyResouces.GetImage(BDAuscultation.Properties.Resources.听诊小图标,0.9f);
        }
    }
}
