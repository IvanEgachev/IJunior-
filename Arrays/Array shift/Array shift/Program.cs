internal class Program
{
    private static void Main(string[] args)
    {
        Random random = new Random();

        int[] array;
        int arrayLength;

        int userInputShift;
        int shift;

        int minArrayNumber = 0;
        int maxArrayNumber = 9;

        Console.Write("Введите размерность массива: ");
        arrayLength = Convert.ToInt32(Console.ReadLine());

        array = new int[arrayLength];

        Console.WriteLine("Исходный массив: ");

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(minArrayNumber, maxArrayNumber);
            Console.Write(array[i] + " ");
        }

        Console.Write("\nНа сколько позиций сдвинуть массив влево: ");
        userInputShift = Convert.ToInt32(Console.ReadLine());

        shift = userInputShift % array.Length;

        int tempNumber;

        for (int i = 0; i < shift; i++)
        {
            tempNumber = array[0];

            for (int j = 0; j < array.Length - 1; j++)
            {
                array[j] = array[j + 1];
            }

            array[array.Length - 1] = tempNumber;
        }

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}