using System;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Pets.Infrastructure.Interfaces.Repositories;

namespace PetRegistry.webjob.Infrastructure
{
    public class PetsRepository : IPetsRepository
    {
        private const string EndpointUri = "https://chumpusdocs.documents.azure.com:443/";
        private const string PrimaryKey = "6TuBAnx5B4HYyIMWY5TdhtQu1x5oEDvufFKHYBaT6sFG2EKBCZ5ZSZxoAq9nXfhfAcThvQw2EIsBOlWZrgvJNw==";

        private const string PetsDb = "Pets";
        private const string PetsCollection = "Pets";
        
        


        public async Task Add(Pet pet)
        {
            var client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);
            var petsCollectionUri = UriFactory.CreateDocumentCollectionUri(PetsDb, PetsCollection);
            var docResponse = await client.CreateDocumentAsync(petsCollectionUri, pet);
        }
    }
}