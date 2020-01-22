using System.IO;
using System.Linq;
using System.Reflection;

namespace Nostrum.Extensions
{
    public static class AssemblyExtensions
    {
        public static Stream GetResourceStream(this Assembly assembly, string name)
        {
            return assembly.GetManifestResourceStream(assembly.GetManifestResourceNames().Single(x => x.EndsWith(name)));
        }
    }
}
