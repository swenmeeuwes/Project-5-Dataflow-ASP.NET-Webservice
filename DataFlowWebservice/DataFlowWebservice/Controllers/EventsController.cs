using DataFlowWebservice.Controllers.Database;
using DataFlowWebservice.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataFlowWebservice.Controllers
{
    public class EventsController : ApiController
    {
        private DatabaseManager databaseManager;

        public EventsController()
        {
            databaseManager = new DatabaseManager();
        }
        // GET: api/Events
        public IEnumerable<Event> Get()
        {
            return databaseManager.GetDatabase().GetCollection<Event>("events").FindAll();
        }

        // GET: api/Events/5
        public IEnumerable<Event> Get(long id)
        {
            IMongoQuery query = Query<Event>.EQ(e => e.unitId, id); // Gebruikt event (e), van e check hij of het unitId en het opgegeven id hetzelfde zijn (EQ)
            return databaseManager.GetDatabase().GetCollection<Event>("events").Find(query);
        }

        // POST: api/Events
        public void Post([FromBody]Event[] document)
        {
            var collection = databaseManager.GetDatabase().GetCollection<BsonDocument>("events");
            foreach (var item in document)
            {
                collection.Insert(item);
            }
        }

        // PUT: api/Events/5
        public void Put(long id, [FromBody]Event document)
        {
            IMongoQuery query = Query<Event>.EQ(e => e.unitId, id); // Gebruikt event (e), van e check hij of het unitId en het opgegeven id hetzelfde zijn (EQ)
            var collection = databaseManager.GetDatabase().GetCollection<BsonDocument>("events");
            var update = Update.Replace(document);
            collection.Update(query, update);
        }

        // DELETE: api/Events/5
        public void Delete(long id)
        {
            IMongoQuery query = Query<Event>.EQ(e => e.unitId, id); // Gebruikt event (e), van e check hij of het unitId en het opgegeven id hetzelfde zijn (EQ)
            var collection = databaseManager.GetDatabase().GetCollection<BsonDocument>("events");
            collection.Remove(query);
        }
    }
}
