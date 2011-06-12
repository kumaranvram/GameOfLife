using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    class Cell
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Cell()
        {
            numberOfNeighborsAlive = 0;
        }

        /// <summary>
        /// Initializes the cell with the value (X for living and - for dead)
        /// </summary>
        /// <param name="value">Value for the cell</param>
        public Cell(String value) : this()
        {
            currentValue = value;
            nextValue = value;
        }

        /// <summary>
        /// Current Value of the cell
        /// </summary>
        String currentValue;

        public String CurrentValue
        {
            get { return currentValue; }
            set { currentValue = value; }
        }
        String nextValue;

        /// <summary>
        /// Value the cell would take in the next generation
        /// </summary>
        public String NextValue
        {
            get { return nextValue; }
            set { nextValue = value; }
        }

        /// <summary>
        /// The number of neighbors alive for the cell
        /// When the number of neigbors is set/changed, the next value of the cell is decided
        /// </summary>
        Int32 numberOfNeighborsAlive;

        public Int32 NumberOfNeighborsAlive
        {
            get { return numberOfNeighborsAlive; }
            set { 
                numberOfNeighborsAlive = value; 
                DecideStatus(); 
            }
        }


        /// <summary>
        /// Takes the cell to the next generation 
        /// i.e. sets the next value as the current value
        /// </summary>
        public void AdvanceToNextGeneration()
        {
            currentValue = nextValue;
        }

        /// <summary>
        /// Checks if the cell is alive or dead
        /// </summary>
        /// <returns>true if alive and dead if otherwise</returns>
        public bool IsAlive()
        {
            return currentValue.Contains("X");
        }

        /// <summary>
        /// Decides the status of the cell based on the number of neighbors
        /// </summary>
        private void DecideStatus()
        {
            //The cell dies if it has less than 2 or more than 3 neighbors
            if (numberOfNeighborsAlive < 2 || numberOfNeighborsAlive > 3)
            {
                nextValue = "-";
                return;
            }
            //A dead cell resurrects if it has exactly 3 neighbors
            if (numberOfNeighborsAlive == 3 && (!IsAlive()))
            {
                nextValue = "X";
            }
        }


        /// <summary>
        /// Returns the string representation of the cell i.e. X if alive and - if dead
        /// </summary>
        /// <returns>String representation of the current value of the cell</returns>
        public override string ToString()
        {
            return currentValue;
        }
    }
}
