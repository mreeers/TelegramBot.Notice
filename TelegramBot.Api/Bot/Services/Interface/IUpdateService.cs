using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TelegramBot.Api.Models;

namespace TelegramBot.Api.Bot.Services.Interface
{
    public interface IUpdateService
    {
        Task EchoAsync(Update update);
        Task SendNotification(Notification notification); 
    }
}
