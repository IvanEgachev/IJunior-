//С помощью Random получить число number, которое не больше 100. 
//Найти сумму всех положительных чисел меньше number (включая число), которые кратные 3 или 5. 
//(К примеру, это числа 3, 5, 6, 9, 10, 12, 15 и т.д.)

Random rand = new Random();
int number = rand.Next(101);
Console.WriteLine("Начальное число: "+number);

int sum = 0;

Console.Write("Последовательность чисел: ");
for (int nextNumber = number; nextNumber > 0; nextNumber--)
{
    if(nextNumber % 5 == 0)
    {
        sum += nextNumber;
        Console.Write(nextNumber+" ");
    }
    else if (nextNumber % 3 == 0)
    {
        sum += nextNumber;
        Console.Write(nextNumber + " ");
    }
}

Console.WriteLine("\nСумма чисел: "+sum);