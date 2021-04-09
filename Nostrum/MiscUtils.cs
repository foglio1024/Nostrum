using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Color = System.Windows.Media.Color;

namespace Nostrum
{
    public static class MiscUtils // TODO: separate these
    {
        public const string DefaultUserAgent =
            "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36";

        /// <summary>
        /// Parses a <see cref="Color"/> from an hex string. The input can be in the "#RRGGBB" or "RRGGBB" format.
        /// </summary>
        /// <param name="input">the color string in "#RRGGBB" or "RRGGBB" format</param>
        /// <returns>the <see cref="Color"/> struct representing the given color string</returns>
        public static Color ParseColor(string input)
        {
            if (input.StartsWith("#")) input = input.Substring(1);
            return Color.FromRgb(
                Convert.ToByte(input.Substring(0, 2), 16),
                Convert.ToByte(input.Substring(2, 2), 16),
                Convert.ToByte(input.Substring(4, 2), 16));
        }

        /// <summary>
        /// Sets the <see cref="SecurityProtocolType"/> to <see cref="SecurityProtocolType.Tls12"/>, then creates a new <see cref="WebClient"/> and sets <see cref="HttpRequestHeader.UserAgent"/> to <see cref="DefaultUserAgent"/>
        /// </summary>
        /// <returns>the constructed <see cref="WebClient"/></returns>
        public static WebClient GetDefaultWebClient()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var wc = new WebClient();
            wc.Headers.Add(HttpRequestHeader.UserAgent, DefaultUserAgent);
            return wc;
        }

        /// <summary>
        /// Checks if a file is locked.
        /// </summary>
        /// <param name="filename">the uriPath to the file</param>
        /// <param name="fileAccess">the file access type</param>
        /// <returns>true if the file is locked, false otherwise</returns>
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

        /// <summary>
        /// Retrieves a resource stream and creates an <see cref="Icon"/> from it.
        /// </summary>
        /// <param name="uriPath">the uri of the icon resource</param>
        /// <returns>the Icon if found, null otherwise</returns>
        public static Icon? GetEmbeddedIcon(string uriPath)
        {
            var stream = Application.GetResourceStream(new Uri(uriPath, UriKind.Relative))?.Stream;
            return stream == null ? null : new Icon(stream);
        }

        /// <summary>
        /// Waits for the specified file to become unlocked.
        /// </summary>
        /// <param name="filename">the path of the file to check</param>
        /// <param name="access">the file access type</param>
        /// <param name="interval">the interval to wait for each repeated check</param>
        /// <param name="timeout">the total timeout to wait before stopping the check in case the file is never unlocked</param>
        /// <returns></returns>
        public static async Task WaitForFileUnlock(string filename, FileAccess access, int interval = 500, int timeout = 2000)
        {
            var elapsedTime = 0;
            while (elapsedTime < timeout)
            {
                if (IsFileLocked(filename, access))
                {
                    elapsedTime += interval;
                }
                else
                {
                    break;
                }

                Debug.WriteLine("Waiting to open file");
                await Task.Delay(interval);
            }
            if (IsFileLocked(filename, access)) throw new IOException($"{filename} is used by another process.");
        }

#if NETCOREAPP
        /// <summary>
        /// Casts the given object to the enum of type <typeparamref name="T"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
#else
        /// <summary>
        /// Casts the given object to the enum of type <typeparamref name="T"/>.
        /// </summary>
#endif
        public static T CastEnum<T>(object val) where T : Enum
        {
#if NETCOREAPP
            return (T)Enum.Parse(typeof(T), val.ToString() ?? throw new ArgumentNullException($"{nameof(val)}.ToString()"));
#elif NETFRAMEWORK
            return (T)Enum.Parse(typeof(T), val.ToString());
#endif
        }
    }
}