using System;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        int maxPercentage = 100;
        int minPercentage = 0;

        string healthBarName = "Здоровье";
        int healthBarProgress = 0;
        int healthBarLength = 0;

        string manaBarName = "Мана";
        int manaBarProgress = 0;
        int manaBarLength = 0;

        Console.Write($"Укажите процент здоровья (от {minPercentage} до {maxPercentage}): ");
        healthBarProgress = EnterPercentage(maxPercentage, minPercentage);

        Console.Write($"Укажите длину: ");
        healthBarLength = EnterLength();

        DrawBar(healthBarName, healthBarProgress, healthBarLength);

        Console.Write($"Укажите процент маны (от {minPercentage} до {maxPercentage}): ");
        manaBarProgress = EnterPercentage(maxPercentage, minPercentage);

        Console.Write($"Укажите длину: ");
        manaBarLength = EnterLength();
        
        DrawBar(manaBarName, manaBarProgress, manaBarLength);
    }

    static void DrawBar(string barName, int barProgress, int barLength)
    {
        int maxPercentage = 100;

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

    static int EnterPercentage(int maxPercentage, int minPercentage)
    {
        int percentage = int.MinValue;

        bool isExit = false; 

        while (isExit == false)
        {
            percentage = ReadInt();

            if (percentage <= maxPercentage && percentage >= minPercentage)
            {
                isExit = true;
            }
            else
            {
                Console.WriteLine("Значение вне допустимого диапазона");
            }
        }

        return percentage;
    }

    static int EnterLength()
    {
        int length = int.MinValue;
        int minLenth = 1;

        bool isExit = false;

        while (isExit == false)
        {
            length = ReadInt();

            if (length >= minLenth)
            {
                isExit = true;
            }
            else
            {
                Console.WriteLine("Длина не может быть отрицательной");
            }
        }

        return length;
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