﻿internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Введите текст: ");
        string text = Console.ReadLine();

        char delimiter = ' ';
        string[] wordArray = text.Split(delimiter);

        foreach (var word in wordArray)
        {
            Console.WriteLine(word);
        }
    }
}