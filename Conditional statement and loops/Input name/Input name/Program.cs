Console.Write("Введите Ваше имя: ");
string inputName = Console.ReadLine();

Console.Write("Введите символ для отрисовки рамки: ");
string inputDrawSymbol = Console.ReadLine();

inputName = inputDrawSymbol + inputName+ inputDrawSymbol;
int drawBordersCount = 2;

for (int i = 0; i < drawBordersCount; i++)
{

    for (int j = 0; j < inputName.Length; j++)
    {
        Console.Write(inputDrawSymbol);
    }

    if (i == 0)
        Console.WriteLine("\n" + inputName);
}
