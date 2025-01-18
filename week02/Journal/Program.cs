using System;
class Program
{
    static void Main(string[] args)
    {
        
        Journal journal = new Journal();
        Console.WriteLine("Welcome to the journal program!!");
        
        int userChoice = 0;

        while (userChoice != 5)
        {
            Console.WriteLine("Please Select one of the following choices:");
        
    
            Console.WriteLine("1. Write:");
            Console.WriteLine("2. Display:");
            Console.WriteLine("3. Load:");
            Console.WriteLine("4. Save:");
            Console.WriteLine("5. Quit");
            Console.WriteLine("What would you like to do?");
            string input = Console.ReadLine();
            if (int.TryParse(input, out userChoice))
            {
                switch (userChoice)
                {
                    case 1:
                    {
                        journal.AddEntry();
                        break;
                    }
                    case 2:
                    {
                        journal.DisplayAll();
                        break;
                    }
                    case 3:
                    {
                        journal.LoadFromFile();
                        break;
                    }
                    case 4:
                    {
                        journal.SaveToFile();
                        break;
                    }
                }
            }
       }
    }   
}