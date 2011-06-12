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
            string pattern = "- - - X X - - -\n- X - - - - X -\nX - - - - - - X\n- X - - - - X -\n- - - X X - - -\n";
            Grid grid = new Grid(pattern);
            Console.WriteLine("Grid As given");
            Console.WriteLine(grid.ToString());            
            grid.AdvanceToNextGeneration();
            Console.WriteLine(grid.ToString());
            Console.ReadLine();
        }
    }
}
