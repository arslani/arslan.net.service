using Microsoft.Extensions.DependencyInjection;
using System;

namespace Arslan.Net.Extensions.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServiceResolver(this IServiceCollection services) {
            if (services == null) 
                throw new ArgumentNullException(nameof(services));

            var serviceProvider = services.BuildServiceProvider();
            Service.Configure(type => serviceProvider.GetRequiredService(type));
            return services;
        }
    }
}
