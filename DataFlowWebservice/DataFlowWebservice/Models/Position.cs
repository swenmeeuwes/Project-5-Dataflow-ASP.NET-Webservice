using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFlowWebservice.Models
{
    public class Position
    {
        public int unitId { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public float rdX { get; set; }
        public float rdY { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public int speed { get; set; }
        public int course { get; set; }
        public int numSatellite { get; set; }
        public int hdop { get; set; }
        public string dopType { get; set; }

        public Position()
        {

        }
        public Position(string json)
        {
            //IF JSON IS NULL THROWWWWW
            JObject jObject = JObject.Parse(json);
            //JToken jUser = jObject["user"];
            this.unitId = (int)jObject["unitId"];
            this.date = (string)jObject["date"];
            this.time = (string)jObject["time"];
            this.rdX = (float)jObject["rdX"];
            this.rdY = (float)jObject["rdY"];
            this.latitude = (float)jObject["latitude"];
            this.longitude = (float)jObject["longitude"];
            this.speed = (int)jObject["speed"];
            this.course = (int)jObject["course"];
            this.numSatellite = (int)jObject["numSatellite"];
            this.hdop = (int)jObject["hdop"];
            this.dopType = (string)jObject["dopType"];
        }
        public Position(int unitId, string date, string time, float rdX, float rdY, float latitude, float longitude, int speed, int course, int numSatellite, int hdop, string dopType)
        {
            this.unitId = unitId;
            this.date = date;
            this.time = time;
            this.rdX = rdX;
            this.rdY = rdY;
            this.latitude = latitude;
            this.longitude = longitude;
            this.speed = speed;
            this.course = course;
            this.numSatellite = numSatellite;
            this.hdop = hdop;
            this.dopType = dopType;
        }

        public Position generate()
        {
            Random random = new Random();
            this.unitId = random.Next(10000);
            this.date = "Date";
            this.time = "Time";
            this.rdX = random.Next(10000);
            this.rdY = random.Next(10000);
            this.latitude = random.Next(10000);
            this.longitude = random.Next(10000);
            this.speed = random.Next(100);
            this.course = random.Next(360);
            this.numSatellite = random.Next(10);
            this.hdop = random.Next(10);
            this.dopType = "dopType";
            return this;
        }
    }
}