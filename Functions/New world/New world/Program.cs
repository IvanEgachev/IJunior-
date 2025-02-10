class Program
{
    private const char Player = '@';
    private const char Block = '#';
    private const char Cleaner = ' ';
    private const char Coin = '0';

    private const ConsoleKey MoveUp = ConsoleKey.UpArrow;
    private const ConsoleKey MoveDown = ConsoleKey.DownArrow;
    private const ConsoleKey MoveLeft = ConsoleKey.LeftArrow;
    private const ConsoleKey MoveRight = ConsoleKey.RightArrow;

    private static void Main(string[] eventArgs)
    {
        Console.CursorVisible = false;

        int playTimeSeconds = 15;
        DateTime endGameTimer = DateTime.Now.AddSeconds(playTimeSeconds);
        TimeSpan delta = new TimeSpan(0, 0, 0, playTimeSeconds);

        char[,] map = new char[,] {
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
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
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
        };

        int playerPositionX;
        int playerPositionY;
        int coinsOnMapCount = GetItemsCount(map, Coin);
        int collectedCoinCount = 0;

        DrawMap(map);
        GetItemPosition(map, out playerPositionX, out playerPositionY, Player);

        while (delta.TotalSeconds > 0 && collectedCoinCount != coinsOnMapCount)
        {
            PlayerInput(map, ref playerPositionX, ref playerPositionY, ref collectedCoinCount);
            UpdateGameStatus(ref delta, endGameTimer, collectedCoinCount, coinsOnMapCount);
        }

        DisplayGameResult(collectedCoinCount, coinsOnMapCount);
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
                    return;
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

    static void PlayerInput(char[,] map, ref int playerPositionX, ref int playerPositionY, ref int collectedCoinCount)
    {
        if (Console.KeyAvailable)
        {
            int playerDirectionX = 0;
            int playerDirectionY = 0;

            ReadDirection(ref playerDirectionX, ref playerDirectionY);

            int newPlayerPositionX = playerPositionX + playerDirectionX;
            int newPlayerPositionY = playerPositionY + playerDirectionY;

            if (map[newPlayerPositionX, newPlayerPositionY] != Block)
            {
                MovePlayer(map, ref playerPositionX, ref playerPositionY, newPlayerPositionX, newPlayerPositionY, ref collectedCoinCount);
            }
        }
    }

    static void MovePlayer(char[,] map, ref int playerPositionX, ref int playerPositionY, int newPlayerPositionX, int newPlayerPositionY, ref int collectedCoinCount)
    {
        OutputToConsole(Cleaner.ToString(), playerPositionY, playerPositionX);

        if (map[newPlayerPositionX, newPlayerPositionY] == Coin)
        {
            collectedCoinCount++;
            map[newPlayerPositionX, newPlayerPositionY] = Cleaner;
        }

        playerPositionX = newPlayerPositionX;
        playerPositionY = newPlayerPositionY;

        OutputToConsole(Player.ToString(), playerPositionY, playerPositionX);
    }

    static void ReadDirection(ref int playerDirectionX, ref int playerDirectionY)
    {
        ConsoleKeyInfo key = Console.ReadKey(true);

        playerDirectionX = 0;
        playerDirectionY = 0;

        switch (key.Key)
        {
            case MoveUp:
                playerDirectionX = -1;
                break;

            case MoveDown:
                playerDirectionX = 1;
                break;

            case MoveLeft:
                playerDirectionY = -1;
                break;

            case MoveRight:
                playerDirectionY = 1;
                break;
        }
    }

    static void UpdateGameStatus(ref TimeSpan delta, DateTime endGameTimer, int collectedCoinCount, int coinsOnMapCount)
    {
        OutputToConsole("Соберите максимальное количество монет за указанное время:", 0, 19);
        OutputToConsole($"Количество монет: {collectedCoinCount}/{coinsOnMapCount}", 0, 20);

        delta = Update(endGameTimer);
        OutputToConsole($"Осталось {delta.Minutes:00}:{delta.Seconds:00}", 0, 21);
    }

    static TimeSpan Update(DateTime endGameTimer)
    {
        return endGameTimer - DateTime.Now;
    }

    static void DisplayGameResult(int collectedCoinCount, int coinsOnMapCount)
    {
        if (collectedCoinCount == coinsOnMapCount)
        {
            OutputToConsole("Вы победили!", 0, 22);
        }
        else
        {
            OutputToConsole("Игра окончена!", 0, 22);
        }
    }

    static void OutputToConsole(string message, int positionY, int positionX)
    {
        Console.SetCursorPosition(positionY, positionX);
        Console.Write(message);
    }
}