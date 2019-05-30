using FoglioUtils.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Color = System.Windows.Media.Color;
using Point = System.Windows.Point;

namespace FoglioUtils
{
    public static class Utils
    {

        public static BitmapImage BitmapToImageSource(Bitmap bitmap)
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

        public static Point GetRelativePoint(double x, double y, double cx, double cy)
        {
            return new Point(x - cx, y - cy);
        }

        public static List<T> ListFromEnum<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

        public static double FactorToAngle(double value, double multiplier = 1)
        {
            return value * (359.9 / multiplier);
        }

        public static T FindVisualParent<T>(DependencyObject sender) where T : DependencyObject
        {
            if (sender == null)
            {
                return null;
            }
            else if (VisualTreeHelper.GetParent(sender) is T)
            {
                return VisualTreeHelper.GetParent(sender) as T;
            }
            else
            {
                var parent = VisualTreeHelper.GetParent(sender);
                return FindVisualParent<T>(parent);
            }
        }

        public static T GetChild<T>(DependencyObject obj) where T : DependencyObject
        {
            DependencyObject child = null;
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                child = VisualTreeHelper.GetChild(obj, i);
                if (child.GetType() == typeof(T))
                {
                    break;
                }
                else
                {
                    child = GetChild<T>(child);
                    if (child != null && child.GetType() == typeof(T))
                    {
                        break;
                    }
                }
            }

            return child as T;
        }

        public static Color ParseColor(string col)
        {
            if (col.StartsWith("#")) col = col.Substring(1);
            return Color.FromRgb(
                Convert.ToByte(col.Substring(0, 2), 16),
                Convert.ToByte(col.Substring(2, 2), 16),
                Convert.ToByte(col.Substring(4, 2), 16));
        }

        public static double FactorCalc(double val, double max)
        {
            return max > 0
                ? val / max > 1 ? 1 : val / max
                : 1;
        }

        public static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        public static string TimeFormatter(ulong seconds)
        {
            if (seconds < 99) return seconds + "";
            if (seconds < 99 * 60) return seconds / 60 + "m";
            if (seconds < 99 * 60 * 60) return seconds / (60 * 60) + "h";
            return seconds / (60 * 60 * 24) + "d";
        }

        public static ICollectionView InitView(Predicate<object> filter, IEnumerable source, IEnumerable<SortDescription> sortDescr)
        {
            var view = new CollectionViewSource { Source = source }.View;
            view.Filter = filter;
            foreach (var sd in sortDescr)
            {
                view.SortDescriptions.Add(sd);
            }
            return view;
        }

        public static ICollectionViewLiveShaping InitLiveView<T>(Predicate<object> predicate, IEnumerable<T> source, string[] filters, SortDescription[] sortFilters)
        {
            var cv = new CollectionViewSource { Source = source }.View;
            cv.Filter = predicate;
            if (!(cv is ICollectionViewLiveShaping liveView)) return null;
            if (!liveView.CanChangeLiveFiltering) return null;
            if (filters.Length > 0)
            {
                foreach (var filter in filters)
                {
                    liveView.LiveFilteringProperties.Add(filter);
                }
                liveView.IsLiveFiltering = true;
            }

            if (sortFilters.Length <= 0) return liveView;

            foreach (var filter in sortFilters)
            {
                ((ICollectionView)liveView).SortDescriptions.Add(filter);
                liveView.LiveSortingProperties.Add(filter.PropertyName);
            }

            liveView.IsLiveSorting = true;

            return liveView;
        }

        public static double Factor(double value, double maxValue)
        {
            if (maxValue == 0) return 1;
            var n = value / maxValue;
            return n;
        }

        public static WebClient GetDefaultWebClient()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var wc = new WebClient();
            wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36");
            return wc;

        }

        public static string GenerateFileHash(string fileName)
        {
            if (!File.Exists(fileName)) return "";
            byte[] fileBuffer;
            try
            {
                fileBuffer = File.ReadAllBytes(fileName);
            }
            catch
            {
                //Log.F($"Failed to check hash on file {fileName}");
                return "";
            }
            return SHA256.Create().ComputeHash(fileBuffer).ToStringEx();

        }

        public static string GenerateHash(string input)
        {
            return SHA256.Create().ComputeHash(input.ToByteArray()).ToStringEx();
        }

        public static bool IsFileLocked(string filename, FileAccess fileAccess)
        {
            // Try to open the file with the indicated access.
            try
            {
                var fs = new FileStream(filename, FileMode.Open, fileAccess);
                fs.Close();
                return false;
            }
            catch (IOException)
            {
                return true;
            }
        }


        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();
    }
}
