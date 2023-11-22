using System;
using System.Collections.Generic;

public static class EnumerableTools
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    public static IEnumerable<TItem> SelectAll<TItem>(this IEnumerable<TItem> items, Predicate<TItem> condition)
    {
        foreach (var item in items)
        {
            if (condition(item))
                yield return item;
        }
    }

    public static Predicate<TItem> And<TItem>(this Predicate<TItem> first, Predicate<TItem> second)
    {
        return item => first(item) && second(item);
    }

    public static Predicate<TItem> Or<TItem>(this Predicate<TItem> first, Predicate<TItem> second)
    {
        return item => first(item) || second(item);
    }
}