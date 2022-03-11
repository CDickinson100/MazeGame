using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGame
{
    public class Star
    {
        public Panel panel;
        public Maze maze;
        public Star(Cell cell, Maze maze)
        {
            this.maze = maze;
            this.panel = new Panel();
            this.panel.Location = new Point(1 + (cell.x * 50), 1 + (cell.z * 50));
            this.panel.Size = new Size(48, 48);
            this.panel.BackColor = Color.Gold;
        }

        public void removeStar()
        {
            maze.panel.Controls.Remove(panel);
        }
    }
}
