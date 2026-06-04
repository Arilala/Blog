using Blog.Application.Interfaces.Repository;
using Blog.Application.Interfaces.SqlFactory;
using Blog.Domain.Entity;
using Dapper;
using static Dapper.SqlMapper;

namespace Blog.Infrastructure.Repositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        private readonly ISqlQueryProvider _sqlQueryProvider;
        public UserRepository(ISqlConnectionFactory sqlConnectionFactory, ISqlQueryProvider sqlQueryProvider) : base(sqlConnectionFactory)
        {
            _sqlQueryProvider = sqlQueryProvider;
        }
        protected override string InsertSql => _sqlQueryProvider.GetSqlQuery(Sql.SqlResources.InsertUser);

        protected override string DeleteSql => _sqlQueryProvider.GetSqlQuery(Sql.SqlResources.DeleteUser);

        protected override string UpdateSql => _sqlQueryProvider.GetSqlQuery(Sql.SqlResources.UpdateUser);

        protected override string SelectAllSql => _sqlQueryProvider.GetSqlQuery(Sql.SqlResources.GetAllUsers);

        protected override string SelectByIdSql => _sqlQueryProvider.GetSqlQuery(Sql.SqlResources.GetUser);



        public async Task<bool> ExistsByNameOrEmailAsync(string name, string email, CancellationToken ct = default)
        {
            string sql = _sqlQueryProvider.GetSqlQuery(Sql.SqlResources.CheckUserByNameOrByEmail);
            using var connection = _sqlConnectionFactory.GetOpenConnection();
            var command = new CommandDefinition(
                                commandText: sql,
                                parameters: new { Username = name, Email = email },
                                cancellationToken: ct
                            );
            return await connection.QuerySingleAsync<bool>(command);

        }

        public async Task<UserEntity?> GetUserByEmailAsync(string email, CancellationToken ct = default)
        {
            string sql = _sqlQueryProvider.GetSqlQuery(Sql.SqlResources.GetUserByEmail);
            using var connection = _sqlConnectionFactory.GetOpenConnection();
            var command = new CommandDefinition(
                                commandText: sql,
                                parameters: new { Email = email },
                                cancellationToken: ct
                            );
            return await connection.QuerySingleAsync<UserEntity>(command);
        }

        public async Task<UserEntity?> GetUserByNameAsync(string name, CancellationToken ct = default)
        {
            string sql = _sqlQueryProvider.GetSqlQuery(Sql.SqlResources.GetUserByName);
            using var connection = _sqlConnectionFactory.GetOpenConnection();
            var command = new CommandDefinition(
                                commandText: sql,
                                parameters: new { Username = name },
                                cancellationToken: ct
                            );
            return await connection.QueryFirstOrDefaultAsync<UserEntity>(command);
        }
    }
}
