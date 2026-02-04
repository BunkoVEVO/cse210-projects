using System;

class Program
{
    static void Main(string[] args)
    {
        // Constructor tests
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(5);
        Fraction f3 = new Fraction(3, 4);
        Fraction f4 = new Fraction(1, 3);

        DisplayFraction(f1);
        DisplayFraction(f2);
        DisplayFraction(f3);
        DisplayFraction(f4);

        Console.WriteLine();

        // Practice using setters with random values
        Fraction randomFraction = new Fraction();
        Random rand = new Random();

        for (int i = 1; i <= 20; i++)
        {
            int top = rand.Next(1, 10);
            int bottom = rand.Next(1, 10);

            randomFraction.SetTop(top);
            randomFraction.SetBottom(bottom);

            Console.WriteLine(
                $"Fraction {i}: string: {randomFraction.GetFractionString()} " +
                $"Number: {randomFraction.GetDecimalValue()}"
            );
        }
    }

    static void DisplayFraction(Fraction f)
    {
        Console.WriteLine(f.GetFractionString());
        Console.WriteLine(f.GetDecimalValue());
    }
}
