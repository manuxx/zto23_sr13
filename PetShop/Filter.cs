using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class Filter
    {
        public static IEnumerable<Pet> FilterBy(IList<Pet> petsInTheStore, Func<Pet, bool> condition)
        {
            foreach (var pet in petsInTheStore)
            {
                if (condition(pet))
                    yield return pet;
            }
        }
    }
}