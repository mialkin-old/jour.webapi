using Telegram.Bot;

namespace Jour.WebAPI.Controllers.Telegram
{
    public interface IWorkoutBotService
    {
        TelegramBotClient Client { get; }
    }
}