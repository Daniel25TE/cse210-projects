using System.Runtime.InteropServices;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        
        
    }
    public string GetName()
    {
        return _name;
    }
    public string GetDescription()
    {
        return _description;
    }
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"\nWelcome to the {_name}.");
        Console.WriteLine("\b");
        Console.WriteLine(_description);
        Console.WriteLine("\b");
        Console.Write("How long in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(5);
        Console.WriteLine("\b");
        Console.WriteLine("\b");
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("Good job!");
        ShowSpinner(5);
        Console.WriteLine("\b");
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        ShowSpinner(5);
    }
    public void ShowCountDown(int second)
    {
        for (int i = second; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    public void ShowSpinner(int Seconds)
    {
        char[] spinnerChars = { '|', '/', '-', '\\' };

        for (int i = 0; i < Seconds; i++) 
        {
            Console.Write("\r" + spinnerChars[i % spinnerChars.Length]); 
            Thread.Sleep(1000); 
        }
    }
    public virtual void Run()
    {
        
    }
}