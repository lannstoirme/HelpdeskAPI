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
    public class PositiveMessageService : IEnumerable<string>
    {
        private readonly IMongoCollection<Message> _messages;
        private readonly IMongoCollection<User> _users;
        private readonly MessageService _messageService;
        private readonly UserService _userService;

        public List<string> positivemessages;

        

        public PositiveMessageService(IHelpdeskDatabaseSettings settings, string[] positivemessages, MessageService _messageService, UserService _userService)
        {
            //var client = new MongoClient(settings.ConnectionString);
            //var database = client.GetDatabase(settings.DatabaseName);

            //_messages = database.GetCollection<Message>(settings.MessageCollectionsName);
            //_users = database.GetCollection<User>(settings.UserCollectionsName);

            //this.positivemessages = new List<string>(positivemessages);

            //var positivemessages = from message in _messageService.Get()
            //                       join user in _userService.Get() on message.Id equals user.Id into userPositiveMessageGroup
            //                       where message.SentimentApplied == true && message.Sentiment == "positive"
            //                       select userPositiveMessageGroup.ToList();

            var client = new MongoClient("mongodb+srv://lannstoirme:#####@cluster0.nwr3l.azure.mongodb.net/AsgardiaDB?retryWrites=true&w=majority");
            var database = client.GetDatabase("AsgardiaDB");
            var collection = database.GetCollection<Message>("Message");
            var collection2 = database.GetCollection<User>("UserData");

            //var query =
            //    from p in collection.AsQueryable<Message>()
            //    where p.Sentiment == "positive"
            //    select p;

            var innerJoinQuery =
                from p in collection.AsQueryable<Message>()
                join p2 in collection2.AsQueryable<User>() on p.UserId equals p2.DiscordId
                where p.Sentiment == "positive"
                select new { UnId = p2.Id, FName = p2.FirstName, LName = p2.LastName, MessageContent = p.MessageText };

            //foreach (var message in query)
            //{
            //    Console.WriteLine(message.MessageText);
            //}

            foreach (var message in innerJoinQuery)
            {
                Console.WriteLine("Unique Identifier is: " + message.UnId);
                Console.WriteLine("Name is: " + message.FName + ' ' + message.LName);
                Console.WriteLine("Message content is: " + message.MessageContent);

                //public List<AsyncResult> result = new List<AsyncResult>();


            }


        }