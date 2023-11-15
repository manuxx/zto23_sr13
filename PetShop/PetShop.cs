using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class EnumerableTools
    {
        public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }

    public class PetShop
    {
        private IList<Pet> _petsInTheStore;

        public PetShop(IList<Pet> petsInTheStore)
        {
            this._petsInTheStore = petsInTheStore;
        }

        public IEnumerable<Pet> AllPets()
        {
            return _petsInTheStore.OneAtATime();
        }

        public void Add(Pet newPet)
        {
            if (_petsInTheStore.Contains(newPet)) return;
            _petsInTheStore.Add(newPet);
        }
    }
}