namespace Kingmaker.Desktop;

public static class PointExtensions
{
    public static Size ConvertToSize(this Point p) => new (p.X, p.Y);

    public static Point EnsureIsBetween(this Point c, Point min, Point max)
    {
        var x = Math.Min(Math.Max(c.X, min.X), max.X);
        var y = Math.Min(Math.Max(c.Y, min.Y), max.Y);
        return new Point(x, y);
    }
}

public static class SizeExtensions
{
    public static Point ConvertToPoint(this Size s) => new(s.Width, s.Height);
    public static Size Abs(this Size s) => new (Math.Abs(s.Width), Math.Abs(s.Height));

    public static Size EnsureIsBetween(this Size c, Size min, Size max)
    {
        var width = Math.Min(Math.Max(c.Width, min.Width), max.Width);
        var height = Math.Min(Math.Max(c.Height, min.Height), max.Height);
        return new Size(width, height);
    }

    public static Size Multiply(this Size sz1, double magnification)
    {
        return new Size((int)(sz1.Width * magnification), (int)(sz1.Height * magnification));
    }
}