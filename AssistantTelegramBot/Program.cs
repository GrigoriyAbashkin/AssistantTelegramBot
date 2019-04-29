using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

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
            switch (message.Text) {
                case "/reply":
                    bot.SendTextMessageAsync(message.Chat.Id, "hi");
                    break;
                case "/keyboard":
                    bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
                    var inlineKeyboard = new InlineKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("1"),
                            InlineKeyboardButton.WithCallbackData("2"),
                            InlineKeyboardButton.WithCallbackData("3")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("4"),
                            InlineKeyboardButton.WithCallbackData("5"),
                            InlineKeyboardButton.WithCallbackData("6")
                        },
                    });
                    bot.SendTextMessageAsync(message.Chat.Id, "ok", replyMarkup: inlineKeyboard);
                    break;
                case "/keyboardCustom":
                    ReplyKeyboardMarkup keyboardMarkup = new[]
                    {
                        new []{"0", "1"},
                        new []{"2", "3"}
                    };
                    bot.SendTextMessageAsync(message.Chat.Id, "ok", replyMarkup: keyboardMarkup);
                    break;
                default:
                    bot.SendTextMessageAsync(message.Chat.Id, message.Text);
                    break;
            }
        
        }
    }
}
