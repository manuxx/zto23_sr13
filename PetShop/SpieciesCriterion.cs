using PetShop;

namespace Training.DomainClasses
{
    internal class SpeciesCriterion : ICriterion<Pet>
    {
        private readonly Species _species;

        public SpeciesCriterion(Species species)
        {
            _species = species;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.species == _species;
        }
    }

    internal class SexCriterion : ICriterion<Pet>
    {
        private readonly Sex _sex;

        public SexCriterion(Sex sex)
        {
            _sex = sex;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.sex == _sex;
        }
    }
}