using System.Collections;

namespace Exercise_1
{
    public class SpiralMatrix : IEnumerable<int>
    {
        private int[,] _matrix;

        public SpiralMatrix(int[,] matrix)
        {
            this._matrix = (int[,])matrix.Clone();
        }

        public IEnumerator<int> GetEnumerator()
        {
            int size = _matrix.GetLength(0);
            int row = 0, col = 0;
            yield return _matrix[row, col];
            for (int i = 0; i < size * size - 1; i++)
            {
                if ((row + col) % 2 == 0)
                {
                    if (col == size - 1)
                    {
                        row++;
                    }
                    else if (row == 0)
                    {
                        col++;
                    }
                    else
                    {
                        row--;
                        col++;
                    }
                }
                else
                {
                    if (row == size - 1)
                    {
                        col++;
                    }
                    else if (col == 0)
                    {
                        row++;
                    }
                    else
                    {
                        row++;
                        col--;
                    }
                }
                yield return _matrix[row, col];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}