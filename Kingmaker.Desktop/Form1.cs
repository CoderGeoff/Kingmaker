namespace Kingmaker.Desktop
{
    public partial class Kingmaker : Form
    {
        private readonly BoardDragEvent _boardDragging = new();
        public Kingmaker()
        {
            InitializeComponent();
        }

        private void OnMouseDownOverBoard(object sender, MouseEventArgs e)
        {
            _boardDragging.Start(e.X, e.Y);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_boardDragging.IsActive)
            {
                var drag = _boardDragging.Stop(e.X, e.Y);
                //_mapPanel.
            }

        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (_boardDragging.IsActive)
            {
                var drag = _boardDragging.Stop(e.X, e.Y);
                //_mapPanel.
                return;
            }
        }

        private void OnClickExit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
