using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;

namespace Nox.Types.EntityFramework.Abstractions;

public interface INoxDatabaseConfigurator
{
    void ConfigureEntity(NoxSolutionCodeGeneratorState codeGeneratorState, EntityTypeBuilder builder, Entity entity, IReadOnlyList<EntityRelationshipWithType> relationshipsToCreate);
}