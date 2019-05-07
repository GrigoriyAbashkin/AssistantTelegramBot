using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssistantBot.Telegram.Models
{
    public class Theme
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Question> Questions { get; set; }

        public Theme()
        {
            Questions = new List<Question>();
        }
    }
}