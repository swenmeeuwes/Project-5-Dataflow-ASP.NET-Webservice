﻿using DataFlowWebservice.Controllers.Database;
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
    public class MonitoringsController : ApiController
    {
        private DatabaseManager databaseManager;

        public MonitoringsController()
        {
            databaseManager = new DatabaseManager();
        }
        // GET: api/Monitorings
        public ResponseModel Get()
        {
            MongoCursor<Monitoring> cursor = databaseManager.GetDatabase().GetCollection<Monitoring>("monitorings").FindAll();
            return new ResponseModel(cursor.ToList<IResponseModel>(), ResponseModel.RESPONSE_GET);
        }

        // GET: api/Monitorings/5
        public ResponseModel Get(int id)
        {
            IMongoQuery query = Query<Monitoring>.EQ(m => m.unitId, id); // Gebruikt monitoring (m), van m check hij of het unitId en het opgegeven id hetzelfde zijn (EQ)
            return new ResponseModel(databaseManager.GetDatabase().GetCollection<Monitoring>("monitorings").Find(query).ToList<IResponseModel>(), ResponseModel.RESPONSE_GET);
        }

        // POST: api/Monitorings
        public ResponseModel Post([FromBody]Monitoring document)
        {
            var collection = databaseManager.GetDatabase().GetCollection<BsonDocument>("monitorings");
            collection.Insert(document);

            return new ResponseModel(new List<IResponseModel>() { document }, ResponseModel.RESPONSE_POST);
        }

        // PUT: api/Monitorings/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Monitorings/5
        public ResponseModel Delete(int id)
        {
            IMongoQuery query = Query<Monitoring>.EQ(m => m.unitId, id); // Gebruikt monitoring (m), van m check hij of het unitId en het opgegeven id hetzelfde zijn (EQ)
            var collection = databaseManager.GetDatabase().GetCollection<BsonDocument>("monitorings");
            collection.Remove(query);

            return new ResponseModel(new List<IResponseModel>(), ResponseModel.RESPONSE_DELETE);
        }
    }
}
