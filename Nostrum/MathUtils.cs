using Point = System.Windows.Point;

namespace Nostrum
{
    public static class MathUtils
    {
        public static double FactorToAngle(double value, double multiplier = 1)
        {
            return value * (359.9 / multiplier);
        }
        public static double FactorCalc(double val, double max)
        {
            return max > 0
                ? val / max > 1 
                    ? 1 
                    : val / max
                : 1;
        }

        public static Point GetRelativePoint(double x, double y, double cx, double cy)
        {
            return new Point(x - cx, y - cy);
        }

    }
}
