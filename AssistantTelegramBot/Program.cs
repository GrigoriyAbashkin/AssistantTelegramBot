using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace AssistantTelegramBot
{
    class Program
    {
        private static readonly TelegramBotClient bot = new TelegramBotClient("");

        static void Main(string[] args)
        {
            bot.OnMessage += answer;

            Console.WriteLine(connectingDb());
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

        private static string connectingDb()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS; Initial Catalog=AssistantDb; Integrated Security=True";
            string SelectAllTable = @"SELECT * FROM Theme
                                      SELECT * FROM Question
                                      SELECT * FROM Answer";

            string themes = "1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(SelectAllTable, connection);
                adapter.TableMappings.Add("Table",  "Theme");
                adapter.TableMappings.Add("Table1", "Question");
                adapter.TableMappings.Add("Table2", "Answer");
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                foreach (DataRow i in dataSet.Tables["Theme"].Rows)
                {
                    themes = i["Name"].ToString();
                }
            }
            return themes;
        }
    }
}
