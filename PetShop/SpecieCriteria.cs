using System;

namespace Training.DomainClasses
{
    public class SpecieCriteria : ICriteria<Pet>
    {
        private readonly Species _species;

        public SpecieCriteria(Species species)
        {
            _species = species;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.species == _species;
        }
    }

    public class NotASpecieCriteria : ICriteria<Pet>
    {
        private readonly Species _species;

        public NotASpecieCriteria(Species species)
        {
            _species = species;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return item.species != _species;
        }
    }
    
    public class BornYearCriteria : ICriteria<Pet>
    {
        private readonly Predicate<Pet> _predicate;

        public BornYearCriteria(int smallerThan = int.MinValue, int greaterThen = int.MaxValue)
        {
            _predicate = pet => smallerThan < pet.yearOfBirth && pet.yearOfBirth > greaterThen;
        }
        
        public bool IsSatisfiedBy(Pet item)
        {
            return _predicate(item);
        }
    }
}