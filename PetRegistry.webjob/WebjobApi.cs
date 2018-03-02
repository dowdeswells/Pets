using Microsoft.Azure.WebJobs;
using PetRegistry.webjob.Infrastructure;
using Pets.Infrastructure.Interfaces.Messaging;
using Pets.Infrastructure.Interfaces.Repositories;

namespace PetRegistry.webjob
{
    public class WebjobApi
    {
        private const string CreatePetQueue = "createpet";

        private readonly IPetsRepository _petsRepository;


        public WebjobApi(IPetsRepository petsRepository)
        {
            _petsRepository = petsRepository;
        }
        
        public void CreatePet([ServiceBusTrigger(CreatePetQueue)] CreatePetCommand cmd)
        {
            Pet pet = new Pet
            {
                Id = cmd.NewPetId,
                OwnerId = cmd.OwnerId,
                AnimalId = cmd.AnimalId,
                Name = cmd.PetName,
                Description = cmd.PetDescription,
            };
            _petsRepository.Add(pet);
        }
        
    }
}