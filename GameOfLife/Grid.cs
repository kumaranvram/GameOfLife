using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    class Grid
    {
        /// <summary>
        /// The array of rows which form the Grid
        /// </summary>
        private List<Row> rows;

        /// <summary>
        /// This denotes the number of rows in the grid
        /// </summary>
        private Int32 numberOfRows;

        /// <summary>
        /// This denotes the number of columns in the grid
        /// The main assumption is that, in case of multiple rows, all rows would be of equal length
        /// </summary>
        private Int32 numberOfColumns;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Grid()
        {
            rows = new List<Row>();
            numberOfColumns = 0;
            numberOfRows = 0;
        }

        /// <summary>
        /// Constructor to initialize the grid with pattern
        /// </summary>
        /// <param name="pattern">The pattern based on which the grid is to be formed</param>
        public Grid(String pattern) : this()
        {
            LoadPattern(pattern);
        }

        /// <summary>
        /// Loads the Grid with the pattern given as parameter.
        /// Internally loads the pattern for each row
        /// </summary>
        /// <param name="pattern">The pattern based on which the grid is to be formed</param>
        public void LoadPattern(String pattern)
        {
            pattern = pattern.Trim();
            //finds pattern for each row
            char[] splitPattern = "\n".ToCharArray();
            String[] rowPatterns = pattern.Split(splitPattern);
            numberOfRows = rowPatterns.Length;
            for (int i = 0; i < numberOfRows; i++)
            {
                //Initializes the row with the pattern
                Row row = new Row(rowPatterns[i]);
                rows.Add(row);
            }
            //Links up the previousRow and Last row for each of the rows
            for (int i = 1; i < numberOfRows; i++)
            {
                rows[i].PreviousRow = rows[i - 1];
            }
            for (int i = 0; i < numberOfRows - 1; i++)
            {
                rows[i].NextRow = rows[i + 1];
            }
            numberOfColumns = rows[0].GetColumnCount();
        }

        /// <summary>
        /// Adds the given row at the beginning of the grid, if required in case of regeneration
        /// </summary>
        /// <param name="row">Row to be inserted at the beginning</param>
        private void AddRowToStart(Row row)
        {
            List<Row> rowNew = new List<Row>();
            rows.Insert(0, row);            
            numberOfRows++;
        }

        /// <summary>
        /// Adds the given row at the end of the grid, if required in case of regeneration
        /// </summary>
        /// <param name="row">Row to be inserted at the end</param>
        private void AddRowToEnd(Row row)
        {
            rows.Add(row);
            numberOfRows++;
        }

        /// <summary>
        /// Prepares the Grid for next generation
        /// </summary>
        private void PrepareForNextGeneration()
        {
            CheckForAdditionalColumnsAndRows();
            DecideStatusForNextGeneration();
        }

        /// <summary>
        /// This checks if any additional columns and rows are required for regeneration
        /// </summary>
        private void CheckForAdditionalColumnsAndRows()
        {
            //If a new row is needed due to the first row, create a new row and 
            //insert the new row at the beginning
            if (rows[0].IsNewRowNeeded())
            {
                int count = rows[0].GetColumnCount();
                Row row = new Row(count);
                //Set the previous row and current row for the new row
                rows[0].PreviousRow = row;
                row.NextRow = rows[0];
                //Add the new row
                AddRowToStart(row);
            }

            //If a new row is needed due to the last row, create a new row and 
            //insert the new row at the end
            if (rows[numberOfRows - 1].IsNewRowNeeded())
            {
                Row row = new Row(numberOfColumns);
                //Set the previous row and current row for the new row
                row.PreviousRow = rows[numberOfRows - 1];
                rows[numberOfRows - 1].NextRow = row;
                //Add the new row
                AddRowToEnd(row);
            }

            //If a new column is needed at the left, create a new column to the Left
            if (IsNewColumnNeededAtLeft())
            {
                AddNewColumnToLeft();
                numberOfColumns++;
            }

            //If a new column is needed at the right, create a new column to the right
            if (IsNewColumnNeededAtRight())
            {
                AddNewColumnToRight();
                numberOfColumns++;
            }
        }

        /// <summary>
        /// Adds a new column at the right end for each of the row
        /// </summary>
        private void AddNewColumnToRight()
        {
            //Add a new column for each row at t
            for (int i = 0; i < numberOfRows; i++)
                rows[i].AddColumnToRight();
        }

        /// <summary>
        /// Adds a new column at the left end for each of the row
        /// </summary>
        private void AddNewColumnToLeft()
        {
            for (int i = 0; i < numberOfRows; i++)
                rows[i].AddColumnToLeft();
        }


        /// <summary>
        /// This function makes each row decide the status for the next generation
        /// </summary>
        private void DecideStatusForNextGeneration()
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                rows[i].DecideStatusForRow();
            }
        }


        /// <summary>
        /// This checks if any additional columns are required at the Left side of the grid 
        /// in case of regeneration
        /// </summary>
        /// <returns>true if needed and false if not</returns>
        private bool IsNewColumnNeededAtLeft()
        {
            int count = 0;
            for (int i = 0; i < numberOfRows; i++)
            {
                //Checks for 3 continuous living cells. Returns true if found
                count = rows[i].IsCellAlive(0) ? count + 1 : 0;
                if (count >= 3) return true;
            }
            //Returns false if not found
            return false;
        }

        /// <summary>
        /// This checks if any additional columns are required at the Right side of the grid 
        /// in case of regeneration
        /// </summary>
        /// <returns>true if needed and false if not</returns>
        private bool IsNewColumnNeededAtRight()
        {
            int count = 0;
            for (int i = 0; i < numberOfRows; i++)
            {
                //Checks for 3 continuous living cells. Returns true if found
                count = rows[i].IsCellAlive(numberOfColumns - 1) ? count + 1 : 0;                    
                if (count >= 3) return true;
            }
            //Returns false if not found
            return false;
        }


        /// <summary>
        /// This function returns the string representation of the grid
        /// </summary>
        /// <returns>String representation of the grid</returns>
        public override String ToString()
        {
            String gridPattern = "";
            for (int i = 0; i < numberOfRows; i++)
            {
                gridPattern = gridPattern + rows[i].ToString();
            }
            return gridPattern;
        }

        /// <summary>
        /// This function is responsible for preparing and advancing the grid to the next generation
        /// </summary>
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
