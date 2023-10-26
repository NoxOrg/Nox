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
using TestEntityExactlyOneEntity = TestWebApp.Domain.TestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public record UpdateTestEntityExactlyOneCommand(System.String keyId, TestEntityExactlyOneUpdateDto EntityDto, System.Guid? Etag) : IRequest<TestEntityExactlyOneKeyDto?>;

internal partial class UpdateTestEntityExactlyOneCommandHandler : UpdateTestEntityExactlyOneCommandHandlerBase
{
	public UpdateTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneEntity, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityExactlyOneCommandHandlerBase : CommandBase<UpdateTestEntityExactlyOneCommand, TestEntityExactlyOneEntity>, IRequestHandler<UpdateTestEntityExactlyOneCommand, TestEntityExactlyOneKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityExactlyOneEntity, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> _entityFactory;

	public UpdateTestEntityExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneEntity, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityExactlyOneKeyDto?> Handle(UpdateTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityExactlyOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityExactlyOnes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		var secondTestEntityExactlyOneRelationshipKey = TestWebApp.Domain.SecondTestEntityExactlyOneMetadata.CreateId(request.EntityDto.SecondTestEntityExactlyOneRelationshipId);
		var secondTestEntityExactlyOneRelationshipEntity = await DbContext.SecondTestEntityExactlyOnes.FindAsync(secondTestEntityExactlyOneRelationshipKey);
						
		if(secondTestEntityExactlyOneRelationshipEntity is not null)
			entity.CreateRefToSecondTestEntityExactlyOneRelationship(secondTestEntityExactlyOneRelationshipEntity);
		else
			throw new RelatedEntityNotFoundException("SecondTestEntityExactlyOneRelationship", request.EntityDto.SecondTestEntityExactlyOneRelationshipId.ToString());

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TestEntityExactlyOneKeyDto(entity.Id.Value);
	}
}