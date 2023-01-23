Console.Write("Введите количество людей в очереди: ");
int queueCount = Convert.ToInt32(Console.ReadLine());
int receptTime = 10;
int hour = 60;

int totalWaitingTime = queueCount * receptTime;
int waitingTimeHours = totalWaitingTime / hour;
int waitingTimeMinutes = totalWaitingTime % hour;

Console.WriteLine($"Время ожидания {waitingTimeHours} часов {waitingTimeMinutes} минут");

