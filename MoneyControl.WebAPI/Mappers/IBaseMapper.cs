namespace MoneyControl.WebAPI.Host.Mappers
{
    public interface IBaseMapper<TSoure, TDestination>
    {
        public TDestination Map(TSoure map);
    }
}
