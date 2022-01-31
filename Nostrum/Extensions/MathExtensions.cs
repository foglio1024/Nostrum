using System;

namespace Nostrum.Extensions
{
    public static class MathExtensions
    {
        public static bool ToleranceEquals(this float val, double other, double tolerance)
        {
            return ToleranceEqualsImpl(val, other, tolerance);
        }

        public static bool ToleranceEquals(this double val, double other, double tolerance)
        {
            return ToleranceEqualsImpl(val, other, tolerance);
        }

        static bool ToleranceEqualsImpl(double val, double other, double tolerance)
        {
            return Math.Abs(val - other) < tolerance;
        }

        public static float ToDeg(this float rad)
        {
            return rad * 180f / (float)Math.PI;
        }

        public static double ToDeg(this double rad)
        {
            return rad * 180d / Math.PI;
        }

        public static float ToRad(this float deg)
        {
            return deg * (float)Math.PI / 180f;
        }

        public static double ToRad(this double deg)
        {
            return deg * Math.PI / 180d;
        }
    }
}