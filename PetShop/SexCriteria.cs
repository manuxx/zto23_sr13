namespace Training.DomainClasses
{
    public class SexCriteria : ICriteria<Pet>
    {
        private Sex _sex;

        public SexCriteria(Sex sex)
        {
            _sex = sex;
        }

        public bool IsSatisfiedBy(Pet p)
        {
            return p.sex == _sex;
        }
    }
}