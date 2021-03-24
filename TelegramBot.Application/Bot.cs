using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.Application.Models;
using TelegramBot.Application.Models.Commands;

namespace TelegramBot.Application
{
    public class Bot
    {
        private static TelegramBotClient _botClient;
        private static List<Command> _commandList;

        public static IReadOnlyList<Command> Commands => _commandList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if(_botClient != null)
            {
                return _botClient;
            }

            _commandList = new List<Command>();
            _commandList.Add(new StartCommand());
            //TODO: Add more command

            _botClient = new TelegramBotClient(TelegramSettings.Key);
            string hook = string.Format(TelegramSettings.Url, "api/messsage/update");
            await _botClient.SetWebhookAsync(hook);
            return _botClient;
        }
    }
}
