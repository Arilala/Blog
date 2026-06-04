using Blog.Application.Interfaces.SqlFactory;
using System.Reflection;

namespace Blog.Infrastructure.Databases
{
    internal sealed class SqlQueryProvider : ISqlQueryProvider
    {
        private readonly Assembly _assembly;
        private readonly Dictionary<string, string> _cache = new();

        public SqlQueryProvider()
        {
            _assembly = Assembly.GetExecutingAssembly();
        }

        public string GetSqlQuery(string ressourceName)
        {
            if (_cache.TryGetValue(ressourceName, out var query)) return query;

            using Stream? stream = _assembly.GetManifestResourceStream(ressourceName);
            if (stream == null) throw new FileNotFoundException($"SQL resource '{ressourceName}' not found.");

            using var reader = new StreamReader(stream);
            query = reader.ReadToEnd();
            _cache[ressourceName] = query;
            return query;
        }
    }
}
