using System;
using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class SatisfyClass
    {
        public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, Func<TItem, bool> condition)
        {
            Criteria<TItem> adapter = new AnonymousCriteria<TItem>(condition);
            return items.ThatSatisfy(adapter);
        }

        public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, Criteria<TItem> criteria)
        {
            foreach (var item in items)
            {
                if (criteria.isSatisfiedBy(item))
                    yield return item;
            }
        }
    }

    public class AnonymousCriteria<T> : Criteria<T>
    {
        private readonly Func<T, bool> _condition;

        public AnonymousCriteria(Func<T, bool> condition)
        {
            _condition = condition;
        }

        public bool isSatisfiedBy(T item)
        {
            return _condition(item);
        }
    }

    public interface Criteria<T>
    {
        bool isSatisfiedBy(T item);
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
            return _petsInTheStore.ThatSatisfy(Pet.isSpecies(Species.Cat));
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return result;
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.ThatSatisfy(Pet.isSpecies(Species.Mouse));
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.ThatSatisfy(Pet.isFemale);
        }


        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.ThatSatisfy(pet => pet.species == Species.Cat || pet.species==Species.Dog);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsNotASpecies(Species.Mouse));
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.ThatSatisfy(Pet.isBornAfter(2010));
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