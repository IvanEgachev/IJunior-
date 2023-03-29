Console.Write("Введите скобочное выражение :");
string inputBracketsExpression = Console.ReadLine();

int maxNesting = 0;
int openBrackets = 0;
bool isWrongExspression = false;

for (int i = 0; i < inputBracketsExpression.Length; i++)
{
    if (inputBracketsExpression[i] == '(')
    {
        openBrackets++;
    }
    else 
    {
        openBrackets--;
    }

    if (openBrackets < 0)
    {
        isWrongExspression = true;
        break;
    }

    if (openBrackets > maxNesting)
    {
        maxNesting = openBrackets;
    }
}

if (openBrackets == 0 && isWrongExspression == false)
{
    Console.WriteLine($"Скобочное выражение верно. Максимальная вложенность {maxNesting}");
}
else
{
    Console.WriteLine("Некорректное скобочное выражение.");
}


