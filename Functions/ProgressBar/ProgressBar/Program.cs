using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string healthBarName = "Здоровье";
        int healthBarProgress = 0;
        int healthBarLength = 0;

        Console.Write($"Укажите процент здоровья: ");
        healthBarProgress = ReadInt();

        Console.Write($"Укажите длину бара: ");
        healthBarLength = ReadInt();

        DrawBar(healthBarName, healthBarProgress, healthBarLength);

        string manaBarName = "Мана";
        int manaBarProgress = 0;
        int manaBarLength = 0;

        Console.Write($"Укажите процент маны: ");
        manaBarProgress = ReadInt();

        Console.Write($"Укажите длину бара: ");
        manaBarLength = ReadInt();

        DrawBar(manaBarName, manaBarProgress, manaBarLength);
    }

    static void DrawBar(string barName, int barProgress, int barLength)
    {
        int maxPercentage = 100;
        int minPercentage = 0;
        int minbarLength = 1;

        barProgress = Math.Clamp(barProgress, minPercentage, maxPercentage);
        barLength = Math.Clamp(barLength, minbarLength, int.MaxValue);

        char fillElement = '█';
        char emptyElement = '▒';

        float filledBarLength = barLength * barProgress / maxPercentage;
        int emptyBarLength = barLength - (int)filledBarLength;

        string progressBar = string.Format(barProgress + "% " + new string(fillElement, (int)filledBarLength)
            + new string(emptyElement, emptyBarLength));

        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine(barName + ": " + progressBar);

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
    }

    static int ReadInt()
    {
        int number;

        while (int.TryParse(Console.ReadLine(), out number) == false )
        {
            Console.WriteLine("Это не число!");
        }

        return number;
    }
}