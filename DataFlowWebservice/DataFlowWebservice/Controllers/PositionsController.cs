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
using System.Threading.Tasks;
using System.Web.Http;

namespace DataFlowWebservice.Controllers
{
    public class PositionsController : ApiController
    {
        private DatabaseManager databaseManager;

        public PositionsController()
        {
            databaseManager = new DatabaseManager();
        }
        // GET: api/Positions
        public IEnumerable<Position> Get()
        {
            return databaseManager.GetDatabase().GetCollection<Position>("positions").FindAll();
        }

        // GET: api/Positions/5
        public IEnumerable<Position> Get(long id)
        {
            IMongoQuery query = Query<Position>.EQ(p => p.unitId, id); // Gebruikt position (p), van p check hij of het unitId en het opgegeven id hetzelfde zijn (EQ)
            return databaseManager.GetDatabase().GetCollection<Position>("positions").Find(query);
        }

        // POST: api/Positions
        public void Post([FromBody]Position[] document)
        {
            var collection = databaseManager.GetDatabase().GetCollection<BsonDocument>("positions");
            foreach (var item in document)
            {
                collection.Insert(item);
            }
        }

        // DELETE: api/Positions/5
        public void Delete(long id)
        {
            IMongoQuery query = Query<Position>.EQ(p => p.unitId, id); // Gebruikt position (p), van p check hij of het unitId en het opgegeven id hetzelfde zijn (EQ)
            var collection = databaseManager.GetDatabase().GetCollection<BsonDocument>("positions");
            collection.Remove(query);
        }
    }
}
