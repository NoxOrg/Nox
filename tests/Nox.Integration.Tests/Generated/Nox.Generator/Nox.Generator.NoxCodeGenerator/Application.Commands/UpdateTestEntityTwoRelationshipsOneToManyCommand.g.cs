﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public record UpdateTestEntityTwoRelationshipsOneToManyCommand(System.String keyId, TestEntityTwoRelationshipsOneToManyUpdateDto EntityDto, System.Guid? Etag) : IRequest<TestEntityTwoRelationshipsOneToManyKeyDto?>;

internal partial class UpdateTestEntityTwoRelationshipsOneToManyCommandHandler : UpdateTestEntityTwoRelationshipsOneToManyCommandHandlerBase
{
	public UpdateTestEntityTwoRelationshipsOneToManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityTwoRelationshipsOneToManyEntity, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityTwoRelationshipsOneToManyCommandHandlerBase : CommandBase<UpdateTestEntityTwoRelationshipsOneToManyCommand, TestEntityTwoRelationshipsOneToManyEntity>, IRequestHandler<UpdateTestEntityTwoRelationshipsOneToManyCommand, TestEntityTwoRelationshipsOneToManyKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityTwoRelationshipsOneToManyEntity, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> _entityFactory;

	public UpdateTestEntityTwoRelationshipsOneToManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityTwoRelationshipsOneToManyEntity, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityTwoRelationshipsOneToManyKeyDto?> Handle(UpdateTestEntityTwoRelationshipsOneToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityTwoRelationshipsOneToManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.TestRelationshipOne).LoadAsync();
		var testRelationshipOneEntities = new List<SecondTestEntityTwoRelationshipsOneToMany>();
		foreach(var relatedEntityId in request.EntityDto.TestRelationshipOneId)
		{
			var relatedKey = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.SecondTestEntityTwoRelationshipsOneToManies.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				testRelationshipOneEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipOne", relatedEntityId.ToString());
		}
		entity.UpdateAllRefToTestRelationshipOne(testRelationshipOneEntities);

		await DbContext.Entry(entity).Collection(x => x.TestRelationshipTwo).LoadAsync();
		var testRelationshipTwoEntities = new List<SecondTestEntityTwoRelationshipsOneToMany>();
		foreach(var relatedEntityId in request.EntityDto.TestRelationshipTwoId)
		{
			var relatedKey = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.SecondTestEntityTwoRelationshipsOneToManies.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				testRelationshipTwoEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipTwo", relatedEntityId.ToString());
		}
		entity.UpdateAllRefToTestRelationshipTwo(testRelationshipTwoEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TestEntityTwoRelationshipsOneToManyKeyDto(entity.Id.Value);
	}
}