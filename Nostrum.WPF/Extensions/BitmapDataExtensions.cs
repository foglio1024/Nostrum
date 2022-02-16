using System;
using System.Drawing.Imaging;

namespace Nostrum.WPF.Extensions
{
    public static class BitmapDataExtensions
    {
        public static int GetBytesCount(this BitmapData bmpd)
        {
            return Math.Abs(bmpd.Stride) * bmpd.Height;
        }
    }
}