using System;
using Training.DomainClasses;
using static Training.DomainClasses.Pet;

public interface Criteria<TItem>
{
    bool IsSatisfiedBy(TItem item);
}