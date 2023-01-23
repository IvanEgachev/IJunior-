Console.Write("Введите количество золота: ");
int goldCount = Convert.ToInt32(Console.ReadLine());

int crystalPrice = 17;
int crystalsCanBuy = goldCount / crystalPrice;

Console.Write($"Вы можете купить {crystalsCanBuy} кристаллов(а), какое количество хотите приобрести: ");
int crystalToBuy = Convert.ToInt32(Console.ReadLine());

int remainder = goldCount - crystalToBuy * crystalPrice;

Console.WriteLine($"Вы приобрели {crystalToBuy} кристаллов. Ваш отстаток - {remainder} золота");