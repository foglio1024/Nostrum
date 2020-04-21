using System.Text;

namespace Nostrum.Extensions
{
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Converts each byte to its hex string representation.
        /// </summary>
        /// <param name="ba"></param>
        /// <returns></returns>
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
