Random random = new Random();

long inputNumber = random.Next();
Console.WriteLine("Исходное число "+ inputNumber);

int numberToPower = 2;
int powerOfNumber = 0;
long result = 1;

while (result <= inputNumber)
{
    result *= numberToPower;
    powerOfNumber++; 
}
   
Console.WriteLine($"Степень двойки, превышающее исходное число  {powerOfNumber} ({result})");