namespace Kingmaker.Desktop
{
    public partial class Kingmaker : Form
    {
        public Kingmaker()
        {
            InitializeComponent();
        }

        private void OnClickExit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
