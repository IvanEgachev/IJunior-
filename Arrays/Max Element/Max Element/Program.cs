
namespace MaxElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int[,] matrix = new int[10, 10];
            int maxElement = int.MinValue;

            int elementToReplace = 0;

            int minRandomElement = 0;
            int maxRandomElemnt = 1000;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(minRandomElement, maxRandomElemnt);
                    Console.Write(Convert.ToString(matrix[i, j]) + '\t');
                }

                Console.WriteLine();
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxElement)
                    {
                        maxElement = matrix[i, j];
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == maxElement)
                    {
                        matrix[i, j] = elementToReplace;
                    }
                }
            }

            Console.WriteLine("Максимальный элемент матрицы: " + maxElement);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(Convert.ToString(matrix[i, j]) + '\t');
                }

                Console.WriteLine();
            }
        }
    }
}