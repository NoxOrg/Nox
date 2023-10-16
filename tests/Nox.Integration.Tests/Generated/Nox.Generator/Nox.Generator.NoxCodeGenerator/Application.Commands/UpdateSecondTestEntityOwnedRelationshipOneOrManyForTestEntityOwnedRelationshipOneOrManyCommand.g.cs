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
using SecondTestEntityOwnedRelationshipOneOrManyEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrMany;

namespace TestWebApp.Application.Commands;
public record UpdateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommand(TestEntityOwnedRelationshipOneOrManyKeyDto ParentKeyDto, SecondTestEntityOwnedRelationshipOneOrManyKeyDto EntityKeyDto, SecondTestEntityOwnedRelationshipOneOrManyUpdateDto EntityDto, System.Guid? Etag) : IRequest <SecondTestEntityOwnedRelationshipOneOrManyKeyDto?>;

internal partial class UpdateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommandHandler : UpdateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase
{
	public UpdateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipOneOrManyEntity, SecondTestEntityOwnedRelationshipOneOrManyCreateDto, SecondTestEntityOwnedRelationshipOneOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase : CommandBase<UpdateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommand, SecondTestEntityOwnedRelationshipOneOrManyEntity>, IRequestHandler <UpdateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommand, SecondTestEntityOwnedRelationshipOneOrManyKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	private readonly IEntityFactory<SecondTestEntityOwnedRelationshipOneOrManyEntity, SecondTestEntityOwnedRelationshipOneOrManyCreateDto, SecondTestEntityOwnedRelationshipOneOrManyUpdateDto> _entityFactory;

	public UpdateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipOneOrManyEntity, SecondTestEntityOwnedRelationshipOneOrManyCreateDto, SecondTestEntityOwnedRelationshipOneOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityOwnedRelationshipOneOrManyKeyDto?> Handle(UpdateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommand request, CancellationToken cancellationToken)
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

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new SecondTestEntityOwnedRelationshipOneOrManyKeyDto(entity.Id.Value);
	}
}