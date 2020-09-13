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
    public class Outcome
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("accept")]
        public bool Accept { get; set; }

        [BsonElement("notes")]
        public string Notes { get; set; }

        [BsonElement("meetingidentifier")]
        public string MeetingIdentifier { get; set; }
    }

}
