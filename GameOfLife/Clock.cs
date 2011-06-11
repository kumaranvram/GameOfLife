using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    class Clock
    {
        public static void Tick()
        {
            Grid grid = new Grid("- - - -\n- X X X\nX X X -\n- - - -");
            Console.WriteLine ("Grid As given");
            Console.WriteLine(grid.ToString());
            grid.AdvanceGridToNextGeneration();
            Console.WriteLine ("Grid Output");
            Console.WriteLine(grid.ToString());
            Console.Read();
        }

        public static void Tick(long iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                Clock.Tick();                
            }
        }
    }
}
