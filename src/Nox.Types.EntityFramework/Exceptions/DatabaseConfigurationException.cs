namespace Nox.Types.EntityFramework.Exceptions;

/// <summary>
/// Represents errors that occur when a database configurator is not found for a specific entity type.
/// </summary>
public class DatabaseConfigurationException : Exception
{
    /// <summary>
    /// Gets the entity type for which the database configurator was not found.
    /// </summary>
    public NoxType EntityType { get; }

    /// <summary>
    /// Gets the name of the entity for which the database configurator was not found.
    /// </summary>
    public string EntityName { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DatabaseConfigurationException"/> class with a specified entity type and entity name.
    /// </summary>
    /// <param name="entityType">The nox type for entity which the database configurator was not found.</param>
    /// <param name="entityName">The name of the entity for which the database configurator was not found.</param>
    public DatabaseConfigurationException(NoxType entityType, string entityName)
        : base($"Could not find DatabaseConfigurator for type {entityType} entity {entityName}")
    {
        EntityType = entityType;
        EntityName = entityName;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DatabaseConfigurationException"/> class with a specified error message, inner exception, entity type, and entity name.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
    /// <param name="entityType">The nox type for entity which the database configurator was not found.</param>
    /// <param name="entityName">The name of the entity for which the database configurator was not found.</param>
    public DatabaseConfigurationException(string message, Exception innerException, NoxType entityType, string entityName)
        : base(message, innerException)
    {
        EntityType = entityType;
        EntityName = entityName;
    }
}
