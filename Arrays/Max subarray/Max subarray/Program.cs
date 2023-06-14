Random random = new Random();

int[] array;
int arrayLength = 0;

int subArrayLength = 0;
int maxSubArrayLength = 0;
int subarrayNumber = 0;

int minArrayNumber = 0;
int maxArrayNumber = 5;

Console.Write("Введите размерность массива ");

if (int.TryParse(Console.ReadLine(), out arrayLength))
{
    array = new int[arrayLength];

    for (int i = 0; i < arrayLength; i++)
    {
        array[i] = random.Next(minArrayNumber, maxArrayNumber);
        Console.Write(array[i] + " ");
    }

    if (array.Length != 0)
	{
		subArrayLength = 1;
        maxSubArrayLength = subArrayLength;
        subarrayNumber = array[0];
	}

	for (int i = 1; i < array.Length; i++)
	{
		if (array[i] == array[i-1])
		{
			subArrayLength++;

            if (subArrayLength >= maxSubArrayLength)
            {
                maxSubArrayLength = subArrayLength;
                subarrayNumber = array[i];
            }
        }
		else
		{
            subArrayLength = 1;
		}
	}

	Console.WriteLine($"\nДлина  самого большого подмассива: {maxSubArrayLength}, Число подмассива: {subarrayNumber}.");
}