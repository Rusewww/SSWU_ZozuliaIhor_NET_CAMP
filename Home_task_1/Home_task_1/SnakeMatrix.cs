using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_1
{
    internal class SnakeMatrix
    {
        private int[,] _matrix;
        private int _n;
        private int _m;
        
        public SnakeMatrix(int n = 3, int m = 4)
        {
            _n = n;
            _m = m;
            _matrix = new int[n, m];
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _m; j++)
                {
                    if (_matrix[i, j] >= 10)
                    {
                        sb.Append(_matrix[i, j] + " ");
                    }
                    else
                    {
                        sb.Append(_matrix[i, j] + "  ");
                    }
                }

                sb.Append("\n");
            }
            return sb.ToString();
        }
        
        public void MakeSnake()
        {
            int[,] directions = { {1, 0}, {0, 1}, {-1, 0}, {0, -1} };  // право, вниз, ліво, вгору
            var currentDirection = 0;
            var currentRow = 0;
            var currentCol = 0;
            var currentValue = 1;
            
            for (var i = 0; i < _n * _m; i++)
            {
                _matrix[currentRow, currentCol] = currentValue;
                currentValue++;

                var nextRow = currentRow + directions[currentDirection, 0];
                var nextCol = currentCol + directions[currentDirection, 1];

                if (nextRow >= 0 && nextRow < _n && nextCol >= 0 && nextCol < _m && _matrix[nextRow, nextCol] == 0)
                {
                    currentRow = nextRow;
                    currentCol = nextCol;
                }
                else
                {
                    currentDirection = (currentDirection + 1) % 4;
                    currentRow += directions[currentDirection, 0];
                    currentCol += directions[currentDirection, 1];
                }
            }
        }
    }
}