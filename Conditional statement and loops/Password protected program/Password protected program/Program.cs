﻿string secretMessage = "Где нет стремления к счастью, там нет и стремления вообще. Стремление к счастью — это стремление стремлений.";

Console.Write("Придумайте пароль: ");
string password = Console.ReadLine();

string confirmPassword;
bool canAccess = false;
int getAccessAttempsCount = 3;

for (int i = getAccessAttempsCount; i > 0; i--)
{
    Console.Write("Введите пароль:");
    confirmPassword = Console.ReadLine();

    if (password == (confirmPassword))
    {
        Console.WriteLine($"Успешно! Вы получили доступ к секретному сообщению. \n Секретное сообщение: {secretMessage}");
        canAccess = true;
        break;
    }
    else
    {
        Console.WriteLine($"Неверный пароль. Осталось попыток {i-1}");
    }
}

if (canAccess == false)
{
    Console.WriteLine("Отказано в доступе! Превышен лимит попыток");
}

