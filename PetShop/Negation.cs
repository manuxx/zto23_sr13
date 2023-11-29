namespace Training.DomainClasses
{
    public class Negation<T> : Criteria<T>
    {
        private readonly Criteria<T> criteria;

        public Negation(Criteria<T> isASpeciesOf)
        {
            criteria = isASpeciesOf;
        }

        public bool IsSatisfiedBy(T pet)
        {
            return !criteria.IsSatisfiedBy(pet);
        }
    }
}