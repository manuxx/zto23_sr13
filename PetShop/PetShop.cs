using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Training.DomainClasses
{
    public class PetShop
    {
        private IList<Pet> _petsInTheStore;

        public PetShop(IList<Pet> petsInTheStore)
        {
            this._petsInTheStore = petsInTheStore;
        }

        public IEnumerable<Pet> AllPets()
        {
            return new ReadOnly<Pet>(_petsInTheStore);
        }

        public IEnumerable<Pet> AllCats()
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species.Equals(Species.Cat))
                    yield return pet;
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var listToSort = new List<Pet>(_petsInTheStore);
            listToSort.Sort((x, y) => x.name.CompareTo(y.name));
            return listToSort;
        }

        public void Add(Pet newPet)
        {
            if (_petsInTheStore.Contains(newPet)) return;
            _petsInTheStore.Add(newPet);
        }
    }

    public class ReadOnly<Pet> : IEnumerable<Pet>
    {
        private readonly IEnumerable<Pet> _pets;

        public ReadOnly(IEnumerable<Pet> pets)
        {
            _pets = pets;
        }

        public IEnumerator<Pet> GetEnumerator()
        {
            return _pets.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}