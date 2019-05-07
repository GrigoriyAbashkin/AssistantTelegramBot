using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AssistantBot.Telegram.Models
{
    public class BotContext: DbContext
    {
        public DbSet<Theme> Themes { get; set; } 
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}