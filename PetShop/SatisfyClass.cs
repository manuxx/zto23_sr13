using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class AnonymousCriteria<TItem> : Criteria<TItem>
    {
        private readonly Func<TItem, bool> _condition;

        public AnonymousCriteria(Func<TItem, bool> condition)
        {
            _condition = condition;
        }

        public bool isSatisfiedBy(TItem item)
        {
            return _condition(item);
        }
    }

    public static class SatisfyClass
    {
        public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, Func<TItem, bool> condition)
        {
            Criteria<TItem> adapter = new AnonymousCriteria<TItem>(condition);
            return items.ThatSatisfy(adapter);
        }

        public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, Criteria<TItem> criteria)
        {
            foreach (var item in items)
            {
                if (criteria.isSatisfiedBy(item))
                    yield return item;
            }
        }
    }
}