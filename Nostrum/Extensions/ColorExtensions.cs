using System.Windows.Media;

namespace Nostrum.Extensions
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Converts the <see cref="Color"/> to its hex representation (eg. #AARRGGBB). Heading sharp and alpha value can be showed/hidden based on parameters.
        /// </summary>
        /// <param name="col"></param>
        /// <param name="alpha"></param>
        /// <param name="sharp"></param>
        /// <returns></returns>
        public static string ToHex(this Color col, bool alpha = false, bool sharp = true)
        {
            return $"{(sharp ? "#" : "")}{(alpha ? col.A.ToHexString() : "")}{col.R.ToHexString()}{col.G.ToHexString()}{col.B.ToHexString()}";
        }
    }
}