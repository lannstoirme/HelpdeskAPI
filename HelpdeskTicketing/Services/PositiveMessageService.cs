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
using System.Collections.ObjectModel;

namespace HelpdeskTicketing.Services
{
    public class PositiveMessageService
    {

        private readonly IMongoCollection<Message> _messages;
        private readonly IMongoCollection<User> _users;
        private readonly MessageService _messageService;
        private readonly UserService _userService;


        public PositiveMessageService(IHelpdeskDatabaseSettings settings, MessageService _messageService, UserService _userService)
        {


            var client = new MongoClient("mongodb+srv://lannstoirme:#####@cluster0.nwr3l.azure.mongodb.net/AsgardiaDB?retryWrites=true&w=majority");
            var database = client.GetDatabase("AsgardiaDB");
            var collection = database.GetCollection<Message>("Message");
            var collection2 = database.GetCollection<User>("UserData");

            var positivemessages =
                       from p in collection.AsQueryable<Message>()
                       join p2 in collection2.AsQueryable<User>() on p.UserId equals p2.DiscordId
                       where p.Sentiment == "positive"
                       select new
                       {
                           UnId = p2.Id,
                           Category = p.Category,
                           DiscordId = p2.DiscordId,
                           EmailAddress = p2.EmailAddress,
                           TimeStamp = p.TimeStamp,
                           Subject = p.Subject,
                           FName = p2.FirstName,
                           LName = p2.LastName,
                           MessageContent = p.MessageText,
                           ResponseRequired = p.ResponseRequired,
                           DepartmentAssigneed = p.DepartmentAssigned,
                           DepartmentId = p.DepartmentId,
                           ResponseSent = p.ResponseSent,
                           ResponseId = p.ResponseId,
                           EscalateToIssue = p.EscalateToIssue,
                           PriorityAssigned = p.PriorityAssigned,
                       };
        }

        // create new class PositiveMessages that is a List<PositiveMessages> positivemessages = new List<PositiveMessages>();
        // Use MapReduce to create the class out of the two collections - Message and User
        // The service PositiveMessages creates the new collection
        // The PositiveServiceModel will display the API call for PositiveMessageCollection
        public class PositiveMessages
        {

            public string Id { get; set; }

            public string UnId { get; set; }

            public string Category { get; set; }

            public string TimeStamp { get; set; }

            public string Subject { get; set; }

            public string DiscordId { get; set; }

            public string EmailAddress { get; set; }

            public string FName { get; set; }

            public string LName { get; set; }

            public bool ResponseRequired { get; set; }

            public bool DepartmentAssigned { get; set; }

            public string DepartmentId { get; set; }

            public bool ResponseSent { get; set; }

            public string ResponseId { get; set; }

            public string MessageContent { get; set; }

            public bool EscalateToIssue { get; set; }

            public int PriorityAssigned { get; set; }

        }

        public static List<PositiveMessages> positivemessages = new List<PositiveMessages>();

       


        //   foreach (var message in innerJoinQuery)
        //   {
        //       Console.WriteLine("Unique Identifier is: " + message.UnId);
        //       Console.WriteLine("Name is: " + message.FName + ' ' + message.LName);
        //       Console.WriteLine("Message content is: " + message.MessageContent);


        //DO THIS USING MAPREDUCE

    }
}


        //private readonly IMongoCollection<Response> _responses;

        //public ResponseService(IHelpdeskDatabaseSettings settings)
        //{


        //    var client = new MongoClient(settings.ConnectionString);
        //    var database = client.GetDatabase(settings.DatabaseName);

        //    _responses = database.GetCollection<Response>(settings.ResponseCollectionsName);
        //}

        //public List<Response> Get() =>
        //    _responses.Find(user => true).ToList();

        //public Response Get(string id) =>
        //    _responses.Find<Response>(response => response.Id == id).FirstOrDefault();

        //public Response Create(Response response)
        //{
        //    _responses.InsertOne(response);
        //    return response;
        //}

        //public void Update(string id, Response responseIn) =>
        //    _responses.ReplaceOne(response => response.Id == id, responseIn);

        //public void Remove(Response responseIn) =>
        //    _responses.DeleteOne(response => response.Id == responseIn.Id);

        //public void Remove(string id) =>
        //    _responses.DeleteOne(response => response.Id == id);
    //}
       