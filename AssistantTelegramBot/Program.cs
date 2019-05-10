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
        private static readonly TelegramBotClient bot = new TelegramBotClient("825644646:AAG5NpRzPEjtIuw2g0k_eo9Uv1B3NjufaBs");
        //private static DataSet dataSet = new DataSet();

        static void Main(string[] args)
        {
            bot.OnMessage += answer;

            //connectingDb();

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
                //case "/keyboardCustom":
                    
                //    DataRowCollection table = dataSet.Tables["Theme"].Rows;
                //    string[][] themes = new string[table.Count][];
                //    for (int i = 0; i < table.Count; i++)
                //    {
                //        themes[i] = new string[1] { table[i]["Name"].ToString() };
                //    }
                //    //ReplyKeyboardMarkup keyboardMarkup = new[]
                //    //{
                //    //    themes
                //    //};
                //    ReplyKeyboardMarkup keyboardMarkup = themes;
                //    bot.SendTextMessageAsync(message.Chat.Id, "ok", replyMarkup: keyboardMarkup);
                //    break;
                default:
                    bot.SendTextMessageAsync(message.Chat.Id, message.Text);
                    break;
            }
        
        }

        //private static void connectingDb()
        //{
        //    string connectionString = @"Data Source=.\SQLEXPRESS; Initial Catalog=AssistantDb; Integrated Security=True";
        //    string SelectAllTable = @"SELECT * FROM Theme
        //                              SELECT * FROM Question
        //                              SELECT * FROM Answer";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlDataAdapter adapter = new SqlDataAdapter(SelectAllTable, connection);
        //        adapter.TableMappings.Add("Table",  "Theme");
        //        adapter.TableMappings.Add("Table1", "Question");
        //        adapter.TableMappings.Add("Table2", "Answer");
        //        //DataSet dataSet = new DataSet();
        //        adapter.Fill(dataSet);
        //        /*foreach (DataRow i in dataSet.Tables["Theme"].Rows)
        //        {
        //            themes = i["Name"].ToString();
        //        }*/
        //    }
        //}
    }
}
