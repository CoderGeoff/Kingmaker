namespace Kingmaker.Desktop;

public class BoardDragEvent
{
    private Point _origin;
    public bool IsActive { get; private set; }

    public void Start(Point origin)
    {
        _origin = origin;
        IsActive = true;
    }

    public Point Drag(Point destination)
    {
        var drag = destination - _origin.ConvertToSize();
        _origin = destination;
        return drag;
    }

    public void Stop()
    {
        IsActive = false;
    }
}