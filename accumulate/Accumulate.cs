//  Date: 10-24-19
//  Exercism IO - Accumulate
//  Purpose: receive a collection and a method and use the method on the collection. return a new collection

//  SEE notes in README.md

using System;
using System.Collections.Generic;

public static class AccumulateExtensions
{
    public static IEnumerable<U> Accumulate<T, U>(this IEnumerable<T> collection, Func<T, U> func)
    {
        
        foreach (T item in collection)
        {
            yield return func(item);    
        }

    }
}