//Нужно написать программу (используя циклы, обязательно пояснить выбор вашего цикла), 
//чтобы она выводила следующую последовательность 5 12 19 26 33 40 47 54 61 68 75 82 89 96
//Нужны переменные для обозначения чисел в условии цикла.

int firstSequenceNumber = 5;
int secondSequenceNumber = 12;
int lastSequenceNumber = 96;

int step = secondSequenceNumber - firstSequenceNumber;

for (int currentNumber = firstSequenceNumber; currentNumber <= lastSequenceNumber; currentNumber+= step)
{
    Console.Write(currentNumber+" ");
}

//Пояснение: был выбран цикла "for", поскольку данные выводятся с четко определенным шагом, задано начальное и конечное значение. 