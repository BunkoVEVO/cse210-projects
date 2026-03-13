using System;

public class EternalGoal : Goal
{
    public string goalType = "Eternal";
    public int goalPoints;
    public int timesCompleted;

    public EternalGoal() { }

    public EternalGoal(string name, string description, int points, int completed)
        : base(name, description)
    {
        goalPoints = points;
        timesCompleted = completed;
    }

    public override void DisplayGoalPoints()
    {
        Console.Write("Enter the points for this goal each time: ");
        goalPoints = int.Parse(Console.ReadLine());
    }

    public override int GetGoalPoints() => goalPoints;

    public override bool GetGoalStatus() => false;

    public override string ToCSVRecord() =>
        $"{goalType}|{goalName}|{goalDescription}|{goalPoints}|{timesCompleted}|false";

    public override string ToString() =>
        $"[ ] {goalName} ({goalDescription}) - Completed {timesCompleted} times";

    public override int RecordEvent()
    {
        timesCompleted++;
        Console.WriteLine($"Congratulations! You earned {goalPoints} points!");
        return goalPoints;
    }
}