Random random = new Random();

long number = random.Next();
Console.WriteLine("Исходное число "+number);

int powerOfTwo = 0;
long numberToPower = 1;

while (numberToPower < number)
{
    numberToPower *= 2;
    powerOfTwo++; 
}
   
Console.WriteLine($"Степень двойки, превышающее исходное число  {powerOfTwo} ({numberToPower})");