using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class Cell
    {
        public int x { get; }
        public int z { get; }
        public bool left { get; set; } = false;
        public bool right { get; set; } = false;
        public bool up { get; set; } = false;
        public bool down { get; set; } = false;
        public bool visited { get; set; } = false;
        public Cell solution { get; set; }
        public Star star { get; set; } = null;

        public Cell(int x, int z)
        {
            this.x = x;
            this.z = z;
        }
    }
}
