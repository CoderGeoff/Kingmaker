namespace Kingmaker.Desktop;

public static class ControlExtensions
{
    public static Point EnsureFullyOverlapsItsParent(this Point location, Control control)
    {
        var parent = control.Parent;
        if (parent == null) return location;
        var min = (parent.Size - control.Size).ConvertToPoint();
        var max = new Point(0, 0);

        return location.EnsureIsBetween(min, max);
    }
}