Console.WindowHeight = 30;
Console.WindowWidth = 30;
Console.BufferHeight = 60;
Console.BufferWidth = 60;

int x = Console.WindowWidth / 2;
int y = Console.WindowHeight / 2;

Console.CursorVisible = false;

List<int> snakeX = new List<int>();
List<int> snakeY = new List<int>();

snakeX.Add(x);
snakeY.Add(y);

Random random = new Random();
int foodX = random.Next(0, Console.WindowWidth);
int foodY = random.Next(0, Console.WindowHeight);

int direction = 0; // 0 = right, 1 = down, 2 = left, 3 = up
ConsoleKeyInfo keyInfo;

while (true)
{
    Console.Clear();

    Console.SetCursorPosition(foodX, foodY);
    Console.WriteLine("F");

    for (int i = 0; i < snakeX.Count; i++)
    {
        Console.SetCursorPosition(snakeX[i], snakeY[i]);
        Console.WriteLine("*");
    }

    if (Console.KeyAvailable)
    {
        keyInfo = Console.ReadKey();

        if (keyInfo.Key == ConsoleKey.LeftArrow && direction != 0)
        {
            direction = 2;
        }
        else if (keyInfo.Key == ConsoleKey.RightArrow && direction != 2)
        {
            direction = 0;
        }
        else if (keyInfo.Key == ConsoleKey.UpArrow && direction != 1)
        {
            direction = 3;
        }
        else if (keyInfo.Key == ConsoleKey.DownArrow && direction != 3)
        {
            direction = 1;
        }
    }

    switch (direction)
    {
        case 0:
            x++;
            break;
        case 1:
            y++;
            break;
        case 2:
            x--;
            break;
        case 3:
            y--;
            break;
    }

    snakeX.Insert(0, x);
    snakeY.Insert(0, y);

    if (x == foodX && y == foodY)
    {
        snakeX.Add(snakeX[snakeX.Count - 1]);
        snakeY.Add(snakeY[snakeY.Count - 1]);

        foodX = random.Next(0, Console.WindowWidth);
        foodY = random.Next(0, Console.WindowHeight);
    }
    else
    {
        snakeX.RemoveAt(snakeX.Count - 1);
        snakeY.RemoveAt(snakeY.Count - 1);
    }

    Thread.Sleep(100);
}