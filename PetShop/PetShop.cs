using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class PetShop
    {
        private IList<Pet> _petsInTheStore;

        public PetShop(IList<Pet> petsInTheStore)
        {
            this._petsInTheStore = petsInTheStore;
        }

        public IEnumerable<Pet> AllPets()
        {
            return _petsInTheStore;
        }

        public void Add(Pet newPet)
        {
            if (_petsInTheStore.Contains(newPet))
            {
                return;
            }

            for (int i = 0; i < _petsInTheStore.Count; i++)
            {
                var pet = _petsInTheStore[i];
                if (pet.name.Equals(newPet.name))
                {
                    return;
                }
            }

            _petsInTheStore.Add(newPet);
        }
    }
}