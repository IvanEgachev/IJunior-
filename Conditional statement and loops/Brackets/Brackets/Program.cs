//Console.Write("Введите строку скобок");
//string inputBrackets = Console.ReadLine();

//string inputBrackets = "(()((()))())";
string inputBrackets = "(()(()))";

int maxNesting = 0;
int openBrackets = 0;

for (int i = 0; i < inputBrackets.Length; i++)
{
    if (inputBrackets[0] == ')')
    {
        Console.WriteLine("Ошибка");
        break;
    }

    if (inputBrackets[i] == '(')
    {
        openBrackets++;
    }
    else if (inputBrackets[i] == ')' && openBrackets != 0)
    {
        openBrackets--;
    }

    if (openBrackets > maxNesting)
    {
        maxNesting = openBrackets;
    }
}

Console.WriteLine(maxNesting + " " + openBrackets);

