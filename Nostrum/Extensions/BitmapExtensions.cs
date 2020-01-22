using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace Nostrum.Extensions
{
    public static class BitmapExtensions
    {
        public static BitmapImage ToImageSource(this Bitmap bitmap)
        {
            using (var ms = new MemoryStream())
            {
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
        }

    }
}
