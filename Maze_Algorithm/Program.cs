using static System.Console;

namespace Maze_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Util.MaximizeConsoleWindow();
            BufferHeight = WindowHeight;

            int rows = WindowHeight / 2 - 1;
            int columns = WindowWidth / 4 - 1;

            Maze maze = new Maze(rows, columns);
            maze.MakeMaze();

            WriteLine("The maze is complete :)");
            Write("Press any key to exit..");
            ReadKey();
        }
    }
}
