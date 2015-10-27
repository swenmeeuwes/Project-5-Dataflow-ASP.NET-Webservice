using DataFlowWebservice.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataFlowWebservice.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Position> Get()
        {
            int amount = 100;
            Position[] positions = new Position[amount];
            for (int i = 0; i < amount; i++)
            {
                positions[i] = new Position().generate();
            }
            
            return positions;
        }

        // GET api/values/5
        public Position Get(int unitId)
        {
            //string connectionString = "mongodb://root:root@145.24.222.160:27017/Dataflow";//ConfigurationManager.AppSettings["connectionString"];

            //IMongoClient mongoClient = new MongoClient(connectionString);

            //IMongoDatabase db = mongoClient.GetDatabase("test");
            //var collection = db.GetCollection<BsonDocument>("positions");

            //var positionObject = new Position(collection.ToJson().ToString());

            var connectionString = "mongodb://145.24.222.160:27017";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            server.Ping();

            Position position = new Position().generate();
            position.unitId = unitId;

            return position;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
