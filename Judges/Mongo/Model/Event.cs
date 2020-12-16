using Microsoft.Extensions.Localization.Internal;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Judges.Mongo.Model
{
    public class Event
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [BsonElement("place")]
        [Display(Name = "Место проведения")]
        public string Place { get; set; }

        [BsonElement("date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Date { get; set; }

        [BsonElement("participants")]
        public string[] Participants { get; set; }
    }
}
