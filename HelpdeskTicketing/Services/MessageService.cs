using System;
using HelpdeskTicketing.Models;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using HelpdeskTicketing.Controllers;
using Microsoft.AspNetCore.Routing;



namespace HelpdeskTicketing.Services
{
    public class MessageService
    {
        private readonly IMongoCollection<Message> _messages;

        public MessageService(IHelpdeskDatabaseSettings settings)
        {

            //var client = new MongoClient("mongodb+srv://lannstoirme:Vienna1988!@cluster0.nwr3l.azure.mongodb.net/AsgardiaDB?retryWrites=true&w=majority");
            //var database = client.GetDatabase("AsgardiaDB");

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _messages = database.GetCollection<Message>(settings.MessageCollectionsName);
        }

        public List<Message> Get() =>
            _messages.Find(user => true).ToList();

        public Message Get(string id) =>
            _messages.Find<Message>(message => message.Id == id).FirstOrDefault();

        public Message Create(Message message)
        {
            _messages.InsertOne(message);
            return message;
        }

        public void Update(string id, Message messageIn) =>
            _messages.ReplaceOne(message => message.Id == id, messageIn);

        public void Remove(Message messageIn) =>
            _messages.DeleteOne(message => message.Id == messageIn.Id);

        public void Remove(string id) =>
            _messages.DeleteOne(message => message.Id == id);
    }

}

