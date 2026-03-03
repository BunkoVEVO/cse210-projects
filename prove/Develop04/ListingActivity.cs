using System;
using System.Diagnostics;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private string _randomPrompt;
    private List<string> _prompts;
    private static Random _rand = new Random();
    private static List<string> _usedPrompts = new List<string>();

    public ListingActivity() : base()
    {
        SetActivityName("Listing Activity");
        SetActivityDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        _prompts = new List<string>
        {
            "--- Who are people that you appreciate? ---",
            "--- What are personal strengths of yours? ---",
            "--- Who are people that you have helped this week? ---",
            "--- When have you felt the Holy Ghost this month? ---",
            "--- Who are some of your personal heroes? ---"
        };
    }

    public void RunListingActivity()
    {
        RunActivityParentStart();
        DisplayPrompt();
        ListingCounter();
        RunActivityParentEnd();
    }

    private void DisplayPrompt()
    {
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();

        // Get available prompts that haven’t been used yet
        var availablePrompts = new List<string>();
        foreach (var prompt in _prompts)
        {
            if (!_usedPrompts.Contains(prompt))
                availablePrompts.Add(prompt);
        }

        if (availablePrompts.Count == 0)
            _usedPrompts.Clear(); // reset if all used

        int randomIndex = _rand.Next(availablePrompts.Count);
        _randomPrompt = availablePrompts[randomIndex];
        _usedPrompts.Add(_randomPrompt);

        Console.WriteLine(_randomPrompt);
        Console.WriteLine();
    }

    private void ListingCounter()
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(GetUserSessionLengthInput());
        DateTime currentTime = DateTime.Now;
        int count = 0;

        while (currentTime < futureTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
            currentTime = DateTime.Now;
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {count} items.");
        DisplaySpinner(5);
    }
}