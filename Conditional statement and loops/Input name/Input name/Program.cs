//Вывести имя в прямоугольник из символа, который введет сам пользователь.
//Вы запрашиваете имя, после запрашиваете символ, а после отрисовываете в консоль его имя в прямоугольнике из его символов.

Console.Write("Введите Ваше имя: ");
string inputName = Console.ReadLine();

Console.Write("Введите символ для отрисовки рамки: ");
string inputSymbol = Console.ReadLine();

inputName = inputSymbol+inputName+inputSymbol;

bool isLastString = false;
for (int i = 0; i < inputName.Length; i++)
{ 
    Console.Write(inputSymbol);
    if (i == inputName.Length - 1 && isLastString == false)
    {
        Console.WriteLine();
        Console.WriteLine(inputName);
        i = 0;
        isLastString = true;
    }
}