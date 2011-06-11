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
            string pattern = "-\tX\tX\tX\nX\tX\tX\t-";
            Grid grid = new Grid(pattern);
            Console.WriteLine("Grid As given");
            Console.WriteLine(grid.ToString());
            grid.AdvanceToNextGeneration();
            Console.WriteLine("Grid Output");
            Console.WriteLine(grid.ToString());
            Console.Read();
        }
    }
}
