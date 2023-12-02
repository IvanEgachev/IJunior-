const string exitCommand = "exit";

Console.WriteLine("Введите что-нибудь");
string userInput = ""; 

while(userInput != exitCommand)
    {
        userInput = Console.ReadLine();
    }

Console.WriteLine("Произошел выход из цикла");
