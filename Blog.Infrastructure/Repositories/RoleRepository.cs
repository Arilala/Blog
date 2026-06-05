using Blog.Application.Interfaces.Repository;
using Blog.Application.Interfaces.SqlFactory;
using Blog.Domain.Entity;
using Blog.Infrastructure.Sql;
using Dapper;

namespace Blog.Infrastructure.Repositories
{
    public class RoleRepository : Repository<RoleEntity>, IRoleRepository
    {
        public RoleRepository(
            ISqlConnectionFactory sqlConnectionFactory,
            ISqlQueryProvider sqlQueryProvider
        )
            : base(sqlConnectionFactory, sqlQueryProvider) { }

        protected override string InsertSql => SqlResources.InsertRole;

        protected override string DeleteSql => SqlResources.DeleteRole;

        protected override string UpdateSql => SqlResources.UpdateRole;

        protected override string SelectAllSql => SqlResources.GetAllRoles;

        protected override string SelectByIdSql => SqlResources.GetRole;

        public async Task<bool> ExistsByNameAsync(string roleName, CancellationToken ct = default)
        {
            string sql = QueryProvider.GetSqlQuery(Sql.SqlResources.CheckRoleByName);
            using var connection = ConnectionFactory.GetOpenConnection();
            var command = new CommandDefinition(
                commandText: sql,
                parameters: new { Name = roleName },
                cancellationToken: ct
            );
            return await connection.QuerySingleAsync<bool>(command);
        }

        public async Task<RoleEntity?> GetRoleByNameAsync(string roleName, CancellationToken ct = default)
        {
            string sql = QueryProvider.GetSqlQuery(Sql.SqlResources.GetRoleByName);
            using var connection = ConnectionFactory.GetOpenConnection();
            var command = new CommandDefinition(
                commandText: sql,
                parameters: new { Name = roleName },
                cancellationToken: ct
            );
            return await connection.QueryFirstOrDefaultAsync<RoleEntity>(command);
        }
    }
}
