using System.Windows;

namespace Nostrum.WPF.Extensions
{
    public static class PointExtensions
    {
        public static Point RelativeTo(this Point input, Point center)
        {
            return new(input.X - center.X, input.Y - center.Y);
        }
        public static Point RelativeTo(this Point input, double centerX, double centerY)
        {
            return new(input.X - centerX, input.Y - centerY);
        }
    }
}