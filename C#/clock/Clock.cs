using System;

public class Clock
{
    // properties
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int TimeInMinutes { get; set; }

    // constructor
    public Clock(int hours, int minutes)
    {
        TimeInMinutes = hours * 60 + minutes;
        ConvertTime();
    }

    // methods
    // returns new clock object with added minutes
    public Clock Add(int minutesToAdd) => new Clock(this.Hours, this.Minutes + minutesToAdd);

    // calls Add method, sending negative minutes. returns new clock object
    public Clock Subtract(int minutesToSubtract) => Add(-minutesToSubtract);

    // converts time in minutes to hours and minutes. If hours are negative, add to 24. If minutes are negative, add to 60
    // and adjust hours.
    public void ConvertTime()
    {
        Hours = TimeInMinutes / 60 % 24;
        Minutes = TimeInMinutes % 60;
        if (Hours < 0)
        {
            Hours += 24;
        }
        if (Minutes < 0)
        {
            Minutes += 60;
            Hours = (Hours - 1 + 24) % 24;
        }
    }

    // returns string with time formatted as HH:MM
    public override string ToString() => $"{Hours.ToString("D2")}:{Minutes.ToString("D2")}";

    // checks hour and minute values to determine equality
    public override bool Equals(Object obj)
    {
        Clock other = (Clock)obj;
        return this.Hours == other.Hours && this.Minutes == other.Minutes;
    }
}