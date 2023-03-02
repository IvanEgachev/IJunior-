Random random = new Random();

int number = random.Next(1, 28);
int last3DigitNumber = 999;
int multiplesNumbers = 0;

Console.WriteLine("Выбранное число из диапозона:" + number);

for (int i = number; i <= last3DigitNumber; i+=number)
{
    if ((int)Math.Log10(i) + 1 == 3)
    {
        multiplesNumbers++;
    }
}

Console.WriteLine($"Количество чисел кратных {number} - {multiplesNumbers}");
