namespace Training.DomainClasses
{
    public partial class Pet
    {
        public class Alternative<TPet> : BinaryCriteria<TPet>
        {
            public Alternative(Criteria<TPet> criteria1, Criteria<TPet> criteria2) : base(criteria1, criteria2){}

            public override bool IsSatisfiedBy(TPet pet)
            {
                return _criteria1.IsSatisfiedBy(pet) || _criteria2.IsSatisfiedBy(pet);
            }
        }
    }
}