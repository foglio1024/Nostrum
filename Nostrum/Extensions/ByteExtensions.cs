using System;

namespace Nostrum.Extensions
{
    public static class ByteExtensions
    {

        /// <summary>
        /// Converts the byte to its hex representation.
        /// </summary>
        public static string ToHexString(this byte b)
        {
#pragma warning disable 618
            return ToStringEx(b);
#pragma warning restore 618
        }

        [Obsolete("Use ToHexString() instead")]
        public static string ToStringEx(this byte b)
        {
            return $"{b:x2}";
        }
    }
}