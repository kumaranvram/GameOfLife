using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    class Row
    {
        /// <summary>
        /// The array of cells which form the row
        /// </summary>
        private List<Cell> cells;

        internal List<Cell> Cells
        {
            get { return cells; }
            set { cells = value; }
        }
        /// <summary>
        /// Points to the previous row of the current row
        /// </summary>
        private Row previousRow;

        internal Row PreviousRow
        {
            get { return previousRow; }
            set { previousRow = value; }
        }

        /// <summary>
        /// Points to the next row of the current row
        /// </summary>
        private Row nextRow;

        internal Row NextRow
        {
            get { return nextRow; }
            set { nextRow = value; }
        }        
        
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Row()
        {
            cells = new List<Cell>();            
        }

        /// <summary>
        /// Constructor that initializes the pattern for the row
        /// </summary>
        /// <param name="rowPattern">Pattern for the row</param>
        public Row(String rowPattern) : this()
        {
            rowPattern = rowPattern.Trim();
            char[] splitPattern = " ".ToCharArray();
            String[] columns = rowPattern.Split(splitPattern);
            for (int i = 0; i < columns.Length; i++)
            {
                Cell cell = new Cell(columns[i]);
                cells.Add(cell);
            }
        }

        /// <summary>
        /// Creates an empty row with dead cells for the number of columns passed as argument
        /// </summary>
        /// <param name="cellsCount">Number of columns</param>
        public Row(int cellsCount) : this()
        {
            for (int i = 0; i < cellsCount; i++)
            {
                Cell cell = new Cell("-");
                cells.Add(cell);
            }
        }

        /// <summary>
        /// Checks if a new row is needed for regeneration
        /// </summary>
        /// <returns>returns true if needed else returns false</returns>
        public bool IsNewRowNeeded()
        {
            //returns true if the row has 3 consecutive living cells
            return ToString().Contains("X X X");
        }

        /// <summary>
        /// Decides the status for each of the cell in the row, by calculating neighbors
        /// </summary>
        public void DecideStatusForRow()
        {
            int neighbors = 0;                
            //Calculates the neighbor for the first cell of the row
            if (previousRow != null)
            {
                neighbors += (previousRow.Cells[1].IsAlive() ? 1 : 0);
                neighbors += (previousRow.Cells[0].IsAlive() ? 1 : 0);
            }
            neighbors += (cells[1].IsAlive() ? 1 : 0);
            if (nextRow != null)
            {
                neighbors += (nextRow.Cells[0].IsAlive() ? 1 : 0);
                neighbors += (nextRow.Cells[1].IsAlive() ? 1 : 0);
            }
            cells[0].NumberOfNeighborsAlive = neighbors;
            //Checks for the neighbors for cells from index 1 to last but one
            int columnIndex = 1;
            for (; columnIndex < cells.Count - 1; columnIndex++)
            {
                neighbors = 0;
                if (previousRow != null)
                {
                    neighbors += (previousRow.IsCellAlive(columnIndex - 1) ? 1 : 0);
                    neighbors += (previousRow.IsCellAlive(columnIndex) ? 1 : 0);
                    neighbors += (previousRow.IsCellAlive(columnIndex + 1) ? 1 : 0);
                }
                neighbors += (IsCellAlive(columnIndex -1) ? 1 : 0);
                neighbors += (IsCellAlive(columnIndex +1) ? 1 : 0);
                if (nextRow != null)
                {
                    neighbors += (nextRow.IsCellAlive(columnIndex - 1) ? 1 : 0);
                    neighbors += (nextRow.IsCellAlive(columnIndex) ? 1 : 0);
                    neighbors += (nextRow.IsCellAlive(columnIndex + 1) ? 1 : 0);
                }
                cells[columnIndex].NumberOfNeighborsAlive = neighbors;
            }
            //Check for the neighbors for the last cell
            neighbors = 0;
            if (previousRow != null)
            {
                neighbors += (previousRow.IsCellAlive(columnIndex) ? 1 : 0);
                neighbors += (previousRow.IsCellAlive(columnIndex - 1) ? 1 : 0);
            }
            neighbors += (cells[columnIndex - 1].IsAlive() ? 1 : 0);
            if (nextRow != null)
            {
                neighbors += (nextRow.IsCellAlive(columnIndex) ? 1 : 0);
                neighbors += (nextRow.IsCellAlive(columnIndex - 1) ? 1 : 0);
            }
            cells[columnIndex].NumberOfNeighborsAlive = neighbors;            
        }

        /// <summary>
        /// Checks whether the row is empty or not
        /// </summary>
        /// <returns>true if empty, false otherwise</returns>
        private bool IsEmpty()
        {
            return !ToString().Contains("X");
        }
        /// <summary>
        /// Adds a new non living cell to the left
        /// </summary>
        public void AddColumnToLeft()
        {            
            Cell cell = new Cell("-");
            cells.Insert(0, cell);            
        }

        /// <summary>
        /// Adds a new non living cell to the right
        /// </summary>
        public void AddColumnToRight()
        {
            Cell cell = new Cell("-");
            cells.Add(cell);
        }


        /// <summary>
        /// Checks whether the cell at the given index is alive or dead
        /// </summary>
        /// <param name="index">index of the cell</param>
        /// <returns>true if the cell is alive and false otherwise</returns>
        public bool IsCellAlive(int index)
        {
            return cells[index].IsAlive();
        }

        /// <summary>
        /// Returns the string representation of the row
        /// i.e the cells seperated by a white space and finally by a new line
        /// </summary>
        /// <returns>String representation of the row</returns>
        public override String ToString()
        {
            
            String rowString = "";            
            //Append each of the cell value and a white space
            for (int index = 0; index < cells.Count - 1; index++)
            {                
                rowString = rowString + cells[index].CurrentValue + " ";                
            }
            rowString = rowString + cells[cells.Count - 1] + "\n";
            return rowString;
        }


        /// <summary>
        /// Returns the number of columns/cells in the row
        /// </summary>
        /// <returns>Number of columns</returns>
        public Int32 GetColumnCount()
        {
            return cells.Count;
        }

        /// <summary>
        /// Takes each of the cell in the row to the next generation
        /// </summary>
        public void AdvanceToNextGeneration()
        {
            for (int i = 0; i < cells.Count; i++)
            {
                cells[i].AdvanceToNextGeneration();
            }
        }
    }
}
