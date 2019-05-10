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
                    string welcome = "Здравствуйте. Вас приветствует Сервисная Группа. Чем могу Вам помочь?";
                    textMenu = new string[nameThemes.Length][];
                    for (int i = 0; i < nameThemes.Length; i++)
                    {
                        textMenu[i] = new string[1] { nameThemes.GetValue(i).ToString() };
                    }
                    ReplyKeyboardMarkup keyboardMarkup = textMenu;
                    Bot.bot.SendTextMessageAsync(message.Chat.Id, "Здравствуйте. Вас приветствует Сервисная Группа. Чем могу Вам помочь?", replyMarkup: keyboardMarkup);
                    //createKeyBoard(message.Chat.Id, nameThemes, welcome);
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
                        //createKeyBoard(message.Chat.Id, nameAnswer, question);
                    }
                    break;
            }
        }

        // прочее
        // находим вопросы по теме
        private IQueryable<string> findQuestion(string nameTheme)
        {
            // номер выводимого вопроса
            //int numberQuestion = 0;

            // находим id, темы которую выбрал пользователь
            int themeId = _db.Themes.Where(n => n.Name == nameTheme).Select(i => i.Id).FirstOrDefault();
            // ищем все вопросы c id темы
            IQueryable<string> questions = _db.Questions.Where(t => t.ThemeId == themeId).Select(n => n.Name);
            return questions;
        }

        // создаем клавиатуру (id чата, текст таблицы, строка приветствия)
        private void createKeyBoard(long chatId, Array textModels, string textGreet)
        {
            string[][] textRow = new string[textModels.Length][];
            for (int i = 0; i < textModels.Length; i++)
            {
                textRow[i] = new string[1] { textModels.GetValue(i).ToString() };
            }
            ReplyKeyboardMarkup keyboardMarkup = textRow;
            Bot.bot.SendTextMessageAsync(chatId, textGreet, replyMarkup: keyboardMarkup);
        }
    }
}