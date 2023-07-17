using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types.EntityFramework.Model;

namespace Nox.Types.EntityFramework.Abstractions;

public interface INoxDatabaseConfigurator
{
    void ConfigureEntity(NoxSolutionCodeGeneratorState codeGeneratorState, EntityTypeBuilder builder, Entity entity, IReadOnlyList<RelationshipFullModel> relationships);
    List<RelationshipFullModel> GetRelationshipsToCreate(NoxSolutionCodeGeneratorState codeGeneratorState, IReadOnlyList<Entity> entities, ModelBuilder builder);
}