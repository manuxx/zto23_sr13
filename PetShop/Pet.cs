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

        public static Criteria<Pet> IsaSpeciesOf(Species spieces)
        {
            return new SpeciesCriteria(spieces);
        }

        public static Criteria<Pet> IsFemale()
        {
            return new IsFemaleCriteria();
        }

        public static Criteria<Pet> IsBornAfter(int year)
        {
            return new BornAfterCriteria(year);
        }
    }

    public class IsFemaleCriteria : Criteria<Pet>
    {
        public bool isSatisfiedBy(Pet pet)
        {
            return pet.sex == Sex.Female;
        }
    }

    public class BornAfterCriteria : Criteria<Pet>
    {
        private readonly int _year;

        public BornAfterCriteria(int year)
        {
            _year = year;
        }
        public bool isSatisfiedBy(Pet pet)
        {
            return _year < pet.yearOfBirth;
        }
    }


    public class SpeciesCriteria : Criteria<Pet>
    {
        private readonly Species _species;

        public SpeciesCriteria(Species species)
        {
            _species = species;
        }

        public bool isSatisfiedBy(Pet pet)
        {
            return _species == pet.species;
        }
    }
}