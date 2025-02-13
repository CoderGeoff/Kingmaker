namespace Kingmaker.Desktop;

public partial class Kingmaker : Form
{
    private readonly BoardDragEvent _boardDragging = new();
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

    private void OnMouseDownOverBoard(object sender, MouseEventArgs e)
    {
        _boardDragging.Start(Cursor.Position);
    }

    private void OnMouseMove(object? sender, MouseEventArgs e)
    {
        if (_boardDragging.IsActive)
        {
            var drag = _boardDragging.Drag(Cursor.Position);
            _mapPanel.Location += drag.ConvertToSize();
        }
    }

    private void OnMouseUp(object? sender, MouseEventArgs e)
    {
        OnMouseMove(sender, e);
        _boardDragging.Stop();
    }

    private void OnClickExit(object sender, EventArgs e)
    {
        Application.Exit();
    }
}