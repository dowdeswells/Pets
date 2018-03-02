using System;

namespace Pets.Infrastructure.Interfaces.Repositories
{
    public interface IAnimalRepository
    {
        AnimalSummaryViewModel GetById(Guid id);
    }
}