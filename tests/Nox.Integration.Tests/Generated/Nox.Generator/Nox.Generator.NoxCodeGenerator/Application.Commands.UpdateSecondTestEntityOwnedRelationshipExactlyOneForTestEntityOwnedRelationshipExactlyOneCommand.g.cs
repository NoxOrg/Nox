﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecondTestEntityOwnedRelationshipExactlyOneEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipExactlyOne;

namespace TestWebApp.Application.Commands;
public record UpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(TestEntityOwnedRelationshipExactlyOneKeyDto ParentKeyDto, SecondTestEntityOwnedRelationshipExactlyOneUpdateDto EntityDto, System.Guid? Etag) : IRequest <SecondTestEntityOwnedRelationshipExactlyOneKeyDto?>;


internal partial class UpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandler : UpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase
{
	public UpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipExactlyOneEntity, SecondTestEntityOwnedRelationshipExactlyOneCreateDto, SecondTestEntityOwnedRelationshipExactlyOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase : CommandBase<UpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand, SecondTestEntityOwnedRelationshipExactlyOneEntity>, IRequestHandler <UpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand, SecondTestEntityOwnedRelationshipExactlyOneKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	private readonly IEntityFactory<SecondTestEntityOwnedRelationshipExactlyOneEntity, SecondTestEntityOwnedRelationshipExactlyOneCreateDto, SecondTestEntityOwnedRelationshipExactlyOneUpdateDto> _entityFactory;

	public UpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipExactlyOneEntity, SecondTestEntityOwnedRelationshipExactlyOneCreateDto, SecondTestEntityOwnedRelationshipExactlyOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityOwnedRelationshipExactlyOneKeyDto?> Handle(UpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOneMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.TestEntityOwnedRelationshipExactlyOnes.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var entity = parentEntity.SecondTestEntityOwnedRelationshipExactlyOne;
		
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		OnCompleted(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new SecondTestEntityOwnedRelationshipExactlyOneKeyDto();
	}
}