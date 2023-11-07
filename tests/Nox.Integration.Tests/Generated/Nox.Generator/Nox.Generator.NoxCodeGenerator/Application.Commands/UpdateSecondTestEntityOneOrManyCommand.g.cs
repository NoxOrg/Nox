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
using SecondTestEntityOneOrManyEntity = TestWebApp.Domain.SecondTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public record UpdateSecondTestEntityOneOrManyCommand(System.String keyId, SecondTestEntityOneOrManyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<SecondTestEntityOneOrManyKeyDto?>;

internal partial class UpdateSecondTestEntityOneOrManyCommandHandler : UpdateSecondTestEntityOneOrManyCommandHandlerBase
{
	public UpdateSecondTestEntityOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOneOrManyEntity, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateSecondTestEntityOneOrManyCommandHandlerBase : CommandBase<UpdateSecondTestEntityOneOrManyCommand, SecondTestEntityOneOrManyEntity>, IRequestHandler<UpdateSecondTestEntityOneOrManyCommand, SecondTestEntityOneOrManyKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<SecondTestEntityOneOrManyEntity, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> _entityFactory;

	public UpdateSecondTestEntityOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOneOrManyEntity, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityOneOrManyKeyDto?> Handle(UpdateSecondTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.SecondTestEntityOneOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.TestEntityOneOrManies).LoadAsync();
		var testEntityOneOrManiesEntities = new List<TestEntityOneOrMany>();
		foreach(var relatedEntityId in request.EntityDto.TestEntityOneOrManiesId)
		{
			var relatedKey = TestWebApp.Domain.TestEntityOneOrManyMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.TestEntityOneOrManies.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				testEntityOneOrManiesEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityOneOrManies", relatedEntityId.ToString());
		}
		entity.UpdateRefToTestEntityOneOrManies(testEntityOneOrManiesEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new SecondTestEntityOneOrManyKeyDto(entity.Id.Value);
	}
}