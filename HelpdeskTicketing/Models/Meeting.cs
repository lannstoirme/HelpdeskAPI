using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace HelpdeskTicketing
{
    public class Meeting
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("adminofficeridattending")]

        public string AdminOfficerIdAttending { get; set; }

        [BsonElement("timestamp")]

        public string TimeStamp { get; set; }

        [BsonElement("issuelistid")]

        public string IssueListId { get; set; }
    }
}