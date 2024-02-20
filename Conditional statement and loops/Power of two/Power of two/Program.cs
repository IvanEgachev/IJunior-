Random random = new Random();

long inputNumber = random.Next(0, 100000);
Console.WriteLine("Исходное число "+ inputNumber);

int numberToPower = 2;
int powerOfNumber = 0;
long result = 1;

for (; result <= inputNumber; powerOfNumber++)
{
    result *= numberToPower;
}

Console.WriteLine($"Степень двойки, превышающее исходное число  {powerOfNumber} ({result})");