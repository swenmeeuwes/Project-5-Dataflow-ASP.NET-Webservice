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
        public ResponseModel Get()
        {
            MongoCursor<Position> cursor = databaseManager.GetDatabase().GetCollection<Position>("positions").FindAll();
            return new ResponseModel(cursor.ToList<IResponseModel>(), ResponseModel.RESPONSE_GET);
        }

        // GET: api/Positions/5
        public ResponseModel Get(long id)
        {
            IMongoQuery query = Query<Position>.EQ(p => p.unitId, id); // Gebruikt position (p), van p check hij of het unitId en het opgegeven id hetzelfde zijn (EQ)
            return new ResponseModel(databaseManager.GetDatabase().GetCollection<Position>("positions").Find(query).ToList<IResponseModel>(), ResponseModel.RESPONSE_GET);
        }

        // POST: api/Positions
        public ResponseModel Post([FromBody]Position document)
        {
            var collection = databaseManager.GetDatabase().GetCollection<BsonDocument>("positions");
            collection.Insert(document);

            return new ResponseModel(new List<IResponseModel>() { document }, ResponseModel.RESPONSE_POST);
        }

        // PUT: api/Positions/5
        public void Put(long id, [FromBody]string value)
        {
        }

        // DELETE: api/Positions/5
        public ResponseModel Delete(long id)
        {
            IMongoQuery query = Query<Position>.EQ(p => p.unitId, id); // Gebruikt position (p), van p check hij of het unitId en het opgegeven id hetzelfde zijn (EQ)
            var collection = databaseManager.GetDatabase().GetCollection<BsonDocument>("positions");
            collection.Remove(query);

            return new ResponseModel(new List<IResponseModel>(), ResponseModel.RESPONSE_DELETE);
        }
    }
}
