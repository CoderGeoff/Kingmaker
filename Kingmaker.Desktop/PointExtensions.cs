namespace Kingmaker.Desktop;

public static class PointExtensions
{
    public static Size ConvertToSize(this Point p) => new (p.X, p.Y);
}