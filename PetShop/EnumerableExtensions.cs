using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TItem> All<TItem>(this IEnumerable<TItem> items, Predicate<TItem> predicate)
        {
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}