using System;

class Program
{
    static void Main(string[] args)
    {
        AllGoals allGoals = new AllGoals();
        int userMainMenuSelection = 0;

        Console.Clear();
        Console.WriteLine("Welcome to the Goal Tracking App!\n");

        while (userMainMenuSelection != 6)
        {
            Menu menu = new Menu();

            allGoals.DisplayPoints();
            Console.WriteLine();

            menu.DisplayMainMenu();

            // Safe input handling
            while (!int.TryParse(Console.ReadLine(), out userMainMenuSelection) 
                   || userMainMenuSelection < 1 || userMainMenuSelection > 6)
            {
                Console.WriteLine("Please enter a valid option (1-6):");
            }

            Console.Clear();

            switch (userMainMenuSelection)
            {
                case 1: // Create new goal
                    menu.DisplayNewGoalMenu();
                    int userNewGoalSelection;

                    while (!int.TryParse(Console.ReadLine(), out userNewGoalSelection) 
                           || userNewGoalSelection < 1 || userNewGoalSelection > 3)
                    {
                        Console.WriteLine("Please select a valid goal type (1-3):");
                    }

                    Console.Clear();
                    Goal goal = null;

                    if (userNewGoalSelection == 1)
                        goal = new SimpleGoal();
                    else if (userNewGoalSelection == 2)
                        goal = new EternalGoal();
                    else
                        goal = new CheckListGoal();

                    // Prompt for name, description, and points
                    goal.DisplayGoalName();
                    goal.DisplayGoalDescription();
                    goal.DisplayGoalPoints();

                    if (goal != null)
                        allGoals.addGoal(goal);

                    break;

                case 2: // List goals
                    allGoals.DisplayGoals();
                    break;

                case 3: // Save goals
                    allGoals.SaveGoals();
                    break;

                case 4: // Load goals
                    allGoals.LoadGoals();
                    break;

                case 5: // Record event
                    allGoals.DisplayGoalRecordEvent();
                    break;

                case 6: // Quit
                    Console.Write("Do you want to save before you quit (y/n)? ");
                    string userInput = Console.ReadLine().ToLower();

                    if (userInput == "y")
                        allGoals.SaveGoals();

                    Console.WriteLine("\nThank you! Goodbye.");
                    break;

                default:
                    Console.WriteLine("Please select a valid option.");
                    break;
            }
        }
    }
}