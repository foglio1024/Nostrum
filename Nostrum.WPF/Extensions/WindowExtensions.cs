using System.Windows;

namespace Nostrum.WPF.Extensions
{
    public static class WindowExtensions
    {
        /// <summary>
        /// Tries to call <see cref="Window.DragMove"/>. Errors are ignored.
        /// </summary>
        public static void TryDragMove(this Window w)
        {
            try { w.DragMove(); } catch { }
        }
        /// <summary>
        /// Tries to call <see cref="Window.Close"/>. Errors are ignored.
        /// </summary>
        public static void TryClose(this Window w)
        {
            try { w.Close(); } catch { }
        }
    }
}