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
using TestEntityZeroOrManyToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany;

namespace TestWebApp.Application.Commands;

public record UpdateTestEntityZeroOrManyToOneOrManyCommand(System.String keyId, TestEntityZeroOrManyToOneOrManyUpdateDto EntityDto, System.Guid? Etag) : IRequest<TestEntityZeroOrManyToOneOrManyKeyDto?>;

internal partial class UpdateTestEntityZeroOrManyToOneOrManyCommandHandler : UpdateTestEntityZeroOrManyToOneOrManyCommandHandlerBase
{
	public UpdateTestEntityZeroOrManyToOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrManyToOneOrManyEntity, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityZeroOrManyToOneOrManyCommandHandlerBase : CommandBase<UpdateTestEntityZeroOrManyToOneOrManyCommand, TestEntityZeroOrManyToOneOrManyEntity>, IRequestHandler<UpdateTestEntityZeroOrManyToOneOrManyCommand, TestEntityZeroOrManyToOneOrManyKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityZeroOrManyToOneOrManyEntity, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> _entityFactory;

	public UpdateTestEntityZeroOrManyToOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrManyToOneOrManyEntity, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityZeroOrManyToOneOrManyKeyDto?> Handle(UpdateTestEntityZeroOrManyToOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrManyToOneOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityZeroOrManyToOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.TestEntityOneOrManyToZeroOrManies).LoadAsync();
		var testEntityOneOrManyToZeroOrManiesEntities = new List<TestEntityOneOrManyToZeroOrMany>();
		foreach(var relatedEntityId in request.EntityDto.TestEntityOneOrManyToZeroOrManiesId)
		{
			var relatedKey = TestWebApp.Domain.TestEntityOneOrManyToZeroOrManyMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.TestEntityOneOrManyToZeroOrManies.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				testEntityOneOrManyToZeroOrManiesEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityOneOrManyToZeroOrManies", relatedEntityId.ToString());
		}
		entity.UpdateRefToTestEntityOneOrManyToZeroOrManies(testEntityOneOrManyToZeroOrManiesEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TestEntityZeroOrManyToOneOrManyKeyDto(entity.Id.Value);
	}
}