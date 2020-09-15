using System;
using HelpdeskTicketing.Models;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using HelpdeskTicketing.Controllers;
using Microsoft.AspNetCore.Routing;



namespace HelpdeskTicketing.Services
{
    public class ResponseService
    {
        private readonly IMongoCollection<Response> _responses;

        public ResponseService(IHelpdeskDatabaseSettings settings)
        {

            
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _responses = database.GetCollection<Response>(settings.ResponseCollectionsName);
        }

        public List<Response> Get() =>
            _responses.Find(user => true).ToList();

        public Response Get(string id) =>
            _responses.Find<Response>(response => response.Id == id).FirstOrDefault();

        public Response Create(Response response)
        {
            _responses.InsertOne(response);
            return response;
        }

        public void Update(string id, Response responseIn) =>
            _responses.ReplaceOne(response => response.Id == id, responseIn);

        public void Remove(Response responseIn) =>
            _responses.DeleteOne(response => response.Id == responseIn.Id);

        public void Remove(string id) =>
            _responses.DeleteOne(response => response.Id == id);
    }

}
