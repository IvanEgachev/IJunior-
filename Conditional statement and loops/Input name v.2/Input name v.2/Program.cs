Console.Write("Введите Ваше имя: ");
string inputName = " " + Console.ReadLine() + " ";

Console.Write("Введите символ для отрисовки рамки: ");
char inputDrawSymbol = Convert.ToChar(Console.ReadLine());

string border = "";
int borderLength = inputName.Length + 2;

for (int i = 0; i < borderLength; i++)
{
    border += inputDrawSymbol;
}

Console.WriteLine(border);
Console.WriteLine(inputDrawSymbol + inputName + inputDrawSymbol);
Console.WriteLine(border);
