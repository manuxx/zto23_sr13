namespace Training.DomainClasses
{
    public class SpeciesCriteria : Criteria<Pet>
    {
        private readonly Species _species;

        public SpeciesCriteria(Species species)
        {
            _species = species;
        }

        public bool isSatisfiedBy(Pet sex)
        {
            return sex.species == _species;
        }
    }
}