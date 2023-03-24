// See https://aka.ms/new-console-template for more information

using Home_task_1;

SnakeMatrix snake = new SnakeMatrix(5, 5);
snake.MakeSnake(true);
Console.Write(snake.ToString());
