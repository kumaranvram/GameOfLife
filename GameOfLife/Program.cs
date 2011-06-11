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
            Grid grid = new Grid("X X - -\nX - - -\n- - - X\n- - X X ");
            Console.WriteLine("Grid As given");
            Console.WriteLine(grid.ToString());
            grid.AdvanceToNextGeneration();
            Console.WriteLine("Grid Output");
            Console.WriteLine(grid.ToString());
            Console.Read();
        }
    }
}
