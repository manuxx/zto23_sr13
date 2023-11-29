using System;
using System.Collections.Generic;
using System.Text;
using Training.DomainClasses;

public static class CriteriaExtension
{
    // from interface Criteria<TItem>

    // Criteria<TItem> Or(Criteria<TItem> other)
    // {
    //     return new Alternative<TItem>(this, other);
    // }
    //
    // Criteria<TItem> And(Criteria<TItem> other)
    // {
    //     return new Conjunction<TItem>(this, other);
    // }

    public static Criteria<TItem> Or<TItem>(this Criteria<TItem> criteria1, Criteria<TItem> criteria2)
    {
        return new Alternative<TItem>(criteria1, criteria2);
    }

    public static Criteria<TItem> And<TItem>(this Criteria<TItem> criteria1, Criteria<TItem> criteria2)
    {
        return new Conjunction<TItem>(criteria1, criteria2);
    }
}
