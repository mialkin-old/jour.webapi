using Jour.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jour.WebAPI.Infrastructure
{
    public static class CustomServicesConfiguration
    {
        public static void AddCustomServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddOptions<LoginSettings>()
                .Bind(configuration.GetSection(LoginSettings.Login))
                .ValidateDataAnnotations();
            
            serviceCollection
                .AddOptions<DatabaseSettings>()
                .Bind(configuration.GetSection(DatabaseSettings.Db))
                .ValidateDataAnnotations();
        }
    }
}
