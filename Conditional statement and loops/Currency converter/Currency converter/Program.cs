const int UsdToRubCommand = 21;
const int RubToUsdCommand = 12;
const int CnyToRubCommand = 31;
const int RubToCnyCommand = 13;
const int UsdToCnyCommand = 23;
const int CnyToUsdCommand = 32;

string exitCommand = "y";

float usdToRub = 69.24f;
float rubToUsd = 0.014f;

float cnyToRub = 10.27f;
float rubToCny = 0.097f;

float usdToCny = 6.78f;
float cnyToUsd = 0.15f;

float transferAmount;
string convertFrom = "";
string convertTo= "";
string userInput = "";

Console.Write("Введите сумму рублей, которая у Вас имеется: ");
float rubBalance = Convert.ToSingle(Console.ReadLine());

Console.Write("Введите сумму долларов, которая у Вас имеется: ");
float usdBalance = Convert.ToSingle(Console.ReadLine());

Console.Write("Введите сумму юаней, которая у Вас имеется: ");
float cnyBalance = Convert.ToSingle(Console.ReadLine());

while (userInput != exitCommand)
{
    Console.Write("\nВыберите валюту из которой хотите перевести ( 1. rub, 2. usd, 3. cny)? ");
    convertFrom = Console.ReadLine();

    Console.Write("Выберите валюту в которую хотите перевести (1. rub, 2. usd, 3. cny)? ");
    convertTo = Console.ReadLine();

    if (convertFrom == convertTo)
    {
        Console.WriteLine("Ошибка. Указана одна и та же валюта ");
        continue;
    }

    Console.Write("Введите сумму которую хотите перевести ? ");
    transferAmount = Convert.ToSingle(Console.ReadLine());

    int currenciesPair = Convert.ToInt32(convertFrom + convertTo);

    switch (currenciesPair)
    {
        case UsdToRubCommand:
            if (usdBalance >= transferAmount)
            {
                usdBalance -= transferAmount;
                rubBalance += transferAmount * usdToRub;                
            }
            else
            {
                Console.WriteLine("Ощибка. Недостаточно средств");         
            }

            break;

        case RubToUsdCommand:
            if (rubBalance >= transferAmount)
            {
                rubBalance -= transferAmount;
                usdBalance += transferAmount * rubToUsd;
            }
            else
            {
                Console.WriteLine("Ощибка. Недостаточно средств");                
            }

            break;

        case CnyToRubCommand:  
            if (cnyBalance >= transferAmount)
            {
                cnyBalance -= transferAmount;
                rubBalance += transferAmount * cnyToRub;               
            }
            else
            {
                Console.WriteLine("Ощибка. Недостаточно средств");              
            }

            break;

        case RubToCnyCommand:
            if (rubBalance >= transferAmount)
            {
                rubBalance -= transferAmount;
                cnyBalance += transferAmount * rubToCny;
            }            
            else
            {
                Console.WriteLine("Ощибка. Недостаточно средств");               
            }

            break;

        case UsdToCnyCommand:
            if (usdBalance >= transferAmount)
            {
                usdBalance -= transferAmount;
                cnyBalance += transferAmount * usdToCny;
            }
            else
            {
                Console.WriteLine("Ощибка. Недостаточно средств");              
            }

            break;

        case CnyToUsdCommand:
            if (cnyBalance >= transferAmount)
            {
                cnyBalance -= transferAmount;
                usdBalance += transferAmount * cnyToUsd;
            }
            else
            {
                Console.WriteLine("Ощибка. Недостаточно средств");               
            }

            break;

        default:
            Console.WriteLine("Такой пары валют не существует");
            break;
    }

    Console.WriteLine($"Баланс ваших валютных счетов: rub {rubBalance}, usd {usdBalance}, cny {cnyBalance}.");

    Console.Write("Чтобы закончить работу программы введите  \"y\" ");
    userInput = Console.ReadLine();
} 