namespace DataStore.Repository.Dapper.DataAccess.Interfaces
{
    public interface IDataBaseSettings
    {
        string ArtConnectionString { get; }
        string AviationConnectionString { get; } 
    }
}