using Microsoft.Extensions.Options;
using MihaZupan;
using Telegram.Bot;
using TelegramBot.Api.Bot.Services.Interface;

namespace TelegramBot.Api.Bot.Services
{
    public class BotService : IBotService
    {
        private readonly BotConfiguration _config;

        public BotService(IOptions<BotConfiguration> config)
        {
            _config = config.Value;
            //use proxy if configured in appsettings.*.json
            Client = string.IsNullOrEmpty(_config.Socks5Host)
                ? new TelegramBotClient(_config.BotToken)
                : new TelegramBotClient(
                    _config.BotToken,
                    new HttpToSocks5Proxy(_config.Socks5Host, _config.Socks5Port));
        }

        public ITelegramBotClient Client { get; set; }
    }
}
