using System;
using System.ComponentModel;

namespace Nostrum.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Returns an enumerator description attribute if present, else the enum as string.
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum en)
        {
            var fi = en.GetType().GetField(en.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((attributes.Length > 0)
                    && (!string.IsNullOrEmpty(attributes[0].Description)))
                ? attributes[0].Description
                : en.ToString();
        }
    }
}