using System;
using System.Drawing;
using System.Windows;
using Color = System.Windows.Media.Color;

namespace Nostrum.WPF
{
    public static class MiscUtils
    {
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
        /// Retrieves a resource stream and creates an <see cref="Icon"/> from it.
        /// </summary>
        /// <param name="uriPath">the uri of the icon resource</param>
        /// <returns>the Icon if found, null otherwise</returns>
        public static Icon? GetEmbeddedIcon(string uriPath)
        {
            var stream = Application.GetResourceStream(new Uri(uriPath, UriKind.Relative))?.Stream;
            return stream == null ? null : new Icon(stream);
        }
    }
}