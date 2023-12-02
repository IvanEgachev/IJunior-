const string ExitCommand = "exit";

Console.WriteLine("Введите что-нибудь");
string userInput = ""; 

while(userInput != ExitCommand)
    {
        userInput = Console.ReadLine();
    }

Console.WriteLine("Произошел выход из цикла");
