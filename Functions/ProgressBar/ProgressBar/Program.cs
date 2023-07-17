Console.Write("Укажите на какой строке расположить бар: ");
int cursorPositionY = Convert.ToInt32(Console.ReadLine());

Console.Write("Укажите отступ от начала строки: ");
int cursorPositionX = Convert.ToInt32(Console.ReadLine());

int barMinValue = 0;
int barMaxValue = 100;

Console.Write($"Укажите процент заполненности бара (от {barMinValue} до {barMaxValue}): ");
int inputProgress = Convert.ToInt32(Console.ReadLine());

if (inputProgress >= barMinValue && inputProgress <= barMaxValue)
{
    CreateProgressBar(inputProgress, cursorPositionX, cursorPositionY, barMinValue, barMaxValue);
}
else
{
    Console.Write($"Ошибка! Указанное значение за пределами диапазона (от {barMinValue} до {barMaxValue})");
}

static void CreateProgressBar(int progress, int cursorPositionX, int cursorPositionY, int barMinValue, int barMaxValue)
{
    char fillElement = '█';
    char emptyElement = '▒';

    int barLength = barMaxValue - barMinValue;

    int hundredthOfNumber = 100;
    float progressPercentage = (float)progress / hundredthOfNumber;

    float filledBarLength = barLength * progressPercentage;
    int emptyBarLength = barLength - (int)filledBarLength;

    Console.ForegroundColor = ConsoleColor.Red;
    Console.SetCursorPosition(cursorPositionX, cursorPositionY);

    string progressBar = string.Format(progress + "% "+ new string(fillElement, (int)filledBarLength) 
        + new string(emptyElement, emptyBarLength));

    Console.WriteLine("Прогресс: " + progressBar);

    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.Black;
}