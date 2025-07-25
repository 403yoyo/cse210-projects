using System;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetSpeed() => _speed;

    public override double GetDistance()
    {
        return _speed * GetMinutes() / 60;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}
