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
using SecondTestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public record PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <SecondTestEntityTwoRelationshipsOneToOneKeyDto?>;

internal class PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommandHandler : PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommandHandlerBase
{
	public PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToOneEntity, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommandHandlerBase : CommandBase<PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommand, SecondTestEntityTwoRelationshipsOneToOneEntity>, IRequestHandler<PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommand, SecondTestEntityTwoRelationshipsOneToOneKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	public IEntityFactory<SecondTestEntityTwoRelationshipsOneToOneEntity, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> EntityFactory { get; }

	public PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToOneEntity, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityTwoRelationshipsOneToOneKeyDto?> Handle(PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityTwoRelationshipsOneToOnes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new SecondTestEntityTwoRelationshipsOneToOneKeyDto(entity.Id.Value);
	}
}