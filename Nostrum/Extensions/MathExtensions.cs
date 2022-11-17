using System;

namespace Nostrum.Extensions;

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

    public static bool IsBetween(this double val, double min, double max)
    {
        return IsBetweenImpl(val, min, max);
    }

    public static bool IsBetween(this float val, double min, double max)
    {
        return IsBetweenImpl(val, min, max);
    }

    static bool IsBetweenImpl(double val, double min, double max)
    {
        var actualMin = min > max ? max : min;
        var actualMax = min > max ? min : max;
        return val >= actualMin && val <= actualMax;
    }

    public static bool IsInRange(this float val, double mid, double delta)
    {
        return val.IsBetween(mid - delta, mid + delta);
    }

    public static bool IsInRange(this double val, double mid, double delta)
    {
        return val.IsBetween(mid - delta, mid + delta);
    }
}