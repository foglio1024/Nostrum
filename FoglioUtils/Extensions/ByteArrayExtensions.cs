using System.Text;

namespace FoglioUtils.Extensions
{
    public static class ByteArrayExtensions
    {
        public static string ToStringEx(this byte[] ba)
        {
            var hex = new StringBuilder(ba.Length * 2);
            foreach (var b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static string ToUTF8String(this byte[] ba)
        {
            return Encoding.UTF8.GetString(ba);
        }
    }
}
