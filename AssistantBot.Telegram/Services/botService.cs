using AssistantBot.Telegram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace AssistantBot.Telegram.Services
{
    public class botService
    {
        BotContext _db { get; set; }

        public botService(BotContext db)
        {
            _db = db;
        }
        public void startBot()
        {
            Bot.bot.OnMessage += answer;
            Bot.bot.StartReceiving(Array.Empty<UpdateType>());
        }

        public void stopBot()
        {
            Bot.bot.StartReceiving();
        }

        private void answer(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;
            string[][] textMenu;
            IEnumerable<Theme> themes = _db.Themes;
            switch (message.Text)
            {
                case "/reply":
                    Bot.bot.SendTextMessageAsync(message.Chat.Id, "hi");
                    break;
                case "/start":
                    Array nameThemes = themes.Select(n => n.Name).ToArray();
                    textMenu = new string[nameThemes.Length][];
                    for (int i = 0; i < nameThemes.Length; i++)
                    {
                        textMenu[i] = new string[1] { nameThemes.GetValue(i).ToString() };
                    }
                    ReplyKeyboardMarkup keyboardMarkup = textMenu;
                    Bot.bot.SendTextMessageAsync(message.Chat.Id, "Здравствуйте. Вас приветствует Сервисная Группа. Чем могу Вам помочь?", replyMarkup: keyboardMarkup);
                    break;
                default:
                    //Bot.bot.SendTextMessageAsync(message.Chat.Id, message.Text);
                    if (themes.Select(n => n.Name).Contains(message.Text))
                    {
                        string question = _db.Questions.Where(t => t.ThemeId == 1).Select(n => n.Name).First();
                        //Bot.bot.SendTextMessageAsync(message.Chat.Id, question);

                        Array nameAnswer = _db.Answers.Where(q => q.QuestionId == 1).Select(n => n.Text).ToArray();
                        textMenu = new string[nameAnswer.Length][];
                        for (int i = 0; i < nameAnswer.Length; i++)
                        {
                            textMenu[i] = new string[1] { nameAnswer.GetValue(i).ToString() };
                        }
                        keyboardMarkup = textMenu;
                        Bot.bot.SendTextMessageAsync(message.Chat.Id, question, replyMarkup: keyboardMarkup);

                    }
                    break;
            }
        }
    }
}