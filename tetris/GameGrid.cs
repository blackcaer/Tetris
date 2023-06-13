using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Tetris
{
    public class GameGrid
    {
        private readonly int[,] grid;
        public int Rows { get; }
        public int Columns { get; }

        public int this[int r,int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }
        public GameGrid(int rows,int cols)
        {
            Rows = rows;
            Columns = cols;
            grid = new int[rows, cols];

        }
        public bool IsInside(int r,int c)
        {
            return r>= 0 && c >= 0 && c < Columns && r < Rows;
        }
        public bool IsEmpty(int r,int c)
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }
        public bool IsRowFull(int r)
        {
            for (int i=0;i<Rows;i++)
            {
                if (IsEmpty(r,i))
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsRowEmpty(int r)
        {
            for (int i = 0; i < Columns; i++)
            {
                if (!IsEmpty(r, i))
                {
                    return false;
                }
            }
            return true;
        }
        private void ClearRow(int r)
        {
            for (int i = 0; i < Columns; i++)
            {
                grid[r, i] = 0;
            }
            
        }
        private void MoveRowDown(int r,int howMany)
        {
            for (int c = 0;c < Columns;c++)
            {
                grid[r + howMany, c] = grid[r, c];
                grid[r, c] = 0;
            } 
        }

        public int ClearFullRows()
        {
            int cleared = 0;
            for (int r=Rows-1;r>=0;r--)
            {
                if (IsRowEmpty(r))
                {
                    break;
                }
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }else if (cleared>0)
                {
                    MoveRowDown(r, cleared);
                }
            }
            return cleared;
        }
    }
}
