using System;
using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class SatisfyClass
    {
        public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> petsInTheStore, Func<TItem, bool> condition)
        {
            foreach (var pet in petsInTheStore)
            {
                if (condition(pet))
                    yield return pet;
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
            return new ReadOnly<Pet>(_petsInTheStore);
        }

        public void Add(Pet newPet)
        {
            if (_petsInTheStore.Contains(newPet)) return;
            _petsInTheStore.Add(newPet);
        }

        public IEnumerable<Pet> AllCats()
        {
            return _petsInTheStore.ThatSatisfy(isSpecies(Species.Cat));
        }

        private static Func<Pet, bool> isSpecies(Species species)
        {
            return pet=>pet.species == species;
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return result;
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.ThatSatisfy(isSpecies(Species.Mouse));
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.ThatSatisfy(isFemale);
        }

        private static bool isFemale(Pet pet)
        {
            return pet.sex == Sex.Female;
        }


        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.ThatSatisfy(pet => pet.species == Species.Cat || pet.species==Species.Dog);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.ThatSatisfy(IsNotASpecies(Species.Mouse));
        }

        private static Func<Pet, bool> IsNotASpecies(Species species)
        {
            return pet => pet.species != species;
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.ThatSatisfy(isBornAfter(2010));
        }

        private static Func<Pet, bool> isBornAfter(int year)
        {
            return pet => pet.yearOfBirth > year;
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.ThatSatisfy(pet => pet.species==Species.Dog && pet.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.ThatSatisfy(pet => pet.species == Species.Dog && pet.sex==Sex.Male);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.ThatSatisfy(pet => pet.species == Species.Rabbit || pet.yearOfBirth > 2011);
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