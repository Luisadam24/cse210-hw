using System;
using System.Xml;

class Program
{
   
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");
        DisplayMessage();
        string yourName = PromptUserName();
        int yourNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(yourNumber);
        DisplayResult(yourName,squaredNumber);
    }
    static void DisplayMessage()
    {
        Console.WriteLine("Welcome to the Program"); 
    
    }
    static string PromptUserName()
    {
        Console.WriteLine("What is your name? ");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber()
    {
        Console.WriteLine("What is your favourite number? ");
        string favourite = Console.ReadLine();
        int number = int.Parse(favourite);
        return number;
    }
    static int SquareNumber(int number)
    {
        int square = number * number;
      return square;
    }
    static void DisplayResult(string yourName, int squaredNumber)
    {
        Console.WriteLine($"Sir {yourName}, the square of your number is {squaredNumber}"); 
    }

}