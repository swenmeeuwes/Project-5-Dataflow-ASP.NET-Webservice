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
        public ResponseModel Get()
        {
            MongoCursor<Event> cursor = databaseManager.GetDatabase().GetCollection<Event>("events").FindAll();
            return new ResponseModel(cursor.ToList<IResponseModel>(), ResponseModel.RESPONSE_GET);
        }

        // GET: api/Events/5
        public ResponseModel Get(int id)
        {
            IMongoQuery query = Query<Event>.EQ(e => e.unitId, id); // Gebruikt event (e), van e check hij of het unitId en het opgegeven id hetzelfde zijn (EQ)
            return new ResponseModel(databaseManager.GetDatabase().GetCollection<Event>("events").Find(query).ToList<IResponseModel>(), ResponseModel.RESPONSE_GET);
        }

        // POST: api/Events
        public ResponseModel Post([FromBody]Event document)
        {
            var collection = databaseManager.GetDatabase().GetCollection<BsonDocument>("events");
            collection.Insert(document);

            return new ResponseModel(new List<IResponseModel>() { document }, ResponseModel.RESPONSE_POST);
        }

        // PUT: api/Events/5
        public ResponseModel Put(int id, [FromBody]Event document)
        {
            IMongoQuery query = Query<Event>.EQ(e => e.unitId, id); // Gebruikt event (e), van e check hij of het unitId en het opgegeven id hetzelfde zijn (EQ)
            var collection = databaseManager.GetDatabase().GetCollection<BsonDocument>("events");
            var update = Update.Replace(document);
            collection.Update(query, update);

            return new ResponseModel(new List<IResponseModel>(), ResponseModel.RESPONSE_PUT);
        }

        // DELETE: api/Events/5
        public ResponseModel Delete(int id)
        {
            IMongoQuery query = Query<Event>.EQ(e => e.unitId, id); // Gebruikt event (e), van e check hij of het unitId en het opgegeven id hetzelfde zijn (EQ)
            var collection = databaseManager.GetDatabase().GetCollection<BsonDocument>("events");
            collection.Remove(query);

            return new ResponseModel(new List<IResponseModel>() , ResponseModel.RESPONSE_DELETE);
        }
    }
}
