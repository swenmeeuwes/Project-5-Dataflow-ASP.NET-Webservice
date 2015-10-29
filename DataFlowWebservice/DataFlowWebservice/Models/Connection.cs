using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFlowWebservice.Models
{
    [Obsolete]
    public class Connection : IResponseModel
    {
        public ObjectId _id { get; set; }
        public int unitId { get; set; }
        public DateTime dateTime { get; set; }
        public int port { get; set; }
        public int isConnected { get; set; }
    }
}