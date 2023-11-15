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

        private bool IsDog(Pet pet)
        {
            return pet.species == Species.Dog;
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return result;
        }
        private IEnumerable<Pet> FilterBy(Func<Pet, bool> compare)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (compare(pet))
                    yield return pet;
            }
        }
        public IEnumerable<Pet> AllMice()
        {
            return FilterBy((Pet pet) => pet.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return FilterBy((Pet pet) => pet.sex == Sex.Female);


        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return FilterBy((Pet pet) => pet.species == Species.Cat || pet.IsDog());

        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return FilterBy((Pet pet) => pet.species != Species.Mouse);

        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return FilterBy((Pet pet) => pet.yearOfBirth > 2010);

        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return FilterBy((Pet pet) => pet.yearOfBirth > 2010 && pet.IsDog() );
        }           

        public IEnumerable<Pet> AllMaleDogs()
        {
            return FilterBy((Pet pet) => pet.sex == Sex.Male && pet.IsDog());

        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return FilterBy((Pet pet) => pet.yearOfBirth > 2011 && pet.species == Species.Rabbit);
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