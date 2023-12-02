Queue<int> storeQueue = new Queue<int>();

storeQueue.Enqueue(1200);
storeQueue.Enqueue(400);
storeQueue.Enqueue(370);
storeQueue.Enqueue(760);

int storeAccount = 0;
int buyerAccount = 0;

while (storeQueue.Count > 0)
{
    buyerAccount = storeQueue.Dequeue();
    storeAccount += buyerAccount;
    
    Console.WriteLine("Покупка на сумму: " + buyerAccount);
    Console.WriteLine("Счет магазина: " + storeAccount);

    Console.ReadKey();
    Console.Clear();
}

Console.WriteLine("Итоговый баланс магазина: " + storeAccount);