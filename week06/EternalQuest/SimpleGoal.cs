public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points,
        bool isComplete = false)
        : base(shortName, description, points)
    {
        _isComplete = isComplete;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }

        _isComplete = true;
        return Points;
    }

    public override string GetDetailsString()
    {
        string status = _isComplete ? "X" : " ";
        return $"[{status}] {ShortName} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        return $"Simple|{ShortName}|{Description}|{Points}|{_isComplete}";
    }
}