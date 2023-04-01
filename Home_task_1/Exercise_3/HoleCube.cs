using System.Text;

namespace Exercise_3
{
    public class HoleCube
    {
        int[,,] _cube;
        int _size;

        public HoleCube(int[,,] cube)
        {
            this._cube = cube;
            this._size = cube.GetLength(0);
        }

        //Функія FindHoles дозволяє нам знайти декілька наскірзних отворів у кубі, якщо вони існують
        public List<(int, int, int)> FindHoles()
        {
            List<(int, int, int)> holes = new List<(int, int, int)>();
            int[,,] visited = new int[_size, _size, _size];
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    for (int k = 0; k < _size; k++)
                    {
                        if (_cube[i, j, k] == 0 && visited[i, j, k] == 0)
                        {
                            //Починаємо пошук отвору
                            Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
                            queue.Enqueue(Tuple.Create(i, j, k));
                            visited[i, j, k] = 1;
                            int x1 = i, y1 = j, z1 = k, x2 = i, y2 = j, z2 = k;

                            while (queue.Count > 0)
                            {
                                Tuple<int, int, int> current = queue.Dequeue();
                                int x = current.Item1;
                                int y = current.Item2;
                                int z = current.Item3;

                                if (x < x1) x1 = x;
                                if (x > x2) x2 = x;
                                if (y < y1) y1 = y;
                                if (y > y2) y2 = y;
                                if (z < z1) z1 = z;
                                if (z > z2) z2 = z;

                                //Перевіряємо сусідніх клітин
                                foreach (Tuple<int, int, int> neighbor in GetNeighbors(x, y, z))
                                {
                                    int nx = neighbor.Item1;
                                    int ny = neighbor.Item2;
                                    int nz = neighbor.Item3;

                                    if (nx < 0 || ny < 0 || nz < 0 || nx >= _cube.GetLength(0) ||
                                        ny >= _cube.GetLength(1) || nz >= _cube.GetLength(2))
                                    {
                                        //Сусідня клітина знаходиться за межами куба
                                        continue;
                                    }

                                    if (_cube[nx, ny, nz] == 0 && visited[nx, ny, nz] == 0)
                                    {
                                        //Знайдено вільну клітину
                                        visited[nx, ny, nz] = 1;
                                        queue.Enqueue(Tuple.Create(nx, ny, nz));
                                    }
                                }
                            }
                            
                            if (((x2 - x1 == _size - 1) || (y2 - y1 == _size - 1) || (z2 - z1 == _size - 1)))
                            {
                                // знайдено отвір
                                holes.Add((x1, y1, z1));
                                holes.Add((x2, y2, z2));
                            }
                        }
                    }
                }
            }

            return holes;
        }

        private List<Tuple<int, int, int>> GetNeighbors(int x, int y, int z)
        {
            List<Tuple<int, int, int>> neighbors = new List<Tuple<int, int, int>>();
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    for (int k = -1; k <= 1; k++)
                    {
                        if (i == 0 && j == 0 && k == 0) //Якщо це та сама вершина, пропускаємо
                            continue;
                        int nx = x + i;
                        int ny = y + j;
                        int nz = z + k;

                        //Перевіряємо, щоб не вийти за межі масиву
                        if (nx >= 0 && ny >= 0 && nz >= 0 && nx < _size && ny < _size && nz < _size)
                        {
                            neighbors.Add(Tuple.Create(nx, ny, nz));
                        }
                    }
                }
            }

            return neighbors;
        }
    }
}
