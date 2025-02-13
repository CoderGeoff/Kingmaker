namespace Kingmaker.Desktop;

public partial class Kingmaker : Form
{
    private readonly DragEvent _mapDragging = new();
    public Kingmaker()
    {
        InitializeComponent();
        CaptureMouseEvents();
    }

    private void CaptureMouseEvents()
    {
        SetMouseCapture(this);

        void SetMouseCapture(Control c)
        {
            c.MouseUp += OnMouseUp;
            c.MouseMove += OnMouseMove;
            foreach (var child in c.Controls.OfType<Control>())
                SetMouseCapture(child);
        }
    }

    private void OnMouseDownOverMap(object sender, MouseEventArgs e)
    {
        _mapDragging.Start(Cursor.Position);
    }

    private void OnMouseMove(object? sender, MouseEventArgs e)
    {
        if (_mapDragging.IsActive)
        {
            var dragSize = _mapDragging.Drag(Cursor.Position).ConvertToSize();
            var newMapLocation = _mapPanel.Location + dragSize;
            newMapLocation = newMapLocation.EnsureFullyOverlapsItsParent(_mapPanel);
            _mapPanel.Location = newMapLocation;
        }
    }

    private void OnMouseUp(object? sender, MouseEventArgs e)
    {
        OnMouseMove(sender, e);
        _mapDragging.Stop();
    }

    private void OnClickExit(object sender, EventArgs e)
    {
        Application.Exit();
    }
}

public static class ControlExtensions
{
    public static Point EnsureFullyOverlapsItsParent(this Point location, Control control)
    {
        var parent = control.Parent;
        if (parent == null) return location;
        var min = (parent.Size - control.Size).ConvertToPoint();
        var max = new Point(0, 0);

        return location.EnsureIsBetween(min, max, out var adjusted) ? adjusted : location;
    }
}