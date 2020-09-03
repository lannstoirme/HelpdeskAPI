using System;
using HelpdeskTicketing.Models;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using HelpdeskTicketing.Controllers;
using Microsoft.AspNetCore.Routing;


namespace HelpdeskTicketing.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IHelpdeskDatabaseSettings settings)
        {

            //var client = new MongoClient("mongodb+srv://lannstoirme:Vienna1988!@cluster0.nwr3l.azure.mongodb.net/AsgardiaDB?retryWrites=true&w=majority");
            //var database = client.GetDatabase("AsgardiaDB");

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UserCollectionsName);
        }

        public List<User> Get() =>
            _users.Find(user => true).ToList();

        public User Get(string id) =>
            _users.Find<User>(user => user.Id == id).FirstOrDefault();

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn) =>
            _users.ReplaceOne(user => user.Id == id, userIn);

        public void Remove(User userIn) =>
            _users.DeleteOne(user => user.Id == userIn.Id);

        public void Remove(string id) =>
            _users.DeleteOne(user => user.Id == id);
    }

}
