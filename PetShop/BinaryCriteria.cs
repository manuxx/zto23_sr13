using System;

namespace Training.DomainClasses
{
    public abstract class BinaryCriteria<TPet> : Criteria<TPet>
    {
        protected Criteria<TPet> _criteria1;
        protected Criteria<TPet> _criteria2;

        public BinaryCriteria(Criteria<TPet> criteria1, Criteria<TPet> criteria2)
        {
            _criteria1 = criteria1;
            _criteria2 = criteria2;
        }
        public abstract bool IsSatisfiedBy(TPet pet);
    }
}