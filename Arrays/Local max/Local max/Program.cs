Random rand =  new Random();

int[,] matrix;

Console.Write("Количество строк в матрице ");
int rows = Convert.ToInt32(Console.ReadLine());

Console.Write("Количество столбцов в матрице ");
int columns = Convert.ToInt32(Console.ReadLine());

matrix = new int[rows, columns];
int secondRow = 1;
int secondRowSum = 0;

int firstColumn = 0;
int firstColumnMultiplication = 1;

for (int i = 0; i < rows; i++)
{

	for (int j = 0; j < columns; j++)
	{
		matrix[i, j] = rand.Next(0, 100);
		Console.Write(Convert.ToString(matrix[i, j])+'\t');
		
		if (i == secondRow)
		{
			secondRowSum += matrix[secondRow, j];
		}
	}

	Console.WriteLine();

    firstColumnMultiplication *= matrix[i, firstColumn];
}

Console.WriteLine("Сумма второй строки:"+ secondRowSum + ", произведение первого столбца: " + firstColumnMultiplication);