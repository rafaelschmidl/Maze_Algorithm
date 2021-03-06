﻿using static System.Console;

namespace Maze_Algorithm
{
    class Grid
    {
        private int gridRows;
        private int gridColumns;
        public Cell[,] Cells;

        public Grid(int rows, int columns)
        {
            gridRows = rows;
            gridColumns = columns;
            Cells = new Cell[gridColumns, gridRows];
            for (int y = 0; y < gridRows; y++) 
            {
                for (int x = 0; x < gridColumns; x++)
                {
                    Cells[x, y] = new Cell(x, y);
                }
            }
        }

        public void PrintGridToConsole()
        {
            for (int row = 0; row < gridRows; row++)
            {
                for (int column = 0; column < gridColumns; column++)
                {
                    Write("+---");
                    if (column + 1 == gridColumns)
                    {
                        WriteLine("+");
                    }
                }
                for (int column = 0; column < gridColumns; column++)
                {
                    Write("|   ");
                    if (column + 1 == gridColumns)
                    {
                        WriteLine("|");
                    }
                }
            }
            for (int column = 0; column < gridColumns; column++)
            {
                Write("+---");
                if (column + 1 == gridColumns)
                {
                    WriteLine("+");
                }
            }
        }

        public int GetGridHeight()
        {
            return gridRows * 2 + 1;
        }

        public int GetGridWidth()
        {
            return gridColumns * 4 + 1;
        }
    }
}
