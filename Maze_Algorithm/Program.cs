using System;
using static System.Console;
using System.Collections.Generic;

namespace Maze_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {

            int rows = 8;
            int columns = 12;

            Maze maze = new Maze(rows, columns);
            maze.MakeMaze();


            /*
            int x = 3;
            int y = 4;

            // find wall
            // north (y * 2 + 1) - 1
            // east  (x * 4 + 2) + 2
            // south (y * 2 + 1) + 1
            // west  (x * 4 + 2) - 2

            // remove west wall
            SetCursorPosition((x * 4 + 2) - 2, y * 2 + 1);
            Write(" ");
 
            // find cell
            // x * 4 + 2
            // y * 2 + 1
            SetCursorPosition(x * 4 + 2, y * 2 + 1);
            Write("X");
            
            // set cursor to end of grid
            SetCursorPosition(0, maze.grid.GetGridHeight());
            */

            Write("\n\n\n");
            WriteLine("Press any key to exit..");
            ReadKey();

        }
    }
}
