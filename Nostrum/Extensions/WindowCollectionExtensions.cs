using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Nostrum.Extensions
{
    public static class WindowCollectionExtensions
    {
        public static List<Window> ToList(this WindowCollection wc)
        {
            var ret = new Window[wc.Count];
            wc.CopyTo(ret, 0);
            return ret.ToList();
        }
    }
}