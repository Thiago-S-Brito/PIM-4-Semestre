using MongoDB.Driver;

namespace PIM_4.Dao
{
    public class BancoDao
    {
        public MongoClient client;
        public IMongoDatabase database;

        public BancoDao()
        {
            var connectionUri = "mongodb://localhost:27017";
            client = new MongoClient(connectionUri);
            database = client.GetDatabase("hotel");
        }
    }
}