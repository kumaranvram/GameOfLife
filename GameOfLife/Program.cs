using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = "X\tX\tX\nX\tX\tX\nX\tX\tX";
            Grid grid = new Grid(pattern);
            Console.WriteLine("Grid As given");
            Console.WriteLine(pattern);
            grid.AdvanceToNextGeneration();
            Console.WriteLine("Grid Output");
            Console.WriteLine(grid.ToString());
            Console.Read();
        }
    }
}
