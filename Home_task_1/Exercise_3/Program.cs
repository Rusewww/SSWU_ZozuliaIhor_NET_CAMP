using System;
using System.Collections.Generic;

namespace Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] cube = new int[,,]
            {
                {
                    {1, 1, 1, 1},
                    {1, 1, 1, 1},
                    {1, 1, 1, 1},
                    {1, 1, 1, 1}
                },

                {
                    {1, 1, 1, 1},
                    {0, 0, 0, 0},
                    {1, 1, 1, 1},
                    {1, 1, 1, 1}
                },
                {
                    {1, 1, 1, 1},
                    {1, 1, 1, 1},
                    {1, 1, 1, 1},
                    {1, 1, 1, 1}
                },
                {
                    {1, 1, 1, 1},
                    {1, 1, 1, 1},
                    {1, 1, 1, 1},
                    {0, 1, 1, 0}
                }
            };
            var holeCube = new HoleCube(cube);
            var result = holeCube.FindHoles();
            for (int i = 0; i < result.Count; i += 2)
            {
                Console.WriteLine($"Отвiр {i / 2 + 1}");
                Console.WriteLine($"Початок: ({result[i].Item1}, {result[i].Item2}, {result[i].Item3})");
                Console.WriteLine($"Кiнець: ({result[i + 1].Item1}, {result[i + 1].Item2}, {result[i + 1].Item3})");
            }
        }
    }
}