using System;
using System.Linq;
using System.Threading;
using Telegram.Bot;

namespace TelegramBot.Simple
{
    internal class TelegramBotHelper
    {
        private string _token;
        private ITelegramBotClient _client;

        public TelegramBotHelper(string token)
        {
            _token = token;
        }

        internal void GetUpdate()
        {
            _client = new TelegramBotClient(_token);
            var me = _client.GetMeAsync().Result;
            
            if(me != null && !string.IsNullOrEmpty(me.Username))
            {
                int offset = 0;
                while (true)
                {
                    try
                    {
                        var updates = _client.GetUpdatesAsync().Result;
                        if(updates != null && updates.Count() > 0)
                        {
                            foreach(var update in updates)
                            {
                                processUpdate(update);
                                offset = update.Id + 1;
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Thread.Sleep(1000);
                }
            }
        }

        private void processUpdate(Telegram.Bot.Types.Update update)
        {
            switch (update.Type)
            {
                case Telegram.Bot.Types.Enums.UpdateType.Message:
                    var text = update.Message.Text;
                    _client.SendTextMessageAsync(update.Message.Chat.Id ,"Recive text: " + text); 
                    break;
                default:
                    Console.WriteLine(update.Type + "Not implemented");
                    break;
            }
        }


    }
}