namespace Kingmaker.Desktop;

public static class PointExtensions
{
    public static Size ConvertToSize(this Point p) => new (p.X, p.Y);
    public static Point ConvertToPoint(this Size s) => new(s.Width, s.Height);
    public static Size Abs(this Size s) => new Size(Math.Abs(s.Width), Math.Abs(s.Height));

    public static bool EnsureIsBetween(this Point c, Point min, Point max, out Point adjusted)
    {
        var x = Math.Min(Math.Max(c.X, min.X), max.X);
        var y = Math.Min(Math.Max(c.Y, min.Y), max.Y);
        adjusted = new Point(x, y);
        return adjusted != c;
    }
}