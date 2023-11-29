namespace Training.DomainClasses
{
    public class Negation<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _innerCteria;

        public Negation(Criteria<TItem> innerCteria)
        {
            _innerCteria = innerCteria;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return ! _innerCteria.IsSatisfiedBy(item);
        }
    }
}