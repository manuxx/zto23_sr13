using System;
using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableTools
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    public static IEnumerable<TItem> FilterBy<TItem>(this IEnumerable<TItem> items, Func<TItem, bool> condition)
    {
        foreach (var item in items)
        {
            if (condition(item))
                yield return item;
        }
    }
}