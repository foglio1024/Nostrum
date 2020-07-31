using System;
using System.Runtime.InteropServices;

namespace Nostrum.WinAPI
{
    public static class Kernel32
    {
        /// <summary>
        /// Retrieves the thread identifier of the calling thread.
        /// </summary>
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();

        /// <summary>
        /// Allocates a new console for the calling process.
        /// </summary>
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();

        /// <summary>
        /// Detaches the calling process from its console.
        /// </summary>
        [DllImport("kernel32.dll")]
        public static extern void FreeConsole();

        /// <summary>
        /// Retrieves the window handle used by the console associated with the calling process.
        /// </summary>
        /// <returns>The return value is a handle to the window used by the console associated with the calling process or NULL if there is no such associated console.</returns>
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();
    }
}
