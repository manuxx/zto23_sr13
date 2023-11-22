namespace Training.DomainClasses
{
    public class SexCriteria : Criteria<Pet>
    {
        private readonly Sex _petSex;

        public SexCriteria(Sex petSex)
        {
            _petSex = petSex;
        }


        public bool isSatisfiedBy(Pet pet)
        {
            return _petSex == pet.sex;
        }
    }
}