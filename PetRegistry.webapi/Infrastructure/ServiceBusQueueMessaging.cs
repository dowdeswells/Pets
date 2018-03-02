using System.Text;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Pets.Infrastructure.Interfaces.Messaging;

namespace PetRegistry.webapi.Infrastructure
{
    public class ServiceBusQueueMessaging : IMessaging
    {
        private const string CreatePetQueue = "createpet";
        
        private readonly IConfiguration _configuration;

        public ServiceBusQueueMessaging(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void Send<TCommand>(TCommand command)
        {
            var connectionString = _configuration.GetConnectionString("ServiceBus");
            var queueClient = new QueueClient(connectionString, CreatePetQueue);
            
            var json = JsonConvert.SerializeObject(command);
            var bytes = Encoding.UTF8.GetBytes(json);

            Message message = new Message(bytes);

            queueClient.SendAsync(message);
        }
    }
}