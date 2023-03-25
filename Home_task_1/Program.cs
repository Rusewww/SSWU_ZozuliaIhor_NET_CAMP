// See https://aka.ms/new-console-template for more information
using Home_task_1;

/*SnakeMatrix snake = new SnakeMatrix();
snake.MakeSnake();
Console.Write(snake.ToString());*/

int[,] matrix =
{
    {
        1, 2, 3, 4
    },
    {
        2, 2, 2, 3
    },
    {
        3, 2, 2, 1
    },
    {
        4, 4, 4, 2
    }
};
ColorMatrix colorMatrix = new ColorMatrix(matrix);
Console.Write(colorMatrix.ToString());
colorMatrix.FindColor();
