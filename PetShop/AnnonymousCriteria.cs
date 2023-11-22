using System;

public class AnnonymousCriteria<TItem> : Criteria<TItem>
{
    private Predicate<TItem> _condition;

    public AnnonymousCriteria(Predicate<TItem> condition)
    {
        _condition = condition;
    }

    public bool isSatisfiedBy(TItem sex)
    {
        return _condition(sex);

    }
}