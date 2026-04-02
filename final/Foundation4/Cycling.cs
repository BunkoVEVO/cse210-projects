using System;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(double length, double speed) : base(length)
    {
        _speed = speed;
    }

    public override double CalculateDistance()
    {
        double distance = GetLength() * CalculateSpeed() / 60;
        return Math.Round(distance, 1);
    }

    public override double CalculateSpeed()
    {
        return Math.Round(_speed, 1);
    }

    public override double CalculatePace()
    {
        double pace = 60 / CalculateSpeed();
        return Math.Round(pace, 1);
    }

    public override void DisplaySummary()
    {
        Console.WriteLine($"{GetDate()} Cycling ({GetLength()} min) - Distance: {CalculateDistance()} miles, Speed: {CalculateSpeed()}, Pace: {CalculatePace()} min per mile");
    }
}