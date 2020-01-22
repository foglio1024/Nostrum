using System.Diagnostics.CodeAnalysis;

namespace Nostrum.Extensions
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class SizeExtensions //funny
    {
        public static bool IsEqual(this System.Windows.Size s, System.Windows.Size other)
        {
            return s.Width == other.Width &&
                   s.Height == other.Height;
        }
        public static bool IsEqual(this System.Windows.Size s, System.Drawing.Size other)
        {
            return s.Width == other.Width &&
                   s.Height == other.Height;
        }
        public static bool IsEqual(this System.Drawing.Size s, System.Drawing.Size other)
        {
            return s.Width == other.Width &&
                   s.Height == other.Height;
        }
        public static bool IsEqual(this System.Drawing.Size s, System.Windows.Size other)
        {
            return s.Width == other.Width &&
                   s.Height == other.Height;
        }
    }
}
