Random rand = new Random();

int[,] matrix = new int[10, 10];
int maxElement = int.MinValue;

int minRandomElement = 0;
int maxRandomElemnt = 20;

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = rand.Next(minRandomElement, maxRandomElemnt);
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
            matrix[i, j] = 0;
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
