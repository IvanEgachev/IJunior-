using System;

internal partial class Program
{

    private static void Main(string[] args)
    {
        const string AddEmployeeCommand = "add";
        const string PrintDossierCommand = "print";
        const string DeleteEmployeeCommand = "delete";
        const string ExitCommand = "exit";
        const string SearchEmployeeCommand = "search";

        string[] fullNames = new string[0];
        string[] posts = new string[0]; ;

        string command;
        bool isWorking = true;
       
        while (isWorking)
        {
            Console.Write($"Введите одну из доступных команд ({AddEmployeeCommand}, {PrintDossierCommand}, {DeleteEmployeeCommand}, {SearchEmployeeCommand}, {ExitCommand}): ");
            command = Console.ReadLine();

            switch (command)
            {
                case AddEmployeeCommand:
                    AddEmployee(ref fullNames, ref posts);
                    break;

                case PrintDossierCommand:
                    PrintAllDossier(fullNames, posts);
                    break;

                case DeleteEmployeeCommand:
                    DeleteEmployee(ref fullNames, ref posts);
                    break;

                case SearchEmployeeCommand:
                    SearchAllEmployees(fullNames, posts);
                    break;

                case ExitCommand:
                    isWorking = false;
                    break;

                default:
                    Console.WriteLine("Такой команды не существует. \nНажмите любую клавишу, чтобы продолжить");;
                    Console.ReadKey();
                    break;
            }

            Console.Clear();
        }
    }

    static void AddEmployee(ref string[] fullNames, ref string[] posts)
    {
        string fullName;
        string post;

        EnterEmployeeData(out fullName, out post);

        fullNames = AddRecord(fullNames, fullName);
        posts = AddRecord(posts, post);
    }

    static void EnterEmployeeData(out string fullName, out string post)
    {
        Console.WriteLine("Введите ФИО :");
        fullName = Console.ReadLine();

        Console.WriteLine("Введите должность: ");
        post = Console.ReadLine();
    }

    static string[] AddRecord(string[] array, string value)
    {
        string[] tempArray = new string[array.Length + 1];

        for (int i = 0; i < array.Length; i++)
        {
            tempArray[i] = array[i];
        }

        tempArray[tempArray.Length - 1] = value;
        
        return tempArray;
    }

    static void PrintAllDossier(string[] fullNames, string[] posts)
    {
        if (fullNames.Length > 0)
        {
            for (int i = 0; i < fullNames.Length; i++)
            {
                PrintDossier(fullNames[i], posts[i], i);
            }
        }
        else
        {
            Console.WriteLine("Список пуст ");
        }

        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
        Console.ReadKey();
    }

    static void PrintDossier(string fullName, string post, int index)
    {
        Console.WriteLine($"{index + 1}. {fullName} - {post}");
    }

    static void DeleteEmployee(ref string[] fullNames, ref string[] posts)
    {
        Console.WriteLine("Удалить досье сотрудника под номером: ");

        int indexToDelete = ReadInt();

        if (indexToDelete > 0 && indexToDelete <= fullNames.Length)
        {
            fullNames = DeleteRecord(fullNames, indexToDelete);
            posts = DeleteRecord(posts, indexToDelete);
        }
    }

    static string[] DeleteRecord(string[] array, int index)
    {
        string[] tempArray = new string[array.Length - 1];

        for (int i = index - 1; i < tempArray.Length; i++)
        {
            array[i] = array[i + 1];
        }

        for (int i = 0; i < tempArray.Length; i++)
        {
            tempArray[i] = array[i];
        }

        return tempArray;
    }

    static void SearchAllEmployees(string[] fullNames, string[] posts)
    {
        Console.WriteLine("Укажите фамилию: ");
        string surnameToSearch = Console.ReadLine();
        string serchedSurname;
        char delimiter = ' ';

        for (int i = 0; i < fullNames.Length; i++)
        {
            serchedSurname = fullNames[i].Split(delimiter)[0];

            if (serchedSurname == surnameToSearch)
            {
                PrintDossier(fullNames[i], posts[i], i);
            }
        }

        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
        Console.ReadKey();
    }

    static int ReadInt()
    {
        int number;
        Console.WriteLine("Введите число:");

        while (int.TryParse(Console.ReadLine(), out number) == false)
        {
            Console.WriteLine("Это не число!");
        }

        return number;
    }
}




