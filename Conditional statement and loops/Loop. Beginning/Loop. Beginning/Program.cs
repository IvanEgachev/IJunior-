Console.Write("Enter tour message: ");
string message = Console.ReadLine();

Console.Write("How many times repeat this message: ");
int timesToReapeatMessage = Convert.ToInt32(Console.ReadLine());

for (int i = 0; i < timesToReapeatMessage; i++)
{
    Console.WriteLine(message);
}