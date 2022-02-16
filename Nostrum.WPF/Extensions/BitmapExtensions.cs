using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using Nostrum.WinAPI;

namespace Nostrum.WPF.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="Bitmap"/> type.
    /// </summary>
    public static class BitmapExtensions
    {
        /// <summary>
        /// Initializes and creates a <see cref="BitmapImage"/> from the <see cref="Bitmap"/>.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static BitmapImage ToBitmapImage(this Bitmap bitmap)
        {
            using var ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Bmp);
            ms.Position = 0;
            var bitmapimage = new BitmapImage();
            bitmapimage.BeginInit();
            bitmapimage.StreamSource = ms;
            bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapimage.EndInit();
            ms.Flush();
            ms.Close();
            ms.Dispose();
            return bitmapimage;
        }

        /// <summary>
        /// Initializes and creates a <see cref="ImageSource"/> from the <see cref="Bitmap"/>.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static ImageSource ToImageSource(this Bitmap bmp)
        {
            var h = bmp.GetHbitmap();
            var src = Imaging.CreateBitmapSourceFromHBitmap(h, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            Gdi32.DeleteObject(h);
            return src;
        }

        /// <summary>
        /// Returns the bytes that compose the bitmap.
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this Bitmap bmp)
        {
            var bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            var count = bmpData.GetBytesCount();
            var values = new byte[count];
            Marshal.Copy(source: bmpData.Scan0, destination: values, startIndex: 0, length: count);
            bmp.UnlockBits(bmpData);
            return values;
        }

    }
}