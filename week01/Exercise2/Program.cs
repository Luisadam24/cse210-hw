using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.Write("What is your final score for the course as a percentage 0-100? ");
        string userInput = Console.ReadLine();
        int number = int.Parse(userInput);
        string letter = "";

        if (number >= 90)
        { letter = ("A"); }
        else if (number >= 80)
        { letter = ("B"); }
        else if (number >= 70)
        { letter = ("C"); }
        else if (number >= 60)
        { letter = ("D"); }
        else
        { letter = ("F"); }

        Console.WriteLine($"You got {letter} ");

        if (number >= 70)
        { Console.WriteLine("You passed!"); }
        else
        { Console.WriteLine("Better luck next time. You failed!"); }
    }
}