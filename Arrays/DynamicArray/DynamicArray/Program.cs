int[] array = new int[0];

string userInput;
bool isExit = false;

while (!isExit)
{
    Console.Write("Введите число или команду: ");
    userInput = Console.ReadLine();

    switch (userInput)
    {
        case "sum":
            Console.WriteLine(array.Sum());
            break;

        case "exit":
            isExit = true;
            break;

        default:
            int tempInputNumber; 

            if (int.TryParse(userInput, out tempInputNumber))
            {
                int[] tempArray = new int[array.Length + 1];

                for (int i = 0; i < array.Length; i++)
                {
                    tempArray[i] = array[i];
                }

                array = tempArray;
                array[array.Length - 1] = tempInputNumber;
            }
            else
            {
                Console.WriteLine("Введено некорректоное значение");
            }        

            break;

            Console.Clear();
    }
}
