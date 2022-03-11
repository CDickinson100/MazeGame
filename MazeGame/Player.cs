using System.Drawing;
using System.Windows.Forms;

namespace MazeGame
{
    public class Player
    {
        public int x = 0;
        public int z = 0;
        public int stars = 0;
        public Panel panel;
        private int cellSize = 50;
        public Maze maze;
        public Label starsLabel;

        public Player()
        {
            this.panel = new Panel();
            this.panel.Location = new Point((x * cellSize) + 1, (z * cellSize) + 1);
            this.panel.Size = new Size(cellSize - 2, cellSize - 2);
            this.panel.BackColor = Color.Red;
            this.maze = new Maze(30, 15);

            this.starsLabel = new Label();
            this.starsLabel.Location = new Point(60, 10);
            this.starsLabel.Name = "Stars";
            this.starsLabel.Size = new Size(100, 20);
            this.starsLabel.TabIndex = 0;
            this.starsLabel.Text = "Stars: " + stars + "/3";
        }

        public void moveLeft()
        {
            Cell cell = maze.getCell(x, z);
            if (cell.left) x--;
            refreshLocation();
        }

        public void moveRight()
        {
            Cell cell = maze.getCell(x, z);
            if (cell.right) x++;
            refreshLocation();
        }

        public void moveUp()
        {
            Cell cell = maze.getCell(x, z);
            if (cell.up) z--;
            refreshLocation();
        }

        public void moveDown()
        {
            Cell cell = maze.getCell(x, z);
            if (cell.down) z++;
            refreshLocation();
        }

        public void refreshLocation()
        {
            this.panel.Location = new Point((x * cellSize) + 1, (z * cellSize) + 1);
            Cell cell = maze.getCell(x, z);
            if (cell != null && cell.star != null)
            {
                stars++;
                cell.star.removeStar();
                cell.star = null;
                this.starsLabel.Text = "Stars: " + stars + "/3";
            }
            if (x == maze.width-1 && z == maze.height - 1)
            {
                Form1.form.regenerateMaze();
            }
        }

        public void solveMaze()
        {
            Cell current = maze.getCell(x, z);
            Cell solution = current.solution;
            if (solution == null) return;
            this.x = solution.x;
            this.z = solution.z;
            refreshLocation();
        }
    }
}
