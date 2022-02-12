using System.Windows;
using System.Windows.Media;

namespace Nostrum.WPF.Extensions
{
    public static class VisualExtensions
    {
        public static DpiScale GetDpiScale(this Visual visual) //todo: docs
        {
            double dpiX = 1, dpiY = 1;

            if (PresentationSource.FromVisual(visual) is PresentationSource source)
            {
                dpiX = source.CompositionTarget.TransformToDevice.M11;
                dpiY = source.CompositionTarget.TransformToDevice.M22;
            }

            return new DpiScale(dpiX, dpiY);
        }
    }
}
