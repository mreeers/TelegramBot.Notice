using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot.Api.Bot.Services.Interface
{
    public interface IBotService
    {
        ITelegramBotClient Client { get; }
    }
}
