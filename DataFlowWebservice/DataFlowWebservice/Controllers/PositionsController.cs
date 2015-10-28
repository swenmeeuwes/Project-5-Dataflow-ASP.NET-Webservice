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
        public IEnumerable<Position> Get()
        {
            MongoCursor<Position> cursor = database.GetCollection<Position>("positions").FindAll();
            return cursor.ToList();
        }

        // GET: api/Positions/5
        public IEnumerable<Position> Get(int id)
        {
            IMongoQuery query = Query<Position>.EQ(p => p.unitId, id); // Gebruikt position (p), van p check hij of het unitId en het opgegeven id hetzelfde zijn (EQ)
            return database.GetCollection<Position>("positions").Find(query);
        }

        // POST: api/Positions
        public void Post([FromBody]Position document)
        {
            //var document = new BsonDocument();
            //document["unitId"] = 100;

            //var document = new BsonDocument
            //{
            //    { "unitId" , 100},
            //    { "date", "10-3-2015"},
            //    { "time", "00:00:02"},
            //    { "rdX", 100 },
            //    { "rdY", 101 },
            //    { "latitude", 200 },
            //    { "longitude", 201 },
            //    { "speed", 19 },
            //    { "course", 360 },
            //    { "numSatellite", 2 },
            //    { "hdop", 10 },
            //    { "dopType", "Type1" }
            //};

            var collection = database.GetCollection<BsonDocument>("positions");
            collection.Insert(document);
        }

        // PUT: api/Positions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Positions/5
        public void Delete(int id)
        {
        }
    }
}
