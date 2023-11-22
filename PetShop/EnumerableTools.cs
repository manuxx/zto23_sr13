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

    public static IEnumerable<Pet> ThatSatisfy(this IList<Pet> petsInTheStore, Predicate<Pet> condition)
    {
        //foreach (var pet in petsInTheStore)
        //{
        //    if (condition(pet))
        //        yield return pet;
        //}

        var adapter = new AnonymousCriteria<Pet>(condition);
        foreach (var pet in petsInTheStore)
        {
            if (adapter.IsSatisfiedBy(pet))
                yield return pet;
        }
    }

    public static IEnumerable<Pet> ThatSatisfy(this IList<Pet> petsInTheStore, Criteria<Pet> criteria)
    {
        foreach (var pet in petsInTheStore)
        {
            if (criteria.IsSatisfiedBy(pet))
                yield return pet;
        }
    }

   
}

public class AnonymousCriteria<T> : Criteria<T>
{
    private Predicate<T> _condition;

    public AnonymousCriteria(Predicate<T> condition)
    {
        _condition = condition;
        //throw new NotImplementedException();
    }

    public bool IsSatisfiedBy(T item)
    {
        return _condition(item);
        //throw new NotImplementedException();
    }
}

public interface Criteria<T>
{
    bool IsSatisfiedBy<Item>(Item item)
    {
        throw new NotImplementedException();
    }
}