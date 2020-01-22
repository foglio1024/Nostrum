using System;
using System.Collections.Generic;
using System.Linq;

namespace Nostrum
{
    public static class EnumUtils
    {
        public static List<T> ListFromEnum<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }
    }
}
