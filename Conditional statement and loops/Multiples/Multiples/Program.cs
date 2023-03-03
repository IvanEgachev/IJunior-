Random random = new Random();

int minInputNumber = 1;
int maxInputNumber = 27;

int inputNumber = random.Next(minInputNumber, maxInputNumber + 1);
int maxRangeNumber = 999;
int multiplesNumbers = 0;

for (int i = inputNumber; i <= maxRangeNumber; i+= inputNumber)
{
    if (i >= 100)
    {
        multiplesNumbers++;
    }
}

Console.WriteLine($"Количество чисел кратных {inputNumber} - {multiplesNumbers}");
