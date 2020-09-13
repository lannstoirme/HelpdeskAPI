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
    public class DepartmentService
    {
        private readonly IMongoCollection<Department> _messages;

        public DepartmentService(IHelpdeskDatabaseSettings settings)
        {

            //var client = new MongoClient("mongodb+srv://lannstoirme:Vienna1988!@cluster0.nwr3l.azure.mongodb.net/AsgardiaDB?retryWrites=true&w=majority");
            //var database = client.GetDatabase("AsgardiaDB");

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _departments = database.GetCollection<Department>(settings.DepartmentCollectionsName);
        }

        public List<Department> Get() =>
            _departments.Find(user => true).ToList();

        public Department Get(string id) =>
            _departments.Find<Department>(department => department.Id == id).FirstOrDefault();

        public Department Create(Department department)
        {
            _departments.InsertOne(department);
            return department;
        }

        public void Update(string id, Department departmentIn) =>
            _departments.ReplaceOne(department => department.Id == id, departmentIn);

        public void Remove(Department departmentIn) =>
            _departments.DeleteOne(department => department.Id == departmentIn.Id);

        public void Remove(string id) =>
            _departments.DeleteOne(department => department.Id == id);
    }

}