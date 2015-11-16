using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFlowWebservice.Controllers.Database
{
    public class DatabaseManager
    {
        private MongoDatabase database;
        public DatabaseManager()
        {
            // Bouwt een connection string
            MongoServerSettings settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress("145.24.222.160", 8010);
            // Maakt een MongoDB server object, met dit object kunnen we communiceren met de server. Het maakt kortom verbinding met de mongodb server
            MongoServer server = new MongoServer(settings);
            // Vraagt onze database op van de server, zodat we read/write kunnen toepassen
            database = server.GetDatabase("Dataflow");
        }
        public MongoDatabase GetDatabase()
        {
            return database;
        }
    }
}