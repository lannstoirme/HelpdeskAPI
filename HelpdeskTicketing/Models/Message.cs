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
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("category")]
        public string Category { get; set; }

        [BsonElement("timestamp")]
        public string TimeStamp { get; set; }

        [BsonElement("subject")]
        public string Subject { get; set; }

        [BsonElement("userid")]
        public string UserId { get; set; }

        [BsonElement("sentimentapplied")]
        public bool SentimentApplied { get; set; }

        [BsonElement("sentiment")]
        public string Sentiment { get; set; }

        [BsonElement("responserequired")]
        public bool ResponseRequired { get; set; }

        [BsonElement("departmentassigned")]
        public bool DepartmentAssigned { get; set; }

        [BsonElement("departmentid")]
        public string DepartmentId { get; set; }

        [BsonElement("responsesent")]
        public bool ResponseSent { get; set; }

        [BsonElement("responseid")]
        public string ResponseId { get; set; }

        [BsonElement("messagetext")]
        public string MessageText { get; set; }

        [BsonElement("escalatetoissue")]
        public bool EscalateToIssue { get; set; }

        [BsonElement("priorityassigned")]
        public bool PriorityAssigned { get; set; }
    }
}
