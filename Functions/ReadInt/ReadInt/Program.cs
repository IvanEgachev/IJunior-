internal partial class Program
{
    private static void Main(string[] args)
    {
        int number = ReadInt();
        Console.WriteLine("Полученное число:" + number);
    }

    static int ReadInt()
    {
        int number;
        Console.WriteLine("Введите число:");

        while (int.TryParse(Console.ReadLine(), out number) == false)
        {
                Console.WriteLine("Это не число!");
        }

        return number;
    }
}
