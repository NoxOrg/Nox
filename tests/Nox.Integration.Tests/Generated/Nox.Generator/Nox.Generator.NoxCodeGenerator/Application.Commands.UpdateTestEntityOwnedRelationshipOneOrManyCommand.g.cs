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
using TestEntityOwnedRelationshipOneOrMany = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany;

namespace TestWebApp.Application.Commands;

public record UpdateTestEntityOwnedRelationshipOneOrManyCommand(System.String keyId, TestEntityOwnedRelationshipOneOrManyUpdateDto EntityDto, System.Guid? Etag) : IRequest<TestEntityOwnedRelationshipOneOrManyKeyDto?>;

internal partial class UpdateTestEntityOwnedRelationshipOneOrManyCommandHandler: UpdateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase
{
	public UpdateTestEntityOwnedRelationshipOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipOneOrMany, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> entityFactory): base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase: CommandBase<UpdateTestEntityOwnedRelationshipOneOrManyCommand, TestEntityOwnedRelationshipOneOrMany>, IRequestHandler<UpdateTestEntityOwnedRelationshipOneOrManyCommand, TestEntityOwnedRelationshipOneOrManyKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityOwnedRelationshipOneOrMany, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> _entityFactory;

	public UpdateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipOneOrMany, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> entityFactory): base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOwnedRelationshipOneOrManyKeyDto?> Handle(UpdateTestEntityOwnedRelationshipOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityOwnedRelationshipOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TestEntityOwnedRelationshipOneOrManyKeyDto(entity.Id.Value);
	}
}