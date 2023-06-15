static int ReadInt()
{
    int number;

    while (true)
    {
        Console.WriteLine("Введите число: ");

        if (int.TryParse(Console.ReadLine(), out number))
        {
            return number;
        }
        else
        {
            Console.WriteLine("Это не число");
        }
    }
}

int number = ReadInt();

Console.WriteLine(number);