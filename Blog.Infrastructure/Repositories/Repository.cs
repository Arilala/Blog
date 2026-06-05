using Blog.Application.Interfaces.Repository;
using Blog.Application.Interfaces.SqlFactory;
using Dapper;

namespace Blog.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        protected readonly ISqlConnectionFactory ConnectionFactory;
        protected readonly ISqlQueryProvider QueryProvider;
        protected abstract string InsertSql { get; }
        protected abstract string DeleteSql { get; }
        protected abstract string UpdateSql { get; }
        protected abstract string SelectAllSql { get; }
        protected abstract string SelectByIdSql { get; }

        protected Repository(ISqlConnectionFactory sqlConnectionFactory, ISqlQueryProvider sqlQueryProvider)
        {
            ConnectionFactory = sqlConnectionFactory;
            QueryProvider = sqlQueryProvider;
        }


        public async Task<int> AddAsync(T entity, CancellationToken ct = default)
        {
            using var connection = ConnectionFactory.GetOpenConnection();
            var command = new CommandDefinition(
                    commandText: QueryProvider.GetSqlQuery(InsertSql),
                    parameters: entity,
                    cancellationToken: ct
                );
            return await connection.ExecuteScalarAsync<int>(command);
        }
        public async Task<bool> UpdateAsync(T entity, CancellationToken ct = default)
        {
            using var connection = ConnectionFactory.GetOpenConnection();
            var command = new CommandDefinition(
                    commandText: QueryProvider.GetSqlQuery(UpdateSql),
                    parameters: entity,
                    cancellationToken: ct
                );
            return await connection.ExecuteAsync(command) > 0;
        }
        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            using var connection = ConnectionFactory.GetOpenConnection();
            var command = new CommandDefinition(
                    commandText: QueryProvider.GetSqlQuery(DeleteSql),
                    parameters: new { Id = id },
                    cancellationToken: ct
                );
            return await connection.ExecuteAsync(command) > 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default)
        {
            using var connection = ConnectionFactory.GetOpenConnection();
            return await connection.QueryAsync<T>(new CommandDefinition(
                    commandText: QueryProvider.GetSqlQuery(SelectAllSql),
                    cancellationToken: ct
                ));
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            using var connection = ConnectionFactory.GetOpenConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(new CommandDefinition(
                    commandText: QueryProvider.GetSqlQuery(SelectByIdSql),
                    parameters: new { Id = id },
                    cancellationToken: ct
                ));
        }


    }
}
