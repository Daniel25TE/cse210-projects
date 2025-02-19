public abstract class Activity
{
    private DateTime _date;
    private int _length;
    
    public Activity(DateTime date, int length)
    {
        _date = date;
        _length = length;
    }
    public int Length => _length;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_length} minutes) - " + 
               $"Distance: {GetDistance():F1} km, Speed: {GetSpeed():F1} km/h, Pace: {GetPace():F2} min/km";
    }
}