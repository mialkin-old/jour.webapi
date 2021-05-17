using Jour.WebAPI.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jour.WebAPI.Infrastructure
{
    public static class CustomServicesConfiguration
    {
        public static void ConfigureCustomOptions(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection
                .AddOptions<LoginSettings>()
                .Bind(configuration.GetSection(LoginSettings.Login))
                .ValidateDataAnnotations();

            serviceCollection
                .AddOptions<TelegramSettings>()
                .Bind(configuration.GetSection(TelegramSettings.Telegram))
                .ValidateDataAnnotations();
            
            serviceCollection.AddOptions<RabbitOptions>()
                .Bind(configuration.GetSection(RabbitOptions.Rabbit))
                .ValidateDataAnnotations();
        }
    }
}