using AssistantBot.Telegram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AssistantBot.Telegram.Controllers.api
{
    public class RedactionController : ApiController
    {
        BotContext _db = new BotContext();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("api/GetAllThemes")]
        public IEnumerable<Theme> GetAllThemes()
        {
            return _db.Themes;//.Select(n => n.Name);
        }
    }
}