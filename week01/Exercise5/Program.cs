using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");
        DisplayMessage();
        
        string userName = PromptUserName();
        
        int favoriteNumber = PromptUserNumber();
        
        int square = SquareNumber(favoriteNumber);
        
        DisplayResult(userName, square);

    }

    static void DisplayMessage()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name: ");
        return Console.ReadLine();
    }
    static int PromptUserNumber()
    {
        Console.WriteLine("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
        
    }
    static int SquareNumber(int number)
    {
        return number * number;
    }
    
    static void DisplayResult(string userName, int square)
    {
        Console.WriteLine($"{userName}, the square of your favorite number is: {square}");
    }
}