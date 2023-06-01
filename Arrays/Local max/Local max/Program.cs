Random random =  new Random();

int[,] matrix;

Console.Write("Количество строк в матрице ");
int rows = Convert.ToInt32(Console.ReadLine());

Console.Write("Количество столбцов в матрице ");
int columns = Convert.ToInt32(Console.ReadLine());

matrix = new int[rows, columns];

int rowIndex = 1;
int rowSum = 0;

int columnIndex = 0;
int columnMultiplication = 1;

int minMatrixNumber = 0;
int maxMatrixNumber = 100;

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        matrix[i, j] = random.Next(minMatrixNumber, maxMatrixNumber);
        Console.Write(Convert.ToString(matrix[i, j]) + '\t');
    }

    Console.WriteLine();
}

for (int i = 0; i < columns; i++)
{
        rowSum += matrix[rowIndex, i];
}

for (int i = 0; i < rows; i++)
{
   columnMultiplication *= matrix[i, columnIndex];
}

Console.WriteLine("Сумма второй строки:"+ rowSum + ", произведение первого столбца: " + columnMultiplication);