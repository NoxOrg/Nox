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
using TestEntityOneOrManyToZeroOrManyEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany;

namespace TestWebApp.Application.Commands;

public record UpdateTestEntityOneOrManyToZeroOrManyCommand(System.String keyId, TestEntityOneOrManyToZeroOrManyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityOneOrManyToZeroOrManyKeyDto?>;

internal partial class UpdateTestEntityOneOrManyToZeroOrManyCommandHandler : UpdateTestEntityOneOrManyToZeroOrManyCommandHandlerBase
{
	public UpdateTestEntityOneOrManyToZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToZeroOrManyEntity, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityOneOrManyToZeroOrManyCommandHandlerBase : CommandBase<UpdateTestEntityOneOrManyToZeroOrManyCommand, TestEntityOneOrManyToZeroOrManyEntity>, IRequestHandler<UpdateTestEntityOneOrManyToZeroOrManyCommand, TestEntityOneOrManyToZeroOrManyKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityOneOrManyToZeroOrManyEntity, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> _entityFactory;

	public UpdateTestEntityOneOrManyToZeroOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToZeroOrManyEntity, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOneOrManyToZeroOrManyKeyDto?> Handle(UpdateTestEntityOneOrManyToZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOneOrManyToZeroOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityOneOrManyToZeroOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.TestEntityZeroOrManyToOneOrManies).LoadAsync();
		var testEntityZeroOrManyToOneOrManiesEntities = new List<TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany>();
		foreach(var relatedEntityId in request.EntityDto.TestEntityZeroOrManyToOneOrManiesId)
		{
			var relatedKey = TestWebApp.Domain.TestEntityZeroOrManyToOneOrManyMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.TestEntityZeroOrManyToOneOrManies.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				testEntityZeroOrManyToOneOrManiesEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityZeroOrManyToOneOrManies", relatedEntityId.ToString());
		}
		entity.UpdateRefToTestEntityZeroOrManyToOneOrManies(testEntityZeroOrManyToOneOrManiesEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TestEntityOneOrManyToZeroOrManyKeyDto(entity.Id.Value);
	}
}