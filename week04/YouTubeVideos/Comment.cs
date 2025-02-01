public class Comment

{
    private string _name;
    private string _text;

    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }
    
    public string Name()
    {
        return _name;
    }   
    public string Text()
    {
        return _text;
    }
}