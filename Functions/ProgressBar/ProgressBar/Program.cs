using System;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        string healthBarName = "Здоровье";
        int healthBarProgress = 0;
        int healthBarLength = 0;

        string manaBarName = "Мана";
        int manaBarProgress = 0;
        int manaBarLength = 0;

        Console.Write($"Укажите процент здоровья: ");
        healthBarProgress = ReadInt();

        Console.Write($"Укажите длину: ");
        healthBarLength = ReadInt();

        DrawBar(healthBarName, healthBarProgress, healthBarLength);

        Console.Write($"Укажите процент маны: ");
        manaBarProgress = ReadInt();

        Console.Write($"Укажите длину: ");
        manaBarLength = ReadInt();
        
        DrawBar(manaBarName, manaBarProgress, manaBarLength);
    }

    static void DrawBar(string barName, int barProgress, int barLength)
    {
        char fillElement = '█';
        char emptyElement = '▒';

        float filledBarLength = barLength * barProgress / 100;
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

        while (int.TryParse(Console.ReadLine(), out number) == false)
        {
            Console.WriteLine("Это не число!");
        }

        return number;
    }
}