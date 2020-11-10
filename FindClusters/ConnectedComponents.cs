using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace FindClusters
{
    public class ConnectedComponents
    {
        private readonly int columns;
        private readonly int rows;
        private readonly int[,] grid;
        private readonly bool[,] visited;
        private int connectedComponents;
        private int componentSize;
        private int maxNum;

        public ConnectedComponents(int columns, int rows, int[,] grid, int maxnUm)
        {
            this.columns = columns;
            this.rows = rows;
            this.grid = grid;
            visited = new bool[rows, columns];
            connectedComponents = 0;
            componentSize = 1;
            maxNum = maxnUm;
        }

        private bool isSafe(int currRow, int currCol, int value)
        {
            return (currRow >= 0 && currRow < rows) &&
                   (currCol >= 0 && currCol < columns) &&
                   (grid[currRow, currCol] == value &&
                   !visited[currRow, currCol]);
        }

        private void DepthFirstSearch(int currRow, int currCol, int value)
        {
            int[] rowNbr = { -1, 1, 0, 0 };
            int[] colNbr = { 0, 0, 1, -1 };

            visited[currRow, currCol] = true;

            for (int k = 0; k < 4; k++)
            {
                if (isSafe(currRow + rowNbr[k], currCol + colNbr[k], value))
                {
                    ++componentSize;
                    DepthFirstSearch(currRow + rowNbr[k], currCol + colNbr[k], value);
                }
            }
            grid[currRow, currCol] = 0;
        }

        private void DropColDown(int cCol)
        {
            int rowIndex = rows - 1; 
            while (rowIndex >=0)
            {
                if(grid[rowIndex, cCol] != 0)
                {
                    --rowIndex;
                    continue;
                }

                for(int i = rowIndex -1; i >=0; i--)
                {
                    if(grid[i, cCol] > 0)
                    {
                        grid[rowIndex, cCol] = grid[i, cCol];
                        grid[i, cCol] = 0;
                        visited[rowIndex, cCol] = false;
                        visited[i, cCol] = true;
                        break;
                    }
                }

                --rowIndex;
            }
        }

        private void FallDown()
        {
            for (int col = 0; col < columns; col++)
            {
               DropColDown(col);
            }

        }

        private void DisplayGrid()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{grid[i, j]} ");
                }
                Console.WriteLine("");
                
            }
            Console.WriteLine("---------------------------");
        }

        public int Do()
        {
            int result = 0;
            while (maxNum > 0)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (!visited[i, j] & grid[i, j] == maxNum)
                        {
                            DepthFirstSearch(i, j, grid[i, j]);
                            result += 1 * componentSize * componentSize;
                            componentSize = 1;
                        }
                        
                    }
                }
                DisplayGrid();
                FallDown();
                DisplayGrid();
                --maxNum;
            }

            return result;
        }
    }
}
