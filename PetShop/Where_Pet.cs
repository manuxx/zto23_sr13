using System;
using Training.DomainClasses;

namespace Training.Specificaton
{
    public class Where<TItem>
    {
        public static CriteriaBuilder<TItem, TProperty> HasAn<TProperty>(Func<TItem, TProperty> propertySelector)
        {
            return new CriteriaBuilder<TItem, TProperty>(propertySelector);
        }

        public static ComparableCriteriaBuilder<TItem, TProperty> HasComparable<TProperty>(Func<TItem, TProperty> propertySelector) where TProperty : IComparable<TProperty>
        {
            return new ComparableCriteriaBuilder<TItem, TProperty>(propertySelector);
        }
    }

    public class CriteriaBuilder<TItem, TProperty>
    {
        private readonly Func<TItem, TProperty> _propertySelector;

        public CriteriaBuilder(Func<TItem, TProperty> propertySelector)
        {
            _propertySelector = propertySelector;
        }

        public Criteria<TItem> EqualTo(TProperty property)
        {
            return new AnonymousCriteria<TItem>(p => _propertySelector(p).Equals(property));
        }
    }

    public class ComparableCriteriaBuilder<TItem, TProperty> where TProperty : IComparable<TProperty>
    {
        private readonly Func<TItem, TProperty> _propertySelector;

        public ComparableCriteriaBuilder(Func<TItem, TProperty> propertySelector)
        {
            _propertySelector = propertySelector;
        }

        public Criteria<TItem> EqualTo(TProperty property)
        {
            return new AnonymousCriteria<TItem>(p => _propertySelector(p).Equals(property));
        }

        public Criteria<TItem> GreaterThan(TProperty property)
        {
            return new AnonymousCriteria<TItem>(p => _propertySelector(p).CompareTo(property) > 0);
        }
    }
}