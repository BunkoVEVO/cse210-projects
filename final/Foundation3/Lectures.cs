using System; 

public class Lectures : Event
{
    public string _speakerName;    
    public int _capacity;    

    public Lectures(string title, string description, string date, string time, string address, string type, string speakerName, int capacity) 
        : base(title, description, date, time, address, type)
    {
        _speakerName = speakerName;
        _capacity = capacity;
    }

    public void DisplayLectureFullDetails()
    {
        DisplayFullDetails();
        Console.WriteLine($"Speaker: {_speakerName}");
        Console.WriteLine($"Capacity: {_capacity}");
    }
}