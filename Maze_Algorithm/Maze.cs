using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static System.Console;

namespace Maze_Algorithm
{
    class Maze
    {
        private int gridRows;
        private int gridColumns;
        private Grid grid;
        private Cell currentCell;
        private Stack<Cell> cellsWithUnvisitedNeighbour = new Stack<Cell>();
        private Random rnd = new Random();

        public Maze(int rows, int columns)
        {
            gridRows = rows;
            gridColumns = columns;
            grid = new Grid(gridRows, gridColumns);
        }

        public void MakeMaze()
        {

            grid.PrintGridToConsole();


            // initial cell [0, 0] = visited - push to stack

            // while stack is not empty
            //  Pop a cell from the stack and make it a current cell
            //  If the current cell has any neighbours which have not been visited
            //      Push the current cell to the stack
            //      Choose one of the unvisited neighbours
            //      Remove the wall between the current cell and the chosen cell
            //      Mark the chosen cell as visited and push it to the stack


            // Init
            grid.Cells[0, 0].IsVisited = true;
            cellsWithUnvisitedNeighbour.Push(grid.Cells[0, 0]);

            // Algorithm
            while (cellsWithUnvisitedNeighbour.Count > 0)
            {
                currentCell = cellsWithUnvisitedNeighbour.Pop();

                bool currentCellHasUnvisitedNeighbour = DoesCellHaveUnvisitedNeighbour(currentCell);

                if (currentCellHasUnvisitedNeighbour)
                {
                    cellsWithUnvisitedNeighbour.Push(currentCell);
                    Cell chosenNeighbour = ChooseRandomUnvisitedNeighbour(currentCell);
                    RemoveWallBetweenNeighbours(currentCell, chosenNeighbour);
                    chosenNeighbour.IsVisited = true;
                    cellsWithUnvisitedNeighbour.Push(chosenNeighbour);
                }

            }
        }

        private bool DoesCellHaveUnvisitedNeighbour(Cell cell)
        {
            if (IsOutOfBounds(cell.X + 1, cell.Y) == false && grid.Cells[cell.X + 1, cell.Y].IsVisited == false)
            {
                return true;
            }
            else if (IsOutOfBounds(cell.X, cell.Y + 1) == false && grid.Cells[cell.X, cell.Y + 1].IsVisited == false)
            {
                return true;
            }
            else if (IsOutOfBounds(cell.X - 1, cell.Y) == false && grid.Cells[cell.X - 1, cell.Y].IsVisited == false)
            {
                return true;
            }
            else if (IsOutOfBounds(cell.X, cell.Y - 1) == false && grid.Cells[cell.X, cell.Y - 1].IsVisited == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Cell ChooseRandomUnvisitedNeighbour(Cell cell)
        {
            List<Cell> choices = new List<Cell>();

            if (IsOutOfBounds(cell.X + 1, cell.Y) == false && grid.Cells[cell.X + 1, cell.Y].IsVisited == false)
            {
                choices.Add(grid.Cells[cell.X + 1, cell.Y]);
            }
            if (IsOutOfBounds(cell.X, cell.Y + 1) == false && grid.Cells[cell.X, cell.Y + 1].IsVisited == false)
            {
                choices.Add(grid.Cells[cell.X, cell.Y + 1]);
            }
            if (IsOutOfBounds(cell.X - 1, cell.Y) == false && grid.Cells[cell.X - 1, cell.Y].IsVisited == false)
            {
                choices.Add(grid.Cells[cell.X - 1, cell.Y]);
            }
            if (IsOutOfBounds(cell.X, cell.Y - 1) == false && grid.Cells[cell.X, cell.Y - 1].IsVisited == false)
            {
                choices.Add(grid.Cells[cell.X, cell.Y - 1]);
            }

            int choice = rnd.Next(choices.Count);

            return choices[choice];
        }

        private bool IsOutOfBounds(int x, int y)
        {
            if (x < 0 || x > gridColumns - 1)
            {
                return true;
            }
            if (y < 0 || y > gridRows - 1)
            {
                return true;
            }
            
            return false;
        }

        private void RemoveWallBetweenNeighbours(Cell cell, Cell neighbour)
        {
            int directionX = neighbour.X - cell.X;
            int directionY = neighbour.Y - cell.Y;

            
            if (directionY == -1)
            {
                RemoveWall(cell, "north");
            }
            else if (directionX == 1)
            {
                RemoveWall(cell, "east");
            }
            else if (directionY == 1)
            {
                RemoveWall(cell, "south");
            }
            else if (directionX == -1)
            {
                RemoveWall(cell, "west");
            }
        }

        private void RemoveWall(Cell cell, string wall)
        {
            switch (wall)
            {
                case "north":
                    SetCursorPosition(cell.X * 4 + 1, cell.Y * 2);
                    Write("   ");
                    break;
                case "east":
                    SetCursorPosition(cell.X * 4 + 4, cell.Y * 2 + 1);
                    Write(" ");
                    break;
                case "south":
                    SetCursorPosition(cell.X * 4 + 1, cell.Y * 2 + 2);
                    Write("   ");
                    break;
                case "west":
                    SetCursorPosition(cell.X * 4, cell.Y * 2 + 1);
                    Write(" ");
                    break;
            }
            Thread.Sleep(500);
            SetCursorPosition(0, grid.GetGridHeight());
        }


    }
}
