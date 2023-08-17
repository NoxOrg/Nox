using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Types;

public class JsonDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    /// <inheritdoc/>
    public NoxType ForNoxType => NoxType.Json;

    /// <inheritdoc/>
    public bool IsDefault => true;

    /// <inheritdoc/>
    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        IEntityBuilderAdapter builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        builder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .HasConversion<JsonConverter>();
    }

    /// <inheritdoc/>
    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}
