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
            Grid grid = new Grid("X - -\nX - X\n");
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
