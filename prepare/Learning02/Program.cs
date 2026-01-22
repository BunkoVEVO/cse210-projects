using System;

class Program
{
    static void Main(string[] args)
    {
        Job firstJob = new Job();
        firstJob._jobTitle = "Software Engineer";
        firstJob._company = "Microsoft";
        firstJob._startYear = 2019;
        firstJob._endYear = 2022;

        Job secondJob = new Job();
        secondJob._jobTitle = "Manager";
        secondJob._company = "Apple";
        secondJob._startYear = 2022;
        secondJob._endYear = 2023;

        Resume resume = new Resume();
        resume._name = "Allison Rose";

        resume._jobs.Add(firstJob);
        resume._jobs.Add(secondJob);

        resume.Display();
    }
}
