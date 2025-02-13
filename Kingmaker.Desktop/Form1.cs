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
            var drag = _mapDragging.Drag(Cursor.Position);
            _mapPanel.Location += drag.ConvertToSize();
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