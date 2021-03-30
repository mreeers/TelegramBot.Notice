using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TelegramBot.Api.Bot.Services.Interface;
using TelegramBot.Api.Models;

namespace TelegramBot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private readonly IUpdateService _updateService;

        public UpdateController(IUpdateService updateService)
        {
            _updateService = updateService;
        }

        [HttpPost("/send")]
        public async Task<IActionResult> Send()
        {
            var testData = new Notification() { Bank = "Тинькофф", Id = 1, CardNumber = "5569852147812632510", DateRequest = DateTime.Now, Sum = 200, IdChat = "368563281" };
            await _updateService.SendNotification(testData);
            return Ok("Тест");
        }

        // POST api/update
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            await _updateService.EchoAsync(update);
            return Ok();
        }

    }
}
