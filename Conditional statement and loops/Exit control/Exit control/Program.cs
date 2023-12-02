const string ExitCommand = "exit";

string userInput = "";

while(userInput != ExitCommand)
    {
        Console.Write("Введите что-нибудь: ");
        userInput = Console.ReadLine();
    }

Console.WriteLine("Произошел выход из цикла");
