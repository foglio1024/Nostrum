namespace Nostrum;

public static class LineMath
{
    public static double Y(double x, double m, double q)
    {
        return m * x + q;
    }

    public static double Y(double x, double ax, double ay, double bx, double by)
    {
        var m = M(ax, ay, bx, by);
        if (double.IsInfinity(m)) return ax;

        var q = Q(ax, ay, m);

        return Y(x, m, q);
    }

    public static double M(double ax, double ay, double bx, double by)
    {
        if (bx - ax == 0) return float.PositiveInfinity;
        return (by - ay) / (bx - ax);
    }

    public static double Q(double ax, double ay, double bx, double by)
    {
        var m = M(ax, ay, bx, by);
        return Q(ax, ay, m);
    }

    public static double Q(double ax, double ay, double m)
    {
        if (double.IsInfinity(m)) return 0;
        return ay - ax * m;
    }
}
