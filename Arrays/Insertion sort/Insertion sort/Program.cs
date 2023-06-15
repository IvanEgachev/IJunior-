Random random = new Random();

int[] numbers;
int arrayLength;

int minArrayNumber = 0;
int maxArrayNumber = 100;

Console.Write("Введите размерность массива: ");
arrayLength = Convert.ToInt32(Console.ReadLine());

numbers = new int[arrayLength];

Console.WriteLine("Изначальный вид массива:");

for (int i = 0; i < numbers.Length; i++)
{
    numbers[i] = random.Next(minArrayNumber, maxArrayNumber);
    Console.Write(numbers[i]+ " ");
}

for (int i = 1; i < numbers.Length; i++)
{
    for (int j = i; j > 0 ; j--)
    {
        if (numbers[j] < numbers[j-1])
        {
            int tempVariable = numbers[j];
            numbers[j] = numbers[j-1];
            numbers[j-1] = tempVariable;
        }
    }
}

Console.WriteLine("\nОтсортированный массив:");

for (int i = 0; i < numbers.Length; i++)
{
    Console.Write(numbers[i] + " ");
}