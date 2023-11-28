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

        public static Criteria<Pet> IsSpecie(Species species)
        {
            return new SpeciesCriteria(species);
        }

        public static Criteria<Pet> IsFemale()
        {
            return new FemaleCriteria<Pet>();
        }

        public static Criteria<Pet> isBornAfter(int age)
        {
            return new AgeCriteria(age);
        }
    }

    public class AgeCriteria : Criteria<Pet>
    {
        private readonly int _age;

        public AgeCriteria(int age)
        {
            _age = age;
        }

        public bool IsSatisfyBy(Pet item)
        {
            return item.yearOfBirth > _age;
        }
    }

    public class FemaleCriteria<T> : Criteria<T>
    {
        public bool IsSatisfyBy(T item)
        {
            return (item as Pet).sex == Sex.Female;
        }
    }

    public class SpeciesCriteria : Criteria<Pet>
    {
        private readonly Species _species;

        public SpeciesCriteria(Species species)
        {
            _species = species;
        }


        public bool IsSatisfyBy(Pet item)
        {
            return item.species == _species;
        }
    }
}