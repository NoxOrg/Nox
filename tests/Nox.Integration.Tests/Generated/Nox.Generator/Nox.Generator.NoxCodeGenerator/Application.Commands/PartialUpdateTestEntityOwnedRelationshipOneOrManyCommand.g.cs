﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityOwnedRelationshipOneOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany;

namespace TestWebApp.Application.Commands;

public record PartialUpdateTestEntityOwnedRelationshipOneOrManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityOwnedRelationshipOneOrManyKeyDto?>;

internal class PartialUpdateTestEntityOwnedRelationshipOneOrManyCommandHandler : PartialUpdateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase
{
	public PartialUpdateTestEntityOwnedRelationshipOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> entityFactory)
		: base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase : CommandBase<PartialUpdateTestEntityOwnedRelationshipOneOrManyCommand, TestEntityOwnedRelationshipOneOrManyEntity>, IRequestHandler<PartialUpdateTestEntityOwnedRelationshipOneOrManyCommand, TestEntityOwnedRelationshipOneOrManyKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> EntityFactory { get; }

	public PartialUpdateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOwnedRelationshipOneOrManyKeyDto?> Handle(PartialUpdateTestEntityOwnedRelationshipOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityOwnedRelationshipOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TestEntityOwnedRelationshipOneOrManyKeyDto(entity.Id.Value);
	}
}