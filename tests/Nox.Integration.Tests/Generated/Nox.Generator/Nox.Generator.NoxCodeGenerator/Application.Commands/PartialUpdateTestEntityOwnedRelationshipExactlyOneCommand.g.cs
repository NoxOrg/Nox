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
using TestEntityOwnedRelationshipExactlyOneEntity = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne;

namespace TestWebApp.Application.Commands;

public record PartialUpdateTestEntityOwnedRelationshipExactlyOneCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <TestEntityOwnedRelationshipExactlyOneKeyDto?>;

internal class PartialUpdateTestEntityOwnedRelationshipExactlyOneCommandHandler : PartialUpdateTestEntityOwnedRelationshipExactlyOneCommandHandlerBase
{
	public PartialUpdateTestEntityOwnedRelationshipExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipExactlyOneEntity, TestEntityOwnedRelationshipExactlyOneCreateDto, TestEntityOwnedRelationshipExactlyOneUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateTestEntityOwnedRelationshipExactlyOneCommandHandlerBase : CommandBase<PartialUpdateTestEntityOwnedRelationshipExactlyOneCommand, TestEntityOwnedRelationshipExactlyOneEntity>, IRequestHandler<PartialUpdateTestEntityOwnedRelationshipExactlyOneCommand, TestEntityOwnedRelationshipExactlyOneKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<TestEntityOwnedRelationshipExactlyOneEntity, TestEntityOwnedRelationshipExactlyOneCreateDto, TestEntityOwnedRelationshipExactlyOneUpdateDto> EntityFactory { get; }

	public PartialUpdateTestEntityOwnedRelationshipExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipExactlyOneEntity, TestEntityOwnedRelationshipExactlyOneCreateDto, TestEntityOwnedRelationshipExactlyOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOwnedRelationshipExactlyOneKeyDto?> Handle(PartialUpdateTestEntityOwnedRelationshipExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityOwnedRelationshipExactlyOnes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TestEntityOwnedRelationshipExactlyOneKeyDto(entity.Id.Value);
	}
}