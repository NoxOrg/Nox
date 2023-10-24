﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecondTestEntityOwnedRelationshipZeroOrManyEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrMany;

namespace TestWebApp.Application.Commands;
public record PartialUpdateSecondTestEntityOwnedRelationshipZeroOrManyForTestEntityOwnedRelationshipZeroOrManyCommand(TestEntityOwnedRelationshipZeroOrManyKeyDto ParentKeyDto, SecondTestEntityOwnedRelationshipZeroOrManyKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <SecondTestEntityOwnedRelationshipZeroOrManyKeyDto?>;
internal partial class PartialUpdateSecondTestEntityOwnedRelationshipZeroOrManyForTestEntityOwnedRelationshipZeroOrManyCommandHandler: PartialUpdateSecondTestEntityOwnedRelationshipZeroOrManyForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase
{
	public PartialUpdateSecondTestEntityOwnedRelationshipZeroOrManyForTestEntityOwnedRelationshipZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrManyEntity, SecondTestEntityOwnedRelationshipZeroOrManyCreateDto, SecondTestEntityOwnedRelationshipZeroOrManyUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateSecondTestEntityOwnedRelationshipZeroOrManyForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase: CommandBase<PartialUpdateSecondTestEntityOwnedRelationshipZeroOrManyForTestEntityOwnedRelationshipZeroOrManyCommand, SecondTestEntityOwnedRelationshipZeroOrManyEntity>, IRequestHandler <PartialUpdateSecondTestEntityOwnedRelationshipZeroOrManyForTestEntityOwnedRelationshipZeroOrManyCommand, SecondTestEntityOwnedRelationshipZeroOrManyKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrManyEntity, SecondTestEntityOwnedRelationshipZeroOrManyCreateDto, SecondTestEntityOwnedRelationshipZeroOrManyUpdateDto> EntityFactory { get; }

	public PartialUpdateSecondTestEntityOwnedRelationshipZeroOrManyForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrManyEntity, SecondTestEntityOwnedRelationshipZeroOrManyCreateDto, SecondTestEntityOwnedRelationshipZeroOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityOwnedRelationshipZeroOrManyKeyDto?> Handle(PartialUpdateSecondTestEntityOwnedRelationshipZeroOrManyForTestEntityOwnedRelationshipZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.TestEntityOwnedRelationshipZeroOrManies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.SecondTestEntityOwnedRelationshipZeroOrMany.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new SecondTestEntityOwnedRelationshipZeroOrManyKeyDto(entity.Id.Value);
	}
}