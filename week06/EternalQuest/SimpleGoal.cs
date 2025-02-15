public class SimpleGoal : Goal
{
    private bool _isCompleteSimple;

    public SimpleGoal(string name, string description, int points, bool isComplete) : base (name, description, points)
    {
       _isCompleteSimple = isComplete;
    }
    
    public override int RecordEvent()
    {
        if (!_isCompleteSimple)
        {
            _isCompleteSimple = true;
            return GetPoints();
        }
        return 0;
    }
    public override bool IsComplete()
    {
        return _isCompleteSimple;
    }
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal| {GetName()}| {GetDescription()}| {GetPoints()}| {_isCompleteSimple} ";
    }
}