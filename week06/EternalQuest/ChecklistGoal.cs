public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base (name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
        
    }
    public override int RecordEvent()
{
    if (_amountCompleted < _target)
    {
        _amountCompleted++;
        int earnedPoints = GetPoints();
        if (_amountCompleted == _target)
        {
            earnedPoints += _bonus;
        }
        return earnedPoints;
    }
    return 0;
}
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }
    public override string GetDetailString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {GetName()} - {GetDescription()} (Completed: {_amountCompleted}/{_target})";
    }
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal| {GetName()}| {GetDescription()}| {GetPoints()}| {_amountCompleted}|{_target}| {_bonus} ";
    }
}