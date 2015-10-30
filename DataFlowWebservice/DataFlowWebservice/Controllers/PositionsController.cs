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
        private MongoDatabase database;

        public PositionsController()
        {
            // Bouwt een connection string (optie 1)
            MongoServerSettings settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress("localhost", 27017); //145.24.222.160
            // Maakt een MongoDB server object, met dit object kunnen we communiceren met de server. Het maakt kortom verbinding met de mongodb server
            MongoServer server = new MongoServer(settings);
            // Vraagt onze database op van de server, zodat we read/write kunnen toepassen
            database = server.GetDatabase("Dataflow");


            //Declareerd een directe connection string (optie 2)
            //string connectionString = "mongodb://localhost"; //145.24.222.160:27017
            //var client = new MongoClient(connectionString);
            //database = client.GetDatabase("Dataflow");
        }
        // GET: api/Positions
        public ResponseModel Get()
        {
            MongoCursor<IResponseModel> cursor = database.GetCollection<IResponseModel>("positions").FindAll();
            return new ResponseModel(cursor.ToList(), ResponseModel.RESPONSE_GET);
        }

        // GET: api/Positions/5
        public ResponseModel Get(int id)
        {
            IMongoQuery query = Query<Position>.EQ(p => p.unitId, id); // Gebruikt position (p), van p check hij of het unitId en het opgegeven id hetzelfde zijn (EQ)
            return new ResponseModel(database.GetCollection<Position>("positions").Find(query).ToList<IResponseModel>(), ResponseModel.RESPONSE_GET);
        }

        // POST: api/Positions
        public ResponseModel Post([FromBody]Position document)
        {
            var collection = database.GetCollection<BsonDocument>("positions");
            collection.Insert(document);

            return new ResponseModel(new List<IResponseModel>() { document }, ResponseModel.RESPONSE_POST);
        }

        // PUT: api/Positions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Positions/5
        public ResponseModel Delete(int id)
        {
            IMongoQuery query = Query<Position>.EQ(p => p.unitId, id); // Gebruikt position (p), van p check hij of het unitId en het opgegeven id hetzelfde zijn (EQ)
            var collection = database.GetCollection<BsonDocument>("positions");
            collection.Remove(query);

            return new ResponseModel(new List<IResponseModel>(), ResponseModel.RESPONSE_DELETE);
        }
    }
}
