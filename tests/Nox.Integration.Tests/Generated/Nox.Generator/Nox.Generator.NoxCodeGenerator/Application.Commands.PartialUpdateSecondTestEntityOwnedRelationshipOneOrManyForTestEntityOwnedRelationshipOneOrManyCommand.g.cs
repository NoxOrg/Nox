﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Commands;
public record PartialUpdateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommand(TestEntityOwnedRelationshipOneOrManyKeyDto ParentKeyDto, SecondTestEntityOwnedRelationshipOneOrManyKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <SecondTestEntityOwnedRelationshipOneOrManyKeyDto?>;
internal partial class PartialUpdateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommandHandler: PartialUpdateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase
{
	public PartialUpdateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipOneOrMany, SecondTestEntityOwnedRelationshipOneOrManyCreateDto, SecondTestEntityOwnedRelationshipOneOrManyUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase: CommandBase<PartialUpdateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommand, SecondTestEntityOwnedRelationshipOneOrMany>, IRequestHandler <PartialUpdateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommand, SecondTestEntityOwnedRelationshipOneOrManyKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	public IEntityFactory<SecondTestEntityOwnedRelationshipOneOrMany, SecondTestEntityOwnedRelationshipOneOrManyCreateDto, SecondTestEntityOwnedRelationshipOneOrManyUpdateDto> EntityFactory { get; }

	public PartialUpdateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipOneOrMany, SecondTestEntityOwnedRelationshipOneOrManyCreateDto, SecondTestEntityOwnedRelationshipOneOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityOwnedRelationshipOneOrManyKeyDto?> Handle(PartialUpdateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrManyMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.TestEntityOwnedRelationshipOneOrManies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.SecondTestEntityOwnedRelationshipOneOrMany.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new SecondTestEntityOwnedRelationshipOneOrManyKeyDto(entity.Id.Value);
	}
}