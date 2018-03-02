using System;
using Microsoft.AspNetCore.Mvc;
using Pets.Infrastructure.Interfaces.Messaging;
using Pets.Infrastructure.Interfaces.Repositories;

namespace PetRegistry.webapi.Controllers.Pets
{
    [Route("api/pets")]
    public class PetsController : Controller
    {
        private Guid _ownerId = Guid.Empty;
        
        private readonly IPetsViewRepository _petsViewRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IMessaging _messaging;

        public PetsController(IPetsViewRepository petsViewRepository, 
            IAnimalRepository animalRepository,
            IMessaging messaging)
        {
            _petsViewRepository = petsViewRepository;
            _animalRepository = animalRepository;
            _messaging = messaging;
        }
        
        [HttpGet]
        public IActionResult GetPetsForOwner()
        {
            var pets = _petsViewRepository.GetPetsForOwner(_ownerId);
            return Ok(pets);
        }
        
        [HttpGet("{id}", Name = "GetPetForOwner")]
        public IActionResult GetPetForOwner(Guid petId)
        {
            var pet = _petsViewRepository.GetPetForOwner(_ownerId, petId);
            return Ok(pet);
        }
        

        [HttpPost]
        public IActionResult CreatePetForOwner([FromBody] CreatePetForOwnerModel pet)
        {
            var animal = _animalRepository.GetById(pet.AnimalId);

            if (animal == null)
            {
                return BadRequest();
            }
            
            var newPetId = Guid.NewGuid();
            var cmd = new CreatePetCommand
            {
                NewPetId = newPetId,
                OwnerId = _ownerId,
                AnimalId = pet.AnimalId,
                PetDescription = pet.Description,
                PetName = pet.Name,
            };

            _messaging.Send(cmd);
            
            object routeParams = new
            {
                id = newPetId
            };
            
            return AcceptedAtRoute("GetPetForOwner", routeParams, cmd);
        }
    }

}