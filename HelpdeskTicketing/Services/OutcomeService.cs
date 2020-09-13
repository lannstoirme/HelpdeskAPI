using System;
using HelpdeskTicketing.Models;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using HelpdeskTicketing.Controllers;
using Microsoft.AspNetCore.Routing;



namespace HelpdeskTicketing.Services
    {
        public class OutcomeService
        {
            private readonly IMongoCollection<Outcome> _outcomes;

            public OutcomeService(IHelpdeskDatabaseSettings settings)
            {

                var client = new MongoClient(settings.ConnectionString);
                var database = client.GetDatabase(settings.DatabaseName);

                _outcomes = database.GetCollection<Outcome>(settings.OutcomeCollectionsName);
            }

            public List<Outcome> Get() =>
                _outcomes.Find(outcome => true).ToList();

            public Outcome Get(string id) =>
                _outcomes.Find<Outcome>(outcome => outcome.Id == id).FirstOrDefault();

            public Outcome Create(Outcome outcome)
            {
                _outcomes.InsertOne(outcome);
                return outcome;
            }

            public void Update(string id, Outcome outcomeIn) =>
                _outcomes.ReplaceOne(outcome => outcome.Id == id, outcomeIn);

            public void Remove(Outcome outcomeIn) =>
                _outcomes.DeleteOne(outcome => outcome.Id == outcomeIn.Id);

            public void Remove(string id) =>
                _outcomes.DeleteOne(outcome => outcome.Id == id);
        }

    }