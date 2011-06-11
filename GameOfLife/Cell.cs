using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    class Cell
    {
        String currentValue;

        public String CurrentValue
        {
            get { return currentValue; }
            set { currentValue = value; }
        }
        String nextValue;

        public String NextValue
        {
            get { return nextValue; }
            set { nextValue = value; }
        }

        Int32 numberOfNeighborsAlive;

        public Int32 NumberOfNeighborsAlive
        {
            get { return numberOfNeighborsAlive; }
            set { numberOfNeighborsAlive = value; }
        }
    }
}
