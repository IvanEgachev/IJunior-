Random random = new Random();

int[] array;
int arrayLength;

int minArrayNumber = 0;
int maxArrayNumber = 100;

Console.Write("Введите размерность массива (размерность >= 10): ");
arrayLength = Convert.ToInt32(Console.ReadLine());

array = new int[arrayLength];

Console.WriteLine("Изначальный вид массива:");

for (int i = 0; i < array.Length; i++)
{
    array[i] = random.Next(minArrayNumber, maxArrayNumber);
    Console.Write(array[i]+ " ");
}

for (int i = 1; i < array.Length; i++)
{
    for (int j = i; j > 0 ; j--)
    {
        if (array[j] < array[j-1])
        {
            int tempVariable = array[j];
            array[j] = array[j-1];
            array[j-1] = tempVariable;
        }
    }
}

Console.WriteLine("\nОтсортированный массив:");

for (int i = 0; i < array.Length; i++)
{
    Console.Write(array[i] + " ");
}