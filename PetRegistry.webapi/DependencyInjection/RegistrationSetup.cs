using Microsoft.Extensions.DependencyInjection;
using PetRegistry.webapi.Infrastructure;
using Pets.Infrastructure.Interfaces.Messaging;
using Pets.Infrastructure.Interfaces.Repositories;

namespace PetRegistry.webapi.DependencyInjection
{
    public class RegistrationSetup
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services
                .AddTransient<IPetsViewRepository, PetsViewRepository>()
                .AddTransient<IAnimalRepository, AnimalRepository>()
                .AddTransient<IMessaging, ServiceBusQueueMessaging>()
                ;
        }
    }
}