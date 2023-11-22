using System;

namespace Training.DomainClasses
{
    public class Pet : IEquatable<Pet>
    {
        public Sex sex;
        public string name { get; set; }
        public int yearOfBirth { get; set; }
        public float price { get; set; }
        public Species species { get; set; }

        public bool Equals(Pet other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return name == other.name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Pet)obj);
        }

        public override int GetHashCode()
        {
            return (name != null ? name.GetHashCode() : 0);
        }
        
        public static bool operator ==(Pet left, Pet right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Pet left, Pet right)
        {
            return !Equals(left, right);
        }

        public static Criteria<Pet> IsASpeciesOf(Species species)
        {
            return new SpeciesCriteria(species);
        }

        public static Criteria<Pet> IsFemale()
        {
            return new SexCriteia(Sex.Female);
        }

        public static Criteria<Pet> IsBornAfter(int year)
        {
            return new BorAfterCriteria(year);
        }

        public static Predicate<Pet> IsNotASpeciesOf(Species species)
        {
            return pet => pet.species != species;
        }
    }

    public class BorAfterCriteria : Criteria<Pet>
    {
        private readonly int _year;

        public BorAfterCriteria(int year)
        {
            _year = year;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return item.yearOfBirth > _year;
        }
    }

    public class SexCriteia : Criteria<Pet>
    {
        private readonly Sex _sex;

        public SexCriteia(Sex sex)
        {
            _sex = sex;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return _sex == pet.sex;
        }
    }

    public class SpeciesCriteria : Criteria<Pet>
    {
        private readonly Species _species;

        public SpeciesCriteria(Species species)
        {
            _species = species;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return _species == pet.species;
        }
    }
}