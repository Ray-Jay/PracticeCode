using System;

public static class Gigasecond
{
    public static DateTime Add(DateTime moment)
    {
        return moment.AddSeconds(1E9);      // 1 x 10^9 = 1_000_000_000
    }
}