namespace Blog.Application.Interfaces.SqlFactory
{
    public interface ISqlQueryProvider
    {
        string GetSqlQuery(string ressourceName);
    }
}
