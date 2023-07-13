using System.Xml;

internal partial class Program
{
    const string AddCommand = "add";
    const string PrintCommand = "print";
    const string DeleteCommand = "delete";
    const string ExitCommand = "exit";
    const string SearchCommand = "search";

    private static void Main(string[] args)
    {
        string[] fullNameArray = new string[0];
        string[] jobTittleArray = new string[0]; ;

        string command;

        bool isExit = false;
       
        while (isExit == false)
        {
            Console.Write($"Введите одну из доступных команд ({AddCommand}, {PrintCommand}, {DeleteCommand}, {SearchCommand}, {ExitCommand}): ");
            command = Console.ReadLine();

            switch (command)
            {
                case AddCommand:
                    string fullName, jobTitle;

                    EnterEmployeeData(out fullName, out jobTitle);

                    Add(ref fullNameArray, fullName);
                    Add(ref jobTittleArray, jobTitle);
                    break;

                case PrintCommand:
                    int listLength = fullNameArray.Length;

                    if (listLength > 0)
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
                    break;

                case DeleteCommand:
                    Console.WriteLine("Удалить досье сотрудника под номером: ");

                    int indexToDelete = Convert.ToInt32(Console.ReadLine());
                    
                    if (indexToDelete > 0 && indexToDelete <= fullNameArray.Length)
                    {
                        Delete(ref fullNameArray, indexToDelete);
                        Delete(ref jobTittleArray, indexToDelete);
                    }

                    break;

                case SearchCommand:
                    Console.WriteLine("Укажите фамилию: ");
                    string surnameToSearch = Console.ReadLine();

                    int indexSearch = Search(fullNameArray, surnameToSearch);

                    if (indexSearch != -1)
                    {
                        PrintDossier(fullNameArray[indexSearch], jobTittleArray[indexSearch], indexSearch);
                    }

                    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
                    Console.ReadKey();
                    break;

                case ExitCommand:
                    isExit = true;
                    break;

                default:
                    Console.WriteLine("Такой команды не существует. \nНажмите любую клавишу, чтобы продолжить");;
                    Console.ReadKey();
                    break;
            }

            Console.Clear();
        }
    }

    static void EnterEmployeeData(out string fullName, out string jobTitle)
    {
        Console.WriteLine("Введите ФИО:");
        fullName = Console.ReadLine();

        Console.WriteLine("Введите должность:");
        jobTitle = Console.ReadLine();
    }
    static void PrintDossier(string fullName, string jobTittle, int index)
    {
        Console.WriteLine($"{index + 1}. {fullName} - {jobTittle}");
    }

    static void Delete(ref string[] array, int index)
    {
        string[] tempArray = new string[array.Length - 1];

        for (int i = index; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }

        for (int i = 0; i < tempArray.Length; i++)
        {
            tempArray[i] = array[i];
        }

        array = tempArray;
    }

    static int Search(string[] fullName, string surname) 
    {
        int indices = -1;
        string surchedSurname;

        for (int i = 0; i < fullName.Length; i++)
        {
            surchedSurname = fullName[i].Split(' ')[0];

            if (surchedSurname == surname)
            {
                indices = i;
                break;
            }
        }

        return indices;
    }

    static void Add(ref string[] array, string value)
    {
        string[] tempArray = new string[array.Length + 1];

        for (int i = 0; i < array.Length; i++)
        {
            tempArray[i] = array[i];
        }

        tempArray[tempArray.Length - 1] = value;
        array = tempArray;
    }
}




