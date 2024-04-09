internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Введите выражение :");
        string inputBracketsExpression = Console.ReadLine();

        char openBracket = '(';
        char closeBracket = ')';

        int deep = 0;
        int maxDeep = 0;

        for (int i = 0; i < inputBracketsExpression.Length; i++)
        {
            if (inputBracketsExpression[i] == openBracket)
            {
                deep++;
            }
            else if (inputBracketsExpression[i] == closeBracket)
            {
                deep--;
            }

            if (deep < 0)
            {
                break;
            }

            if (deep > maxDeep)
            {
                maxDeep = deep;
            }
        }

        if (deep == 0)
        {
            Console.WriteLine($"Скобочное выражение верно. Максимальная вложенность {maxDeep}");
        }
        else
        {
            Console.WriteLine("Некорректное скобочное выражение.");
        }
    }
}