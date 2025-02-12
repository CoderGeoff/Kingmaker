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
            menuStrip1 = new MenuStrip();
            gameToolStripMenuItem = new ToolStripMenuItem();
            _gameMenu = new ToolStripMenuItem();
            panel2 = new Panel();
            _boardPanel = new Panel();
            hScrollBar1 = new HScrollBar();
            vScrollBar1 = new VScrollBar();
            _mapPanel = new Panel();
            menuStrip1.SuspendLayout();
            _boardPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { gameToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(810, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
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
            _gameMenu.Size = new Size(224, 26);
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
            // _boardPanel
            // 
            _boardPanel.Controls.Add(_mapPanel);
            _boardPanel.Controls.Add(vScrollBar1);
            _boardPanel.Controls.Add(hScrollBar1);
            _boardPanel.Dock = DockStyle.Fill;
            _boardPanel.Location = new Point(0, 28);
            _boardPanel.Name = "_boardPanel";
            _boardPanel.Size = new Size(560, 399);
            _boardPanel.TabIndex = 3;
            // 
            // hScrollBar1
            // 
            hScrollBar1.Dock = DockStyle.Bottom;
            hScrollBar1.Location = new Point(0, 373);
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(560, 26);
            hScrollBar1.TabIndex = 0;
            // 
            // vScrollBar1
            // 
            vScrollBar1.Dock = DockStyle.Right;
            vScrollBar1.Location = new Point(534, 0);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(26, 373);
            vScrollBar1.TabIndex = 1;
            // 
            // _mapPanel
            // 
            _mapPanel.Dock = DockStyle.Fill;
            _mapPanel.Location = new Point(0, 0);
            _mapPanel.Name = "_mapPanel";
            _mapPanel.Size = new Size(534, 373);
            _mapPanel.TabIndex = 2;
            // 
            // Kingmaker
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 427);
            Controls.Add(_boardPanel);
            Controls.Add(panel2);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Kingmaker";
            Text = "Kingmaker";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            _boardPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem _gameMenu;
        private Panel panel2;
        private Panel _boardPanel;
        private VScrollBar vScrollBar1;
        private HScrollBar hScrollBar1;
        private Panel _mapPanel;
    }
}
