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
                    sb.Append(_matrix[i, j] + " ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
        
        public void MakeSnake()
        {
            int[,] directions = { {1, 0}, {0, 1}, {-1, 0}, {0, -1} };  // право, вниз, ліво, вгору
            int current_direction = 0;
            int current_row = 0;
            int current_col = 0;
            int current_value = 1;
            
            for (int i = 0; i < _n * _m; i++)
            {
                _matrix[current_row, current_col] = current_value;
                current_value++;

                int next_row = current_row + directions[current_direction, 0];
                int next_col = current_col + directions[current_direction, 1];

                if (next_row >= 0 && next_row < _n && next_col >= 0 && next_col < _m && _matrix[next_row, next_col] == 0)
                {
                    current_row = next_row;
                    current_col = next_col;
                }
                else
                {
                    current_direction = (current_direction + 1) % 4;
                    current_row += directions[current_direction, 0];
                    current_col += directions[current_direction, 1];
                }
            }
        }
    }
}