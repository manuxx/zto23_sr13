namespace Training.DomainClasses
{
    public partial class Pet
    {
        public class Negation<TPet> : Criteria<TPet>
        {
            private readonly Criteria<TPet> _criteria;

            public Negation(Criteria<TPet> criteria)
            {
                _criteria = criteria;
            }

            public bool IsSatisfiedBy(TPet pet)
            {
                return !_criteria.IsSatisfiedBy(pet);
            }
        }
    }
}