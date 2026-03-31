using System;
using System.Collections.Generic;

public class Menu
{
    public List<string> mainMenu = new List<string>();
    public List<string> createGoalMenu = new List<string>();

    public Menu()
    {
        mainMenu.Add("Menu Options:");
        mainMenu.Add("  1. Create New Goal");
        mainMenu.Add("  2. List Goals");
        mainMenu.Add("  3. Save Goals");
        mainMenu.Add("  4. Load Goals");
        mainMenu.Add("  5. Record Event");
        mainMenu.Add("  6. Quit");

        createGoalMenu.Add("The types of Goals are:");
        createGoalMenu.Add("  1. Simple Goal");
        createGoalMenu.Add("  2. Eternal Goal");
        createGoalMenu.Add("  3. CheckList Goal");
    }

    public void DisplayMainMenu()
    {
        for (int i = 0; i < mainMenu.Count; i++)
        {
            Console.WriteLine(mainMenu[i]);
        }

        Console.Write("Select a choice: ");
    }

    public void DisplayNewGoalMenu()
    {
        for (int i = 0; i < createGoalMenu.Count; i++)
        {
            Console.WriteLine(createGoalMenu[i]);
        }

        Console.Write("Select a choice from the menu: ");
    }
}