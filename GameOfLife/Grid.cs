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
            //this
            LoadPattern(pattern);
        }

        public void LoadPattern(String pattern)
        {
            char[] splitPattern = "\n".ToCharArray();
            String[] rows = pattern.Split(splitPattern);
            numberOfRows = rows.Length;
            for (int i = 0; i < numberOfRows; i++)
            {
                List<Cell> row = new List<Cell>();
                cells.Add(LoadRow(rows[i], i));
            }
            numberOfColumns = cells[0].Count;
        }

        private List<Cell> LoadRow(String rowPattern, int index)
        {
            List<Cell> row = new List<Cell>();
            char[] splitPattern = " ".ToCharArray();
            String[] columns = rowPattern.Split(splitPattern);
            for (int i = 0; i < columns.Length; i++)
            {
                Cell cell = new Cell();
                cell.CurrentValue = columns[i];
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

        public void AdvanceToNextGeneration()
        {

        }

        private void IsNewRowRequired(List<Cell> row)
        {
        }

        private void IsNewColumnRequired()
        {
            
        }

    }
}
