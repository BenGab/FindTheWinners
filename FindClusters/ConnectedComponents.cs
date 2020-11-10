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

        public ConnectedComponents(int columns, int rows, int[,] grid)
        {
            this.columns = columns;
            this.rows = rows;
            this.grid = grid;
            visited = new bool[rows, columns];
            connectedComponents = 0;
            componentSize = 1;
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
                if(isSafe(currRow + rowNbr[k], currCol + colNbr[k], value))
                {
                    ++componentSize;
                    DepthFirstSearch(currRow + rowNbr[k], currCol + colNbr[k], value);
                }
            }
        }

        public int Do()
        {
            int result = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (!visited[i, j])
                    {
                        DepthFirstSearch(i, j, grid[i, j]);
                        result += 1 * componentSize * componentSize;
                        componentSize = 1;
                    }
                }
            }

            return result;
        }
    }
}
