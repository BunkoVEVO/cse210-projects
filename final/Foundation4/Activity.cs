using System;

public abstract class Activity
{
    private string _date;
    private double _length;

    public Activity(double length)
    {
        _length = length;

        DateTime date = DateTime.Now;
        _date = date.ToString("dd MMM yyyy");
    }

    public string GetDate()
    {
        return _date;
    }

    public double GetLength()
    {
        return _length;
    }

    public abstract double CalculateDistance();
    public abstract double CalculateSpeed();
    public abstract double CalculatePace();
    public abstract void DisplaySummary();
}