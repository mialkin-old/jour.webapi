using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jour.WebAPI.Infrastructure
{
    public static class CustomServicesConfiguration
    {
        public static void ConfigureCustomOptions(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddOptions<LoginSettings>()
                .Bind(configuration.GetSection(LoginSettings.Login))
                .ValidateDataAnnotations();
        }
    }
}
