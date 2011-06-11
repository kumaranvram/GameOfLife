using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    class Grid
    {
        private List<Row> rows;

        private Int32 numberOfRows;
        private Int32 numberOfColumns;

        public Grid()
        {
            rows = new List<Row>();
            numberOfColumns = 0;
            numberOfRows = 0;
        }

        public Grid(String pattern) : this()
        {
            LoadPattern(pattern);
        }

        private void AddRowToStart(Row row)
        {
            List<Row> rowNew = new List<Row>();
            rows.Insert(0, row);            
            numberOfRows++;
        }

        private void AddRowToEnd(Row row)
        {
            rows.Add(row);
            numberOfRows++;
        }

        public void LoadPattern(String pattern)
        {            
            pattern = pattern.Trim();
            char[] splitPattern = "\n".ToCharArray();
            String[] rowPatterns = pattern.Split(splitPattern);
            numberOfRows = rowPatterns.Length;
            for (int i = 0; i < numberOfRows; i++)
            {
                Row row = new Row(rowPatterns[i]);                
                rows.Add(row);
            }
            for (int i = 1; i < rows.Count; i++)
            {
                rows[i].PreviousRow = rows[i - 1];                
            }
            for (int i = 0; i < rows.Count - 1; i++)
            {
                rows[i].NextRow = rows[i + 1];
            }
            numberOfColumns = rows[0].GetColumnCount();
        }

        private void PrepareForNextGeneration()
        {
            CheckForAdditionalColumnsAndRows();
            DecideStatusForNextGeneration();
        }

        private void CheckForAdditionalColumnsAndRows()
        {
            if (rows[0].IsNewRowNeeded())
            {
                int count = rows[0].GetColumnCount();
                Row row = new Row(count);
                rows[0].PreviousRow = row;
                row.NextRow = rows[0];
                AddRowToStart(row);
            }

            if (rows[rows.Count - 1].IsNewRowNeeded())
            {
                Row row = new Row(numberOfColumns);
                row.PreviousRow = rows[numberOfRows - 1];
                rows[numberOfRows - 1].NextRow = row;
                AddRowToEnd(row);
            }

            if (IsNewColumnNeededAtLeft())
            {
                AddNewColumnAtStart();
                numberOfColumns++;
            }

            if (IsNewColumnNeededAtRight())
            {
                AddNewColumnAtEnd();
                numberOfColumns++;
            }
        }

        private void AddNewColumnAtEnd()
        {
            for (int i = 0; i < numberOfRows; i++)
                rows[i].AddColumnAtEnd();
        }

        private void AddNewColumnAtStart()
        {
            for (int i = 0; i < numberOfRows; i++)
                rows[i].AddColumnAtStart();
        }

        private void DecideStatusForNextGeneration()
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                rows[i].DecideStatusForRow();
            }
        }

        private bool IsNewColumnNeededAtLeft()
        {
            int count = 0;
            for (int i = 0; i < numberOfRows; i++)
            {
                count = rows[i].Cells[0].IsAlive() ? count + 1 : 0;
                if (count >= 3) return true;
            }
            return false;
        }

        private bool IsNewColumnNeededAtRight()
        {
            int count = 0;
            for (int i = 0; i < numberOfRows; i++)
            {
                count = rows[i].Cells[numberOfColumns - 1].IsAlive() ? count + 1 : 0;
                if (count >= 3) return true;
            }
            return false;
        }

        public override String ToString()
        {
            String gridPattern = "";
            for (int i = 0; i < numberOfRows; i++)
            {
                gridPattern = gridPattern + rows[i].ToString();
            }
            return gridPattern;
        }

        public void AdvanceToNextGeneration()
        {
            PrepareForNextGeneration();
            for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
            {
                rows[rowIndex].AdvanceToNextGeneration();
            }
        }
    }
}
