namespace PetShop
{
    public interface ICriterion<TItem>
    {
        bool IsSatisfiedBy(TItem item);
    }
}