using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        List<string> prompts = new List<string>
        {
            "What was the best part of my day?",
            "Who was the most interesting person I interacted with today?",
            "What was the strongest emotion I felt today?",
            "What is something new I learned today?",
            "What is one thing I would like to improve tomorrow?",
            "What made me laugh today?",
            "What was one challenge I faced today?"
        };

        Random random = new Random();

        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. View entry count");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");

            choice = int.Parse(Console.ReadLine());

            Console.WriteLine();

            if (choice == 1)
            {
                string prompt = prompts[random.Next(prompts.Count)];

                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("Response: ");
                string response = Console.ReadLine();

                string date = DateTime.Now.ToShortDateString();

                Entry entry = new Entry(date, prompt, response);
                journal.AddEntry(entry);

                Console.WriteLine("Entry added.");
                Console.WriteLine();
            }
            else if (choice == 2)
            {
                journal.DisplayEntries();
            }
            else if (choice == 3)
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();

                journal.SaveToFile(filename);
                Console.WriteLine();
            }
            else if (choice == 4)
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();

                journal.LoadFromFile(filename);
                Console.WriteLine();
            }
            else if (choice == 5)
            {
                Console.WriteLine($"You have {journal.GetEntryCount()} journal entries.");
                Console.WriteLine();
            }
            else if (choice == 6)
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
                Console.WriteLine();
            }
        }
    }

}