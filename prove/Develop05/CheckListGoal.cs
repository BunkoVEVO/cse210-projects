using System;

public class CheckListGoal : Goal
{
    public string goalType = "CheckList";
    public int goalPoints;
    public int goalTimes;
    public int timesCompleted;
    public int goalBonus;
    public bool goalComplete;

    public CheckListGoal() { }

    public CheckListGoal(string name, string description, int points, int times, int completed, int bonus, bool complete)
        : base(name, description)
    {
        goalPoints = points;
        goalTimes = times;
        timesCompleted = completed;
        goalBonus = bonus;
        goalComplete = complete;
    }

    public override void DisplayGoalPoints()
    {
        Console.Write("How many times do you want to complete this goal? ");
        goalTimes = int.Parse(Console.ReadLine());
        Console.Write("Points for each completion: ");
        goalPoints = int.Parse(Console.ReadLine());
        Console.Write("Bonus points when fully completed: ");
        goalBonus = int.Parse(Console.ReadLine());
    }

    public override int GetGoalPoints()
    {
        return timesCompleted >= goalTimes ? goalPoints + goalBonus : goalPoints;
    }

    public override bool GetGoalStatus() => goalComplete;

    public override string ToCSVRecord() =>
        $"{goalType}|{goalName}|{goalDescription}|{goalPoints}|{goalTimes}|{timesCompleted}|{goalBonus}|{goalComplete}";

    public override string ToString() =>
        $"[{(goalComplete ? "x" : " ")}] {goalName} ({goalDescription}) - Completed {timesCompleted}/{goalTimes}";

    public override int RecordEvent()
    {
        if (!goalComplete)
        {
            timesCompleted++;
            int pointsEarned = goalPoints;
            if (timesCompleted >= goalTimes)
            {
                goalComplete = true;
                pointsEarned += goalBonus;
                Console.WriteLine("You completed this goal & earned the bonus points!");
            }

            Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
            return pointsEarned;
        }
        else
        {
            Console.WriteLine("This goal has already been completed!");
            return 0;
        }
    }
}