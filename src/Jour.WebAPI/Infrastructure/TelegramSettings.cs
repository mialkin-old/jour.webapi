using System.ComponentModel.DataAnnotations;

namespace Jour.WebAPI.Infrastructure
{
    public class TelegramSettings
    {
        public const string Telegram = "Telegram";

        [Required(AllowEmptyStrings = false)]
        public string WorkoutBotToken { get; set; }
    }
}