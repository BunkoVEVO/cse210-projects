using System;
using System.Collections.Generic;

public class AllGoals
{
    public List<Goal> allGoals = new List<Goal>();
    public int totalPoints = 0;
    public string fileName = "";

    public void addGoal(Goal goal)
    {
        allGoals.Add(goal);
    }

    public void DisplayPoints()
    {
        Console.WriteLine("Total Points: " + totalPoints);
    }

    public void DisplayGoals()
    {
        if (allGoals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        Console.WriteLine("Your goals:");

        for (int i = 0; i < allGoals.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + allGoals[i].ToString());
        }

        Console.WriteLine();
    }

    public void SaveGoals()
    {
        if (allGoals.Count == 0)
        {
            Console.WriteLine("No goals to save.");
            return;
        }

        Console.Write("Enter filename to save: ");
        fileName = Console.ReadLine();

        List<string> saveGoals = new List<string>();
        saveGoals.Add(totalPoints.ToString());

        for (int i = 0; i < allGoals.Count; i++)
        {
            saveGoals.Add(allGoals[i].ToCSVRecord());
        }

        SaveLoadCSV.SaveToCSV(saveGoals, fileName);
        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        fileName = Console.ReadLine();

        List<string> fileGoals = SaveLoadCSV.LoadFromCSV(fileName);

        allGoals.Clear();
        totalPoints = 0;

        for (int i = 1; i < fileGoals.Count; i++)
        {
            string[] parts = fileGoals[i].Split('|');
            string type = parts[0];

            Goal goal = null;

            if (type == "Simple")
            {
                goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
            }
            else if (type == "Eternal")
            {
                goal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]));
            }
            else if (type == "CheckList")
            {
                goal = new CheckListGoal(parts[1], parts[2], int.Parse(parts[3]),
                    int.Parse(parts[4]), int.Parse(parts[5]),
                    int.Parse(parts[6]), bool.Parse(parts[7]));
            }

            if (goal != null)
            {
                allGoals.Add(goal);
            }
        }

        for (int i = 0; i < allGoals.Count; i++)
        {
            totalPoints = totalPoints + allGoals[i].GetGoalPoints();
        }

        Console.WriteLine("Goals loaded.");
    }

    public void DisplayGoalRecordEvent()
    {
        if (allGoals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }

        Console.WriteLine("Goals:");

        for (int i = 0; i < allGoals.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + allGoals[i].ToString());
        }

        Console.Write("Which goal did you complete? ");

        int choice;

        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > allGoals.Count)
        {
            Console.WriteLine("Please select a valid goal number:");
        }

        choice = choice - 1;

        int pointsEarned = allGoals[choice].RecordEvent();
        totalPoints = totalPoints + pointsEarned;

        Console.WriteLine("Total Points: " + totalPoints);
        Console.WriteLine();
    }
}