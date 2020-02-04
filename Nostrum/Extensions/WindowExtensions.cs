﻿using System.Windows;

namespace Nostrum.Extensions
{
    public static class WindowExtensions
    {
        public static void TryDragMove(this Window w)
        {
            try { w.DragMove(); } catch { }
        }

        public static void TryClose(this Window w)
        {
            try { w.Close(); } catch { }
        }
    }
}