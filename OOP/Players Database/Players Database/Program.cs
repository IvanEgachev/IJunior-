using System;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

const string AddCommand = "add";
const string RemoveCommand = "remove";
const string BanCommand = "ban";
const string UnbanCommand = "unban";

string command = "";

Database players = new Database();

List<Person> persons = new List<Person>() {
    new Person ("Nagibator228", 9),
    new Person ("ybicaNoobov", 1),
    new Person ("S_T_A_L_K_E_R", 13),
};


Console.Write($"Введите одну из доступных команд ({AddCommand}, {RemoveCommand}, {BanCommand}, {UnbanCommand}): ");
command = Console.ReadLine();

switch(command)
{
    case AddCommand:
        string nickName = Console.ReadLine();
        int level = Convert.ToInt32(Console.ReadLine());

        Person person = new Person (nickName, level);
        players.Add (person);

        break;
    case RemoveCommand:
        break;
    case BanCommand:
        break;
    case UnbanCommand:
        break;
    default:
        Console.WriteLine("Некорректный ввод");
        break;
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
    
    public void BunByID(int id)
    {
        if (IsFind(id, out Person player))
        {
            player.IsBanned = true;
        }
    }

    public void UnbunByID(int id)
    {
        if (IsFind(id, out Person player))
        {
            player.IsBanned = false;
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
