using System;
using System.Collections.Generic;
using System.Linq;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        Dictionary<string, int> transformed = new Dictionary<string, int>();

        foreach (int point in old.Keys)
        {
            old.TryGetValue(point, out string[] valuesArr);
            for (int i = 0; i < valuesArr.Length; i++)
            {
                transformed[valuesArr[i].ToLower()] = point;
            }
        }

        return transformed;
    }
}