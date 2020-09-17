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

namespace HelpdeskTicketing.Services
{
    public class PositiveMessageService
    {
        private readonly IMongoCollection<Message> _messages;
        private readonly IMongoCollection<User> _users;
        private readonly MessageService _messageService;
        private readonly UserService _userService;

        //public List<String> positivemessageslist = new List<String>();

        public PositiveMessageService(IHelpdeskDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _messages = database.GetCollection<Message>(settings.MessageCollectionsName);
            _users = database.GetCollection<User>(settings.UserCollectionsName);
        }


        public List<string> PositiveMessageFilter(MessageService _messageService, UserService _userService)
        {


            var positivemessages = from message in _messageService.Get()
                                   join user in _userService.Get() on message.Id equals user.Id into userPositiveMessageGroup
                                   where message.SentimentApplied == true && message.Sentiment == "positive"
                                   select userPositiveMessageGroup;

     

            return (List<string>)positivemessages;

        }

       

}
}
