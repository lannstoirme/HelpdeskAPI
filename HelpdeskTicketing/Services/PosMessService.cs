using System;
using HelpdeskTicketing.Controllers;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;
using HelpdeskTicketing.Models;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections;
using Microsoft.AspNetCore.Mvc;


//API endpoint return messages and users that offered positive feedback
namespace HelpdeskTicketing.Services
    {


    public class PosMessService
    {
        //public List<PosMess> = new List<PosMess>();
       

        private readonly IMongoCollection<Message> _messages;
        private readonly IMongoCollection<User> _users;

        public PosMessService(IHelpdeskDatabaseSettings settings)
        {
            
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _messages = database.GetCollection<Message>(settings.MessageCollectionsName);
            _users = database.GetCollection<User>(settings.UserCollectionsName);


         
        }

        internal ActionResult Get()
        {
            throw new NotImplementedException();
        }

        internal ActionResult Get(string id)
        {
            throw new NotImplementedException();
        }

        //Get all positive messages and add to a list
        void PosMessages()
        {
            var posMessages =
                from message in _messages.AsQueryable<Message>()
                join user in _users.AsQueryable<User>() on message.Id equals user.Id into userPositiveMessageGroup
                where message.SentimentApplied == true && message.Sentiment == "positive"
                select userPositiveMessageGroup;

            var posMessagesList = new ArrayList();

            foreach (var item in posMessages)
            {
                posMessagesList.Add(item);
            }

           
        }

        
        //public PosMessages Get(string Id)

        //TO DO Add Controller and Get function
       

      

    }
}
