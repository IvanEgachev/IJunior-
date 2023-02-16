Console.Write("Enter tour message: ");
string message = Console.ReadLine();

Console.Write("How many times repeat this message: ");
int timesToReapeat = Convert.ToInt32(Console.ReadLine());

for (int i = 0; i < timesToReapeat; i++)
{
    Console.WriteLine(message);
}