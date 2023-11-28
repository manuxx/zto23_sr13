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

    public static IEnumerable<Pet> SatisfyThat(this IEnumerable<Pet> petsInTheStore, Predicate<Pet> condition)
    {
        return petsInTheStore.SatisfyThat(new AnonymousCriteria(condition));
    }

    public static IEnumerable<Pet> SatisfyThat(this IEnumerable<Pet> petsInTheStore, Criteria<Pet> criteria)
    {
        foreach (var pet in petsInTheStore)
        {
            if (criteria.IsSatisfyBy(pet))
                yield return pet;
        }
    }
}

public class AnonymousCriteria : Criteria<Pet>
{
    private readonly Predicate<Pet> _condition;

    public AnonymousCriteria(Predicate<Pet> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfyBy(Pet item)
    {
        return _condition(item);
    }
}

public interface Criteria<T>
{
    bool IsSatisfyBy(T item);
}