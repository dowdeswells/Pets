using System;
using Pets.Infrastructure.Interfaces.Repositories;

namespace PetRegistry.webapi.Infrastructure
{
    public class AnimalRepository : IAnimalRepository
    {
        public AnimalSummaryViewModel GetById(Guid id)
        {
            return new AnimalSummaryViewModel
            {
                Id = id,
                Name = "Dog"
            };
        }
    }
}