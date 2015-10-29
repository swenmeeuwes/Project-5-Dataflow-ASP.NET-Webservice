using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFlowWebservice.Models
{
    public class Monitoring : IResponseModel
    {
        public ObjectId _id { get; set; }
        public int unitId { get; set; }
        public string beginTime { get; set; }
        public string endTime { get; set; }
        public string sensorType { get; set; }
        public int minValue { get; set; }
        public int maxValue { get; set; }
    }
}