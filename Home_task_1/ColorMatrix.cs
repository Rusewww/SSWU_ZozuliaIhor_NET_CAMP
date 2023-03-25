using System.Text;

namespace Home_task_1
{
    internal class ColorMatrix
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

        public ColorMatrix(int n = 5, int m = 5)
        {
            N = n;
            M = m;
            _matrix = new int[N, M];
        }
        
        public ColorMatrix(int[,] matrix)
        {
            N = matrix.GetLength(0);
            M = matrix.GetLength(1);
            _matrix = matrix;
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

        public void FillMatrixRandom()
        {
            var rand = new Random();

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    _matrix[i, j] = rand.Next(0, 17);
                }
            }
        }

        public void FindColor()
        {
            var maxLength = 0;
            var startRow = -1;
            var startCol = -1;
            var endRow = -1;
            var endCol = -1;
            
            for (var i = 0; i < N; i++)
            {
                var currentColor = -1;
                var currentLength = 0;

                for (var j = 0; j < M; j++)
                {
                    if (_matrix[i, j] == currentColor)
                    {
                        currentLength++;

                        if (currentLength > maxLength)
                        {
                            maxLength = currentLength;
                            startRow = i;
                            startCol = j - maxLength + 1;
                            endRow = i;
                            endCol = j;
                        }
                    }
                    else
                    {
                        currentLength = 1;
                        currentColor = _matrix[i, j];
                    }
                }
            }
            Console.Write("Колiр найдовшої горизонтальної лiнiї: {0} \n" +
                          "Iндекс початкової точки: [{1},{2}];\nIндекс кiнцевої точки:[{3},{4}].\n", 
                          _matrix[startRow, startCol], startRow, startCol, endRow, endCol);
        }
    }
}