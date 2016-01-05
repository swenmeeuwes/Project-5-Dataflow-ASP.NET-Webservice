using DataFlowWebservice.Controllers.Database;
using DataFlowWebservice.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataFlowWebservice.Controllers
{
    public class IdController : ApiController
    {
        DatabaseManager databaseManager;
        public IdController()
        {
            databaseManager = new DatabaseManager();
        }
        // GET: api/Id
        public IEnumerable<long> Get()
        {
            IEnumerable<BsonValue> bsonValues = databaseManager.GetDatabase().GetCollection<Position>("positions").Distinct("unitId");
            return BsonSerializer.Deserialize<List<long>>(bsonValues.ToJson());
        }
    }
}
