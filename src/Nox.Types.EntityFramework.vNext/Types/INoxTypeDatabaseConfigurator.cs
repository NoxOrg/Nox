using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;

namespace Nox.Types.EntityFramework.vNext.Types;

public interface INoxTypeDatabaseConfigurator
{
    void ConfigureEntityProperty(EntityTypeBuilder builder, NoxSimpleTypeDefinition property, bool isKey);
}