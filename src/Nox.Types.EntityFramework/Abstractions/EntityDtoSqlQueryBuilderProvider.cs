namespace Nox.Types.EntityFramework.Abstractions;

public class EntityDtoSqlQueryBuilderProvider : IEntityDtoSqlQueryBuilderProvider
{
    private readonly Dictionary<string, IEntityDtoSqlQueryBuilder> _sqlQueryBuilders;

    public EntityDtoSqlQueryBuilderProvider(
        IEnumerable<IEntityDtoSqlQueryBuilder> sqlQueryBuilders)
    {
        _sqlQueryBuilders = sqlQueryBuilders.ToDictionary(x => x.EntityName);
    }

    public IEntityDtoSqlQueryBuilder GetBuilder(string entityName)
        => _sqlQueryBuilders[entityName];
}