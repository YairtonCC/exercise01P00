namespace POO.Backend;
using System;

public class Time
{
    private int _hour;
    private int _minute;
    private int _second;
    private int _millisecond;


    //Constructors

    public Time()
    {
        Hour = 0;
        Minute = 0;
        Second = 0;
        Millisecond = 0;
    }

    public Time(int hour)
    {
        Hour = hour;
        Minute = 0;
        Second = 0;
        Millisecond = 0;
    }

    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
        Second = 0;
        Millisecond = 0;
    }

    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = 0;
    }

    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
    }

    // Propieties
    public int Hour
    {
        get => _hour;
        set
        {
            ValidateHour(value);
            _hour = value;
        }
    }

    public int Minute
    {
        get => _minute;
        set
        {
            ValidateMinute(value);
            _minute = value;
        }
    }

    public int Second
    {
        get => _second;
        set
        {
            ValidateSecond(value);
            _second = value;
        }
    }

    public int Millisecond
    {
        get => _millisecond;
        set
        {
            ValidateMillisecond(value);
            _millisecond = value;
        }
    }

    //validations
    private void ValidateHour(int value)
    {
        if (value < 0 || value > 23)
            throw new ArgumentOutOfRangeException($"The hour: {value}, is not valid.");
    }

    private void ValidateMinute(int value)
    {
        if (value < 0 || value > 59)
            throw new ArgumentOutOfRangeException($"The minute: {value}, is not valid.");
    }

    private void ValidateSecond(int value)
    {
        if (value < 0 || value > 59)
            throw new ArgumentOutOfRangeException($"The second: {value}, is not valid.");
    }

    private void ValidateMillisecond(int value)
    {
        if (value < 0 || value > 999)
            throw new ArgumentOutOfRangeException($"The millisecond: {value}, is not valid.");
    }

    //methods
    public override string ToString()
    {
        var dt = new DateTime(1, 1, 1, Hour, Minute, Second, Millisecond);
        return dt.ToString("hh:mm:ss.fff tt");
    }

    public int ToMilliseconds()
    {
        return (Hour * 3600000) +
               (Minute * 60000) +
               (Second * 1000) +
               Millisecond;
    }

    public int ToSeconds()
    {
        return (Hour * 3600) +
               (Minute * 60) +
               Second;
    }

    public int ToMinutes()
    {
        return (Hour * 60) + Minute;
    }

    public bool IsOtherDay(Time other)
    {
        return (this.ToMilliseconds() + other.ToMilliseconds())
                >= 24 * 60 * 60 * 1000;
    }

    public Time Add(Time other)
    {
        int totalMilliseconds = this.ToMilliseconds() + other.ToMilliseconds();

        int hours = (totalMilliseconds / 3600000) % 24;
        totalMilliseconds %= 3600000;

        int minutes = totalMilliseconds / 60000;
        totalMilliseconds %= 60000;

        int seconds = totalMilliseconds / 1000;
        int milliseconds = totalMilliseconds % 1000;

        return new Time(hours, minutes, seconds, milliseconds);
    }
}

    