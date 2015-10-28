using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFlowWebservice.Models
{
    public class Event
    {
        public ObjectId _id { get; set; }
        public int unitId { get; set; }
        public int ignition { get; set; }
        public int powerStatus { get; set; }
    }
}