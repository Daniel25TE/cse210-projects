using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager 
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager(int score)
    {
        _score = score;
        _goals = new List<Goal>();
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine($"\b");
            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine($"\b");
            Console.WriteLine($"Manu options: ");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit (Please save your progress before you quit)");
            Console.WriteLine($"\b");
            Console.WriteLine($"Note: If you have a file already, save your progress in the same file.");
            Console.WriteLine($"\b");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        
        Console.WriteLine($"Total Points: {_score}");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The Goals are: ");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i}. { _goals[i].GetDetailString()}");
        }
        Console.WriteLine($"Your total score is now: {_score} points.");
    }

    public void CreateGoal()
    {
        
        Console.WriteLine("The types of goals are: ");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();
        
        Console.Write("What is the name of your goal?: ");
        string name = Console.ReadLine();
        
        Console.Write("What is a short description of it?: "); 
        string description = Console.ReadLine();
        
        Console.Write("What is the amount of points associated with this goal?: ");
        int points = GetValidIntegerInput("Invalid input. Please enter a valid number for points: ");

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points, false));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.WriteLine("How many times does this goal need to be accomplished for a bonus?: ");
                int target = GetValidIntegerInput("Enter target number of times: ", true);
                Console.WriteLine("What is the bonus for accomplishing it that many times?: ");
                int bonus = GetValidIntegerInput("Enter bonus points: ", true);
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        } 
    }

public void RecordEvent()
{
    
    if (_goals.Count == 0)
    {
        Console.WriteLine("No goals available to record events. Please create a goal first.");
        return;
    }

    ListGoalDetails();
    Console.Write("Enter the index of the goal to record: ");
    
    
    int index = GetValidIntegerInput("Invalid index. Please enter a valid index: ", false, _goals.Count - 1);
    
    
    int pointsEarned = _goals[index].RecordEvent();
    
    
    _score += pointsEarned;

    
    if (pointsEarned > 0)
    {
        Console.WriteLine($"Event recorded. You earned {pointsEarned} points!");
    }
    else
    {
        Console.WriteLine("Event recorded, but no points were earned (goal may already be complete).");
    }
    Console.WriteLine($"Your total score is now: {_score} points.");
}

    public void SaveGoals()
    {
        Console.Write("Enter the filename to save goals (e.g., goals.txt): ");
        string filePath = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename to load goals (e.g., goals.txt): ");
        string fullFileName = Console.ReadLine();

        if (File.Exists(fullFileName))
        {
            try
            {
                using (StreamReader reader = new StreamReader(fullFileName))
                {
                    if (int.TryParse(reader.ReadLine(), out int loadedScore))
                    {
                        _score = loadedScore;
                    }
                    else
                    {
                        Console.WriteLine("Invalid score format in file. Score will be reset to 0.");
                        _score = 0;
                    }
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length < 4)
                        {
                            Console.WriteLine("Invalid goal format in file. Skipping this entry.");
                            continue;
                        }

                        switch (parts[0])
                        {
                            case "SimpleGoal":
                                _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4].Trim())));
                                break;
                            case "EternalGoal":
                                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                                break;
                            case "ChecklistGoal":
                                if (parts.Length != 7)
                                {
                                    Console.WriteLine("Invalid checklist goal format in file. Skipping this entry.");
                                    continue;
                                }
                                int amountCompleted = int.Parse(parts[4]);
                                int target = int.Parse(parts[5]);
                                int bonus = int.Parse(parts[6]);
                                ChecklistGoal checklistGoal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), target, bonus);
                                for (int i = 0; i < amountCompleted; i++)
                                {
                                    checklistGoal.RecordEvent();
                                }
                                _goals.Add(checklistGoal);
                                break;
                            default:
                                Console.WriteLine("Unknown goal type in file.");
                                break;
                        }
                    }
                }
                Console.WriteLine("Goals loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading goals: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    private int GetValidIntegerInput(string errorMessage, bool allowZero = false, int maxValue = int.MaxValue)
{
    int result;
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out result) && (allowZero || result >= 0) && result <= maxValue)
        {
            return result;
        }
        Console.Write(errorMessage);
    }
}
}