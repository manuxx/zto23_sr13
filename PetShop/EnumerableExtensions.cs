using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, Predicate<TItem> predicate)
        {
            return items.ThatSatisfy(new AnonymousCriteria<TItem>(predicate));
        }
        
        public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, ICriteria<TItem> criteria)
        {
            foreach (var item in items)
            {
                if (criteria.IsSatisfiedBy(item))
                {
                    yield return item;
                }
            }
        }
    }
}