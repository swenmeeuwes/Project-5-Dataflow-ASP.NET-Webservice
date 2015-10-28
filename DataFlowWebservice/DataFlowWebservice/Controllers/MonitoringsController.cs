using DataFlowWebservice.Models;
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
    public class MonitoringsController : ApiController
    {
        private MongoDatabase database;

        public MonitoringsController()
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
        // GET: api/Monitorings
        public IEnumerable<Monitoring> Get()
        {
            MongoCursor<Monitoring> cursor = database.GetCollection<Monitoring>("monitorings").FindAll();
            return cursor.ToList();
        }

        // GET: api/Monitorings/5
        public IEnumerable<Monitoring> Get(int id)
        {
            IMongoQuery query = Query<Monitoring>.EQ(m => m.unitId, id); // Gebruikt monitoring (m), van m check hij of het unitId en het opgegeven id hetzelfde zijn (EQ)
            return database.GetCollection<Monitoring>("monitorings").Find(query);
        }

        // POST: api/Monitorings
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Monitorings/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Monitorings/5
        public void Delete(int id)
        {
        }
    }
}
