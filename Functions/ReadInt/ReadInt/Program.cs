int number = ReadInt();
Console.WriteLine("Полученное число:" + number);

static int ReadInt()
{
    int number;

    while (true)
    {
        Console.Write("Введите число: ");

        if (int.TryParse(Console.ReadLine(), out number))
        {
            return number;
        }
        else
        {
            Console.Write("Это не число!");

            Console.ReadKey();
            Console.Clear();
        }
    }
}

