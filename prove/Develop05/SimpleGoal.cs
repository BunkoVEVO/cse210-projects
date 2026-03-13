using System;

public class SimpleGoal : Goal
{
    public string goalType = "Simple";
    public int goalPoints;
    public bool goalComplete;

    public SimpleGoal() { }

    public SimpleGoal(string name, string description, int points, bool complete)
        : base(name, description)
    {
        goalPoints = points;
        goalComplete = complete;
    }

    public override void DisplayGoalPoints()
    {
        Console.Write("Enter the points for this goal: ");
        goalPoints = int.Parse(Console.ReadLine());
    }

    public override int GetGoalPoints() => goalPoints;

    public override bool GetGoalStatus() => goalComplete;

    public override string ToCSVRecord() =>
        $"{goalType}|{goalName}|{goalDescription}|{goalPoints}|{goalComplete}";

    public override string ToString() =>
        $"[{(goalComplete ? "x" : " ")}] {goalName} ({goalDescription})";

    public override int RecordEvent()
    {
        if (!goalComplete)
        {
            goalComplete = true;
            Console.WriteLine($"Congratulations! You earned {goalPoints} points!");
            return goalPoints;
        }
        else
        {
            Console.WriteLine("This goal has already been completed!");
            return 0;
        }
    }
}