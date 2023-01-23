Console.Write("Введите количество людей в очереди: ");
int queueCount = Convert.ToInt32(Console.ReadLine());
int receoptTime = 10;

int waitingTime = queueCount * receoptTime;
int waitingTimeHours = waitingTime / 60;
int waitingTimeMin = waitingTime % 60;

Console.WriteLine($"Время ожидания {waitingTimeHours} часов {waitingTimeMin} минут");

