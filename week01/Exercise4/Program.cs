using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        string userGuess = Console.ReadLine();
        int number = int.Parse(userGuess);
        List<int> numbers;
        numbers = new List<int>();
        int total = 0;
        double average = 0;
       



        while (number != 0)
        {
            numbers.Add(number);
            Console.Write("Enter a list of numbers? ");
            userGuess = Console.ReadLine();
            number = int.Parse(userGuess);
       

        }
        int x = numbers[0];
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine(numbers[i]);
            total = total + numbers[i];
            if (numbers[i] > x)
            {
                x = numbers[i]; 
            }
        }
        average = total / numbers.Count;


        Console.WriteLine($"The sum is {total}");
        Console.WriteLine($"The average is {average}");
        Console.WriteLine($"The largest number is {x}");


    }
}