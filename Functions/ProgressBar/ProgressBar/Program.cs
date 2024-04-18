using System;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        string healthBarName = "Здоровье";
        string manaBarName = "Мана";

        DrawBar(healthBarName);
        DrawBar(manaBarName);
    }

    static void DrawBar(string barName)
    {
        int maxPercentage = 100;
        int minPercentage = 0;

        int minbarLength = 1;

        int barProgress = 0;
        int barLength = 0;

        Console.Write($"Укажите процент {barName} (от {minPercentage} до {maxPercentage}): ");
        barProgress = Math.Clamp(ReadInt(),minPercentage, maxPercentage);

        Console.Write($"Укажите длину: ");
        barLength = Math.Clamp(ReadInt(), minbarLength, int.MaxValue);

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