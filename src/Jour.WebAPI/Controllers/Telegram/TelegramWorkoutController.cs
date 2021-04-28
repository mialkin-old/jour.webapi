using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Jour.WebAPI.Controllers.Telegram
{
    [Route("api/v1/telegram/workout")]
    public class TelegramWorkoutController : AppController
    {
        private readonly IWorkoutBotService _workoutBotService;
        private readonly ILogger<TelegramWorkoutController> _logger;

        public TelegramWorkoutController(IWorkoutBotService workoutBotService, ILogger<TelegramWorkoutController> logger)
        {
            _workoutBotService = workoutBotService;
            _logger = logger;
        }

        [HttpPost]
        [Route("jjiiHnemwgBOmfpMHUkdbUUkdPocs")]
        public async Task<IActionResult> Update([FromBody] Update update)
        {
            if (update.Type != UpdateType.Message)
                return Ok();
            
            var message = update.Message;
            
            switch (message.Type)
            {
                case MessageType.Text:
                    // Echo each Message
                    await _workoutBotService.Client.SendTextMessageAsync(message.Chat.Id, message.Text);
                    break;
            
                case MessageType.Photo:
                    // Download Photo
                    var fileId = message.Photo.LastOrDefault()?.FileId;
                    var file = await _workoutBotService.Client.GetFileAsync(fileId);
            
                    var filename = file.FileId + "." + file.FilePath.Split('.').Last();
                    using (var saveImageStream = System.IO.File.Open(filename, FileMode.Create))
                    {
                        await _workoutBotService.Client.DownloadFileAsync(file.FilePath, saveImageStream);
                    }
            
                    await _workoutBotService.Client.SendTextMessageAsync(message.Chat.Id, "Thx for the Pics");
                    break;
            }
            
            return Ok();
        }
    }
}