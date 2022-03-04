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
            if (input.StartsWith("#")) input = input[1..];
            return Color.FromRgb(
                Convert.ToByte(input.Substring(0, 2), 16),
                Convert.ToByte(input.Substring(2, 2), 16),
                Convert.ToByte(input.Substring(4, 2), 16));
        }

        /// <summary>
        /// Creates a new <see cref="Color"/> from hue, saturation and value.
        /// </summary>
        /// <param name="hue">the hue of the color (in degrees)</param>
        /// <param name="saturation">the saturation of the color (from 0 to 1)</param>
        /// <param name="value">the value of the color (from 0 to 1)</param>
        /// <returns>the resulting color</returns>
        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            double H = hue;
            while (H < 0) { H += 360; };
            while (H >= 360) { H -= 360; };

            double R, G, B;
            if (value <= 0)
            {
                R = G = B = 0;
            }
            else if (saturation <= 0)
            {
                R = G = B = value;
            }
            else
            {
                double hf = H / 60.0;
                int i = (int)Math.Floor(hf);
                double f = hf - i;
                double pv = value * (1 - saturation);
                double qv = value * (1 - saturation * f);
                double tv = value * (1 - saturation * (1 - f));
                switch (i)
                {
                    // Red is the dominant color
                    case 0:
                        R = value;
                        G = tv;
                        B = pv;
                        break;

                    // Green is the dominant color
                    case 1:
                        R = qv;
                        G = value;
                        B = pv;
                        break;

                    case 2:
                        R = pv;
                        G = value;
                        B = tv;
                        break;

                    // Blue is the dominant color
                    case 3:
                        R = pv;
                        G = qv;
                        B = value;
                        break;

                    case 4:
                        R = tv;
                        G = pv;
                        B = value;
                        break;

                    // Red is the dominant color

                    case 5:
                        R = value;
                        G = pv;
                        B = qv;
                        break;

                    // Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.
                    case 6:
                        R = value;
                        G = tv;
                        B = pv;
                        break;

                    case -1:
                        R = value;
                        G = pv;
                        B = qv;
                        break;

                    default:
                        R = G = B = value; // Just pretend its black/white
                        break;
                }
            }

            return Color.FromRgb(Clamp((int)(R * 255.0)), Clamp((int)(G * 255.0)), Clamp((int)(B * 255.0)));

            byte Clamp(int i)
            {
                if (i < 0) return 0;
                if (i > 255) return 255;
                return (byte)i;
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
    }
}