using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Color = System.Windows.Media.Color;


namespace FoglioUtils
{
    public static class MiscUtils // TODO: separate these
    {
        public static Color ParseColor(string col)
        {
            if (col.StartsWith("#")) col = col.Substring(1);
            return Color.FromRgb(
                Convert.ToByte(col.Substring(0, 2), 16),
                Convert.ToByte(col.Substring(2, 2), 16),
                Convert.ToByte(col.Substring(4, 2), 16));
        }

        public static WebClient GetDefaultWebClient()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var wc = new WebClient();
            wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36");
            return wc;

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

        public static Icon GetEmbeddedIcon(string path)
        {
            var stream = Application.GetResourceStream(new Uri(path, UriKind.Relative))?.Stream;
            return stream == null ? null : new Icon(stream);
        }
#pragma warning disable 1998
        public static async Task WaitForFileUnlock(string filename, FileAccess access, int interval = 500, int timeout = 2000)
#pragma warning restore 1998
        {
            var elapsedTime = 0;
            while (elapsedTime < timeout)
            {
                if (IsFileLocked(filename, access)) elapsedTime += interval;
                else break;
                Thread.Sleep(interval);
                Console.WriteLine("Waiting to open file");
            }
            if (IsFileLocked(filename, access)) throw new IOException($"{filename} is used by another process.");
        }

        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();

        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();

    }
}
