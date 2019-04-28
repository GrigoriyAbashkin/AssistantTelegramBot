using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace AssistantTelegramBot
{
    class Program
    {
        private static readonly TelegramBotClient bot = new TelegramBotClient("825644646:AAG2dgY8DmeEZtkUhsMZx4boJNCvg-TSfDQ");

        static void Main(string[] args)
        {
            bot.OnMessage += answer;

            bot.StartReceiving(Array.Empty<UpdateType>());
            Console.ReadLine();
            bot.StopReceiving();
        }

        private static void answer(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;
            if (message.Text == "/reply")
            {
                bot.SendTextMessageAsync(message.Chat.Id, "hi");
            }
            else
            {
                bot.SendTextMessageAsync(message.Chat.Id, message.Text);
            }
        }
    }
}
