using System;
using System.Drawing;
using System.Windows.Forms;

namespace MazeGame
{
    public partial class Form1 : Form
    {
        public static Form1 form;
        public Player player;
        public Form1()
        {
            form = this;
            InitializeComponent();
            regenerateMaze();
            DoubleBuffered = true;
        }

        public void regenerateMaze()
        {
            if (player != null)
            {
                this.Controls.Remove(player.maze.panel);
                this.Controls.Remove(player.maze.timerLabel);
                this.Controls.Remove(player.starsLabel);
                player.maze.timer.Stop();
            }
            this.player = new Player();
            this.Controls.Add(player.maze.timerLabel);
            this.Controls.Add(player.starsLabel);
            this.Controls.Add(player.maze.panel);
            player.maze.panel.Controls.Add(player.panel);
            foreach (Cell cell in player.maze.cells)
            {
                if(cell.star != null)
                {
                    player.maze.panel.Controls.Add(cell.star.panel);
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyData)
            {
                case Keys.W:
                    player.moveUp();
                    break;
                case Keys.A:
                    player.moveLeft();
                    break;
                case Keys.S:
                    player.moveDown();
                    break;
                case Keys.D:
                    player.moveRight();
                    break;
                case Keys.R:
                    regenerateMaze();
                    break;
                case Keys.Escape:
                    Close();
                    break;
                case Keys.P:
                    player.solveMaze();
                    break;
            }
        }
    }
}
