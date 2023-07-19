internal partial class Program
{

    private static void Main(string[] args)
    {
        const string AddEmployeeCommand = "add";
        const string PrintDossierCommand = "print";
        const string DeleteEmployeeCommand = "delete";
        const string ExitCommand = "exit";
        const string SearchEmployeeCommand = "search";

        string[] fullNameArray = new string[0];
        string[] jobTittleArray = new string[0]; ;

        string command;
        bool isWorking = true;
       
        while (isWorking)
        {
            Console.Write($"Введите одну из доступных команд ({AddEmployeeCommand}, {PrintDossierCommand}, {DeleteEmployeeCommand}, {SearchEmployeeCommand}, {ExitCommand}): ");
            command = Console.ReadLine();

            switch (command)
            {
                case AddEmployeeCommand:
                    AddEmployee(ref fullNameArray, ref jobTittleArray);
                    break;

                case PrintDossierCommand:
                    PrintAllDossier(fullNameArray, jobTittleArray);
                    break;

                case DeleteEmployeeCommand:
                    DeleteEmployee(ref fullNameArray, ref jobTittleArray);
                    break;

                case SearchEmployeeCommand:
                    SearchAllEmployees(fullNameArray, jobTittleArray);
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

    static void AddEmployee(ref string[] fullNameArray, ref string[] jobTittleArray)
    {
        string fullName;
        string jobTitle;

        EnterEmployeeData(out fullName, out jobTitle);

        AddRecord(ref fullNameArray, fullName);
        AddRecord(ref jobTittleArray, jobTitle);
    }

    static void EnterEmployeeData(out string fullName, out string jobTitle)
    {
        Console.WriteLine("Введите ФИО :");
        fullName = Console.ReadLine();

        Console.WriteLine("Введите должность: ");
        jobTitle = Console.ReadLine();
    }

    static void AddRecord( ref string[] array, string value)
    {
        string[] tempArray = new string[array.Length + 1];

        for (int i = 0; i < array.Length; i++)
        {
            tempArray[i] = array[i];
        }

        tempArray[tempArray.Length - 1] = value;
        array = tempArray;
    }

    static void PrintAllDossier(string[] fullNameArray, string[] jobTittleArray)
    {
        if (fullNameArray.Length > 0)
        {
            for (int i = 0; i < fullNameArray.Length; i++)
            {
                PrintDossier(fullNameArray[i], jobTittleArray[i], i);
            }
        }
        else
        {
            Console.Write("Список пуст");
        }

        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
        Console.ReadKey();
    }

    static void PrintDossier(string fullName, string jobTittle, int index)
    {
        Console.WriteLine($"{index + 1}. {fullName} - {jobTittle}");
    }

    static void DeleteEmployee(ref string[] fullNameArray, ref string[] jobTittleArray)
    {
        Console.WriteLine("Удалить досье сотрудника под номером: ");

        int indexToDelete = Convert.ToInt32(Console.ReadLine());

        if (indexToDelete > 0 && indexToDelete <= fullNameArray.Length)
        {
            DeleteRecord(ref fullNameArray, indexToDelete);
            DeleteRecord(ref jobTittleArray, indexToDelete);
        }
    }

    static void DeleteRecord(ref string[] array, int index)
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

        array = tempArray;
    }

    static void SearchAllEmployees(string[] fullNameArray, string[] jobTittleArray)
    {
        Console.WriteLine("Укажите фамилию: ");
        string surnameToSearch = Console.ReadLine();

        int[] indexSearch = SearchRecord(fullNameArray, surnameToSearch);

        if (indexSearch.Length > 0)
        {
            foreach (var index in indexSearch)
            {
                PrintDossier(fullNameArray[index], jobTittleArray[index], index);
            }
        }

        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
        Console.ReadKey();
    }

    static int[] SearchRecord(string[] fullName, string surname) 
    {
        int []indices = new int[0];
        string surchedSurname;

        char delimiter = ' ';

        for (int i = 0; i < fullName.Length; i++)
        {
            surchedSurname = fullName[i].Split(delimiter)[0];

            if (surchedSurname == surname)
            {
                indices = AddToArray(indices, i);
            }
        }

        return indices;
    }

    static int[] AddToArray(int[] array, int index)
    {
        int[] tempNumbers = new int[array.Length + 1];

        for (int i = 0; i < array.Length; i++)
        {
            tempNumbers[i] = array[i];
        }

        tempNumbers[tempNumbers.Length - 1] = index;
        return tempNumbers;
    }
}




