 class Program
{
    private static void Main(string[] eventArgs)
    {
        Console.CursorVisible = false;

        int playTimeSeconds = 15;
        DateTime endGameTimer = DateTime.Now.AddSeconds(playTimeSeconds);
        TimeSpan delta = new TimeSpan(0, 0, 0, playTimeSeconds);

        char[,] map = new char[,] { { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                                    { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '0', ' ', ' ', ' ',' ', ' ', ' ', '#',},
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

        int playerPositionX;
        int playerPositionY;

        int playerDirectionX = 0;
        int playerDirectionY = 0;

        int playerShiftX = 0;
        int playerShiftY = 0;

        int coinsOnMapCount = GetItemsCount(map, coin);
        int collectedCoinCount = 0;

        DrawMap(map);
        GetItemPosition(map, out playerPositionX, out playerPositionY, player);

        while (delta.TotalSeconds > 0 && collectedCoinCount != coinsOnMapCount)
        {
            if (Console.KeyAvailable)
            {
                ChangeDirection(ref playerDirectionX, ref playerDirectionY);
                ChangeShift(ref playerShiftX, ref playerShiftY, playerPositionX, playerDirectionX, playerPositionY, playerDirectionY);

                if (map[playerShiftX, playerShiftY] != block)
                {
                    OutputToConsole(Convert.ToString(cleaner), playerPositionY, playerPositionX);

                    if (map[playerShiftX, playerShiftY] == coin)
                    {
                        collectedCoinCount++;
                        map[playerShiftX, playerShiftY] = cleaner;
                    }

                    ChangePosition(ref playerPositionX, ref playerPositionY, playerDirectionX, playerDirectionY);

                    OutputToConsole(player.ToString(), playerShiftY, playerShiftX);
                }
            }

            OutputToConsole("Соберите максимальное количеество монет за указанное время:", 0, 19);
            OutputToConsole($"Количество монет: {collectedCoinCount}/{coinsOnMapCount}", 0, 20);

            delta = Update(endGameTimer);
            OutputToConsole($"Осталось {delta.Minutes:00}:{delta.Seconds:00}", 0, 21);
        }

        if (collectedCoinCount == coinsOnMapCount)
        {
            OutputToConsole("Вы победили!", 0, 22);
        }
        else
        {
            OutputToConsole("Игра окончена!", 0, 22);
        }
        
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

    static void ChangeDirection(ref int playerDirectionX, ref int playerDirectionY )
    {
        ConsoleKeyInfo key = Console.ReadKey(true);

        const ConsoleKey up = ConsoleKey.UpArrow;
        const ConsoleKey down = ConsoleKey.DownArrow;
        const ConsoleKey left = ConsoleKey.LeftArrow;
        const ConsoleKey right = ConsoleKey.RightArrow;

        playerDirectionX = 0;
        playerDirectionY = 0;

        switch (key.Key)
        {
            case up:
                playerDirectionX = -1;
                break;

            case down:
                playerDirectionX = 1;
                break;

            case left:
                playerDirectionY = -1;
                break;

            case right:
                playerDirectionY = 1;
                break;
        }
    }

    static void ChangeShift(ref int playerShiftX, ref int playerShiftY, int playerPositionX, int playerDirectionX,
                            int playerPositionY, int playerDirectionY)
    {
        playerShiftX = playerPositionX + playerDirectionX;
        playerShiftY = playerPositionY + playerDirectionY;
    }

    static void ChangePosition(ref int playerPositionX, ref int playerPositionY, int playerDirectionX, int playerDirectionY)
    {
        playerPositionX += playerDirectionX;
        playerPositionY += playerDirectionY;
    }

    static TimeSpan Update(DateTime endGameTimer)
    {
        return endGameTimer - DateTime.Now;
    }

    static void OutputToConsole(string message, int positionY, int positionX)
    {
        Console.SetCursorPosition(positionY, positionX);
        Console.Write(message);
    }
}

