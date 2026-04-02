using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(double length, int laps) : base(length)
    {
        _laps = laps;
    }

    public override double CalculateDistance()
    {
        double distance = (_laps * 50.0) / 1000.0 * 0.62;
        return Math.Round(distance, 1);
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
        Console.WriteLine($"{GetDate()} Swimming ({GetLength()} min) - Distance: {CalculateDistance()} miles, Speed: {CalculateSpeed()}, Pace: {CalculatePace()} min per mile");
    }
}