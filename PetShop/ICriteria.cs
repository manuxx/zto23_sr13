namespace Training.DomainClasses
{
    public interface ICriteria<in TItem>
    {
        bool IsSatisfiedBy(TItem item);
    }
}