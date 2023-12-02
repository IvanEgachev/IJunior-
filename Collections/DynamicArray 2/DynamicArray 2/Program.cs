const string SumCommand = "sum";
const string ExitCommand = "exit";

List<int> numbers = new List<int>();
int numbersSum = 0;

string userInput;
bool isWorking = true;

while (isWorking)
{
    Console.Write($"Введите число или команду ({SumCommand} - сумма введенных чисел, {ExitCommand} - выход из программы): ");
    userInput = Console.ReadLine();

    switch (userInput)
    {
        case SumCommand:
            numbersSum = numbers.Sum();
            Console.WriteLine(numbersSum);
            break;

        case ExitCommand:
            isWorking = false;
            break;

        default:
            ReadAndAddNumber(userInput, numbers);
            break;
    }
}

static void ReadAndAddNumber(string userInput, List<int> numbers)
{
    int tempInputNumber;

    if (int.TryParse(userInput, out tempInputNumber))
    {
        numbers.Add(tempInputNumber);
    }
    else
    {
        Console.WriteLine("Введено некорректоное значение");
    }
}