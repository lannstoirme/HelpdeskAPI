﻿using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpdeskTicketing.Models
{
    public class HelpdeskDatabaseSettings : IHelpdeskDatabaseSettings
    {
        public string UserCollectionsName { get; set; }
        public string MessageCollectionsName { get; set; }
        public string DepartmentCollectionsName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string IssueCollectionsName { get; set; }
        public string OutcomeCollectionsName { get; set; }
        public string ResponseCollectionsName { get; set; }
        public string MeetingCollectionsName { get; set; }
    }

    public interface IHelpdeskDatabaseSettings
    {
        string UserCollectionsName { get; set; }
        string MessageCollectionsName { get; set; }
        string DepartmentCollectionsName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string IssueCollectionsName { get; set; }
        string OutcomeCollectionsName { get; set; }
        string ResponseCollectionsName { get; set; }
        string MeetingCollectionsName { get; set; }

    }
}
