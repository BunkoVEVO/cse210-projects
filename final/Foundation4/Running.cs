using System;

public class Running : Activity
{
    private double _distance;

    public Running(double length, double distance) : base(length)
    {
        _distance = distance;
    }

    public override double CalculateDistance()
    {
        return Math.Round(_distance, 1);
    }

    public override double CalculateSpeed()
    {
        double speed = (CalculateDistance() / GetLength()) * 60;
        return Math.Round(speed, 1);
    }

    public override double CalculatePace()
    {
        double pace = GetLength() / CalculateDistance();
        return Math.Round(pace, 1);
    }

    public override void DisplaySummary()
    {
        Console.WriteLine($"{GetDate()} Running ({GetLength()} min) - Distance: {CalculateDistance()} miles, Speed: {CalculateSpeed()}, Pace: {CalculatePace()} min per mile");
    }
}