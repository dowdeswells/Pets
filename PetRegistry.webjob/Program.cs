using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PetRegistry.webjob
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var appSettings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();


            var configuration = new JobHostConfiguration();
            configuration.Queues.MaxPollingInterval = TimeSpan.FromSeconds(10);
            configuration.Queues.BatchSize = 1;
            configuration.JobActivator = new CustomJobActivator(serviceCollection.BuildServiceProvider());
            configuration.UseTimers();
            configuration.DashboardConnectionString = appSettings.GetConnectionString("WebJobsDashboard");
            configuration.StorageConnectionString = appSettings.GetConnectionString("WebJobsStorage");

            configuration.UseServiceBus(BuildServiceBusConfiguration(appSettings));
            var host = new JobHost(configuration);
            host.RunAndBlock();
        }

        private static ServiceBusConfiguration BuildServiceBusConfiguration(IConfigurationRoot appSettings)
        {
            var config = new ServiceBusConfiguration
            {
                ConnectionString = appSettings.GetConnectionString("ServiceBus"),
            };
            return config;
        }


        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Setup your container here, just like a asp.net core app

            // Optional: Setup your configuration:

            //serviceCollection.Configure<WebjobSettings>(configuration);

            // A silly example of wiring up some class used by the web job:
            //serviceCollection.AddScoped<ISomeInterface, SomeUsefulClass>();
            // Your classes that contain the webjob methods need to be DI-ed up too
            serviceCollection.AddScoped<WebjobApi, WebjobApi>();

        }
    }
}