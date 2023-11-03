﻿﻿// Generated

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
using SecondTestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public record UpdateSecondTestEntityTwoRelationshipsManyToManyCommand(System.String keyId, SecondTestEntityTwoRelationshipsManyToManyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<SecondTestEntityTwoRelationshipsManyToManyKeyDto?>;

internal partial class UpdateSecondTestEntityTwoRelationshipsManyToManyCommandHandler : UpdateSecondTestEntityTwoRelationshipsManyToManyCommandHandlerBase
{
	public UpdateSecondTestEntityTwoRelationshipsManyToManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsManyToManyEntity, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateSecondTestEntityTwoRelationshipsManyToManyCommandHandlerBase : CommandBase<UpdateSecondTestEntityTwoRelationshipsManyToManyCommand, SecondTestEntityTwoRelationshipsManyToManyEntity>, IRequestHandler<UpdateSecondTestEntityTwoRelationshipsManyToManyCommand, SecondTestEntityTwoRelationshipsManyToManyKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<SecondTestEntityTwoRelationshipsManyToManyEntity, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> _entityFactory;

	public UpdateSecondTestEntityTwoRelationshipsManyToManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsManyToManyEntity, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityTwoRelationshipsManyToManyKeyDto?> Handle(UpdateSecondTestEntityTwoRelationshipsManyToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityTwoRelationshipsManyToManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.TestRelationshipOneOnOtherSide).LoadAsync();
		var testRelationshipOneOnOtherSideEntities = new List<TestEntityTwoRelationshipsManyToMany>();
		foreach(var relatedEntityId in request.EntityDto.TestRelationshipOneOnOtherSideId)
		{
			var relatedKey = TestWebApp.Domain.TestEntityTwoRelationshipsManyToManyMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.TestEntityTwoRelationshipsManyToManies.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				testRelationshipOneOnOtherSideEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipOneOnOtherSide", relatedEntityId.ToString());
		}
		entity.UpdateRefToTestRelationshipOneOnOtherSide(testRelationshipOneOnOtherSideEntities);

		await DbContext.Entry(entity).Collection(x => x.TestRelationshipTwoOnOtherSide).LoadAsync();
		var testRelationshipTwoOnOtherSideEntities = new List<TestEntityTwoRelationshipsManyToMany>();
		foreach(var relatedEntityId in request.EntityDto.TestRelationshipTwoOnOtherSideId)
		{
			var relatedKey = TestWebApp.Domain.TestEntityTwoRelationshipsManyToManyMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.TestEntityTwoRelationshipsManyToManies.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				testRelationshipTwoOnOtherSideEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipTwoOnOtherSide", relatedEntityId.ToString());
		}
		entity.UpdateRefToTestRelationshipTwoOnOtherSide(testRelationshipTwoOnOtherSideEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new SecondTestEntityTwoRelationshipsManyToManyKeyDto(entity.Id.Value);
	}
}