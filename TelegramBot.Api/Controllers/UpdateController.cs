using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TelegramBot.Api.Bot.Services.Interface;
using TelegramBot.Application;
using TelegramBot.Application.Models;

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

        [HttpGet]
        public IActionResult GetTest()
        {
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
