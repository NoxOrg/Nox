namespace Nox.Types.EntityFramework.Abstractions;

/// <summary>
/// Used for building custom SQL queries for entities that have localized or enum attributes. These
/// SQL queries will be configured on the entity model builder as the default queries for the entity.
/// </summary>
public interface IEntityDtoSqlQueryBuilder
{
    string EntityName { get; }

    string Build();
}