using System.Drawing;

const string AddSubstractCommand = "1";
const string MultiplicationTableCommand = "2";
const string ComparisonCommand = "3";
const string ExitCommand = "4";

Random random = new Random();

bool isRunning = true;

while(isRunning == true)
{
    Console.WriteLine("Математика для начинающих. \nГлавное меню.");

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"{AddSubstractCommand}. Сложение/Вычитание");

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"{MultiplicationTableCommand}. Таблица умножения");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"{ComparisonCommand}. Сравнения");

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"{ExitCommand}. Завершить работу.");

    Console.ForegroundColor = ConsoleColor.White;

    string command =  Console.ReadLine();

    switch (command)
    {
        case AddSubstractCommand:
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            char plusSign = '+';
            char minusSign = '-';

            int minExspressionValue = 1;
            int maxExspressionValue = 20;

            int expressionValue = 0;
            int firstValue = random.Next(minExspressionValue, maxExspressionValue + 1);
            int secondValue = random.Next(minExspressionValue, maxExspressionValue + 1);

            int taskOptionsCount = 2;
            
            char exspressionType = random.Next(taskOptionsCount) == 0 ? plusSign : minusSign;
            string outputExspression = "";

            if (exspressionType == plusSign)
            {
                expressionValue = firstValue + secondValue;
                outputExspression = $"Решите выражение: {firstValue} + {secondValue} = ";
            }
            else if (exspressionType == minusSign)
            {
                if (firstValue >= secondValue)
                {
                    expressionValue = firstValue - secondValue;
                    outputExspression = $"Решите выражение: {firstValue} - {secondValue} = ";
                }
                else
                {
                    expressionValue = secondValue - firstValue;
                    outputExspression = $"Решите выражение: {secondValue} - {firstValue} = ";
                }
            }

            Console.WriteLine(outputExspression);

            int inputSolution = Convert.ToInt32(Console.ReadLine());

            if (inputSolution == expressionValue)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Верно!");
                Console.ReadKey();
              
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Не верно! Правильный ответ {expressionValue}");
                Console.ReadKey();
            }

            Console.ForegroundColor = ConsoleColor.White;
            break;

        case MultiplicationTableCommand:
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();

            Console.WriteLine("\t\t\tТаблица умножения \n");
            Console.WriteLine("    |  1\t2\t3\t4\t5\t6\t7\t8\t9");
            Console.Write("--------------------------------------------------------------------------\n");

            int firstTableNumeral = 1;
            int lastTableNumeral = 9;
          
            for (int i = firstTableNumeral; i < lastTableNumeral +1; i++)
            {
                Console.Write(i + "   |  ");

                for (int j = firstTableNumeral; j < lastTableNumeral + 1; j++)
                {
                    Console.Write(i * j+ "\t");
                }

                Console.WriteLine("");
            }

            Console.ReadKey();
            break;

        case ComparisonCommand:
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Clear();

            int minFirstCompareValue = 0;
            int maxFirstCompareValue = 500;

            int minDifference = 10;
            int maxDifference = 200;

            int leftBorderNumber = random.Next(minFirstCompareValue, maxFirstCompareValue);
            int rightBorderNumber = leftBorderNumber + random.Next(minDifference, maxDifference);

            Console.WriteLine("Введите число, которое удовлевтворяет следующему условию:");
            Console.Write($"{leftBorderNumber} <     > {rightBorderNumber}");
            Console.SetCursorPosition(Console.CursorLeft - 9, Console.CursorTop);

            int inputBorderNumber = Convert.ToInt32(Console.ReadLine());

            if(inputBorderNumber > leftBorderNumber && inputBorderNumber < rightBorderNumber)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Верно!");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Не верно!");
            }

            Console.ReadKey();
            break;

        case ExitCommand:
            isRunning = false;
            break;

        default:
            Console.WriteLine("Неверная команда!");
            Console.ReadKey();
            break;
    }

    Console.ResetColor();
    Console.Clear();
}