using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son");
       // Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
        
        Console.WriteLine("John 3:16");
        Console.WriteLine("For God so loved the world that he gave his one and only Son");
        Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
        while (true)
        {
            
            string input = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(input))
            
            {
                Console.Clear();
                scripture.HideRandomWords(3);
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
                if (scripture.IsCompletelyHidden())
                {
                    break;
                }
            }
            else if (input.ToLower() == "quit")
            {
                Console.WriteLine("You left the program.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Press Enter to continue or type 'quit' to exit.");
            }
        }
    
    }
}