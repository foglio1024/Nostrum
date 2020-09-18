using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Nostrum.WinAPI;

namespace Nostrum.Extensions
{
    public static class ProcessExtensions
    {
        public static IEnumerable<IntPtr> GetProcessWindows(this Process p)
        {
            var windows = new List<IntPtr>();
            User32.EnumWindows((hwnd, prm) =>
            {
                User32.GetWindowThreadProcessId(hwnd, out var proc);
                if (p.Id != proc) return true;
                windows.Add(hwnd);
                return true;
            }, IntPtr.Zero);

            return windows;
        }
    }
}