using System;
using System.Collections.Generic;


public abstract class Activity
{
    protected DateTime _date;
    protected int _duration; 

    public Activity(DateTime date, int duration)
    {
        _date = date;
        _duration = duration;
    }

    public virtual double GetDistance()
    {
        return 0; 
    }

    public virtual double GetSpeed()
    {
        return 0; 
    }

    public virtual double GetPace()
    {
        double distance = GetDistance();
        return distance > 0 ? (_duration / distance) : 0; 
    }

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} - Duration: {_duration} min";
    }
}


public class Running : Activity
{
    private double _distance; 

    public Running(DateTime date, int duration, double distance) : base(date, duration)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / _duration) * 60; 
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" Running - Distance: {_distance:F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F2} min per mile";
    }
}


public class Cycling : Activity
{
    private double _speed; 

    public Cycling(DateTime date, int duration, double speed) : base(date, duration)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed * _duration) / 60; 
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" Cycling - Distance: {GetDistance():F1} miles, Speed: {_speed} mph, Pace: {60 / _speed:F2} min per mile";
    }
}


public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return (_laps * 50) / 1000.0 * 0.62; 
    }

    public override double GetSpeed()
    {
        return (GetDistance() / _duration) * 60; 
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" Swimming - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F2} min per mile";
    }
}


class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 2, 3), 30, 3.0),
            new Cycling(new DateTime(2024, 5, 4), 45, 12.0),
            new Swimming(new DateTime(2024, 6, 5), 30, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
