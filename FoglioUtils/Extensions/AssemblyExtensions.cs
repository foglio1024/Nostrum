using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FoglioUtils.Extensions
{
    public static class AssemblyExtensions
    {
        public static Stream GetResourceStream(this Assembly assembly, string name)
        {
            return assembly.GetManifestResourceStream(assembly.GetManifestResourceNames().Single(x => x.EndsWith(name)));
        }
    }
}
