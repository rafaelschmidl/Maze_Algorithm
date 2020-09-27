using System;
using System.Collections.Generic;
using System.Text;

namespace Maze_Algorithm
{
    class Cell
    {
        public int X { get; }
        public int Y { get; }
        public bool IsVisited { get; set; }
        public bool NorthWall { get; set; }
        public bool EastWall { get; set; }
        public bool SouthWall { get; set; }
        public bool WestWall { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            IsVisited = false;
            NorthWall = true;
            EastWall = true;
            SouthWall = true;
            WestWall = true;
        }
    }
}
