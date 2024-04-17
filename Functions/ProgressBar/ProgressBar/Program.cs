using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int barMinValue = 0;
        int barMaxValue = 100;

        string healthBarName = "Здоровье";
        string manaName = "Мана";

        string progressBar;
        int inputProgress;
        int cursorPositionX;
        int cursorPositionY;

        InputBarData(out inputProgress, out cursorPositionX, out cursorPositionY, barMinValue, barMaxValue);
        progressBar = CreateProgressBar(inputProgress,cursorPositionX, barMinValue, barMaxValue);
        OutputProgressBar(healthBarName, progressBar, cursorPositionX, cursorPositionY);

        InputBarData(out inputProgress, out cursorPositionX, out cursorPositionY, barMinValue, barMaxValue);
        progressBar = CreateProgressBar(inputProgress, cursorPositionX, barMinValue, barMaxValue);
        OutputProgressBar(manaName, progressBar, cursorPositionX, cursorPositionY);
    }

        static void InputBarData(out int inputProgress, out int cursorPositionX, out int cursorPositionY, int barMinValue, int barMaxValue)
        {
            Console.Write("Укажите на какой строке расположить бар: ");
            cursorPositionY = Convert.ToInt32(Console.ReadLine());

            Console.Write("Укажите отступ от начала строки: ");
            cursorPositionX = Convert.ToInt32(Console.ReadLine());

            Console.Write($"Укажите процент здоровья (от {barMinValue} до {barMaxValue}): ");
            inputProgress = Convert.ToInt32(Console.ReadLine());
        }

        static string CreateProgressBar(int progress, int cursorPositionX, int barMinValue, int barMaxValue)
        {
            char fillElement = '█';
            char emptyElement = '▒';

            int barLength = (barMaxValue - barMinValue) - cursorPositionX;

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