internal partial class Program
{
    private static void Main()
    {
        int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        Console.Write("Исходный массив: ");
        DisplayArray(numbers);

        ShuffleArray(numbers);

        Console.Write("\nПеремешанный массив: ");
        DisplayArray(numbers);
    }

    static void ShuffleArray(int[] numbers)
    {
        Random random = new Random(); 
        int index;

        for (int i = 0; i < numbers.Length; i++)
        {
            index = random.Next(i);
            numbers[i] = numbers[index];
            numbers[index] = i;
        }
    }

    static void DisplayArray(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
        }
    }
}