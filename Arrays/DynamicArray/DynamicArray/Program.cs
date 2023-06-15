int[] numbers = new int[0];
int numbersSum = 0;

string userInput;
bool isExit = false;

const string sumCommand = "sum";
const string exitCommand = "exit";

while (isExit == false)
{
    Console.Write("Введите число или команду (sum - сумма введенных чисел, exit - выход из программы): ");
    userInput = Console.ReadLine();

    switch (userInput)
    {
        case sumCommand:
            numbersSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbersSum += numbers[i];
            }
              
            Console.WriteLine(numbersSum);
            break;

        case exitCommand:
            isExit = true;
            break;

        default:
            int tempInputNumber; 

            if (int.TryParse(userInput, out tempInputNumber))
            {
                int[] tempnumbers = new int[numbers.Length + 1];

                for (int i = 0; i < numbers.Length; i++)
                {
                    tempnumbers[i] = numbers[i];
                }

                numbers = tempnumbers;
                numbers[numbers.Length - 1] = tempInputNumber;
            }
            else
            {
                Console.WriteLine("Введено некорректоное значение");
            }        
            break;
    }
}
