using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Application.Models;

namespace TelegramBot.Application
{
    public class GetRequest
    {
        private static ITelegramBotClient _botClient;
        public GetRequest(string token, Notification notification, string chatId)
        {
            _botClient = new TelegramBotClient(token) { Timeout = TimeSpan.FromSeconds(5)};
            var me = _botClient.GetMeAsync().Result;
            
            Bot_SendMessage(chatId, notification);
        }

        private static async void Bot_SendMessage(string id, Notification notification)
        {
            var buttons = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("✅ Подтвердить", "myCommand1"),
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("❌ Отказать", "myCommand2"),
                },
            });

            if (notification == null)
                return;

            await _botClient.SendTextMessageAsync(
                chatId: id,
                text: $"Дата заявки: {notification.DateRequest}\nБанк: {notification.Bank}\nНомер карты: {notification.CardNumber}\nСумма: {notification.Sum}",
                replyMarkup: buttons);
            
        }
        
    }
}
