using System;
using System.Collections.Generic;

public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        // create an IEnumberable type, iterate through the given collection, applying the predicate
        List<T> kept = new List<T>();
        foreach (T item in collection)
        {
            if(predicate(item))
            {
                kept.Add(item);
            }
        }

        return kept;
    }

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        // create an IEnumberable type, iterate through the given collection, applying the predicate
        List<T> notKept = new List<T>();
        foreach (T item in collection)
        {

            if (!predicate(item))
            {
                notKept.Add(item);
            }
        }

        return notKept;
    }
}