using System.Windows.Media;

namespace FoglioUtils.Extensions
{
    public static class ColorExtensions
    {
        public static string ToHex(this Color col, bool alpha = false, bool sharp = true)
        {
            return $"{(sharp ? "#" : "")}{(alpha ? col.A.ToStringEx() : "")}{col.R.ToStringEx()}{col.G.ToStringEx()}{col.B.ToStringEx()}";
        }
    }
}