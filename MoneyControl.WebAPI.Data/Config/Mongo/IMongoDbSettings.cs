namespace MoneyControl.WebAPI.Data.Config.Mongo
{
    public interface IMongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }
    }
}
