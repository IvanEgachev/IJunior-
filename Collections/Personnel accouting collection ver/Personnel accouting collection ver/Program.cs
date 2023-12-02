const string AddCommand = "add";
const string PrintCommand = "print";
const string DeleteCommand = "delete";
const string Exitcommand = "exit";
const string SearchCommand = "search";

Dictionary<string, string> personnel = new Dictionary<string, string>();

string fullName;
string jobTitle;
string command;

bool isWorking = true;

while (isWorking)
{
    Console.Write("Введите команду \n(add - доюавить новое досье, \nprint - вывод всех струдников, " +
        "\nsearch - поиск досье сторудника, \ndelete - удалить досье сотрудника, \nexit - выход из программы): ");
    command = Console.ReadLine();

    switch (command)
    {
        case AddCommand:
            Console.WriteLine("Введите ФИО:");
            fullName = Console.ReadLine();

            Console.WriteLine("Введите должность:");
            jobTitle = Console.ReadLine();

            personnel.Add(fullName, jobTitle);

            break;

        case PrintCommand:
            PrintAllDossier(personnel);
            
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
            Console.ReadKey();
            break;

        case DeleteCommand:
            Console.WriteLine("Удалить досье сотрудника: ");
            string employeeToDelete = Console.ReadLine();

            personnel.Remove(employeeToDelete);
            //Delete(ref personnel,employeeToDelete);
           
            break;

        case SearchCommand:
            Console.WriteLine("Укажите фамилию: ");
            string surnameToSearch = Console.ReadLine();

            Search(personnel, surnameToSearch);
          
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
            Console.ReadKey();
            break;

        case Exitcommand:
            isWorking = false;
            break;

        default:
            Console.WriteLine("Такой команды не существует. \nНажмите любую клавишу, чтобы продолжить"); ;
            Console.ReadKey();
            break;
    }

    Console.Clear();
}

static void PrintDossier( KeyValuePair<string,string> personnel)
{
    Console.WriteLine($"{personnel.Key} - {personnel.Value}");
}

static void PrintAllDossier(Dictionary<string, string> personnel)
{
    foreach (var employee in personnel)
    {
        PrintDossier(employee);
    }
}

static void Search(Dictionary<string,string> personnel, string key)
{
   if (personnel.TryGetValue(key, out string employee))
    {
        PrintDossier(new KeyValuePair<string, string>(key, employee));
    }
    else
    {
        Console.WriteLine("Такого сотрудника нет.");
    }
}

static void Delete (ref Dictionary<string,string> personnel, string key)
{
    personnel.Remove(key);
}
