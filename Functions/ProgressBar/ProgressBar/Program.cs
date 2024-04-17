using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int barMinValue = 0;
        int barMaxValue = 100;

        string healthBarName = "Здоровье";
        string manaBarName = "Мана";

        int healthBarLength = 20;
        int manaBarLength = 35;

        string progressBar;
        int inputProgress;
        int cursorPositionX;
        int cursorPositionY;

        EnterBarData(out inputProgress, out cursorPositionX, out cursorPositionY, barMinValue, barMaxValue);
        progressBar = CreateProgressBar(inputProgress, barMinValue, barMaxValue, healthBarLength);
        OutputProgressBar(healthBarName, progressBar, cursorPositionX, cursorPositionY);

        EnterBarData(out inputProgress, out cursorPositionX, out cursorPositionY, barMinValue, barMaxValue);
        progressBar = CreateProgressBar(inputProgress, barMinValue, barMaxValue, manaBarLength);
        OutputProgressBar(manaBarName, progressBar, cursorPositionX, cursorPositionY);
    }

        static void EnterBarData(out int inputProgress, out int cursorPositionX, out int cursorPositionY, int barMinValue, int barMaxValue)
        {
            bool isNumber;

            Console.Write("Укажите на какой строке расположить бар: ");
            isNumber = int.TryParse(Console.ReadLine(), out cursorPositionY);

            Console.Write("Укажите отступ от начала строки: ");
            isNumber = int.TryParse(Console.ReadLine(), out cursorPositionX);

            Console.Write($"Укажите процент здоровья (от {barMinValue} до {barMaxValue}): ");
            isNumber = int.TryParse(Console.ReadLine(), out inputProgress);
    }

        static string CreateProgressBar(int progress, int barMinValue, int barMaxValue, int barLength)
        {
            char fillElement = '█';
            char emptyElement = '▒';

            float progressPercentage = (float)progress / barMaxValue;

            float filledBarLength = barLength * progressPercentage;
            int emptyBarLength = barLength - (int)filledBarLength;

            string progressBar = string.Format(progress + "% " + new string(fillElement, (int)filledBarLength)
                + new string(emptyElement, emptyBarLength));

            return progressBar;
        }

         static void OutputProgressBar(string barName,string progressBar, int cursorPositionX, int cursorPositionY)
         {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(cursorPositionX, cursorPositionY);

            Console.WriteLine(barName+ ": " + progressBar);

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
         }
}