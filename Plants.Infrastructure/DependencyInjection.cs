using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Plants.Infrastructure.Data;

namespace Plants.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Add(new ServiceDescriptor(typeof(DataContext), 
                new DataContext(configuration.GetConnectionString("Default"))));

            return services;
        }
    }
}