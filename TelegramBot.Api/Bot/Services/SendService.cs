using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Api.Bot.Services.Interface;
using TelegramBot.Api.Models;

namespace TelegramBot.Api.Bot.Services
{
    public class SendService : ISendService
    {
        private readonly IBotService _botService;

        public SendService(IBotService botService)
        {
            _botService = botService;
        }

        public async Task<Notification> Send(Notification notification)
        {
            var _botClient = new TelegramBotClient("1774859986:AAEEmCaDmrbR7uWe5Sf8m8WAYos_ef-JtLU");
            try
            {
                var buttons = new InlineKeyboardMarkup(new[]
                {
                    InlineKeyboardButton.WithCallbackData("✅ Подтвердить"),
                    InlineKeyboardButton.WithCallbackData("❌ Отказать"),
                });

                foreach (var chatId in notification.IdChats)
                {
                    //await _botService.Client.SendTextMessageAsync(chatId: chatId, text: "dsvdsvdsv");
                    await _botClient.SendTextMessageAsync(chatId: chatId,
                        text: $"📆 Дата заявки: {notification.DateRequest}\n🏦 Банк: {notification.Bank}\n💳 Номер карты: {notification.CardNumber}\n💵 Сумма: {notification.Sum}",
                        replyMarkup: buttons);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return notification;
        }
    }
}
