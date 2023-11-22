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

        public static Func<Pet, bool> isSpecies(Species species)
        {
            return pet=>pet.species == species;
        }

        public static bool isFemale(Pet pet)
        {
            return pet.sex == Sex.Female;
        }

        public static Func<Pet, bool> IsNotASpecies(Species species)
        {
            return pet => pet.species != species;
        }

        public static Func<Pet, bool> isBornAfter(int year)
        {
            return pet => pet.yearOfBirth > year;
        }
    }
}