using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOfLifeWebApplication.Models
{
    public class Grid
    {
        public bool[,] grid;
        public int generation = 0;

        public Grid(int rows, int columns)
        {
            this.grid = new bool[rows, columns];

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    this.grid[i, j] = false;
                }
            }
        }

        public static bool[,] GameLogic(bool[,] grid)
        {
            List<string> neighbors = new List<string>();
            bool[,] newgrid = new bool[3, 3];
            for(int i = 1; i < grid.GetLength(0) - 1; i++)
            {
                for(int j = 1; j < grid.GetLength(1) - 1; j++)
                {
                    int count = 0;
                    neighbors.Add(grid[i - 1,j - 1].ToString());
                    neighbors.Add(grid[i -1,j].ToString());
                    neighbors.Add(grid[i -1,j + 1].ToString());
                    neighbors.Add(grid[i,j - 1].ToString());
                    neighbors.Add(grid[i,j + 1].ToString());
                    neighbors.Add(grid[i + 1,j -1].ToString());
                    neighbors.Add(grid[i + 1,j].ToString());
                    neighbors.Add(grid[i + 1,j + 1].ToString());
                    foreach(string s in neighbors)
                    {
                        if(s == "True")
                        {
                            count++;
                        }
                    }
                    neighbors.Clear();
                    if (count <= 1 && grid[i, j] == true)
                    {
                        newgrid[i - 1, j - 1] = false;
                    }
                    if(count == 2 && grid[i,j] == false)
                    {
                        newgrid[i - 1, j - 1] = false;
                    }
                    if (count == 2 || count == 3 && grid[i, j] == true)
                    {
                        newgrid[i - 1, j - 1] = true;
                    }
                    if (count == 3 && grid[i,j] == false)
                    {
                        newgrid[i - 1, j - 1] = true;
                    }  
                    if(count >= 4 && grid[i, j] == true)
                    {
                        newgrid[i -1 , j -1] = false;
                    }
                }
            }
            foreach (var v in newgrid)
            {
                Console.Write(v);
            }
            return newgrid;
        }
    }
}