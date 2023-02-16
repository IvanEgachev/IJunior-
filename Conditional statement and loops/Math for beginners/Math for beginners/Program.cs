using System.Drawing;

Random rand = new Random();

while(true)
{
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

    string command = Console.ReadLine();

    switch (command)
    {
        case "1":
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            int expressionValue = 0;
            int firstValue = rand.Next(1,21);
            int secondValue = rand.Next(1, 21);
            
            char exspressionType = rand.Next(2) == 0 ? '+' : '-';
            string outputExspression = "";

            if (exspressionType == '+')
            {
                expressionValue = firstValue + secondValue;
                outputExspression = $"Решите выражение: {firstValue} + {secondValue} = ";
            }
            else if (exspressionType == '-')
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

        case "2":
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();

            Console.WriteLine("\t\t\tТаблица умножения \n");
            Console.WriteLine("    |  1\t2\t3\t4\t5\t6\t7\t8\t9");
            Console.Write("--------------------------------------------------------------------------\n");
          
            for (int i = 1; i < 10; i++)
            {
                Console.Write(i + "   |  ");
                for (int j = 1; j < 10; j++)
                {
                    Console.Write(i * j+ "\t");
                }
                Console.WriteLine("");
            }

            Console.ReadKey();
            break;

        case "3":
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Clear();

            int leftBorderNumber = rand.Next(0,500);
            int rightBorderNumber = leftBorderNumber + rand.Next(10,200);

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

        case "4":
            return;
        default:
            Console.WriteLine("Неверная команда!");
            Console.ReadKey();
            break;
    }

    Console.ResetColor();
    Console.Clear();
}