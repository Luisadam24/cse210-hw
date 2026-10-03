using System;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;
        int completedActivities = 0;

        
        while (choice != 4)
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            choice = int.Parse(Console.ReadLine());

            Console.WriteLine();

            if (choice == 1)
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
                completedActivities++;
            }
            else if (choice == 2)
            {
                ReflectingActivity activity = new ReflectingActivity();
                activity.Run();
                completedActivities++;
            }
            else if (choice == 3)
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
                completedActivities++;
            }
            else if (choice == 4)
            {
                Console.WriteLine();
                Console.WriteLine($"You completed {completedActivities} mindfulness activities this session.");
                Console.WriteLine("Thank you for using the Mindfulness Program.");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select 1, 2, 3, or 4.");
            }

            if (choice != 4)
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
            }
        }
    }
}