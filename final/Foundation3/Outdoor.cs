using System; 

public class Outdoor : Event
{   
    public string _weather;   

    public Outdoor(string title, string description, string date, string time, string address, string type, string weather) 
        : base(title, description, date, time, address, type)
    {
        _weather = weather;
    }

    public void DisplayOutdoorFullDetails()
    {
        DisplayFullDetails();
        Console.WriteLine($"Weather: {_weather}");
    }
}