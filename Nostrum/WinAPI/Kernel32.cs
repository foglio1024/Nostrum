using System;
using System.Runtime.InteropServices;

namespace Nostrum.WinAPI
{
    public static class Kernel32
    {
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();

        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        public static extern void FreeConsole();

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();
    }
}
