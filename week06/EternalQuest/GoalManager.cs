using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\nYour total score is {_score}");
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nYour Goals:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nChoose a goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine() ?? "";

        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter the goal description: ");
        string description = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Name and description cannot be empty.");
            return;
        }

        int points = ReadInt("Enter points for completing the goal: ", 1);

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;

            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;

            case "3":
                int target = ReadInt(
                    "How many times must you complete this goal? ", 1);

                int bonus = ReadInt(
                    "Enter the bonus points for finishing it: ", 0);

                _goals.Add(new ChecklistGoal(
                    name, description, points, target, bonus));
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        Console.WriteLine("Goal created successfully!");
    }

    public void RecordGoalEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal first.");
            return;
        }

        DisplayGoals();

        int choice = ReadInt(
            "Enter the number of the goal you accomplished: ", 1);

        if (choice > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal selectedGoal = _goals[choice - 1];

        if (selectedGoal.IsComplete())
        {
            Console.WriteLine("This goal is already complete.");
            return;
        }

        int earnedPoints = selectedGoal.RecordEvent();
        _score += earnedPoints;

        Console.WriteLine($"Congratulations! You earned {earnedPoints} points.");
        Console.WriteLine($"Your total score is now {_score}.");
    }

    public void SaveGoals()
    {
        Console.Write("Enter the filename to save to: ");
        string filename = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }

        try
        {
            using StreamWriter outputFile = new StreamWriter(filename);

            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }

            Console.WriteLine("Goals and score saved successfully!");
        }
        catch (IOException)
        {
            Console.WriteLine("Could not save the file.");
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename to load: ");
        string filename = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(filename) || !File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);

            if (lines.Length == 0 ||
                !int.TryParse(lines[0], out int loadedScore) ||
                loadedScore < 0)
            {
                Console.WriteLine("The save file is invalid.");
                return;
            }

            List<Goal> loadedGoals = new List<Goal>();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');

                try
                {
                    if (parts[0] == "Simple" && parts.Length == 5)
                    {
                        loadedGoals.Add(new SimpleGoal(
                            parts[1],
                            parts[2],
                            int.Parse(parts[3]),
                            bool.Parse(parts[4])));
                    }
                    else if (parts[0] == "Eternal" && parts.Length == 4)
                    {
                        loadedGoals.Add(new EternalGoal(
                            parts[1],
                            parts[2],
                            int.Parse(parts[3])));
                    }
                    else if (parts[0] == "Checklist" && parts.Length == 7)
                    {
                        loadedGoals.Add(new ChecklistGoal(
                            parts[1],
                            parts[2],
                            int.Parse(parts[3]),
                            int.Parse(parts[4]),
                            int.Parse(parts[5]),
                            int.Parse(parts[6])));
                    }
                    else
                    {
                        Console.WriteLine(
                            $"Skipping invalid goal on line {i + 1}.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine(
                        $"Skipping invalid goal on line {i + 1}.");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine(
                        $"Skipping invalid goal on line {i + 1}.");
                }
            }

            _goals = loadedGoals;
            _score = loadedScore;

            Console.WriteLine("Goals and score loaded successfully!");
        }
        catch (IOException)
        {
            Console.WriteLine("Could not read the file.");
        }
    }

    // Extra feature: award a rank based on the user's accumulated score.
    public void DisplayRank()
    {
        string rank;

        if (_score >= 5000)
        {
            rank = "Legend";
        }
        else if (_score >= 2000)
        {
            rank = "Champion";
        }
        else if (_score >= 500)
        {
            rank = "Rising Star";
        }
        else
        {
            rank = "Beginner";
        }

        Console.WriteLine($"Your Eternal Quest rank: {rank}");
    }

    private int ReadInt(string prompt, int minimum)
    {
        while (true)
        {
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine(), out int value) &&
                value >= minimum)
            {
                return value;
            }

            Console.WriteLine($"Enter a whole number of at least {minimum}.");
        }
    }
}