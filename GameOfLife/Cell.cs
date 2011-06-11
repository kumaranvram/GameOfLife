using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    class Cell
    {
        public Cell()
        {
            numberOfNeighborsAlive = 0;
        }

        public Cell(String value) : this()
        {
            currentValue = value;
            nextValue = value;
        }
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

        public void AdvanceToNextGeneration()
        {
            currentValue = nextValue;
        }

        public bool IsAlive()
        {
            return currentValue.Contains("X");
        }

        public void DecideStatus()
        {
            if (numberOfNeighborsAlive < 2 || numberOfNeighborsAlive > 3)
            {
                nextValue = "-";
                return;
            }
            if (numberOfNeighborsAlive == 3 && (!IsAlive()))
            {
                nextValue = "X";
            }
        }

        public override string ToString()
        {
            return currentValue;
        }
    }
}
