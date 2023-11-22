using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
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