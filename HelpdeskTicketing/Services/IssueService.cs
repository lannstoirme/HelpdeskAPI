using System;
using System;
using HelpdeskTicketing.Models;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using HelpdeskTicketing.Controllers;
using Microsoft.AspNetCore.Routing;



namespace HelpdeskTicketing.Services
{
    public class IssueService
    {
        private readonly IMongoCollection<Issue> _issues;

        public IssueService(IHelpdeskDatabaseSettings settings)
        {

           
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _issues = database.GetCollection<Issue>(settings.IssueCollectionsName);
        }

        public List<Issue> Get() =>
            _issues.Find(issue => true).ToList();

        public Issue Get(string id) =>
            _issues.Find<Issue>(issue => issue.Id == id).FirstOrDefault();

        public Issue Create(Issue issue)
        {
            _issues.InsertOne(department);
            return ;
        }

        public void Update(string id, Issue issueIn) =>
            _issues.ReplaceOne(issue => issue.Id == id, issueIn);

        public void Remove(Department issueIn) =>
            _issues.DeleteOne(issue => issue.Id == issueIn.Id);

        public void Remove(string id) =>
            _departments.DeleteOne(issue => issue.Id == id);
    }

}
