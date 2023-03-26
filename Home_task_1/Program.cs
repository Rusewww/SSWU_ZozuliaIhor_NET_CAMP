using Home_task_1;

Task_1_1();
Task_1_2();

static void Task_1_1()
{
    Console.WriteLine("|============TASK_1_1============|");
    var snake = new SnakeMatrix();
    snake.MakeSnake();
    Console.Write(snake.ToString());
    Console.WriteLine("|================================|");
}

static void Task_1_2()
{
    Console.WriteLine("|============TASK_1_2============|");
    /*int[,] matrix = {{1, 2, 3, 4}, {2, 2, 2, 3}, {3, 2, 2, 1}, {4, 4, 4, 2}};
    ColorMatrix colorMatrix = new ColorMatrix(matrix);*/
    var colorMatrix = new ColorMatrix(5, 5);
    colorMatrix.FillMatrixRandom();
    Console.Write(colorMatrix.ToString());
    colorMatrix.FindColor();
    Console.WriteLine("|================================|");
}

