using System;
using Newtonsoft.Json;

namespace Pets.Infrastructure.Interfaces.Repositories
{
    public class Pet
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid AnimalId { get; set; }
        public Guid OwnerId { get; set; }
    }
}