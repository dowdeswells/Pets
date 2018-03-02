using System;
using System.Collections.Generic;

namespace Pets.Infrastructure.Interfaces.Repositories
{
    public interface IPetsViewRepository
    {
        IEnumerable<PetSummaryViewModel> GetPetsForOwner(Guid ownerId);
        PetSummaryViewModel GetPetForOwner(Guid ownerId, Guid petId);
    }
}