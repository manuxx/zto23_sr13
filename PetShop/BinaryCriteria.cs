using System;
using System.Collections.Generic;
using System.Text;
using Training.DomainClasses;

namespace PetShop
{
    public abstract class BinaryCriteria : Criteria<Pet>
    {
        protected Criteria<Pet> _first;
        protected Criteria<Pet> _second;

        public BinaryCriteria(Criteria<Pet> first, Criteria<Pet> second)
        {
            _first = first;
            _second = second;
        }

        public abstract bool IsSatisfiedBy(Pet item);
    }
}
