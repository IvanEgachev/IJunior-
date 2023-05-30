Random rand = new Random();

int[] array;

int arrayLength = Convert.ToInt32(Console.ReadLine());
array = new int[arrayLength];

for (int i = 0; i < arrayLength; i++)
{
    array[i] = rand.Next(0, 100);
    Console.Write(array[i] + " ");
}

Console.WriteLine();

for (int i = 0; i < arrayLength; i++)
{
    if (i == 0)
    {
        if (array[i] > array[i+1])
        {
            Console.Write(array[i] + " ");
        }
    }
    else if (i == arrayLength - 1)
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