using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Api.Bot.Services.Interface;
using TelegramBot.Api.Models;

namespace TelegramBot.Api.Bot.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly IBotService _botService;
        private readonly ILogger<UpdateService> _logger;

        public UpdateService(IBotService botService, ILogger<UpdateService> logger)
        {
            _botService = botService;
            _logger = logger;
        }

        
        public async Task EchoAsync(Update update)
        {
            if (update.Type != UpdateType.Message)
                return;

            var message = update.Message;

            _logger.LogInformation("Received Message from {0}", message.Chat.Id);

            switch (message.Type)
            {
                case MessageType.Text:
                    // Echo each Message
                    await _botService.Client.SendTextMessageAsync(message.Chat.Id, message.Text);
                    break;

                case MessageType.Photo:
                    // Download Photo
                    var fileId = message.Photo.LastOrDefault()?.FileId;
                    var file = await _botService.Client.GetFileAsync(fileId);

                    var filename = file.FileId + "." + file.FilePath.Split('.').Last();
                    using (var saveImageStream = System.IO.File.Open(filename, FileMode.Create))
                    {
                        await _botService.Client.DownloadFileAsync(file.FilePath, saveImageStream);
                    }

                    await _botService.Client.SendTextMessageAsync(message.Chat.Id, "Thx for the Pics");
                    break;
            }
        }

        public async Task<Notification> SendNotification(Notification notification)
        {
            try
            {
                var buttons = new InlineKeyboardMarkup(new[]
                {
                    InlineKeyboardButton.WithCallbackData("✅ Подтвердить"),
                    InlineKeyboardButton.WithCallbackData("❌ Отказать"),
                });

                _logger.LogInformation($"Отпавлена заявка на вывод. Id {notification.Id}");
                
                await _botService.Client.SendTextMessageAsync(
                    chatId: notification.IdChat,
                    text: $"📆 Дата заявки: {notification.DateRequest}\n🏦 Банк: {notification.Bank}\n💳 Номер карты: {notification.CardNumber}\n💵 Сумма: {notification.Sum}",
                    replyMarkup: buttons);

                notification.Status = 0;
                return notification;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
