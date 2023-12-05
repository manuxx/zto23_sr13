using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using PetShop;

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
            return _petsInTheStore.ThatSatisfy(Pet.IsASpeciesOf(Species.Cat));
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return result;
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsASpeciesOf(Species.Mouse));
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsFemale());
        }


        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsBornAfter(2010));
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.ThatSatisfy((pet => pet.species == Species.Cat || pet.species==Species.Dog));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsNotASpeciesOf(Species.Mouse));
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsASpeciesOf(Species.Dog).And(Pet.IsBornAfter(2010)));
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsASpeciesOf(Species.Dog).And(new Pet.Negation(Pet.IsFemale())));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsBornAfter(2011).Or(Pet.IsASpeciesOf(Species.Rabbit)));
        }

        public class Conjuction : BinaryCriteria
        {
            public Conjuction(Criteria<Pet> first, Criteria<Pet> second) : base(first, second)
            {
            }

            public override bool IsSatisfiedBy(Pet item)
            {
                return _first.IsSatisfiedBy(item) && _second.IsSatisfiedBy(item);
            }
        }

        public class Alternative : BinaryCriteria
        {
            public Alternative(Criteria<Pet> first, Criteria<Pet> second) : base(first, second)
            {
            }

            public override bool IsSatisfiedBy(Pet item)
            {
                return _first.IsSatisfiedBy(item) || _second.IsSatisfiedBy(item);
            }
        }
    }
}