public class ListingActivity : Activity
{
   
    private List<string> _prompts;

    public void Prompts()
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
        };
    }
    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        Prompts();
    }
    public override void Run()
    {
        string prompt = GetRandomPrompt();
        DisplayStartingMessage();
        Console.WriteLine("List as many responses you can to the following prompt: ");
        Console.WriteLine($"---{prompt}---");
        ShowSpinner(8);
        
        List<string> items = GetListFromUser ();
        DisplayEndingMessage();
    }
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        Console.WriteLine (_prompts[index]);
        return _prompts[index];
    }
    public List<string> GetListFromUser()
    {
        Console.WriteLine("Start listing items (press Enter after each item). You have " + _duration + " seconds.");
        Console.WriteLine("You may begin in: ");
        ShowCountDown(5);
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }
        Console.WriteLine($"You listed {items.Count} items.");
        Console.WriteLine("\b");
        return items;
    }
}