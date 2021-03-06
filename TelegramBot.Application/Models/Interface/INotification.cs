using System;

namespace TelegramBot.Application.Models.Interface
{
    public interface INotification
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public DateTime DateRequest { get; set; }
        public decimal Sum { get; set; }
        public string Bank { get; set; }
        public bool Status { get; set; }
    }
}