using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

 void AddPlayerCommand(Database players)
{
    Console.Write("Введите никнейм: ");
    string nickName = Console.ReadLine();

    Console.Write("Введите уровень игрока: ");
    int level = Convert.ToInt32(Console.ReadLine());

    Person person = new Person(nickName, level);
    players.Add(person);
}

void RemovePlayerCommand(Database players)
{
    Console.Write("Введите уникальный номер пользователя, которого хотите удалить: ");
    int  playerUid = Convert.ToInt32(Console.ReadLine());
    players.RemoveById(playerUid);
}

void BunOrUnbunPlayerCommand (Database players, bool status)
{
    string playerBunStatus = status == true ? "забанить" : "разбанить";

    Console.Write($"Введите уникальный номер пользователя, которого хотите {playerBunStatus}: ");
    int playerUid = Convert.ToInt32(Console.ReadLine());

    players.BunOrUnbunById(playerUid, status);
}

const string AddCommand = "add";
const string RemoveCommand = "remove";
const string BanCommand = "ban";
const string UnbanCommand = "unban";
const string PLayersList = "list";
const string ExitCommand = "exit";

Database players = new Database();

bool isExit = false;
string command = "";

int playerUid;

while (isExit == false)
{
    Console.Write($"Введите одну из доступных команд ({AddCommand}, {RemoveCommand}, {BanCommand}, {UnbanCommand}, {PLayersList}, {ExitCommand}): ");
    command = Console.ReadLine();

    switch (command)
    {
        case PLayersList:
            players.PlayersList();

            break;
        case AddCommand:
            AddPlayerCommand(players);

            break;
        case RemoveCommand:
            RemovePlayerCommand(players);

            break;
        case BanCommand:
            BunOrUnbunPlayerCommand(players, true);

            break;
        case UnbanCommand:
            BunOrUnbunPlayerCommand(players, false);

            break;
        case ExitCommand:
            isExit = true;

            break;
        default:
            Console.WriteLine("Некорректный ввод");
            break;
    }
}

class Database
{
    private List<Person> Players { get; set; } = new List<Person>();

    public Database(){}

    public void Add(Person person)
    {
        person.Id = Players.Count + 1;
        Players.Add(person);    
    }
    public void RemoveById(int id)
    {
        if (IsFind(id, out Person player))
        {
            Players.Remove(player);
        }
    }
    
    public void BunOrUnbunById(int id, bool status)
    {
        if (IsFind(id, out Person player))
        {
            player.IsBanned = status;
        }
    }

    public void PlayersList()
    {
        if (Players.Count == 0)
        {
            Console.WriteLine("Список пуст");
        }

        foreach (var player in Players)
        {
            Console.WriteLine("Id игрока: " + player.Id + "\nИмя игрока: "+ player.NickName + "\nУровень игрока: " + player.Level + "\nСтатус бана: " + player.IsBanned);
        }
    }

    private bool IsFind (int id, out Person player)
    {
        player = new Person();

        foreach (var el in Players)
        {
            if (el.Id == id)
            {
                player = el;
                return true;
            }
        }

        return false;
    }
}

class Person
{
    public int Id { get; set; }
    public string NickName { get; set; }
    public int Level { get; set; }
    public bool IsBanned { get; set; } = false;

    public Person(){}

    public Person (string nickName, int level)
    {
        NickName = nickName;
        Level = level;
    }
}
