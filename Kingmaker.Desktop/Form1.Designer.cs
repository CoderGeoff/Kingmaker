namespace Kingmaker.Desktop
{
    partial class Kingmaker
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kingmaker));
            _mainMenu = new MenuStrip();
            gameToolStripMenuItem = new ToolStripMenuItem();
            _gameMenu = new ToolStripMenuItem();
            panel2 = new Panel();
            _outerBoardPanel = new Panel();
            _innerBoardPanel = new Panel();
            _mapPanel = new Panel();
            _boardVScroll = new VScrollBar();
            _boardHScroll = new HScrollBar();
            _mainMenu.SuspendLayout();
            _outerBoardPanel.SuspendLayout();
            _innerBoardPanel.SuspendLayout();
            SuspendLayout();
            // 
            // _mainMenu
            // 
            _mainMenu.ImageScalingSize = new Size(20, 20);
            _mainMenu.Items.AddRange(new ToolStripItem[] { gameToolStripMenuItem });
            _mainMenu.Location = new Point(0, 0);
            _mainMenu.Name = "_mainMenu";
            _mainMenu.Size = new Size(810, 28);
            _mainMenu.TabIndex = 0;
            _mainMenu.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _gameMenu });
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new Size(62, 24);
            gameToolStripMenuItem.Text = "&Game";
            // 
            // _gameMenu
            // 
            _gameMenu.Name = "_gameMenu";
            _gameMenu.Size = new Size(116, 26);
            _gameMenu.Text = "E&xit";
            _gameMenu.Click += OnClickExit;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(560, 28);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 399);
            panel2.TabIndex = 2;
            // 
            // _outerBoardPanel
            // 
            _outerBoardPanel.Controls.Add(_boardHScroll);
            _outerBoardPanel.Controls.Add(_boardVScroll);
            _outerBoardPanel.Controls.Add(_innerBoardPanel);
            _outerBoardPanel.Dock = DockStyle.Fill;
            _outerBoardPanel.Location = new Point(0, 28);
            _outerBoardPanel.Name = "_outerBoardPanel";
            _outerBoardPanel.Size = new Size(560, 399);
            _outerBoardPanel.TabIndex = 3;
            // 
            // _innerBoardPanel
            // 
            _innerBoardPanel.Controls.Add(_mapPanel);
            _innerBoardPanel.Dock = DockStyle.Fill;
            _innerBoardPanel.Location = new Point(0, 0);
            _innerBoardPanel.Name = "_innerBoardPanel";
            _innerBoardPanel.Size = new Size(534, 373);
            _innerBoardPanel.TabIndex = 3;
            _innerBoardPanel.MouseMove += OnMouseMove;
            _innerBoardPanel.MouseUp += OnMouseUp;
            // 
            // _mapPanel
            // 
            _mapPanel.BackgroundImage = (Image)resources.GetObject("_mapPanel.BackgroundImage");
            _mapPanel.Cursor = Cursors.Hand;
            _mapPanel.Location = new Point(0, 0);
            _mapPanel.Name = "_mapPanel";
            _mapPanel.Size = new Size(4631, 6469);
            _mapPanel.MouseDown += OnMouseDownOverBoard;
            _mapPanel.TabIndex = 2;
            // 
            // _boardVScroll
            // 
            _boardVScroll.Dock = DockStyle.Right;
            _boardVScroll.Location = new Point(534, 0);
            _boardVScroll.Name = "_boardVScroll";
            _boardVScroll.Size = new Size(26, 373);
            _boardVScroll.TabIndex = 1;
            // 
            // _boardHScroll
            // 
            _boardHScroll.Dock = DockStyle.Bottom;
            _boardHScroll.Location = new Point(0, 373);
            _boardHScroll.Name = "_boardHScroll";
            _boardHScroll.Size = new Size(560, 26);
            _boardHScroll.TabIndex = 0;
            // 
            // Kingmaker
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 427);
            Controls.Add(_outerBoardPanel);
            Controls.Add(panel2);
            Controls.Add(_mainMenu);
            MainMenuStrip = _mainMenu;
            Name = "Kingmaker";
            Text = "Kingmaker";
            _mainMenu.ResumeLayout(false);
            _mainMenu.PerformLayout();
            _outerBoardPanel.ResumeLayout(false);
            _innerBoardPanel.ResumeLayout(false);
            _mapPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip _mainMenu;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem _gameMenu;
        private Panel panel2;
        private Panel _outerBoardPanel;
        private Panel _innerBoardPanel;
        private VScrollBar _boardVScroll;
        private HScrollBar _boardHScroll;
        private Panel _mapPanel;
    }
}
