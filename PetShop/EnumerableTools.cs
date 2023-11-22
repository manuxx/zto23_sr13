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
    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IList<TItem> items, Predicate<TItem> condition)
    {
        Criteria<TItem> adapter = new AnonymousCriteria<TItem>(condition);
        return items.ThatSatisfy(adapter);
    }
    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IList<TItem> items, Criteria<TItem> criteria)
    {
        foreach (var item in items)
        {
            if (criteria.IsSatisfiedBy(item))
                yield return item;
        }
    }
}