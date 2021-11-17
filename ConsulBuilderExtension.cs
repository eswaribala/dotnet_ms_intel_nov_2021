using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

namespace InventoryService
{
    public static class ConsulBuilderExtensions
    {
        
        public static IApplicationBuilder RegisterConsul(this IApplicationBuilder app, IApplicationLifetime lifetime, ConsulOption consulOption)
        {
            var consulClient = new ConsulClient(x =>
            {
                // CONSUL service address
                x.Address = new Uri(consulOption.Address);
            });

            var registration = new AgentServiceRegistration()
            {
                ID = Guid.NewGuid().ToString(),
                Name = consulOption.ServiceName,//  Service Name
                Address = consulOption.ServiceIP, //  Service binding IP
                Port = consulOption.ServicePort, //  Service binding port
                //Check = new AgentServiceCheck()
                //{
                //    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//How long is the service startup?
                //    Interval = TimeSpan.FromSeconds(10),//Health check interval
                //   // HTTP = consulOption.ServiceHealthCheck,//Health check address
                //    Timeout = TimeSpan.FromSeconds(5)
                //}
            };

            //  Service registration
            consulClient.Agent.ServiceRegister(registration).Wait();

            //  When the application terminates, the service cancels registration
            lifetime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            });
            return app;
        }
        
    }
}
