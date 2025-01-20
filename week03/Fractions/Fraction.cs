public class Fractions
{
    private int _top;
    private int _bottom;
    
    public Fractions()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fractions(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fractions(int fortop, int forbottom)
    {
        _top = fortop;
        _bottom = forbottom;
    }
    public string GetFractionString()
    {
        string text = $"{_top}/{_bottom}";
        return text;
    }
    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}