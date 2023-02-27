string secretMessage = "This is secret message";

Console.Write("Создайте пароль: ");
string createdPassword = Console.ReadLine();

int attemptsCount = 3;

string checkedPassword ="";

Console.WriteLine("Введите пароль:");
for (int i = attemptsCount; i > 0; i--)
{
    checkedPassword = Console.ReadLine();

    if(createdPassword == checkedPassword)
    {
        Console.WriteLine($"Успешно! {secretMessage}");
        break;
    }
    else
    {
        Console.WriteLine($"Неверный пароль. Осталось попыток {i-1}");
    }
}

