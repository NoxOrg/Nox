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
using TestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public record UpdateTestEntityTwoRelationshipsManyToManyCommand(System.String keyId, TestEntityTwoRelationshipsManyToManyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityTwoRelationshipsManyToManyKeyDto?>;

internal partial class UpdateTestEntityTwoRelationshipsManyToManyCommandHandler : UpdateTestEntityTwoRelationshipsManyToManyCommandHandlerBase
{
	public UpdateTestEntityTwoRelationshipsManyToManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityTwoRelationshipsManyToManyEntity, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityTwoRelationshipsManyToManyCommandHandlerBase : CommandBase<UpdateTestEntityTwoRelationshipsManyToManyCommand, TestEntityTwoRelationshipsManyToManyEntity>, IRequestHandler<UpdateTestEntityTwoRelationshipsManyToManyCommand, TestEntityTwoRelationshipsManyToManyKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityTwoRelationshipsManyToManyEntity, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> _entityFactory;

	public UpdateTestEntityTwoRelationshipsManyToManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityTwoRelationshipsManyToManyEntity, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityTwoRelationshipsManyToManyKeyDto?> Handle(UpdateTestEntityTwoRelationshipsManyToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityTwoRelationshipsManyToManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityTwoRelationshipsManyToManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.TestRelationshipOne).LoadAsync();
		var testRelationshipOneEntities = new List<SecondTestEntityTwoRelationshipsManyToMany>();
		foreach(var relatedEntityId in request.EntityDto.TestRelationshipOneId)
		{
			var relatedKey = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.SecondTestEntityTwoRelationshipsManyToManies.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				testRelationshipOneEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipOne", relatedEntityId.ToString());
		}
		entity.UpdateRefToTestRelationshipOne(testRelationshipOneEntities);

		await DbContext.Entry(entity).Collection(x => x.TestRelationshipTwo).LoadAsync();
		var testRelationshipTwoEntities = new List<SecondTestEntityTwoRelationshipsManyToMany>();
		foreach(var relatedEntityId in request.EntityDto.TestRelationshipTwoId)
		{
			var relatedKey = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.SecondTestEntityTwoRelationshipsManyToManies.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				testRelationshipTwoEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipTwo", relatedEntityId.ToString());
		}
		entity.UpdateRefToTestRelationshipTwo(testRelationshipTwoEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TestEntityTwoRelationshipsManyToManyKeyDto(entity.Id.Value);
	}
}