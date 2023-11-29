using System;
using Training.DomainClasses;

public interface Criteria<TItem>
{
    bool IsSatisfiedBy(TItem item);
}