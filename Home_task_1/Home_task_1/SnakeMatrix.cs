using System.Text;

namespace Home_task_1
{
    internal class SnakeMatrix
    {
        private int[,] _matrix;
        private int _n;
        private int _m;
        
        public int N
        {
            get { return _n; }
            set
            {
                _n = value > 0 ? value : 1;
            }
        }
        
        public int M
        {
            get { return _m; }
            set
            {
                _m = value > 0 ? value : 1;
            }
        }
        
        public SnakeMatrix(int n = 3, int m = 4)
        {
            N = n;
            M = m;
            _matrix = new int[n, m];
        }
        
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
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
        
        
        //* MakeSnake - метод який заповнює матрицю у вигляді спіральної змійки
        //* direction - змінна яка задає напрям заповнення
        public void MakeSnake(bool direction = true)
        {
            int[,] directions = direction ? new[,]{{1, 0}, {0, 1}, {-1, 0}, {0, -1}} : new [,]{{0, 1}, {1, 0}, {0, -1}, {-1, 0}};

            var currentDirection = 0;
            var currentRow = 0;
            var currentCol = 0;
            var currentValue = 1;
            
            for (var i = 0; i < N * M; i++)
            {
                _matrix[currentRow, currentCol] = currentValue;
                currentValue++;

                var nextRow = currentRow + directions[currentDirection, 0];
                var nextCol = currentCol + directions[currentDirection, 1];

                if (nextRow >= 0 && nextRow < N && nextCol >= 0 && nextCol < M && _matrix[nextRow, nextCol] == 0)
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