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
            return FilteredBy(pet => pet.species == Species.Cat);
        }

        private IEnumerable<Pet> FilteredBy(Func<Pet, bool> condition)
        {
            foreach (var pet in _petsInTheStore)
            {
<<<<<<< Updated upstream
                if (pet.species.Equals(Species.Cat))
=======
                if (condition(pet))
>>>>>>> Stashed changes
                    yield return pet;
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
<<<<<<< Updated upstream
            var listToSort = new List<Pet>(_petsInTheStore);
            listToSort.Sort((x, y) => x.name.CompareTo(y.name));
            return listToSort;
        }

        public void Add(Pet newPet)
        {
            if (_petsInTheStore.Contains(newPet)) return;
            _petsInTheStore.Add(newPet);
=======
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((p1, p2) => p1.name.CompareTo(p2.name));
            return result;
>>>>>>> Stashed changes
        }

        public IEnumerable<Pet> AllMice()
        {
            return FilteredBy(pet => pet.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return FilteredBy(pet => pet.sex == Sex.Female);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return FilteredBy(pet => pet.species == Species.Cat || pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return FilteredBy(pet => pet.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return FilteredBy(pet => pet.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return FilteredBy(pet => pet.yearOfBirth > 2010 && pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return FilteredBy(pet => pet.sex == Sex.Male && pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return FilteredBy(pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit);
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