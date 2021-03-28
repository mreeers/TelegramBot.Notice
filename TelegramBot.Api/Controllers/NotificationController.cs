using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramBot.Application;
using TelegramBot.Application.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelegramBot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private string token = "1774859986:AAEEmCaDmrbR7uWe5Sf8m8WAYos_ef-JtLU";

        // POST api/<NotificationController>
        [HttpPost("{id}/PostNote")]
        public async Task<ActionResult> Post([FromBody] Notification data, string chatId)
        {
            var testData = new Notification() { Bank = "Тинькофф", Id = 1, CardNumber = "123456", DateRequest = DateTime.Now, Sum = 100};
            
            
            try
            {
                var note = new GetRequest(token, testData, chatId);
                return Ok("Сообщение отправлено");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
