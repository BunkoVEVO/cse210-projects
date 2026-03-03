using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private static Random _rand = new Random();
    private static List<string> _usedPrompts = new List<string>();

    public ReflectingActivity() : base()
    {
        SetActivityName("Reflection Activity");
        SetActivityDescription("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        _prompts = new List<string>
        {
            "--- Think of a time when you stood up for someone else. ---",
            "--- Think of a time when you did something really difficult. ---",
            "--- Think of a time when you helped someone in need. ---",
            "--- Think of a time when you did something truly selfless. ---"
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void RunReflectingActivity()
    {
        RunActivityParentStart();
        DisplayPrompt();
        DisplayQuestions();
        RunActivityParentEnd();
    }

    private void DisplayPrompt()
    {
        Console.WriteLine("Consider the following: ");
        Console.WriteLine();

        // Avoid repeating prompts
        var availablePrompts = new List<string>();
        foreach (var prompt in _prompts)
        {
            if (!_usedPrompts.Contains(prompt))
                availablePrompts.Add(prompt);
        }

        if (availablePrompts.Count == 0)
            _usedPrompts.Clear();

        int randomIndex = _rand.Next(availablePrompts.Count);
        string selectedPrompt = availablePrompts[randomIndex];
        _usedPrompts.Add(selectedPrompt);

        Console.WriteLine(selectedPrompt);
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
    }

    private void DisplayQuestions()
    {
        List<int> indexes = new List<int>();

        for (int i = 0; i < 4; i++)
        {
            int randomInt = _rand.Next(_questions.Count);
            while (indexes.Contains(randomInt))
            {
                randomInt = _rand.Next(_questions.Count);
            }
            indexes.Add(randomInt);
        }

        Console.Clear();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.WriteLine();
        DisplayCountdown(5);

        int sessionLength = GetUserSessionLengthInput();
        foreach (int index in indexes)
        {
            Console.Write(_questions[index]);
            DisplaySpinner(sessionLength / indexes.Count);
            Console.WriteLine();
        }
    }
}