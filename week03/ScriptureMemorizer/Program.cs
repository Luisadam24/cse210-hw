using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        Console.WriteLine("SCRIPTURE MEMORIZER");
        Console.WriteLine("===================");
        Console.WriteLine();
        Console.WriteLine("Choose a scripture to memorize:");
        Console.WriteLine("1. John 3:16");
        Console.WriteLine("2. Proverbs 3:5-6");
        Console.WriteLine("3. Philippians 4:13");
        Console.WriteLine();

        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        Reference reference;
        string text;

        if (choice == "1")
        {
            reference = new Reference("Genesis", 1, 1);
            text = "In the beginning God created the heaven and the earth.";
        }
        else if (choice == "2")
        {
            reference = new Reference("Isaiah", 1, 18);
            text = "Come now, and let us reason together, saith the Lord: though your sins be as scarlet, they shall be as white as snow; though they be red like crimson, they shall be as wool.";
        }
        else if (choice == "3")
        {
            reference = new Reference("Matthew", 15, 14);
            text = "Let them alone: they be blind leaders of the blind. And if the blind lead the blind, both shall fall into the ditch.";
        }
        else
        {
            Console.WriteLine("Invalid choice. The program will close.");
            return;
        }

        Scripture scripture = new Scripture(reference, text);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            Console.Write("Press Enter to hide words or type 'quit' to exit: ");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                return;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("Congratulations! You memorized the scripture!");
    }
}