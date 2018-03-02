using System;
using System.Text;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.InteropExtensions;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
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
        
        public void ProcessQueueMessage([ServiceBusTrigger(CreatePetQueue)] Message message)
        {
            try
            {
                CreatePet(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void CreatePet(Message message)
        {
            var bytes = message.Body;
            var json = Encoding.UTF8.GetString(bytes);
            var cmd = JsonConvert.DeserializeObject<CreatePetCommand>(json);

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