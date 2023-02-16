int firstSequenceNumber = 5;
int secondSequenceNumber = 12;
int lastSequenceNumber = 96;

int step = secondSequenceNumber - firstSequenceNumber;

for (int i = firstSequenceNumber; i <= lastSequenceNumber; i+= step)
{
    Console.Write(i+" ");
}