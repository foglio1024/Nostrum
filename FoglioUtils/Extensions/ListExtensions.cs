﻿using System.Collections;
using System.Text;

namespace FoglioUtils.Extensions
{
    public static class ListExtensions
    {
        public static string ToCSV(this IList list)
        {
            var sb = new StringBuilder();
            foreach (var val in list)
            {
                sb.Append(val);
                if (list.IndexOf(val) < list.Count - 1) sb.Append(',');
            }
            return sb.ToString();
        }
    }
}