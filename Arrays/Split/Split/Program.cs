Console.WriteLine("Введите текст: ");
string text = Console.ReadLine();

string[] wordArray = text.Split(' ');

foreach (var word in wordArray)
{
    Console.WriteLine(word);
}