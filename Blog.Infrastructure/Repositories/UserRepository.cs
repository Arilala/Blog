using Blog.Application.Interfaces.Repository;
using Blog.Application.Interfaces.SqlFactory;
using Blog.Domain.Entity;
using Blog.Infrastructure.Sql;
using Dapper;
using static Dapper.SqlMapper;

namespace Blog.Infrastructure.Repositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(
            ISqlConnectionFactory sqlConnectionFactory,
            ISqlQueryProvider sqlQueryProvider
        )
            : base(sqlConnectionFactory, sqlQueryProvider) { }

        protected override string InsertSql => SqlResources.InsertUser;

        protected override string DeleteSql => Sql.SqlResources.DeleteUser;

        protected override string UpdateSql => Sql.SqlResources.UpdateUser;

        protected override string SelectAllSql => Sql.SqlResources.GetAllUsers;

        protected override string SelectByIdSql => Sql.SqlResources.GetUser;

        public async Task<bool> AddRoleToUserAsync(int userId, int roleId, CancellationToken ct = default)
        {
            string sql = QueryProvider.GetSqlQuery(Sql.SqlResources.AddRoleUser);
            using var connection = ConnectionFactory.GetOpenConnection();
            var command = new CommandDefinition(
                commandText: sql,
                parameters: new { UserId = userId, RoleId = roleId },
                cancellationToken: ct
            );
            return await connection.ExecuteAsync(command) > 0;
        }

        public async Task<bool> ExistsByNameOrEmailAsync(
            string name,
            string email,
            CancellationToken ct = default
        )
        {
            string sql = QueryProvider.GetSqlQuery(Sql.SqlResources.CheckUserByNameOrByEmail);
            using var connection = ConnectionFactory.GetOpenConnection();
            var command = new CommandDefinition(
                commandText: sql,
                parameters: new { Username = name, Email = email },
                cancellationToken: ct
            );
            return await connection.QuerySingleAsync<bool>(command);
        }

        public async Task<UserEntity?> GetUserByEmailAsync(
            string email,
            CancellationToken ct = default
        )
        {
            string sql = QueryProvider.GetSqlQuery(Sql.SqlResources.GetUserByEmail);
            using var connection = ConnectionFactory.GetOpenConnection();
            var command = new CommandDefinition(
                commandText: sql,
                parameters: new { Email = email },
                cancellationToken: ct
            );
            return await connection.QuerySingleAsync<UserEntity>(command);
        }

        public async Task<UserEntity?> GetUserByNameAsync(
            string name,
            CancellationToken ct = default
        )
        {
            string sql = QueryProvider.GetSqlQuery(Sql.SqlResources.GetUserByName);
            using var connection = ConnectionFactory.GetOpenConnection();
            var command = new CommandDefinition(
                commandText: sql,
                parameters: new { Username = name },
                cancellationToken: ct
            );
            return await connection.QueryFirstOrDefaultAsync<UserEntity>(command);
        }
    }
}
