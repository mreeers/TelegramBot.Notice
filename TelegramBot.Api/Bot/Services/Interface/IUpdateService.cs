﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TelegramBot.Api.Bot.Services.Interface
{
    public interface IUpdateService
    {
        Task EchoAsync(Update update);
    }
}
