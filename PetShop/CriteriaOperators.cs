namespace Training.DomainClasses
{
    public class Negation<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _criteria;

        public Negation(Criteria<TItem> criteria)
        {
            _criteria = criteria;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return !_criteria.IsSatisfiedBy(item);
        }
    }

    public abstract class MultiCriteria<TItem> : Criteria<TItem>
    {
        protected Criteria<TItem>[] _criteria;

        public MultiCriteria(Criteria<TItem>[] criteria)
        {
            _criteria = criteria;
        }

        public abstract bool IsSatisfiedBy(TItem item);
    }

    public class Conjunction<TItem> : MultiCriteria<TItem>
    {
        public Conjunction(params Criteria<TItem>[] criteria) : base(criteria)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            var result = true;
            foreach (var criterion in _criteria)
            {
                result = result && criterion.IsSatisfiedBy(item);
            }

            return result;
        }
    }

    public class Alternative<TItem> : MultiCriteria<TItem>
    {
        public Alternative(params Criteria<TItem>[] criteria) : base(criteria)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            foreach (var criterion in _criteria)
            {
                if (criterion.IsSatisfiedBy(item)) return true;
            }

            return false;
        }
    }
}