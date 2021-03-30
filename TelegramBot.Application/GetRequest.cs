using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Application.Models;

namespace TelegramBot.Application
{
    public class GetRequest
    {
        private static ITelegramBotClient _botClient;
        public GetRequest(TelegramSettings settings, Notification notification)
        {
            _botClient = new TelegramBotClient(settings.Token) { Timeout = TimeSpan.FromSeconds(5)};
            var me = _botClient.GetMeAsync().Result;
            
            foreach(var chatId in settings.ChatId)
            {
                Bot_SendMessage(chatId, notification);
            }

            _botClient.OnCallbackQuery += async (object sc, CallbackQueryEventArgs ev) =>
            {
                var message = ev.CallbackQuery.Message;
                if (ev.CallbackQuery.Data == "myCommand1")
                {
                    // сюда то что тебе нужно сделать при нажатии на первую кнопку 
                    Console.WriteLine("Ура");
                }
                else
                if (ev.CallbackQuery.Data == "myCommand2")
                {
                    Console.WriteLine("Ура 2");
                    // сюда то что нужно сделать при нажатии на вторую кнопку
                }
            };

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
            }); ;

            if (notification == null)
                return;

            await _botClient.SendTextMessageAsync(
                chatId: id,
                text: $"Дата заявки: {notification.DateRequest}\nБанк: {notification.Bank}\nНомер карты: {notification.CardNumber}\nСумма: {notification.Sum}",
                replyMarkup: buttons);
        }
        


    }
}
