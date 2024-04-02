namespace DynamicArray
{
    class Program
    {
        static void Main( string[] args)
            {
                const string SumCommand = "sum";
                const string ExitCommand = "exit";

                int[] numbers = new int[0];

                string userInput;
                bool isExit = false;

                while (isExit == false)
                {
                    Console.Write($"Введите число или команду ({SumCommand} - сумма введенных чисел, {ExitCommand} - выход из программы): ");
                    userInput = Console.ReadLine();

                switch (userInput)
                {
                    case SumCommand:
                        int numbersSum = 0;

                        for (int i = 0; i < numbers.Length; i++)
                        {
                            numbersSum += numbers[i];
                        }

                        Console.WriteLine(numbersSum);
                        break;

                    case ExitCommand:
                        isExit = true;
                        break;

                    default:
                        int tempInputNumber;

                        if (int.TryParse(userInput, out tempInputNumber))
                        {
                            int[] tempNumbers = new int[numbers.Length + 1];

                            for (int i = 0; i < numbers.Length; i++)
                            {
                                tempNumbers[i] = numbers[i];
                            }

                            numbers = tempNumbers;
                            numbers[numbers.Length - 1] = tempInputNumber;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод");
                        }
                        break;
                }
            }
        }
    }
}