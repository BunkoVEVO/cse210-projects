using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address ("Avenida Dom João II", "Lisbon", "Lisbon", "1990-365", "Portugal");
        string lectureAddress = address1.GetAddress();
        Lectures lecture = new Lectures("Stake Conference", "Church meeting with members of the Almada Stake.", "March 5, 2023", "10:00 am - 12:00 pm", $"{lectureAddress}", "Lecture", "Elder Pokhylko", 400);

        //display lecture event details
        Console.WriteLine("---------------------------------------------------------------------------");
        lecture.DisplayShortDescription();
        Console.WriteLine();
        lecture.DisplayStandardDetails();
        Console.WriteLine();
        lecture.DisplayLectureFullDetails();


        Address address2 = new Address ("Estr. Q.ta do Torneiro", "Lisbon", "Lisbon", "2700-144", "Portugal");
        string receptionAddress = address2.GetAddress();
        Receptions reception = new Receptions("Marta and Renato", "Marta and Renato's wedding ceremony and reception", "September 2, 2022", "4:00 pm - 12:00am", $"{receptionAddress}", "Reception", "mandr@gmail.com");
        //display reception event details
        Console.WriteLine("---------------------------------------------------------------------------");
        reception.DisplayShortDescription();
        Console.WriteLine();
        reception.DisplayStandardDetails();
        Console.WriteLine();
        reception.DisplayReceptionsFullDetails();


        Address address3 = new Address ("5200 Emerald Pkwy", "Dublin", "OH", "43017", "USA");
        string outdoorAddress = address3.GetAddress();
        Outdoor outdoor = new Outdoor("YM & YM Activity", "Sports night at the park for all youth.", "February 28, 2023", "6:00 pm", $"{outdoorAddress}", "Outdoor", "Sunny");
        //display outdoor event details
        Console.WriteLine("---------------------------------------------------------------------------");
        
        outdoor.DisplayShortDescription();
        Console.WriteLine();
        outdoor.DisplayStandardDetails();
        Console.WriteLine();
        outdoor.DisplayOutdoorFullDetails();
        Console.WriteLine("---------------------------------------------------------------------------");
        
    }
}