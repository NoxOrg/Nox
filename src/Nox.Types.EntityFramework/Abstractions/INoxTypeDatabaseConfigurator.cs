using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;

namespace Nox.Types.EntityFramework.Abstractions;

public interface INoxTypeDatabaseConfigurator
{
    /// <summary>
    /// Configure ModelBuilder Property for a Type
    /// </summary>
    
    void ConfigureEntityProperty(EntityTypeBuilder builder, NoxSimpleTypeDefinition property, bool isKey);

    /// <summary>
    /// Compute the Key Property Name for a Type.
    /// This will be different from property name for Complex Types
    /// </summary>
    string GetKeyPropertyName(NoxSimpleTypeDefinition key);
}