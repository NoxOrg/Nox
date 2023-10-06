﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public record PartialUpdateTestEntityTwoRelationshipsOneToOneCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <TestEntityTwoRelationshipsOneToOneKeyDto?>;

internal class PartialUpdateTestEntityTwoRelationshipsOneToOneCommandHandler : PartialUpdateTestEntityTwoRelationshipsOneToOneCommandHandlerBase
{
	public PartialUpdateTestEntityTwoRelationshipsOneToOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateTestEntityTwoRelationshipsOneToOneCommandHandlerBase : CommandBase<PartialUpdateTestEntityTwoRelationshipsOneToOneCommand, TestEntityTwoRelationshipsOneToOneEntity>, IRequestHandler<PartialUpdateTestEntityTwoRelationshipsOneToOneCommand, TestEntityTwoRelationshipsOneToOneKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	public IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> EntityFactory { get; }

	public PartialUpdateTestEntityTwoRelationshipsOneToOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityTwoRelationshipsOneToOneKeyDto?> Handle(PartialUpdateTestEntityTwoRelationshipsOneToOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityTwoRelationshipsOneToOnes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TestEntityTwoRelationshipsOneToOneKeyDto(entity.Id.Value);
	}
}