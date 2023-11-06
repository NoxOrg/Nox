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
using SecondTestEntityZeroOrManyEntity = TestWebApp.Domain.SecondTestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record UpdateSecondTestEntityZeroOrManyCommand(System.String keyId, SecondTestEntityZeroOrManyUpdateDto EntityDto, System.Guid? Etag) : IRequest<SecondTestEntityZeroOrManyKeyDto?>;

internal partial class UpdateSecondTestEntityZeroOrManyCommandHandler : UpdateSecondTestEntityZeroOrManyCommandHandlerBase
{
	public UpdateSecondTestEntityZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityZeroOrManyEntity, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateSecondTestEntityZeroOrManyCommandHandlerBase : CommandBase<UpdateSecondTestEntityZeroOrManyCommand, SecondTestEntityZeroOrManyEntity>, IRequestHandler<UpdateSecondTestEntityZeroOrManyCommand, SecondTestEntityZeroOrManyKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<SecondTestEntityZeroOrManyEntity, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> _entityFactory;

	public UpdateSecondTestEntityZeroOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityZeroOrManyEntity, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityZeroOrManyKeyDto?> Handle(UpdateSecondTestEntityZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.SecondTestEntityZeroOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityZeroOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.TestEntityZeroOrManyRelationship).LoadAsync();
		var testEntityZeroOrManyRelationshipEntities = new List<TestEntityZeroOrMany>();
		foreach(var relatedEntityId in request.EntityDto.TestEntityZeroOrManyRelationshipId)
		{
			var relatedKey = TestWebApp.Domain.TestEntityZeroOrManyMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.TestEntityZeroOrManies.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				testEntityZeroOrManyRelationshipEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityZeroOrManyRelationship", relatedEntityId.ToString());
		}
		entity.UpdateRefToTestEntityZeroOrManyRelationship(testEntityZeroOrManyRelationshipEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new SecondTestEntityZeroOrManyKeyDto(entity.Id.Value);
	}
}