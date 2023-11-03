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
using SecondTestEntityExactlyOneEntity = TestWebApp.Domain.SecondTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public record UpdateSecondTestEntityExactlyOneCommand(System.String keyId, SecondTestEntityExactlyOneUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<SecondTestEntityExactlyOneKeyDto?>;

internal partial class UpdateSecondTestEntityExactlyOneCommandHandler : UpdateSecondTestEntityExactlyOneCommandHandlerBase
{
	public UpdateSecondTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateSecondTestEntityExactlyOneCommandHandlerBase : CommandBase<UpdateSecondTestEntityExactlyOneCommand, SecondTestEntityExactlyOneEntity>, IRequestHandler<UpdateSecondTestEntityExactlyOneCommand, SecondTestEntityExactlyOneKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> _entityFactory;

	public UpdateSecondTestEntityExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityExactlyOneKeyDto?> Handle(UpdateSecondTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.SecondTestEntityExactlyOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityExactlyOnes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		var testEntityExactlyOneRelationshipKey = TestWebApp.Domain.TestEntityExactlyOneMetadata.CreateId(request.EntityDto.TestEntityExactlyOneRelationshipId);
		var testEntityExactlyOneRelationshipEntity = await DbContext.TestEntityExactlyOnes.FindAsync(testEntityExactlyOneRelationshipKey);
						
		if(testEntityExactlyOneRelationshipEntity is not null)
			entity.CreateRefToTestEntityExactlyOneRelationship(testEntityExactlyOneRelationshipEntity);
		else
			throw new RelatedEntityNotFoundException("TestEntityExactlyOneRelationship", request.EntityDto.TestEntityExactlyOneRelationshipId.ToString());

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new SecondTestEntityExactlyOneKeyDto(entity.Id.Value);
	}
}