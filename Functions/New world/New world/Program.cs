internal partial class Program
{
    private static void Main(string[] eventArgs)
    {
        Console.CursorVisible = false;

        int playTime = 15;
        DateTime timerEnd = DateTime.Now.AddSeconds(playTime);
        TimeSpan delta = new TimeSpan(0, 0, 0, playTime);

        char[,] map = new char[,] { { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                                    { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', '#',},
                                    { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ',' ', ' ', '#', '#',},
                                    { '#', '#', '#', '#', ' ', ' ', ' ', '0', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ',' ', '#', ' ', '#',},
                                    { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '0', ' ',' ', '#', ' ', '#',},
                                    { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ',' ', ' ', '#', '#',},
                                    { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', '#',},
                                    { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '@', ' ', ' ', ' ', ' ', '#', '#', '#','#', ' ', ' ', '#',},
                                    { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', '#',},
                                    { '#', ' ', '#', '0', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', '#',},
                                    { '#', ' ', ' ', ' ', ' ', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', '#',},
                                    { '#', ' ', ' ', ' ', ' ', '#', '0', '#', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ',' ', ' ', ' ', '#',},
                                    { '#', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ',' ', ' ', ' ', '#',},
                                    { '#', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ',' ', ' ', ' ', '#',},
                                    { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}, };

        char player = '@';
        char block = '#';
        char cleaner = ' ';
        char coin = '0';

        int playerX;
        int playerY;

        int playerDX = 0;
        int playerDY = 0;

        int playerShiftX;
        int playerShiftY;

        int coinsOnMapCount = GetItemsCount(map, coin);
        int collectedCoinCount = 0;

        DrawMap(map);
        GetItemPosition(map, out playerX, out playerY, player);

        while (delta.TotalSeconds > 0 && collectedcoinCount != coinsOnMapCount)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        playerDX = -1;
                        playerDY = 0;
                        break;
                    case ConsoleKey.DownArrow:
                        playerDX = 1;
                        playerDY = 0;
                        break;
                    case ConsoleKey.LeftArrow:
                        playerDX = 0;
                        playerDY = -1;
                        break;
                    case ConsoleKey.RightArrow:
                        playerDX = 0;
                        playerDY = 1;
                        break;
                    default:
                        break;
                }

                playerShiftX = playerX + playerDX;
                playerShiftY = playerY + playerDY;

                if (map[playerShiftX, playerShiftY] != block)
                {
                    ConsoleOutput(Convert.ToString(cleaner), playerY, playerX);

                    if (map[playerShiftX, playerShiftY] == coin)
                    {
                        collectedcoinCount++;
                        map[playerShiftX, playerShiftY] = cleaner;
                    }

                    playerX += playerDX;
                    playerY += playerDY;

                    ConsoleOutput(player.ToString(), playerY, playerX);
                }
            }

            ConsoleOutput("Соберите максимальное количеество монет за указанное время:", 0, 19);
            ConsoleOutput($"Количество монет: {collectedcoinCount}/{coinsOnMapCount}", 0, 20);

            delta = Update(delta, timerEnd);
            ConsoleOutput($"Осталось {delta.Minutes.ToString("00")}:{delta.Seconds.ToString("00")}", 0, 21);
        }

        ConsoleOutput("Игра окончена!", 0, 22);
        Console.ReadKey();
    }

    static void DrawMap(char[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                Console.Write(map[i, j]);
            }

            Console.WriteLine();
        }
    }

    static void GetItemPosition(char[,] map, out int positionX, out int positionY, char item)
    {
        positionX = 0;
        positionY = 0;

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j] == item)
                {
                    positionX = i;
                    positionY = j;
                }
            }
        }
    }

    static int GetItemsCount(char[,] map, char item)
    {
        int itemCount = 0;

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j] == item)
                {
                    itemCount++;
                }
            }
        }

        return itemCount;
    }

    static TimeSpan Update(TimeSpan delta, DateTime timerEnd)
    {
        delta = timerEnd - DateTime.Now;
        return delta;
    }

    static void ConsoleOutput(string message, int positionY, int positionX)
    {
        Console.SetCursorPosition(positionY, positionX);
        Console.Write(message);
    }
}

