using System;
using System.Collections.Generic;

public class AllGoals
{
    public List<Goal> allGoals = new List<Goal>();
    public int totalPoints;
    public string fileName;

    public void addGoal(Goal goal)
    {
        allGoals.Add(goal);
    }

    public void DisplayPoints()
    {
        Console.WriteLine($"Total Points: {totalPoints}");
    }

    public void DisplayGoals()
    {
        if (allGoals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        Console.WriteLine("Your goals:");
        foreach (Goal goal in allGoals)
            Console.WriteLine($"{allGoals.IndexOf(goal) + 1}. {goal}");
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
        foreach (Goal goal in allGoals)
            saveGoals.Add(goal.ToCSVRecord());

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

        for (int i = 1; i < fileGoals.Count; i++) // skip total points line
        {
            string[] parts = fileGoals[i].Split('|');
            string type = parts[0];
            Goal goal = null;

            if (type == "Simple")
                goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
            else if (type == "Eternal")
                goal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]));
            else if (type == "CheckList")
                goal = new CheckListGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]),
                                          int.Parse(parts[5]), int.Parse(parts[6]), bool.Parse(parts[7]));

            if (goal != null)
                allGoals.Add(goal);
        }

        foreach (Goal g in allGoals)
            totalPoints += g.GetGoalPoints();

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
        foreach (Goal g in allGoals)
            Console.WriteLine($"{allGoals.IndexOf(g) + 1}. {g}");

        Console.Write("Which goal did you complete? ");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > allGoals.Count)
            Console.WriteLine("Please select a valid goal number:");

        choice--; // convert to index
        int pointsEarned = allGoals[choice].RecordEvent();
        totalPoints += pointsEarned;

        Console.WriteLine($"Total Points: {totalPoints}\n");
    }
}