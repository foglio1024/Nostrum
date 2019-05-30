using FoglioUtils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoglioUtils
{
    public static class EnumUtils
    {
        public static List<T> ListFromEnum<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }
    }
}
