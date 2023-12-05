using Training.DomainClasses;

public interface Criteria<TItem>
{
    bool IsSatisfiedBy(TItem item);

    Training.DomainClasses.PetShop.Conjuction And(Criteria<TItem> item)
    {
        return new Training.DomainClasses.PetShop.Conjuction(this as Criteria<Pet>, item as Criteria<Pet>);
    }

    Training.DomainClasses.PetShop.Alternative Or(Criteria<TItem> item)
    {
        return new Training.DomainClasses.PetShop.Alternative(this as Criteria<Pet>, item as Criteria<Pet>);
    }
}