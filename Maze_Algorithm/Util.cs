using System;
using System.Runtime.InteropServices;

namespace Maze_Algorithm
{
    class Util
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]

        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void MaximizeConsoleWindow()
        {
            ShowWindow(ThisConsole, 3);
        }
    }
}
