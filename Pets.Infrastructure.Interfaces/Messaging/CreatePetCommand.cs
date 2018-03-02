using System;

namespace Pets.Infrastructure.Interfaces.Messaging
{
    public class CreatePetCommand
    {
        public Guid OwnerId { get; set; }
        public Guid NewPetId { get; set; }
        public string PetName { get; set; }
        public Guid AnimalId { get; set; }
        public string PetDescription { get; set; }
    }
}