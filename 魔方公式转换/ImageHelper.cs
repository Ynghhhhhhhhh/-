using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image
{
    public static class ImageHelper
    {
        /// <summary>
        /// 拼接图像
        /// </summary>
        /// <param name="bitmap1">图像1的位图</param>
        /// <param name="bitmap2">图像2的位图</param>
        /// <param name="isParallel">水平拼接？</param>
        public static Bitmap SpliceImage(Bitmap bitmap1, Bitmap bitmap2, bool isParallel)
        {
            Bitmap bitmap;
            if (isParallel)
            {
                bitmap = new Bitmap(bitmap1.Width + bitmap2.Width, Math.Max(bitmap1.Height, bitmap2.Height));
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(bitmap1, 0, 0);
                g.DrawImage(bitmap2, bitmap1.Width, 0);
            }
            else
            {
                bitmap = new Bitmap(Math.Max(bitmap1.Width ,bitmap2.Width), bitmap1.Height + bitmap2.Height);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(bitmap1, 0, 0);
                g.DrawImage(bitmap2, 0, bitmap1.Height);
            }
            return bitmap;
        }

        public static Bitmap ReshapeImage(Bitmap bitmap, int width, int height)
        {
            Bitmap draw = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(draw);
            g.DrawImage(bitmap, new Rectangle(0, 0, width, height));
            return draw;
        }
    }
}
