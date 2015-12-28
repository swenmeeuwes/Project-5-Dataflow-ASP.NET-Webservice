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

        public IEnumerable<Event> Get(string beginDate, string endDate)
        {
            string[] beginDateSplitted = beginDate.Split('-');
            string[] endDateSplitted = endDate.Split('-');

            DateTime begin = new DateTime(Convert.ToInt32(beginDateSplitted[0]), Convert.ToInt32(beginDateSplitted[1]), Convert.ToInt32(beginDateSplitted[2]));
            DateTime end = new DateTime(Convert.ToInt32(endDateSplitted[0]), Convert.ToInt32(endDateSplitted[1]), Convert.ToInt32(endDateSplitted[2]));

            IMongoQuery query = Query<Event>.Where(m => m.dateTime >= begin && m.dateTime <= end); // Gebruikt event (e), van e check hij of het unitId en het opgegeven id hetzelfde zijn (EQ)
            return databaseManager.GetDatabase().GetCollection<Event>("events").Find(query);
        }

        // POST: api/Events
        public void Post([FromBody]Event document)
        {
            var collection = databaseManager.GetDatabase().GetCollection<BsonDocument>("events");
            collection.Insert(document);
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
