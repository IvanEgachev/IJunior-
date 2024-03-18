namespace ArrayStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,] { { 13, 26, 17 }, { 5, 12, 34 }, { 54, 77, 36 }, { 1, 2, 3 } };

            int line = 2;
            int column = 1;

            int lineSum = 0;
            int columnMultiple = 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                columnMultiple *= matrix[i, column - 1];

                if (i == line - 1)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        lineSum += matrix[i, j];
                    }
                }
                
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Результат:\n Произведение {column} столбца: {columnMultiple}  \n Сумма {line} строки: {lineSum}");
        }
    }
}