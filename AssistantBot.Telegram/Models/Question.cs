using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssistantBot.Telegram.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Theme Theme { get; set; }
        public int? ThemeId { get; set; }
        public ICollection<Answer> Answers { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}