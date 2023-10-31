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
using TestEntityZeroOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne;

namespace TestWebApp.Application.Commands;

public record UpdateTestEntityZeroOrManyToZeroOrOneCommand(System.String keyId, TestEntityZeroOrManyToZeroOrOneUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityZeroOrManyToZeroOrOneKeyDto?>;

internal partial class UpdateTestEntityZeroOrManyToZeroOrOneCommandHandler : UpdateTestEntityZeroOrManyToZeroOrOneCommandHandlerBase
{
	public UpdateTestEntityZeroOrManyToZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrManyToZeroOrOneEntity, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityZeroOrManyToZeroOrOneCommandHandlerBase : CommandBase<UpdateTestEntityZeroOrManyToZeroOrOneCommand, TestEntityZeroOrManyToZeroOrOneEntity>, IRequestHandler<UpdateTestEntityZeroOrManyToZeroOrOneCommand, TestEntityZeroOrManyToZeroOrOneKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityZeroOrManyToZeroOrOneEntity, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> _entityFactory;

	public UpdateTestEntityZeroOrManyToZeroOrOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrManyToZeroOrOneEntity, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityZeroOrManyToZeroOrOneKeyDto?> Handle(UpdateTestEntityZeroOrManyToZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityZeroOrManyToZeroOrOnes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.TestEntityZeroOrOneToZeroOrMany).LoadAsync();
		var testEntityZeroOrOneToZeroOrManyEntities = new List<TestEntityZeroOrOneToZeroOrMany>();
		foreach(var relatedEntityId in request.EntityDto.TestEntityZeroOrOneToZeroOrManyId)
		{
			var relatedKey = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrManyMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.TestEntityZeroOrOneToZeroOrManies.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				testEntityZeroOrOneToZeroOrManyEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToZeroOrMany", relatedEntityId.ToString());
		}
		entity.UpdateRefToTestEntityZeroOrOneToZeroOrMany(testEntityZeroOrOneToZeroOrManyEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TestEntityZeroOrManyToZeroOrOneKeyDto(entity.Id.Value);
	}
}