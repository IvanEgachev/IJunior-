using System.Linq;

internal partial class Program
{
    private static void Main(string[] args)
    {
        string[] array1 = new string[] { "1", "2", "1" };
        string[] array2 = new string[] { "2", "3", "4", "1" };

        List<string> uniqueCollection = new List<string>();

        AddArray(uniqueCollection, array1);
        AddArray(uniqueCollection, array2);

        string elements1 = OutputElements(array1);
        string elements2 = OutputElements(array2);
        string elements3 = OutputElements(uniqueCollection);

        PrintResult(elements1, elements2, elements3);
    }

    static void AddArray(List<string> uniqueCollection, string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (uniqueCollection.Contains (array[i]) == false)
            {
                uniqueCollection.Add(array[i]);
            }
        }
    }

    static string OutputElements(string[] array)
    {
        string outputResult = "{ ";

        foreach (var item in array)
        {
            outputResult += item + " ";
        }

        outputResult += "}";
        return outputResult;
    }

    static string OutputElements(List<string> collection)
    {
        string outputResult = "{ ";

        foreach (var item in collection)
        {
            outputResult += item + " ";
        }

        outputResult += "}";
        return outputResult;
    }

    static void PrintResult (string array1, string array2, string collection)
    {
        Console.Write(array1 + " + " + array2 + " => " + collection);
    }
}




