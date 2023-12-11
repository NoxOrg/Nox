namespace Nox.Types.EntityFramework.Abstractions;

public interface IEntityDtoSqlQueryBuilderProvider
{
    IEntityDtoSqlQueryBuilder GetBuilder(string entityName);
}
