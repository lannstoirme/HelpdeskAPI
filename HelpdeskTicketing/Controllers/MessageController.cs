using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.AspNetCore.Routing;
using HelpdeskTicketing.Services;
using HelpdeskTicketing.Models;

namespace HelpdeskTicketing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {


        // private readonly ILogger<UserController> _logger;
        private readonly MessageService _messageService;

        //public UserController(ILogger<UserController> logger)
        //{
        //    _logger = logger;
        //}

        public MessageController(MessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public ActionResult<List<Message>> Get() =>
            _messageService.Get();


        [HttpGet("{Id}", Name = "GetMessage")]
        public ActionResult<Message> Get(string id)
        {
            var message = _messageService.Get(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

        [HttpPost]
        public ActionResult<Message> Create(Message message)
        {
            _messageService.Create(message);

            return CreatedAtRoute("GetMessage", new { id = message.Id.ToString() }, message);
        }

        [HttpPut("{Id}")]
        public IActionResult Update(string id, Message messageIn)
        {
            var user = _messageService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _messageService.Update(id, messageIn);

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(string id)
        {
            var message = _messageService.Get(id);

            if (message == null)
            {
                return NotFound();
            }

            _messageService.Remove(message.Id);

            return NoContent();
        }
        //public IEnumerable<User> Get()
        //{
        //    var client = new MongoClient("mongodb+srv://lannstoirme:Vienna1988!@cluster0.nwr3l.azure.mongodb.net/AsgardiaDB?retryWrites=true&w=majority");
        //    var database = client.GetDatabase("AsgardiaDB");
        //    var collection = database.GetCollection<User>("UserData");

        //    return collection.Find(s => s.NativeLanguage == "English").ToList();

        //}
    }
}
