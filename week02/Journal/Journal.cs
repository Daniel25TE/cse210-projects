public class Journal
{
    public List<Entry> _entries;
    public Journal()
    {
        _entries = new List<Entry>();
    }
    public void AddEntry()
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        string randomPrompt = promptGenerator.GetRandomPrompt();
        
        
        Console.WriteLine (randomPrompt);
        string userInput = Console.ReadLine();

        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        
        if (!string.IsNullOrWhiteSpace(userInput))
        {
            Entry newEntry = new Entry(randomPrompt, userInput, dateText);
            _entries.Add(newEntry);

            
        }
        else
        {
            Console.WriteLine("Entry cannot be empty.");
        }
        
    }
    
    public void DisplayAll()
    {
        Console.WriteLine("Journal Entries:");
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry.ToString());
            
        }
    }
    public void SaveToFile()
    {
        
        Console.Write("Please enter the file name (without extension): ");
        string fileName = Console.ReadLine();
        Console.Write("Please enter the file extension (e.g., txt, csv): ");
        string fileExtension = Console.ReadLine();

        string fullFileName = $"{fileName}.{fileExtension}";
        try
        {
            
            var stringBuilder = new System.Text.StringBuilder();

            foreach (var entry in _entries)
            {
                stringBuilder.AppendLine(entry.ToString()); 
            }

            
            File.WriteAllText(fullFileName, stringBuilder.ToString());
            Console.WriteLine($"All entries have been saved to {fullFileName}.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while saving the file: {e.Message}");
        }
        
    }
    public void LoadFromFile()
    {
        
        Console.Write("Please enter the file name to load (without extension): ");
        string fileName = Console.ReadLine();
        Console.Write("Please enter the file extension (e.g., txt, csv): ");
        string fileExtension = Console.ReadLine();

        string fullFileName = $"{fileName}.{fileExtension}";

        try
        {
            if (File.Exists(fullFileName))
            {
                Console.WriteLine($"Entries loaded from {fullFileName}.");
                Console.WriteLine("\nLoaded Entries:");
                var lines = File.ReadAllLines(fullFileName);
                _entries.Clear(); 

                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }

            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while loading the file: {e.Message}");
        }
    }
}