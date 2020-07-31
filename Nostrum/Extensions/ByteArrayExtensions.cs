using System;
using System.Text;

namespace Nostrum.Extensions
{
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Converts each byte to its hex string representation.
        /// <code>
        ///     new byte[] { 0, 255 }.ToStringEx() // returns "00ff"
        /// </code>
        /// </summary>
        public static string ToHexString(this byte[] ba)
        {
#pragma warning disable 618
            return ToStringEx(ba);
#pragma warning restore 618
        }

        /// <summary>
        /// Converts each byte to an UTF8 character.
        /// <code>
        ///     new byte[] { 65, 66 }.ToUTF8String() // returns "AB"
        /// </code>
        /// </summary>
        public static string ToUTF8String(this byte[] ba)
        {
            return Encoding.UTF8.GetString(ba);
        }

        [Obsolete("Use ToHexString() instead")]
        public static string ToStringEx(this byte[] ba)
        {
            var hex = new StringBuilder(ba.Length * 2);
            foreach (var b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
