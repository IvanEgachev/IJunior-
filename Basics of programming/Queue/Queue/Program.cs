Console.Write("Введите количество людей в очереди: ");
int queueCount = Convert.ToInt32(Console.ReadLine());
int receptTimeMinute = 10;
int minutesInHour = 60;

int totalWaitingTime = queueCount * receptTimeMinute;
int waitingTimeHours = totalWaitingTime / minutesInHour;
int waitingTimeMinutes = totalWaitingTime % minutesInHour;

Console.WriteLine($"Время ожидания {waitingTimeHours} часов {waitingTimeMinutes} минут");