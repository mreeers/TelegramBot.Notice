using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramBot.Api.Models;

namespace TelegramBot.Api.Bot.Services.Interface
{
    public interface ISendService
    {
        Task<Notification> Send(Notification notification);
    }
}
