Console.Write("Введите Ваше имя: ");
string inputName = Console.ReadLine();

Console.Write("Введите символ для отрисовки рамки: ");
char inputDrawSymbol = Convert.ToChar(Console.ReadLine());

for (int i = 0; i < inputName.Length + 2; i++)
{
    Console.Write(inputDrawSymbol);
}

Console.WriteLine("\n"+ inputDrawSymbol + inputName + inputDrawSymbol);

for (int i = 0; i < inputName.Length + 2; i++)
{
    Console.Write(inputDrawSymbol);
}
