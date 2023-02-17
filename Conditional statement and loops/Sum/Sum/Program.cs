Random random = new Random();
int number = random.Next(101);
Console.WriteLine("Начальное число: "+number);

const int multipleNumber1 = 3;
const int multipleNumber2 = 5;

int sum = 0;

Console.Write("Последовательность чисел: ");

for (int i = number; i > 0; i--)
{
    if(i % multipleNumber1 == 0)
    {
        sum += i;
        Console.Write(i+" ");
    }
    else if (i % multipleNumber2 == 0)
    {
        sum += i;
        Console.Write(i + " ");
    }
}

Console.WriteLine("\nСумма чисел: "+sum);