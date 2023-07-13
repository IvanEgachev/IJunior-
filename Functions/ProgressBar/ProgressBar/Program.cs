int cursorTopPosition; 
int cursorLeftPosition;

Console.Write("Укажите на какой строке расположить бар: ");
cursorTopPosition = Convert.ToInt32(Console.ReadLine());

Console.Write("Укажите отступ от начала строки: ");
cursorLeftPosition = Convert.ToInt32(Console.ReadLine());

Console.Write("Укажите процент заполненности бара (от 0 до 100): ");
int inputProgress = Convert.ToInt32(Console.ReadLine());

Progressbar(inputProgress, cursorLeftPosition, cursorTopPosition);

static void Progressbar(int inputProgress, int cursorLeftPosition, int cursorTopPosition)
{
    char blackBlock = '█';
    char ligthBlock = '▒';

    int progressBarLength = 100;

    float progressPercentage = (float)inputProgress / 100;
    float inputProgressLength = progressBarLength * progressPercentage;

    int progressBarOutputLength = (progressBarLength - (int)inputProgressLength);

    Console.ForegroundColor = ConsoleColor.Red;
    Console.SetCursorPosition(cursorLeftPosition, cursorTopPosition);

    string progressBarOutput = string.Format(inputProgress + "% "+ new string(blackBlock, (int)inputProgressLength) 
        + new string(ligthBlock, progressBarOutputLength));

    Console.WriteLine("Прогресс: " + progressBarOutput);

    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.Black;
}