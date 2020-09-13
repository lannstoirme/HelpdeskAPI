using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace HelpdeskTicketing
{
    public class Response
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("messageid")]

        public string MessageId { get; set; }

        [BsonElement("issueformed")]

        public string IssueFormed { get; set; }

        [BsonElement("adminofficerid")]

        public string AdminOfficerId { get; set; }

        [BsonElement("responsetext")]
        public string ResponseText { get; set; }

        [BsonElement("departmentid")]
        public string DepartmentId { get; set; }

        [BsonElement("category")]
        public string Category { get; set; }

        [BsonElement("meetingassigned")]
        public bool MeetingAssigned { get; set; }

        [BsonElement("meetingid")]
        public string MeetingId { get; set; }
    }
}
