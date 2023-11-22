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

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, Func<TItem, bool> condition)
    {
        Criteria<TItem> adapter = new AnonymousAdapterCriteria<TItem>(condition);
        return items.ThatSatisfy(adapter);
    }

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, Criteria<TItem> criteria)
    {
        foreach (var pet in items)
        {
            if (criteria.IsSatisfiedBy())
                yield return pet;
        }
    }
}

public class AnonymousAdapterCriteria<T> : Criteria<Pet>
{
    public AnonymousAdapterCriteria(Predicate<T, bool> condition)
    {
        throw new NotImplementedException();
    }

    public bool IsSatisfiedBy<T>(T item)
    {
        throw new NotImplementedException();
    }
}

public interface Criteria<T>
{
    bool IsSatisfiedBy();
}