﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFlowWebservice.Models
{
    public class Event : IResponseModel
    {
        public ObjectId _id { get; set; }
        public DateTime dateTime { get; set; }
        public long unitId { get; set; }
        public string port { get; set; }
        public int portValue { get; set; }
    }
}