using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace HelpdeskTicketing.Models
{
    public class Issue
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("meetingidentifier")]
        public string MeetingIdentifier { get; set; }

        [BsonElement("outcome")]
        public string Outcome { get; set; }

        [BsonElement("subject")]
        public string Subject { get; set; }

        [BsonElement("category")]
        public string Category { get; set; }

        [BsonElement("responsesent")]
        public bool ResponseSent { get; set; }

        [BsonElement("adminofficerid")]
        public string AdminOfficerId { get; set; }

        [BsonElement("departmentid")]
        public string DepartmentId { get; set; }
    }
}
