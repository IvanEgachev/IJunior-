const string ExitCommand = "exit";

string userInput = "";

Console.WriteLine("Введите что-нибудь");

while(userInput != ExitCommand)
    {
        userInput = Console.ReadLine();
    }

Console.WriteLine("Произошел выход из цикла");
