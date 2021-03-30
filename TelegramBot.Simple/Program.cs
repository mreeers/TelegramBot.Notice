using System;

namespace TelegramBot.Simple
{
    class Program
    {
        //1774859986:AAEEmCaDmrbR7uWe5Sf8m8WAYos_ef-JtLU
        static void Main(string[] args)
        {
            try
            {
                TelegramBotHelper helper = new TelegramBotHelper(token: "1774859986:AAEEmCaDmrbR7uWe5Sf8m8WAYos_ef-JtLU");
                helper.GetUpdate();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
