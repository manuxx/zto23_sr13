using System;
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
            return _petsInTheStore.ThatSatisfy(new Negation<Pet>(Pet.IsASpeciesOf(Species.Mouse)));
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.ThatSatisfy(And(Pet.IsASpeciesOf(Species.Dog), Pet.IsBornAfter(2010)));
        }

        private static Conjunction<Pet> And(
            Criteria<Pet> criteria1, Criteria<Pet> criteria2)
        {
            return new Conjunction<Pet>(criteria1, criteria2);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.ThatSatisfy((pet => pet.species == Species.Dog && pet.sex==Sex.Male));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.ThatSatisfy(new Alternative<Pet>(Pet.IsASpeciesOf(Species.Rabbit), Pet.IsBornAfter(2011)));
        }
    }

    public abstract class AlternativeBase<TItem> : Criteria<TItem>
    {
        protected Criteria<TItem> _isASpeciesOf;
        protected Criteria<TItem> _isBornAfter;

        public AlternativeBase(Criteria<TItem> isASpeciesOf, Criteria<TItem> isBornAfter)
        {
            _isASpeciesOf = isASpeciesOf;
            _isBornAfter = isBornAfter;
        }

        public abstract bool IsSatisfiedBy(TItem item);
    }

    public class Alternative<TItem> : AlternativeBase<TItem>
    {
        public Alternative(Criteria<TItem> isASpeciesOf, Criteria<TItem> isBornAfter) : base(isASpeciesOf, isBornAfter)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _isASpeciesOf.IsSatisfiedBy(item) || _isBornAfter.IsSatisfiedBy(item);
        }
    }

    public class Conjunction<TItem> : AlternativeBase<TItem>
    {

        public Conjunction(Criteria<TItem> isASpeciesOf, Criteria<TItem> isBornAfter) : base(isASpeciesOf, isBornAfter)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _isASpeciesOf.IsSatisfiedBy(item) && _isBornAfter.IsSatisfiedBy(item);
        }
    }
}