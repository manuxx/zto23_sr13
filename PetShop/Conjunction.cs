namespace Training.DomainClasses
{
    public partial class Pet
    {
        public class Conjunction<TPet> : BinaryCriteria<TPet>
        {
            public Conjunction(Criteria<TPet> criteria1, Criteria<TPet> criteria2) : base(criteria1, criteria2) { }

            public override bool IsSatisfiedBy(TPet pet)
            {
                return _criteria1.IsSatisfiedBy(pet) && _criteria2.IsSatisfiedBy(pet);
            }
        }
    }
}