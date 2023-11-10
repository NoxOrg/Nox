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
using TestEntityOneOrManyEntity = TestWebApp.Domain.TestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public record UpdateTestEntityOneOrManyCommand(System.String keyId, TestEntityOneOrManyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityOneOrManyKeyDto?>;

internal partial class UpdateTestEntityOneOrManyCommandHandler : UpdateTestEntityOneOrManyCommandHandlerBase
{
	public UpdateTestEntityOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyEntity, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityOneOrManyCommandHandlerBase : CommandBase<UpdateTestEntityOneOrManyCommand, TestEntityOneOrManyEntity>, IRequestHandler<UpdateTestEntityOneOrManyCommand, TestEntityOneOrManyKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityOneOrManyEntity, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> _entityFactory;

	public UpdateTestEntityOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyEntity, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOneOrManyKeyDto?> Handle(UpdateTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOneOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.SecondTestEntityOneOrManies).LoadAsync();
		var secondTestEntityOneOrManiesEntities = new List<TestWebApp.Domain.SecondTestEntityOneOrMany>();
		foreach(var relatedEntityId in request.EntityDto.SecondTestEntityOneOrManiesId)
		{
			var relatedKey = TestWebApp.Domain.SecondTestEntityOneOrManyMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.SecondTestEntityOneOrManies.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				secondTestEntityOneOrManiesEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("SecondTestEntityOneOrManies", relatedEntityId.ToString());
		}
		entity.UpdateRefToSecondTestEntityOneOrManies(secondTestEntityOneOrManiesEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TestEntityOneOrManyKeyDto(entity.Id.Value);
	}
}