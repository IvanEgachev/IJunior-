using System.Drawing;

Random random = new Random();

bool shutdown  = false;

while(!shutdown)
{
    const int AddSubstractCommand = 1;
    const int MultiplicationTableCommand = 2;
    const int ComparisonCommand = 3;
    const int ExitCommand =  4;

    Console.WriteLine("Математика для начинающих. \nГлавное меню.");

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("1. Сложение/Вычитание");

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("2. Таблица умножения");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("3. Сравнения");

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("4. Завершить работу.");

    Console.ForegroundColor = ConsoleColor.White;

    int command =  Convert.ToInt32(Console.ReadLine());

    switch (command)
    {
        case AddSubstractCommand:

            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            char plusSign = '+';
            char minusSign = '-';

            int expressionValue = 0;
            int firstValue = random.Next(1,21);
            int secondValue = random.Next(1, 21);
            
            char exspressionType = random.Next(2) == 0 ? plusSign : minusSign;
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

            int leftBorderNumber = random.Next(0,500);
            int rightBorderNumber = leftBorderNumber + random.Next(10,200);

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

            shutdown = true;
            break;

        default:
            Console.WriteLine("Неверная команда!");
            Console.ReadKey();
            break;
    }

    Console.ResetColor();
    Console.Clear();
}