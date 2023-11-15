using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class EnumerableTools
    {
        public static IEnumerable<TItem> OneAtTheTime<TItem>(this IEnumerable<TItem> items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}