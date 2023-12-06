namespace Nox.Types.EntityFramework.Abstractions;

public interface IEntityDtoSqlQueryBuilder
{
    string EntityName { get; }
    string Build();
}