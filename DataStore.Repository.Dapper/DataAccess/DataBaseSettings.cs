using System.Configuration;
using DataStore.Repository.Dapper.DataAccess.Interfaces;

namespace DataStore.Repository.Dapper.DataAccess
{
    public class DataBaseSettings : IDataBaseSettings
    {
        public string ArtConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["Art"].ConnectionString; }
        }

        public string AviationConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["Aviation"].ConnectionString; }
        }

        public string MLDBConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["MLDB"].ConnectionString; }
        }
    }
}