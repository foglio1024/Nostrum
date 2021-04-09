namespace Nostrum.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="System.Drawing.Color"/> and <see cref="System.Windows.Media.Color"/> types.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Converts the <see cref="System.Drawing.Color"/> to its hex representation (eg. #AARRGGBB). Heading sharp and alpha value can be showed/hidden based on parameters.
        /// </summary>
        /// <param name="col"></param>
        /// <param name="alpha"></param>
        /// <param name="sharp"></param>
        /// <returns></returns>
        public static string ToHex(this System.Drawing.Color col, bool alpha = false, bool sharp = true)
        {
            return $"{(sharp ? "#" : "")}{(alpha ? col.A.ToHexString() : "")}{col.R.ToHexString()}{col.G.ToHexString()}{col.B.ToHexString()}";
        }
        /// <summary>
        /// Converts the <see cref="System.Windows.Media.Color"/> to its hex representation (eg. #AARRGGBB). Heading sharp and alpha value can be showed/hidden based on parameters.
        /// </summary>
        /// <param name="col"></param>
        /// <param name="alpha"></param>
        /// <param name="sharp"></param>
        /// <returns></returns>
        public static string ToHex(this System.Windows.Media.Color col, bool alpha = false, bool sharp = true)
        {
            return $"{(sharp ? "#" : "")}{(alpha ? col.A.ToHexString() : "")}{col.R.ToHexString()}{col.G.ToHexString()}{col.B.ToHexString()}";
        }
        /// <summary>
        /// Converts this <see cref="System.Drawing.Color"/> to a <see cref="System.Windows.Media.Color"/>.
        /// </summary>
        public static System.Windows.Media.Color ToMediaColor(this System.Drawing.Color color)
        {
            return System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        }
        /// <summary>
        /// Converts this <see cref="System.Windows.Media.Color"/> to a <see cref="System.Drawing.Color"/>.
        /// </summary>
        public static System.Drawing.Color ToDrawingColor(this System.Windows.Media.Color color)
        {
            return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

    }
}