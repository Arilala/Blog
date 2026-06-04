using Blog.Application.Interfaces.SqlFactory;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Blog.Infrastructure.Databases
{
    public class SqlConnectionFactory(string connectionString) : ISqlConnectionFactory, IDisposable
    {
        private readonly string _connectionString = connectionString;
        private IDbConnection? _connection;

        public IDbConnection GetOpenConnection()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = CreateNewConnection();
            }
            return _connection;
        }

        public IDbConnection CreateNewConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}
