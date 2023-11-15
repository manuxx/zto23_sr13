using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

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

        public void Add(Pet newPet)
        {
            if (_petsInTheStore.Contains(newPet)) return;
            _petsInTheStore.Add(newPet);
        }

        public IEnumerable<Pet> AllCats()
        {
            return _petsInTheStore.FilterBy(pet => pet.species == Species.Cat);
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            List<Pet> pets = new List<Pet>(_petsInTheStore);
            pets.Sort((pet1, pet2) => string.Compare(pet1.name, pet2.name, StringComparison.Ordinal));
            return pets;
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.FilterBy(pet => pet.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.FilterBy(pet => pet.sex == Sex.Female);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.FilterBy(pet => pet.species == Species.Cat || pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.FilterBy(pet => pet.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.FilterBy(pet => pet.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.FilterBy(pet => pet.yearOfBirth > 2010 && pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.FilterBy(pet => pet.sex == Sex.Male && pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.FilterBy(pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit);
        }
    }

    public class ReadOnly<TItem> : IEnumerable<TItem>
    {
        private readonly IEnumerable<TItem> _items;

        public ReadOnly(IEnumerable<TItem> items)
        {
            _items = items;
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}