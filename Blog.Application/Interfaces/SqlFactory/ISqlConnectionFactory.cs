using System.Data;

namespace Blog.Application.Interfaces.SqlFactory
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
        IDbConnection CreateNewConnection();
        string GetConnectionString();
    }
}
