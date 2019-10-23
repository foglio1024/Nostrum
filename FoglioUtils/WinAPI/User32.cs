using System;
using System.Runtime.InteropServices;

namespace FoglioUtils.WinAPI
{
    public static class User32
    {
        // window styles
        // ReSharper disable InconsistentNaming
        public const uint WS_EX_TRANSPARENT = 0x20;      //clickthru
        public const uint WS_EX_NOACTIVATE = 0x08000000; //don't focus
        public const uint WS_EX_TOOLWINDOW = 0x00000080; //don't show in alt-tab
        public const int GWL_EXSTYLE = -20;           //set new exStyle
        public const int WM_CHAR = 0x0102;
        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYUP = 0x0101;

        public const int VK_RETURN = 0x0D;
        // ReSharper restore InconsistentNaming

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern uint GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        public static extern uint SetWindowLong(IntPtr hwnd, int index, uint newStyle);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        public static extern uint GetGuiResources(IntPtr hProcess, uint uiFlags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(out POINT pPoint);

        #region Types
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public readonly int Left;
            public readonly int Top;
            public readonly int Right;
            public readonly int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        } 
        #endregion
    }
}
