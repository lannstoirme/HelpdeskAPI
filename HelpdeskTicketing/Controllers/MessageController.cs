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
using System.Collections;

namespace HelpdeskTicketing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class MessageController : ControllerBase
    {



        private readonly MessageService _messageService;
        private readonly UserService _userService;

        public MessageController(MessageService messageService, UserService userService)
        {
            _messageService = messageService;
            _userService = userService;
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

        [Route("[controller]/[action]")]
        public IActionResult PosSentiment()
        {
            //move this back into messageservice

            var posmessages = from message in _messageService.Get()
                join user in _userService.Get() on message.Id equals user.Id into userPositiveMessageGroup
                where message.SentimentApplied == true && message.Sentiment == "positive"
                select userPositiveMessageGroup;


            var posMessagesList = new ArrayList();

            foreach (var item in posmessages)
            {
                posMessagesList.Add(item);
            }

            return (IActionResult)posMessagesList;
                
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
            var message = _messageService.Get(id);

            if (message == null)
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
       
    }
}
