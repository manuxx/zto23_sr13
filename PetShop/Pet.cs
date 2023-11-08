using System;
using System.Diagnostics.CodeAnalysis;

namespace Training.DomainClasses
{
    public class Pet : IEquatable<Pet>
    {
        public Sex sex;
        public string name { get; set; }
        public int yearOfBirth { get; set; }
        public float price { get; set; }
        public Species species { get; set; }

        public bool Equals([AllowNull] Pet other)
        {
            return other != null &&
                   name == other.name &&
                   yearOfBirth == other.yearOfBirth &&
                   price == other.price &&
                   species == other.species;
        }
    }
}