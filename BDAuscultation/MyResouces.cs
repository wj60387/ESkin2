using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BDAuscultation
{
    public static class MyResouces
    {
        public static Image ImageTZPZ = GetImage(BDAuscultation.Properties.Resources.听诊配置, 0.5f);
        public static Image ImageTZJX = GetImage(BDAuscultation.Properties.Resources.听诊教学, 0.6f);
        public static Image ImageTZLY = GetImage(BDAuscultation.Properties.Resources.听诊录音, 0.6f);
        public static Image ImageYDTZ = GetImage(BDAuscultation.Properties.Resources.云端听诊, 0.50f);
        public static Image ImageYCTZ = GetImage(BDAuscultation.Properties.Resources.远程教学, 0.55f);
        public static Image ImageXY = GetImage(BDAuscultation.Properties.Resources.心音, 0.5f);
        public static Image ImageMNCS = GetImage(BDAuscultation.Properties.Resources.模拟测试 , 0.4f);
        /// <summary>
        /// 获取图片的缩略图
        /// </summary>
        /// <param name="image">原图</param>
        /// <param name="width">缩略的图的宽度</param>
        /// <param name="height">缩略的图的高度</param>
        /// <returns></returns>
        static Image GetImage(Image image,int width,int height)
        {       
            //new NavItem(BDAuscultation.Properties.Resources.听诊配置, "听诊配置"));
        //        new NavItem(BDAuscultation.Properties.Resources.听诊教学, "听诊教学"));
        //        new NavItem(BDAuscultation.Properties.Resources.听诊录音, "听诊录音"));
        //        new NavItem(BDAuscultation.Properties.Resources.云端听诊, "云端听诊"));
        //        new NavItem(BDAuscultation.Properties.Resources.远程教学, "远程教学"));
            return image.GetThumbnailImage(width, height, () => { return true; }, IntPtr.Zero);
        }
        /// <summary>
        /// 获取图片的缩略图
        /// </summary>
        /// <param name="image">原图</param>
        /// <param name="scale">缩略比例</param>
        /// <returns></returns>
         public static Image GetImage(Image image, float scale=1.0f)
         {
             return image.GetThumbnailImage((int)(image.Width * scale), (int)(image.Height * scale), () => { return true; }, IntPtr.Zero);
         }


    }
}
