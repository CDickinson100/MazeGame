using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MazeGame
{
    public class Maze
    {
        public int width { get; }
        public int height { get; }
        public List<Cell> cells = new List<Cell>();
        public Panel panel;
        private int cellSize = 50;
        private bool rendered = false;
        private int time = 60;
        public Timer timer;
        public Label timerLabel;
        public Maze(int width, int height)
        {
            this.width = width;
            this.height = height;
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    cells.Add(new Cell(x, z));
                }
            }
            generateMaze();
            this.panel = new Panel();
            this.panel.Location = new Point(0, 30);
            this.panel.Size = new Size(width * cellSize, height * cellSize);
            this.panel.Paint += new PaintEventHandler(renderMaze);
            this.panel.BackColor = Color.White;

            this.timerLabel = new Label();
            this.timerLabel.Location = new Point(10, 10);
            this.timerLabel.Name = "Time";
            this.timerLabel.Size = new Size(50, 20);
            this.timerLabel.TabIndex = 0;
            this.timerLabel.Text = "Time: " + time;

            this.timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += TimerEventProcessor;
            timer.Start();
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            this.time--;
            this.timerLabel.Text = "Time: "+time;
            if(time == 0)
            {
                Form1.form.regenerateMaze();
            }
        }

        public void generateMaze()
        {
            Random random = new Random();
            Cell currentCell = getCell(width - 1, height - 1);
            currentCell.visited = true;
            Stack<Cell> visitedCells = new Stack<Cell>();
            visitedCells.push(currentCell);
            while (visitedCells.getSize() != 0)
            {
                Cell solution = currentCell;
                List<Direction> availableDirections = getAvailableDirections(currentCell);
                if (availableDirections.Count == 0)
                {
                    currentCell = visitedCells.pop();
                    continue;
                }
                Direction direction = availableDirections[random.Next(availableDirections.Count)];
                visitedCells.push(currentCell);
                switch (direction)
                {
                    case Direction.LEFT:
                        currentCell.left = true;
                        currentCell = getCell(currentCell.x - 1, currentCell.z);
                        currentCell.right = true;
                        break;
                    case Direction.RIGHT:
                        currentCell.right = true;
                        currentCell = getCell(currentCell.x + 1, currentCell.z);
                        currentCell.left = true;
                        break;
                    case Direction.UP:
                        currentCell.up = true;
                        currentCell = getCell(currentCell.x, currentCell.z - 1);
                        currentCell.down = true;
                        break;
                    case Direction.DOWN:
                        currentCell.down = true;
                        currentCell = getCell(currentCell.x, currentCell.z + 1);
                        currentCell.up = true;
                        break;
                }
                currentCell.visited = true;
                currentCell.solution = solution;
            }
            for (int i = 0; i < 3; i++)
            {
                Cell cell = cells[random.Next(cells.Count)];
                cell.star = new Star(cell, this);
            }
        }

        public List<Direction> getAvailableDirections(Cell cell)
        {
            List<Direction> directions = new List<Direction>();
            if (isCellAvailable(cell.x - 1, cell.z)) directions.Add(Direction.LEFT);
            if (isCellAvailable(cell.x + 1, cell.z)) directions.Add(Direction.RIGHT);
            if (isCellAvailable(cell.x, cell.z - 1)) directions.Add(Direction.UP);
            if (isCellAvailable(cell.x, cell.z + 1)) directions.Add(Direction.DOWN);
            return directions;
        }

        public bool isCellAvailable(int x, int z)
        {
            Cell cell = getCell(x, z);
            if (cell == null) return false;
            return !cell.visited;
        }

        public Cell getCell(int x, int z)
        {
            foreach (Cell cell in cells)
            {
                if (cell.x == x && cell.z == z) return cell;
            }
            return null;
        }

        public void renderMaze(object sender, PaintEventArgs args)
        {
            if (rendered) return;
            rendered = true;
            Graphics graphics = args.Graphics;
            Pen pen = new Pen(new SolidBrush(Color.Black), 1);
            Pen gold = new Pen(new SolidBrush(Color.Gold), 1);
            foreach (Cell cell in cells)
            {
                if (!cell.left)
                {
                    graphics.DrawLine(pen, cell.x * cellSize, cell.z * cellSize, cell.x * cellSize, (cell.z + 1) * cellSize);
                }
                if (!cell.right)
                {
                    graphics.DrawLine(pen, (cell.x + 1) * cellSize, cell.z * cellSize, (cell.x + 1) * cellSize, (cell.z + 1) * cellSize);
                }
                if (!cell.up)
                {
                    graphics.DrawLine(pen, cell.x * cellSize, cell.z * cellSize, (cell.x + 1) * cellSize, cell.z * cellSize);
                }
                if (!cell.down)
                {
                    graphics.DrawLine(pen, cell.x * cellSize, (cell.z + 1) * cellSize, (cell.x + 1) * cellSize, (cell.z + 1) * cellSize);
                }
            }
        }

    }
}
