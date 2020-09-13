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
    public class User
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("firstname")]

        public string FirstName { get; set; }

        [BsonElement("lastname")]

        public string LastName { get; set; }

        [BsonElement("discordid")]

        public string DiscordId { get; set; }

        [BsonElement("emailaddress")]

        public string EmailAddress { get; set; }

        [BsonElement("adminofficer")]

        public bool AdminOfficer { get; set; }

        [BsonElement("departmentid")]

        public string DepartmentId { get; set; }

        [BsonElement("country")]

        public string Country { get; set; }

        [BsonElement("adminofficerid")]

        public string AdminOfficerId { get; set; }

        [BsonElement("nativelanguage")]

        public string NativeLanguage { get; set; }

        [BsonElement("secondarylanguage")]

        public string SecondaryLanguage { get; set; }

        [BsonElement("cellnumber")]

        public string CellNumber { get; set; }

        [BsonElement("paidresidentfee")]

        public bool PaidResidentFee { get; set; }

        [BsonElement("numcontacts")]

        public int NumContacts { get; set; }

        [BsonElement("generalsentiment")]

        public string GeneralSentiment { get; set; }

        public string FullName
        {
            get
            { return $"{ FirstName } + ' ' + { LastName }";
            }
        }

    }
}