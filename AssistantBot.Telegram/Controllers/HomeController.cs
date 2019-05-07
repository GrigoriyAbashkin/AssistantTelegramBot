using AssistantBot.Telegram.Models;
using AssistantBot.Telegram.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace AssistantBot.Telegram.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            BotContext _db = new BotContext();
            botService service = new botService(_db);
            Task.Run(()=>service.startBot());
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}