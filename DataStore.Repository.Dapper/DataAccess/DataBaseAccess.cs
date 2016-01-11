using System.Data;
using System.Data.SqlClient;
using Dapper;
using DataStore.Repository.Dapper.DataAccess.Interfaces;

namespace DataStore.Repository.Dapper.DataAccess
{
    public class DataBaseAccess : IDataBaseAccess
    {
        private readonly IDataBaseSettings _dataBaseSettings;

        public DataBaseAccess(IDataBaseSettings dataBaseSettings)
        {
            _dataBaseSettings = dataBaseSettings;
        }

        public IDbConnection GetOpenConnectionArt()
        {
            var connection = new SqlConnection(_dataBaseSettings.ArtConnectionString);
            connection.Open();
            return connection;
        }

        public IDbConnection GetOpenConnectionAviation()
        {
            var connection = new SqlConnection(_dataBaseSettings.AviationConnectionString);
            connection.Open();
            return connection;
        }

        public int Execute(IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return cnn.Execute(sql, param, transaction, commandTimeout, commandType);
        }


        public T GetOutParamValue<T>(DynamicParameters parameters, string parameterName)
        {
            return parameters.Get<T>(parameterName);
        }
    }
}