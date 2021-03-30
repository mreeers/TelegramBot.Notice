using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Application.Models;

namespace TelegramBot.Application
{
    public class BotHelper
    {
        private readonly TelegramSettings _settings;
        private ITelegramBotClient _client;

        public BotHelper(TelegramSettings settings)
        {
            _settings = settings;
            _client = new TelegramBotClient(_settings.Token) { Timeout = TimeSpan.FromSeconds(5) }; 
        }

        public void GetUpdate(Update update)
        {
            _client.OnCallbackQuery += async (object sc, CallbackQueryEventArgs ev) =>
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

        public void SendMessage(Notification notification)
        {
            
            foreach (var chatId in _settings.ChatId)
            {
                //Bot_SendMessage(chatId, notification);
                var buttons = new InlineKeyboardMarkup(new[]
                {
                    InlineKeyboardButton.WithCallbackData("✅ Подтвердить"),
                    InlineKeyboardButton.WithCallbackData("❌ Отказать"),
                });


                if (notification == null)
                    return;

                _client.SendTextMessageAsync(chatId: chatId, 
                    text: $"📆 Дата заявки: {notification.DateRequest}\n🏦 Банк: {notification.Bank}\n💳 Номер карты: {notification.CardNumber}\n💵 Сумма: {notification.Sum}",
                    replyMarkup: buttons);

                var updates = _client.GetUpdatesAsync().Result;

                if (updates != null && updates.Count() > 0)
                {
                    foreach (var update in updates)
                    {
                        processUpdate(update);
                    }
                }

            }
        }

        private void processUpdate(Update update)
        {
            
        }
    }
}
