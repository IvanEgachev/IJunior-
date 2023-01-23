Console.Write("Как Вас зовут? ");
string name = Console.ReadLine();

Console.Write("Сколько Вам лет? ");
int age = Convert.ToInt32(Console.ReadLine());

Console.Write("Какой Ваш знак зодиака? ");
string zodiacSign = Console.ReadLine();

Console.Write("Где Вы работаете? ");
string workPlace = Console.ReadLine();

string personalInfo = $"Вас зовут {name}, Вам {age} год(лет), Вы {zodiacSign}, Вы работаете на {workPlace}.";
Console.WriteLine(personalInfo);
