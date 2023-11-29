using System;
using Training.DomainClasses;

public interface Criteria<TItem>
{
    //Criteria<TItem> And(Criteria<TItem> criteria)
    //{
    //    return new Conjuction<TItem>(this, criteria);
    //}
    bool IsSatisfiedBy(TItem item);

    public Conjuction<TItem> And(Criteria<TItem> crit2)
    {
        return new Conjuction<TItem>(this, crit2);
    }
}