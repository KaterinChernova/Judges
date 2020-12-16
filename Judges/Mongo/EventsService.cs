using Judges.Mongo.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judges.Mongo
{
    public class EventsService
    {
        private IMongoCollection<Event> _events;

        public EventsService()
        {
            string connection = "mongodb://localhost:27017/eventsDataBase";

            MongoUrlBuilder builder = new MongoUrlBuilder(connection);

            MongoClient client = new MongoClient(connection);

            IMongoDatabase db = client.GetDatabase(builder.DatabaseName);

            _events = db.GetCollection<Event>("events");
        }

        public async Task<Event> Get(string id)
        {
            return await _events.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }

        public async Task<string> Create(Event eventModel)
        {
            await _events.InsertOneAsync(eventModel);

            return eventModel.Id;
        }

        public async Task Update(Event eventModel)
        {
            await _events.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(eventModel.Id)), eventModel);
        }

        public async Task Delete(string id)
        {
            await _events.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}
