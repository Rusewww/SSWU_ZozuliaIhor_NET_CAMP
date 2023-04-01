using System;
using System.Collections.Generic;
using Exercise_3;

class Program
{
    static void Main(string[] args)
    {
        int[,,] cube = new int[,,]
        {
            {
                {1, 1, 1},
                {0, 0, 0},
                {1, 1, 1}
            },

            {
                {1, 1, 1},
                {1, 1, 1},
                {1, 1, 1}
            },
            {
                {1, 1, 1},
                {1, 1, 1},
                {0, 1, 0}
            }
        };
        var res = new HoleCube(cube);
        Console.WriteLine(res.FindHoles());
    }
}