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
using SecondTestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public record PartialUpdateSecondTestEntityTwoRelationshipsOneToManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <SecondTestEntityTwoRelationshipsOneToManyKeyDto?>;

internal class PartialUpdateSecondTestEntityTwoRelationshipsOneToManyCommandHandler : PartialUpdateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase
{
	public PartialUpdateSecondTestEntityTwoRelationshipsOneToManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase : CommandBase<PartialUpdateSecondTestEntityTwoRelationshipsOneToManyCommand, SecondTestEntityTwoRelationshipsOneToManyEntity>, IRequestHandler<PartialUpdateSecondTestEntityTwoRelationshipsOneToManyCommand, SecondTestEntityTwoRelationshipsOneToManyKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	public IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> EntityFactory { get; }

	public PartialUpdateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityTwoRelationshipsOneToManyKeyDto?> Handle(PartialUpdateSecondTestEntityTwoRelationshipsOneToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityTwoRelationshipsOneToManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new SecondTestEntityTwoRelationshipsOneToManyKeyDto(entity.Id.Value);
	}
}