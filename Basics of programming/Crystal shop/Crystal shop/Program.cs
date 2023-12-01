Console.Write("Введите количество золота: ");
int gold = Convert.ToInt32(Console.ReadLine());

int crystalPrice = 17;
int availableCrystals = gold / crystalPrice;

Console.Write($"Вы можете купить {availableCrystals} кристаллов(а), какое количество хотите приобрести: ");
int crystals = Convert.ToInt32(Console.ReadLine());

int remainder = gold - crystals * crystalPrice;

Console.WriteLine($"Вы приобрели {crystals} кристаллов. Ваш отстаток - {remainder} золота");