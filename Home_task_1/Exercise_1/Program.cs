﻿// See https://aka.ms/new-console-template for more information

namespace Exercise_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("|============STANDART_MATRIX============|");
            var snake = new SnakeMatrix();
            snake.MakeSnake();
            Console.Write(snake.ToString());
            Console.WriteLine("|=============REVERT_MATRIX=============|");
            var snakeRevert = new SnakeMatrix();
            snakeRevert.MakeSnake(false);
            Console.Write(snakeRevert.ToString());
            Console.WriteLine("|=======================================|");
        }
    }
}