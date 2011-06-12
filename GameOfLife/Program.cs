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
            string pattern = "- X X X\nX X X -";
            Grid grid = new Grid(pattern);
            Console.WriteLine("Grid As given");
            Console.WriteLine(grid.ToString());            
            for (int i = 0; i < 21; i++)
            {
                Console.WriteLine("Generation  {0}: ", (i+1));                
                grid.AdvanceToNextGeneration();
                Console.WriteLine(grid.ToString());
                Console.Read();
            }            
        }
    }
}
