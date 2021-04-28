using Jour.WebAPI.Infrastructure;
using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace Jour.WebAPI.Controllers.Telegram
{
    public class WorkoutBotService: IWorkoutBotService
    {
        public WorkoutBotService(IOptions<TelegramSettings> config)
        {
            Client = new TelegramBotClient(config.Value.WorkoutBotToken);
        }
        
        public TelegramBotClient Client { get; }
    }
}