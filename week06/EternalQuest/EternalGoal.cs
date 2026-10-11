public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override int RecordEvent()
    {
        return Points;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {ShortName} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        return $"Eternal|{ShortName}|{Description}|{Points}";
    }
}