using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    internal class ColorMatrix
    {
        private int[,] _matrix;
        private int _n;
        private int _m;

        public int[,] Matrix
        {
            get { return _matrix; }
            set { _matrix = value; }
        }

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

        public (int startRow, int startCol, int Length) FindColor()
        {
            var maxLength = 0;
            var startRow = -1;
            var startCol = -1;

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
                        }
                    }
                    else
                    {
                        currentLength = 1;
                        currentColor = _matrix[i, j];
                    }
                }
            }
            return (startRow, startCol, maxLength);
        }
    }
}
