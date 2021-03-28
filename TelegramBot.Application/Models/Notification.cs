using System;
using System.Collections.Generic;
using System.Text;
using TelegramBot.Application.Models.Interface;

namespace TelegramBot.Application.Models
{
    public class Notification : INotification
    {
        public int Id { get ; set; }
        public string CardNumber { get; set ; }
        public DateTime DateRequest { get ; set ; }
        public decimal Sum { get; set; }
        public string Bank { get; set; }
    }
}
