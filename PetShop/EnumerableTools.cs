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
        Criteria<Pet> adapter = new AnonymousCriteria<Pet>(condition);
        return petsInTheStore.SatisfyThat(adapter);

    }

    public static IEnumerable<Pet> SatisfyThat(this IEnumerable<Pet> petsInTheStore, Criteria<Pet> criteria)
    {
        foreach (var pet in petsInTheStore)
        {
            if(criteria.isSatisfiedBy(pet))
                yield return pet;
        }
    }
}