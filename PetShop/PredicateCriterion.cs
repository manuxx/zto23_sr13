using System;
using PetShop;

namespace Training.DomainClasses
{
    public class PredicateCriterion<TItem> : ICriterion<TItem>
    {
        private readonly Predicate<TItem> _condition;

        public PredicateCriterion(Predicate<TItem> condition)
        {
            _condition = condition;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return _condition(item);
        }
    }
}