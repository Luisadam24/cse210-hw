using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(0, 100); 
        Console.Write("What is your guess? ");
        string userGuess = Console.ReadLine();
        int guess = int.Parse(userGuess);
        while (guess != number)
        {
            if (guess > number)
            { Console.WriteLine("Lower"); }
            else
            { Console.WriteLine("Higher"); }
            Console.Write("What is your guess? ");
            userGuess = Console.ReadLine();
            int gue = int.Parse(userGuess);
            guess = gue;

            

        }
        if (guess == number)
        { Console.Write("You guessed it!"); }
        
        


    }
}