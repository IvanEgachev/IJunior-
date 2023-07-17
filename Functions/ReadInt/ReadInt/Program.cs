internal partial class Program
{
    private static void Main(string[] args)
    {
        int number = ReadInt();
        Console.WriteLine("Полученное число:" + number);
    }

    static int ReadInt()
    {
        int number = int.MinValue;
        bool notNumber = true;

        while (notNumber)
        {
            Console.Write("Введите число: ");

            if (int.TryParse(Console.ReadLine(), out number))
            {
                notNumber = false;
            }
            else
            {
                Console.Write("Это не число!");
                Console.ReadKey();
                Console.Clear();
            }
        }

        return number;
    }
}

