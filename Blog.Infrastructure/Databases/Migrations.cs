using Blog.Application.Interfaces.SqlFactory;
using Dapper;

namespace Blog.Infrastructure.Databases
{
    public class Migrations
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        private readonly ISqlQueryProvider _sqlQueryProvider;

        public Migrations(
            ISqlConnectionFactory connectionFactory,
            ISqlQueryProvider sqlQueryProvider
        )
        {
            _connectionFactory = connectionFactory;
            _sqlQueryProvider = sqlQueryProvider;
        }

        void Excecute(string sql)
        {
            using var connection = _connectionFactory.CreateNewConnection();
            var command = connection.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        public void CreateUserTable_1()
        {
            Excecute(_sqlQueryProvider.GetSqlQuery(Sql.SqlResources.CreateUserTable));
        }

        public void RunMigrations()
        {
            var type = GetType();

            var methsq =
                from m in type.GetMethods()
                where m.GetParameters().Length == 0
                let s = m.Name.Split("_")
                where s.Length == 2
                let version = int.Parse(s[1])
                orderby version
                select (m, version);
            var methods = methsq.ToArray();
            var dbVersion = GetDatabaseVersion();

            try
            {
                foreach (var (m, v) in methods)
                {
                    if (v <= dbVersion)
                    {
                        continue;
                    }
                    m.Invoke(this, null);
                    dbVersion = v;
                }

                using var connection = _connectionFactory.CreateNewConnection();
                connection.Execute(
                    _sqlQueryProvider.GetSqlQuery(Sql.SqlResources.UpdateVersion),
                    new { Version = dbVersion }
                );
            }
            catch (Exception)
            {
                throw;
            }
        }

        class DbVersion
        {
            public int Version = 0;
        }

        int GetDatabaseVersion()
        {
            using var connection = _connectionFactory.CreateNewConnection();
            var command = connection.CreateCommand();
            command.CommandText = _sqlQueryProvider.GetSqlQuery(
                Sql.SqlResources.CreateVersionTable
            );

            command.ExecuteNonQuery();

            var dbVersion = connection.QuerySingleOrDefault<DbVersion>(
                _sqlQueryProvider.GetSqlQuery(Sql.SqlResources.GetVersion)
            );

            if (dbVersion != null)
            {
                return dbVersion.Version;
            }

            var version = -1;
            string sql = _sqlQueryProvider.GetSqlQuery(Sql.SqlResources.InsertVersion);
            connection.Execute(sql, new { Version = version });

            return version;
        }
    }
}
