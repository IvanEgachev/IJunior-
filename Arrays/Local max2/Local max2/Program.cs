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

for (int i = 0; i < array.Length; i++)
{
    if (i == 0)
    {
        if (array[i] > array[i+1])
        {
            Console.Write(array[i] + " ");
        }
    }
    else if (i == array.Length - 1)
    {
        if (array[i] > array[i - 1])
        {
            Console.Write(array[i] + " ");
        }
    }
    else
    {
        if (array[i] > array[i + 1] && array[i] > array[i - 1])
        {
            Console.Write(array[i] + " ");
        }
    }
}