using System;
using System.Collections;
using System.Collections.Generic;

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
            foreach (var pet in _petsInTheStore)
            {
                if(pet.species==Species.Cat)
                    yield return pet;
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return result;
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.All(p => p.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.All(p => p.sex == Sex.Female);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.All(p => p.species == Species.Cat || p.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.All(p => p.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.All(p => p.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return AllPetsBornAfter2010().All(p => p.species == Species.Dog);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.All(p => p.sex == Sex.Male && p.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.All(p => p.yearOfBirth > 2011 || p.species == Species.Rabbit);
        }
    }

    public class ReadOnly<TItem> : IEnumerable<TItem>
    {
        private readonly IEnumerable<TItem> _pets;

        public ReadOnly(IEnumerable<TItem> pets)
        {
            _pets = pets;
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return _pets.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}