using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBot.Api.Models
{
    public class Notification 
    {
        public int Id { get ; set; }
        public string CardNumber { get; set ; }
        public DateTime DateRequest { get ; set ; }
        public decimal Sum { get; set; }
        public string Bank { get; set; }

        /// <summary>
        /// Статус заявления
        /// 0 - Оповещение отправлено
        /// 1 - Заявка подтверждена
        /// 2 - Отказано
        /// </summary>
        public int Status { get; set; }
        
        /// <summary>
        /// Id чата оператора/ов??
        /// </summary>
        public string IdChat { get; set; }
    }
}
