using System;

namespace PetRegistry.webapi.Controllers.Pets
{
    public class CreatePetForOwnerModel
    {
        public string Name { get; set; }
        public Guid AnimalId { get; set; }
        public string Description { get; set; }
    }
}