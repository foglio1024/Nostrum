using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace Nostrum.WPF.Extensions
{
    public static class ImageSourceExtensions
    {
        /// <summary>
        /// Converts the <see cref="ImageSource"/> to a <see cref="Bitmap"/>. The image must have the <see cref="PixelFormat.Format32bppArgb"/>.
        /// </summary>
        /// <param name="isrc"></param>
        /// <returns></returns>
        public static Bitmap ToBitmap(this ImageSource isrc)
        {
            var src = (BitmapSource)isrc;
            int width = src.PixelWidth;
            int height = src.PixelHeight;
            int stride = width * ((src.Format.BitsPerPixel + 7) / 8);
            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.AllocHGlobal(height * stride);
                src.CopyPixels(new Int32Rect(0, 0, width, height), ptr, height * stride, stride);
                using var btm = new Bitmap(width, height, stride, PixelFormat.Format32bppArgb, ptr);
                return new Bitmap(btm);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Marshal.FreeHGlobal(ptr);
            }
        }
    }
}