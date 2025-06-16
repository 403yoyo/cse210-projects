public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _currentCount++;
        int pointsEarned = GetPoints();
        if (_currentCount == _targetCount)
        {
            pointsEarned += _bonus;
            Console.WriteLine($"Congrats! You completed the goal and earned a bonus of {_bonus} points!");
        }
        Console.WriteLine($"Event recorded! You earned {pointsEarned} points.");
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {GetName()} ({GetDescription()}) -- Completed {_currentCount}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetName()}|{GetDescription()}|{GetPoints()}|{_bonus}|{_targetCount}|{_currentCount}";
    }
}
