using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Nostrum.WinAPI
{
    public static class Psapi
    {
        [DllImport("psapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int GetMappedFileName(IntPtr hProcess, IntPtr lpv, StringBuilder lpFilename, int nSize);
    }
}
