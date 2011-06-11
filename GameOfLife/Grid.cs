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
            DecideStatusForNextGeneration();
        }
        
        private void DecideStatusForNextGeneration()
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                rows[i].DecideStatusForRow();
            }
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
            for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
            {
                rows[rowIndex].AdvanceToNextGeneration();
            }
        }
    }
}
