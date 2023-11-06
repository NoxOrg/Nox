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
using TestEntityOneOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityOneOrManyToExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityOneOrManyToExactlyOneCommand(System.String keyId, TestEntityOneOrManyToExactlyOneUpdateDto EntityDto, System.Guid? Etag) : IRequest<TestEntityOneOrManyToExactlyOneKeyDto?>;

internal partial class UpdateTestEntityOneOrManyToExactlyOneCommandHandler : UpdateTestEntityOneOrManyToExactlyOneCommandHandlerBase
{
	public UpdateTestEntityOneOrManyToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToExactlyOneEntity, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityOneOrManyToExactlyOneCommandHandlerBase : CommandBase<UpdateTestEntityOneOrManyToExactlyOneCommand, TestEntityOneOrManyToExactlyOneEntity>, IRequestHandler<UpdateTestEntityOneOrManyToExactlyOneCommand, TestEntityOneOrManyToExactlyOneKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityOneOrManyToExactlyOneEntity, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> _entityFactory;

	public UpdateTestEntityOneOrManyToExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToExactlyOneEntity, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOneOrManyToExactlyOneKeyDto?> Handle(UpdateTestEntityOneOrManyToExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOneOrManyToExactlyOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityOneOrManyToExactlyOnes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.TestEntityExactlyOneToOneOrManies).LoadAsync();
		var testEntityExactlyOneToOneOrManiesEntities = new List<TestEntityExactlyOneToOneOrMany>();
		foreach(var relatedEntityId in request.EntityDto.TestEntityExactlyOneToOneOrManiesId)
		{
			var relatedKey = TestWebApp.Domain.TestEntityExactlyOneToOneOrManyMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.TestEntityExactlyOneToOneOrManies.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				testEntityExactlyOneToOneOrManiesEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityExactlyOneToOneOrManies", relatedEntityId.ToString());
		}
		entity.UpdateRefToTestEntityExactlyOneToOneOrManies(testEntityExactlyOneToOneOrManiesEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TestEntityOneOrManyToExactlyOneKeyDto(entity.Id.Value);
	}
}