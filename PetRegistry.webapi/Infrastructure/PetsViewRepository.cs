using System;
using System.Collections.Generic;
using Pets.Infrastructure.Interfaces.Repositories;

namespace PetRegistry.webapi.Infrastructure
{
    public class PetsViewRepository : IPetsViewRepository
    {
        public IEnumerable<PetSummaryViewModel> GetPetsForOwner(Guid ownerId)
        {
            return new PetSummaryViewModel[0];
        }

        public PetSummaryViewModel GetPetForOwner(Guid ownerId, Guid petId)
        {
            throw new NotImplementedException();
        }
    }
}