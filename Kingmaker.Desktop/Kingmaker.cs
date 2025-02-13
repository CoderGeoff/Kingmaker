using System.Runtime.InteropServices;

namespace Kingmaker.Desktop;

public partial class Kingmaker : Form, IMessageFilter
{
    private readonly DragEvent _mapDragging = new();
    private readonly Size _maximumMapSize;
    private readonly Size _minimumMapSize;

    public Kingmaker()
    {
        InitializeComponent();
        CaptureMouseEvents();
        Application.AddMessageFilter(this);
        _maximumMapSize = _mapPanel.Image!.Size;
        _minimumMapSize = _innerBoardPanel.Size;
    }

    private void CaptureMouseEvents()
    {
        SetMouseCapture(this);
        _mapPanel.MouseWheel += OnMouseWheel;

        void SetMouseCapture(Control c)
        {
            c.MouseUp += OnMouseUp;
            c.MouseMove += OnMouseMove;
            foreach (var child in c.Controls.OfType<Control>())
                SetMouseCapture(child);
        }
    }

    private void OnMouseWheel(object? sender, MouseEventArgs e)
    {
        const int wheelDelta = 120;
        var magnitude = e.Delta / wheelDelta;
        if (ModifierKeys == Keys.Control)
        {
            const int max = 12;
            var multiplier = 1 + (double) magnitude / max;
            var mapPanelSize = _mapPanel.Size.Multiply(multiplier).EnsureIsBetween(_minimumMapSize, _maximumMapSize);
            _mapPanel.Size = mapPanelSize;
        }
    }

    private void OnMouseDownOverMap(object sender, MouseEventArgs e)
    {
        _mapDragging.Start(Cursor.Position);
    }

    private void OnMouseMove(object? sender, MouseEventArgs e)
    {
        if (_mapDragging.IsActive) 
            DragMap();
    }

    private void OnMouseUp(object? sender, MouseEventArgs e)
    {
        if (_mapDragging.IsActive)
            DragMap(mayIgnore: false);
        _mapDragging.Stop();
    }

    private void DragMap(bool mayIgnore = true)
    {
        try
        {
            var dragSize = _mapDragging.Drag(Cursor.Position).ConvertToSize();
            if (mayIgnore && dragSize.Abs() is { Width: < 10, Height: < 10 })
                return;

            var newMapLocation = _mapPanel.Location + dragSize;
            newMapLocation = newMapLocation.EnsureFullyOverlapsItsParent(_mapPanel);
            _mapPanel.Location = newMapLocation;
        }
        catch
        {
            // ignored
        }
    }

    public bool PreFilterMessage(ref Message m)
    {
        if (m.Msg == 0x20a)
        {
            // WM_MOUSEWHEEL, find the control at screen position m.LParam
            var pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
            var hWnd = WindowFromPoint(pos);
            var fromHandle = FromHandle(hWnd);
            if (fromHandle == _mapPanel)
            {
                SendMessage(hWnd, m.Msg, m.WParam, m.LParam);
                return true;
            }
        }
        return false;
    }

    // P/Invoke declarations
    [DllImport("user32.dll")]
    private static extern IntPtr WindowFromPoint(Point pt);
    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

    private void OnClickExit(object sender, EventArgs e)
    {
        Application.Exit();
    }
}