using System.Data;
using Dapper;

namespace DataStore.Repository.Dapper.DataAccess.Interfaces
{
    public interface IDataBaseAccess
    {
        IDbConnection GetOpenConnectionArt();
        IDbConnection GetOpenConnectionAviation();
        int Execute(IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        T GetOutParamValue<T>(DynamicParameters parameters, string parameterName);
    }
}