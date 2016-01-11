using System.Data;
using System.Data.SqlClient;

namespace DataStore.Handlers.UnitTests.Fakes
{
    public class FakeDBConnection
    {
        public IDbConnection _dbConnection;

        public FakeDBConnection()
            : this(new SqlConnection())
        {
        }

        public FakeDBConnection(IDbConnection connection)
        {
            _dbConnection = connection;
        }
    }
}