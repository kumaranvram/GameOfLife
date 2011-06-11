using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    class Row
    {
        private List<Cell> cells;

        internal List<Cell> Cells
        {
            get { return cells; }
            set { cells = value; }
        }
        private Row previousRow;

        internal Row PreviousRow
        {
            get { return previousRow; }
            set { previousRow = value; }
        }
        private Row nextRow;

        internal Row NextRow
        {
            get { return nextRow; }
            set { nextRow = value; }
        }        
        
        public Row()
        {
            cells = new List<Cell>();            
        }

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

        public Row(int cellsCount) : this()
        {
            for (int i = 0; i < cellsCount; i++)
            {
                Cell cell = new Cell("-");
                cells.Add(cell);
            }
        }

        public bool IsNewRowNeeded()
        {
            return ToString().Contains("X X X");
        }

        public void DecideStatusForRow()
        {
            int neighbors = 0;
            if (previousRow == null)
            {
                DecideStatusForFirstRow();
                return;
            }

            if (nextRow == null)
            {
                DecideStatusForLastRow();
                return;
            }
                        
            neighbors = 0;
            neighbors = neighbors + (previousRow.Cells[1].IsAlive() ? 1 : 0);
            neighbors = neighbors + (previousRow.Cells[0].IsAlive() ? 1 : 0);
            neighbors = neighbors + (cells[1].IsAlive() ? 1 : 0);
            neighbors = neighbors + (nextRow.Cells[0].IsAlive() ? 1 : 0);
            neighbors = neighbors + (nextRow.Cells[1].IsAlive() ? 1 : 0);
            cells[0].NumberOfNeighborsAlive = neighbors;
            cells[0].DecideStatus();
            int columnIndex = 1;
            for (; columnIndex < cells.Count - 1; columnIndex++)
            {
                neighbors = 0;
                neighbors = neighbors + (previousRow.Cells[columnIndex - 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (previousRow.Cells[columnIndex].IsAlive() ? 1 : 0);
                neighbors = neighbors + (previousRow.Cells[columnIndex + 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (cells[columnIndex - 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (cells[columnIndex + 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (nextRow.Cells[columnIndex - 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (nextRow.cells[columnIndex].IsAlive() ? 1 : 0);
                neighbors = neighbors + (nextRow.cells[columnIndex + 1].IsAlive() ? 1 : 0);
                cells[columnIndex].NumberOfNeighborsAlive = neighbors;
                cells[columnIndex].DecideStatus();
            }
            neighbors = 0;
            neighbors = neighbors + (previousRow.Cells[columnIndex].IsAlive() ? 1 : 0);
            neighbors = neighbors + (previousRow.Cells[columnIndex - 1].IsAlive() ? 1 : 0);
            neighbors = neighbors + (cells[columnIndex - 1].IsAlive() ? 1 : 0);
            neighbors = neighbors + (nextRow.Cells[columnIndex].IsAlive() ? 1 : 0);
            neighbors = neighbors + (nextRow.Cells[columnIndex - 1].IsAlive() ? 1 : 0);
            cells[columnIndex].NumberOfNeighborsAlive = neighbors;
            cells[columnIndex].DecideStatus();
        }

        private void DecideStatusForFirstRow()
        {
            int neighbors = 0;
            neighbors = neighbors + (cells[1].IsAlive() ? 1 : 0);
            neighbors = neighbors + (nextRow.Cells[0].IsAlive() ? 1 : 0);
            neighbors = neighbors + (nextRow.Cells[1].IsAlive() ? 1 : 0);
            cells[0].NumberOfNeighborsAlive = neighbors;
            cells[0].DecideStatus();
            int columnIndex = 1;
            for (; columnIndex < cells.Count - 1; columnIndex++)
            {
                neighbors = 0;
                neighbors = neighbors + (cells[columnIndex - 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (cells[columnIndex + 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (nextRow.Cells[columnIndex - 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (nextRow.Cells[columnIndex].IsAlive() ? 1 : 0);
                neighbors = neighbors + (nextRow.Cells[columnIndex + 1].IsAlive() ? 1 : 0);
                cells[columnIndex].NumberOfNeighborsAlive = neighbors;
                cells[columnIndex].DecideStatus();
            }
            neighbors = 0;
            neighbors = neighbors + (cells[columnIndex - 1].IsAlive() ? 1 : 0);
            neighbors = neighbors + (nextRow.Cells[columnIndex].IsAlive() ? 1 : 0);
            neighbors = neighbors + (nextRow.Cells[columnIndex - 1].IsAlive() ? 1 : 0);
            cells[columnIndex].NumberOfNeighborsAlive = neighbors;
            cells[columnIndex].DecideStatus();
        }

        private void  DecideStatusForLastRow()
        {
            int neighbors = 0;            
            neighbors = neighbors + (cells[1].IsAlive() ? 1 : 0);
            neighbors = neighbors + (previousRow.Cells[0].IsAlive() ? 1 : 0);
            neighbors = neighbors + (previousRow.Cells[1].IsAlive() ? 1 : 0);
            cells[0].NumberOfNeighborsAlive = neighbors;
            cells[0].DecideStatus();
            int columnIndex = 1;
            for (; columnIndex < cells.Count - 1; columnIndex++)
            {
                neighbors = 0;
                neighbors = neighbors + (cells[columnIndex - 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (cells[columnIndex + 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (previousRow.Cells[columnIndex - 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (previousRow.Cells[columnIndex].IsAlive() ? 1 : 0);
                neighbors = neighbors + (previousRow.Cells[columnIndex + 1].IsAlive() ? 1 : 0);
                cells[columnIndex].NumberOfNeighborsAlive = neighbors;
                cells[columnIndex].DecideStatus();
            }
            neighbors = 0;
            neighbors = neighbors + (cells[columnIndex - 1].IsAlive() ? 1 : 0);
            neighbors = neighbors + (previousRow.Cells[columnIndex].IsAlive() ? 1 : 0);
            neighbors = neighbors + (previousRow.Cells[columnIndex - 1].IsAlive() ? 1 : 0);
            cells[columnIndex].NumberOfNeighborsAlive = neighbors;
            cells[columnIndex].DecideStatus();
        }

        public void AddColumnAtStart()
        {            
            Cell cell = new Cell("-");
            cells.Insert(0, cell);            
        }

        public void AddColumnAtEnd()
        {
            Cell cell = new Cell("-");
            cells.Add(cell);
        }

        public override String ToString()
        {
            String rowString = "";
            for (int index = 0; index < cells.Count - 1; index++)
            {
                rowString = rowString + cells[index].CurrentValue + " ";
            }
            rowString = rowString + cells[cells.Count - 1] + "\n";
            return rowString.ToString();
        }

        public Int32 GetColumnCount()
        {
            return cells.Count;
        }

        public void AdvanceToNextGeneration()
        {
            for (int i = 0; i < cells.Count; i++)
            {
                cells[i].AdvanceToNextGeneration();
            }
        }
    }
}
