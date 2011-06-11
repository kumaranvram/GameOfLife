using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    class Grid
    {
        private List<List<Cell>> cells;

        private Int32 numberOfRows;
        private Int32 numberOfColumns;

        public Grid()
        {
            cells = new List<List<Cell>>();
            numberOfColumns = 0;
            numberOfRows = 0;
        }

        public Grid(String pattern) : this()
        {
            LoadPattern(pattern);
        }

        public void LoadPattern(String pattern)
        {
            pattern = pattern.Trim();
            char[] splitPattern = "\n".ToCharArray();
            String[] rows = pattern.Split(splitPattern);
            numberOfRows = rows.Length;
            for (int i = 0; i < numberOfRows; i++)
            {
                List<Cell> row = new List<Cell>();
                cells.Add(LoadRow(rows[i], i));
            }
            numberOfColumns = cells[0].Count;
            DecideStatusForNextGeneration();
        }
       

        private void DecideStatusForLastRow()
        {
            int neighbors = 0;
            int rowIndex = numberOfRows - 1;
            neighbors = neighbors + (cells[rowIndex][1].IsAlive() ? 1 : 0);
            neighbors = neighbors + (cells[rowIndex - 1][0].IsAlive() ? 1 : 0);
            neighbors = neighbors + (cells[rowIndex - 1][1].IsAlive() ? 1 : 0);
            cells[rowIndex][0].NumberOfNeighborsAlive = neighbors;
            cells[rowIndex][0].DecideStatus();
            int columnIndex = 1;
            for (; columnIndex < cells[0].Count - 1; columnIndex++)
            {
                neighbors = 0;
                neighbors = neighbors + (cells[rowIndex][columnIndex - 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (cells[rowIndex][columnIndex + 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (cells[rowIndex - 1][columnIndex - 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (cells[rowIndex - 1][columnIndex].IsAlive() ? 1 : 0);
                neighbors = neighbors + (cells[rowIndex - 1][columnIndex + 1].IsAlive() ? 1 : 0);
                cells[rowIndex][columnIndex].NumberOfNeighborsAlive = neighbors;
                cells[rowIndex][columnIndex].DecideStatus();
            }
            neighbors = 0;
            neighbors = neighbors + (cells[rowIndex][columnIndex - 1].IsAlive() ? 1 : 0);
            neighbors = neighbors + (cells[rowIndex - 1][columnIndex].IsAlive() ? 1 : 0);
            neighbors = neighbors + (cells[rowIndex - 1][columnIndex - 1].IsAlive() ? 1 : 0);
            cells[rowIndex][columnIndex].NumberOfNeighborsAlive = neighbors;
            cells[rowIndex][columnIndex].DecideStatus();
        }

        private void DecideStatusForFirstRow()
        {
            int neighbors = 0;
            neighbors = neighbors + (cells[0][1].IsAlive() ? 1 : 0);
            neighbors = neighbors + (cells[1][0].IsAlive() ? 1 : 0);
            neighbors = neighbors + (cells[1][1].IsAlive() ? 1 : 0);
            cells[0][0].NumberOfNeighborsAlive = neighbors;
            cells[0][0].DecideStatus();
            int columnIndex=1;
            for (; columnIndex < cells[0].Count - 1; columnIndex++)
            {
                neighbors = 0;
                neighbors = neighbors + (cells[0][columnIndex - 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (cells[0][columnIndex + 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (cells[1][columnIndex - 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (cells[1][columnIndex].IsAlive() ? 1 : 0);
                neighbors = neighbors + (cells[1][columnIndex + 1].IsAlive() ? 1 : 0);
                cells[0][columnIndex].NumberOfNeighborsAlive = neighbors;
                cells[0][columnIndex].DecideStatus();
            }
            neighbors = 0;
            neighbors = neighbors + (cells[0][columnIndex - 1].IsAlive() ? 1 : 0);
            neighbors = neighbors + (cells[1][columnIndex].IsAlive() ? 1 : 0);
            neighbors = neighbors + (cells[1][columnIndex - 1].IsAlive() ? 1 : 0);
            cells[0][columnIndex].NumberOfNeighborsAlive = neighbors;
            cells[0][columnIndex].DecideStatus();
        }

        private void DecideStatusForRow(int rowIndex)
        {
            int neighbors = 0;
            if (rowIndex == 0)
            {
                DecideStatusForFirstRow();
                return;
            }

            if (rowIndex == (numberOfRows - 1))
            {
                DecideStatusForLastRow();
                return;
            }

            neighbors = 0;
            neighbors = neighbors + (cells[rowIndex - 1][1].IsAlive() ? 1 : 0);
            neighbors = neighbors + (cells[rowIndex - 1][0].IsAlive() ? 1 : 0);
            neighbors = neighbors + (cells[rowIndex][1].IsAlive() ? 1 : 0);
            neighbors = neighbors + (cells[rowIndex + 1][0].IsAlive() ? 1 : 0);
            neighbors = neighbors + (cells[rowIndex + 1][1].IsAlive() ? 1 : 0);
            cells[rowIndex][0].NumberOfNeighborsAlive = neighbors;
            cells[rowIndex][0].DecideStatus();
            int columnIndex = 1;
            for (; columnIndex < numberOfColumns - 1; columnIndex++)
            {
                neighbors = 0;
                neighbors = neighbors + (cells[rowIndex - 1][columnIndex - 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (cells[rowIndex - 1][columnIndex].IsAlive() ? 1 : 0);
                neighbors = neighbors + (cells[rowIndex - 1][columnIndex + 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (cells[rowIndex][columnIndex - 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (cells[rowIndex][columnIndex + 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (cells[rowIndex + 1][columnIndex - 1].IsAlive() ? 1 : 0);
                neighbors = neighbors + (cells[rowIndex + 1][columnIndex].IsAlive() ? 1 : 0);
                neighbors = neighbors + (cells[rowIndex + 1][columnIndex + 1].IsAlive() ? 1 : 0);
                cells[rowIndex][columnIndex].NumberOfNeighborsAlive = neighbors;
                cells[rowIndex][columnIndex].DecideStatus();
            }
            neighbors = 0;
            neighbors = neighbors + (cells[rowIndex - 1][columnIndex].IsAlive() ? 1 : 0);
            neighbors = neighbors + (cells[rowIndex - 1][columnIndex - 1].IsAlive() ? 1 : 0);
            neighbors = neighbors + (cells[rowIndex][columnIndex - 1].IsAlive() ? 1 : 0);
            neighbors = neighbors + (cells[rowIndex + 1][columnIndex].IsAlive() ? 1 : 0);
            neighbors = neighbors + (cells[rowIndex + 1][columnIndex - 1].IsAlive() ? 1 : 0);
            cells[rowIndex][columnIndex].NumberOfNeighborsAlive = neighbors;
            cells[rowIndex][columnIndex].DecideStatus();
        }

        private void DecideStatusForNextGeneration()
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                DecideStatusForRow(i);
            }
        }

        private List<Cell> LoadRow(String rowPattern, int index)
        {
            rowPattern = rowPattern.Trim();
            List<Cell> row = new List<Cell>();
            char[] splitPattern = " ".ToCharArray();
            String[] columns = rowPattern.Split(splitPattern);
            for (int i = 0; i < columns.Length; i++)
            {
                Cell cell = new Cell();
                cell.CurrentValue = columns[i];
                cell.NextValue = columns[i];
                row.Add(cell);
            }
            return row;
        }

        public override String ToString()
        {
            StringBuilder gridPattern = new StringBuilder();
            for (int i = 0; i < numberOfRows; i++)
            {
                gridPattern.Append(PrintRow(cells[i]));
                gridPattern.Append("\n");
            }
            return gridPattern.ToString();
        }

        private StringBuilder PrintRow(List<Cell> row)
        {
            StringBuilder rowPattern = new StringBuilder();
            for (int i = 0; i < row.Count; i++)
            {
                rowPattern.Append(GetStringValue(row, i));
                rowPattern.Append("\t");
            }
            return rowPattern;
        }

        private String GetStringValue(List<Cell> row, int index)
        {
            return row[index].CurrentValue;
        }

        public void AdvanceGridToNextGeneration()
        {
            for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
            {
                AdvanceRowToNextGeneration(rowIndex);
            }
        }

        private void AdvanceRowToNextGeneration(int rowIndex)
        {
            for (int columnIndex = 0; columnIndex < numberOfColumns; columnIndex++)
            {
                cells[rowIndex][columnIndex].SetNextValueToCurrentValue();
            }
        }

    }
}
