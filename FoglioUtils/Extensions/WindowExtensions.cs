using System.Windows;

namespace FoglioUtils.Extensions
{
    public static class WindowExtensions
    {
        public static void TryDragMove(this Window w)
        {
            try { w.DragMove(); } catch { }
        }
    }
}