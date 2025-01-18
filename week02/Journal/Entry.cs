public class Entry

{
    public string Prompt { get; }
    public string UserInput { get; }
    public string Date { get; }

    public Entry(string prompt, string userInput, string date)
    {
        Prompt = prompt;
        UserInput = userInput;
        Date = date;
    }

    public override string ToString()
    {
        return $"{Date}: {Prompt}\n{UserInput}";
    }
}