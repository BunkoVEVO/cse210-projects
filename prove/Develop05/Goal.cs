using System;

public class Goal
{
    public string goalName;
    public string goalDescription;

    public Goal() { }

    public Goal(string name, string description)
    {
        goalName = name;
        goalDescription = description;
    }

    public virtual void DisplayGoalPoints() { }

    public virtual int GetGoalPoints() { return 0; }

    public virtual bool GetGoalStatus() { return false; }

    public virtual string ToCSVRecord() { return ""; }

    public virtual int RecordEvent() { return 0; }

    public string DisplayGoalName()
    {
        Console.Write("Enter the goal name: ");
        goalName = Console.ReadLine();
        return goalName;
    }

    public string DisplayGoalDescription()
    {
        Console.Write("Enter the goal description: ");
        goalDescription = Console.ReadLine();
        return goalDescription;
    }
}