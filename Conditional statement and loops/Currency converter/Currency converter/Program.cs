//У пользователя есть баланс в каждой из представленных валют (3 валюты). 
//Он может попросить сконвертировать часть баланса с одной валюты в другую. 
//Тогда у него с баланса одной валюты снимется X и зачислится на баланс другой Y. 
//Курс конвертации должен быть просто прописан в программе.
//По имени переменной курса конвертации должно быть понятно, из какой валюты в какую валюту конвертируется.

//Программа должна завершиться тогда, когда это решит пользователь.

float transferAmount;
string convertFrom, convertTo;

Console.Write("Введите сумму рублей, которая у Вас имеется: ");
float rubBalance = Convert.ToSingle(Console.ReadLine());

Console.Write("Введите сумму долларов, которая у Вас имеется: ");
float usdBalance = Convert.ToSingle(Console.ReadLine());

Console.Write("Введите сумму юаней, которая у Вас имеется: ");
float cnyBalance = Convert.ToSingle(Console.ReadLine());

float usdRub = 69.24f;
float rubUsd = 0.014f;

float cnyRub = 10.27f;
float rubCny = 0.097f;

float usdCny = 6.78f;
float cnyUsd = 0.15f;

do
{
    Console.Write("\nВыберите валюту из которой хотите перевести (rub, usd, cny)? ");
    convertFrom = Console.ReadLine();

    Console.Write("Выберите валюту в которую хотите перевести (rub, usd, cny)? ");
    convertTo = Console.ReadLine();

    if (convertFrom == convertTo)
    {
        Console.WriteLine("Ошибка. Указана одна и та же валюта ");
        continue;
    }

    Console.Write("Введите сумму которую хотите перевести ? ");
    transferAmount = Convert.ToSingle(Console.ReadLine());

    string currenciesPair = $"{convertFrom}/{convertTo}";
    switch (currenciesPair)
    {
        case "usd/rub":

            usdBalance -= transferAmount;
            if (usdBalance >= 0)
                rubBalance += transferAmount * usdRub;
            else Console.WriteLine("Ощибка. Недостаточно средств");

            break;

        case "rub/usd":

            rubBalance -= transferAmount;
            if (rubBalance >= 0)
                usdBalance += transferAmount * rubUsd;
            else Console.WriteLine("Ощибка. Недостаточно средств");

            break;

        case "rub/cny":

            rubBalance -= transferAmount;
            if (rubBalance >= 0)
                cnyBalance += transferAmount * rubCny;
            else Console.WriteLine("Ощибка. Недостаточно средств");

            break;

        case "cny/rub":

            cnyBalance -= transferAmount;
            if (cnyBalance >= 0)
                rubBalance += transferAmount * cnyRub;
            else Console.WriteLine("Ощибка. Недостаточно средств");

            break;

        case "cny/usd":

            cnyBalance -= transferAmount;
            if (cnyBalance >= 0)
                usdBalance += transferAmount * cnyUsd;
            else Console.WriteLine("Ощибка. Недостаточно средств");

            break;

        case "usd/cny":
            usdBalance -= transferAmount;
            if (usdBalance >= 0)
                cnyBalance += transferAmount * usdCny;
            else Console.WriteLine("Ощибка. Недостаточно средств");

            break;

        default:
            Console.WriteLine("Такой пары валют не существует");
            break;
    }

    Console.WriteLine($"Баланс ваших валютных счетов: rub {rubBalance}, usd {usdBalance}, cny {cnyBalance}.");
    Console.Write("Чтобы закончить работу программы нажмите  Y");

} while (Console.ReadKey().Key != ConsoleKey.Y);