using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFlowWebservice.Models
{
    public class Connection : IResponseModel
    {
        public ObjectId _id { get; set; }
        public int unitId { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public int port { get; set; }
        public int isConnected { get; set; }
    }
}