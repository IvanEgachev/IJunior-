namespace MaxElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int[] array;

            Console.WriteLine("Укажите размерность массива: ");
            int arrayLength = Convert.ToInt32(Console.ReadLine());

            array = new int[arrayLength];

            int minRandomElement = 0;
            int maxRandomElement = 100;

            Console.Write("Элементы массива: ");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minRandomElement, maxRandomElement);
                Console.Write(array[i] + " ");
            }

            Console.Write("\nЛокальные максимумы: ");

            int firstArrayIndex = 0;
            int lastArrayIndex = array.Length - 1;

            if (array[firstArrayIndex] > array[firstArrayIndex + 1])
            {
                Console.Write(array[firstArrayIndex] + " ");
            }

            for (int i = firstArrayIndex + 1; i < lastArrayIndex; i++)
            {
                if (array[i] > array[i + 1] && array[i] > array[i - 1])
                {
                    Console.Write(array[i] + " ");
                }
            }

            if (array[lastArrayIndex] > array[lastArrayIndex - 1])
            {
                Console.Write(array[lastArrayIndex] + " ");
            }
        }
    }
}