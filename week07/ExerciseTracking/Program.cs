using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");
        
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2021, 10, 1), 30, 5),
            new Bicycles(new DateTime(2021, 10, 2), 60, 20),
            new Swimming(new DateTime(2021, 10, 3), 45, 10)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}