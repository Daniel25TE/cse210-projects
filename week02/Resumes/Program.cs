using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");

        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Apple";
        job1._startYear = 2025;
        job1._endYear= 2029;

        Job job2 = new Job();
        job2._jobTitle = "Back-end Developer";
        job2._company = "Microsoft";
        job2._startYear = 2026;
        job2._endYear= 2030;


        Resume myResume = new Resume();
        myResume._name = "Allison Rose";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
        
    }
}