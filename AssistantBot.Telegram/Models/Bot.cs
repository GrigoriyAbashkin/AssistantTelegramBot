using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;

namespace AssistantBot.Telegram.Models
{
    public static class Bot
    {
        private static string Token { get; }
        public static TelegramBotClient bot { get; }

        static Bot()
        {
            Token = "825644646:AAG5NpRzPEjtIuw2g0k_eo9Uv1B3NjufaBs";
            bot = new TelegramBotClient(Token);
        }
    }
}