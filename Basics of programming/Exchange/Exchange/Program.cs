string country = "Moscow";
string capital = "Russia";

Console.WriteLine("Переменная country до перестановки: " + country);
Console.WriteLine("Переменная capital до перестановки: " + capital);

string temp = country;
country = capital;
capital = temp;

Console.WriteLine("Переменная country после перестановки: " + country);
Console.WriteLine("Переменная capital после перестановки: " + capital);