namespace Training.DomainClasses
{
    public class Alternative<T> : Criteria<T>
    {
        private Criteria<T> _crit1;
        private Criteria<T> _crit2;

        public Alternative(Criteria<T> crit1, Criteria<T> crit2)
        {
            _crit2 = crit2;
            _crit1 = crit1;
        }

        public bool IsSatisfiedBy(T pet)
        {
            return _crit1.IsSatisfiedBy(pet) || _crit2.IsSatisfiedBy(pet);
        }
    }
}