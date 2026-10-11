public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points,
        int target, int bonus, int amountCompleted = 0)
        : base(shortName, description, points)
    {
        _target = target > 0 ? target : 1;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        _amountCompleted++;
        int earnedPoints = Points;

        if (IsComplete())
        {
            earnedPoints += _bonus;
        }

        return earnedPoints;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "X" : " ";
        return $"[{status}] {ShortName} ({Description}) -- Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"Checklist|{ShortName}|{Description}|{Points}|{_target}|{_bonus}|{_amountCompleted}";
    }
}