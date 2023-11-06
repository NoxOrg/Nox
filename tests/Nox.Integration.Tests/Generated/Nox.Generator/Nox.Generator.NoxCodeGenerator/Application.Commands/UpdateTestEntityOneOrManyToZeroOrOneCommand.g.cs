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
using TestEntityOneOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityOneOrManyToZeroOrOneCommand(System.String keyId, TestEntityOneOrManyToZeroOrOneUpdateDto EntityDto, System.Guid? Etag) : IRequest<TestEntityOneOrManyToZeroOrOneKeyDto?>;

internal partial class UpdateTestEntityOneOrManyToZeroOrOneCommandHandler : UpdateTestEntityOneOrManyToZeroOrOneCommandHandlerBase
{
	public UpdateTestEntityOneOrManyToZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToZeroOrOneEntity, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityOneOrManyToZeroOrOneCommandHandlerBase : CommandBase<UpdateTestEntityOneOrManyToZeroOrOneCommand, TestEntityOneOrManyToZeroOrOneEntity>, IRequestHandler<UpdateTestEntityOneOrManyToZeroOrOneCommand, TestEntityOneOrManyToZeroOrOneKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityOneOrManyToZeroOrOneEntity, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> _entityFactory;

	public UpdateTestEntityOneOrManyToZeroOrOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToZeroOrOneEntity, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOneOrManyToZeroOrOneKeyDto?> Handle(UpdateTestEntityOneOrManyToZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityOneOrManyToZeroOrOnes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.TestEntityZeroOrOneToOneOrManies).LoadAsync();
		var testEntityZeroOrOneToOneOrManiesEntities = new List<TestEntityZeroOrOneToOneOrMany>();
		foreach(var relatedEntityId in request.EntityDto.TestEntityZeroOrOneToOneOrManiesId)
		{
			var relatedKey = TestWebApp.Domain.TestEntityZeroOrOneToOneOrManyMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.TestEntityZeroOrOneToOneOrManies.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				testEntityZeroOrOneToOneOrManiesEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToOneOrManies", relatedEntityId.ToString());
		}
		entity.UpdateRefToTestEntityZeroOrOneToOneOrManies(testEntityZeroOrOneToOneOrManiesEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TestEntityOneOrManyToZeroOrOneKeyDto(entity.Id.Value);
	}
}