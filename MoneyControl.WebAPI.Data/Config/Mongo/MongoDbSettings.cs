namespace MoneyControl.WebAPI.Data.Config.Mongo
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }

    }
}
