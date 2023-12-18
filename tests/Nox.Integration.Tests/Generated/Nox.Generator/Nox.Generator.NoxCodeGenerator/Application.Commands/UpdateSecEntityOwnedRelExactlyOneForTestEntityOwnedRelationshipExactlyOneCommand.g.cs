﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecEntityOwnedRelExactlyOneEntity = TestWebApp.Domain.SecEntityOwnedRelExactlyOne;
using TestEntityOwnedRelationshipExactlyOneEntity = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record UpdateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(TestEntityOwnedRelationshipExactlyOneKeyDto ParentKeyDto, SecEntityOwnedRelExactlyOneUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <SecEntityOwnedRelExactlyOneKeyDto>;

internal partial class UpdateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandler : UpdateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase
{
	public UpdateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelExactlyOneEntity, SecEntityOwnedRelExactlyOneUpsertDto, SecEntityOwnedRelExactlyOneUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase : CommandBase<UpdateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand, SecEntityOwnedRelExactlyOneEntity>, IRequestHandler <UpdateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand, SecEntityOwnedRelExactlyOneKeyDto>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<SecEntityOwnedRelExactlyOneEntity, SecEntityOwnedRelExactlyOneUpsertDto, SecEntityOwnedRelExactlyOneUpsertDto> _entityFactory;

	protected UpdateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelExactlyOneEntity, SecEntityOwnedRelExactlyOneUpsertDto, SecEntityOwnedRelExactlyOneUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecEntityOwnedRelExactlyOneKeyDto> Handle(UpdateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOneMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await _dbContext.TestEntityOwnedRelationshipExactlyOnes.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipExactlyOne",  $"{keyId.ToString()}");
		}
		await _dbContext.Entry(parentEntity).Reference(e => e.SecEntityOwnedRelExactlyOne).LoadAsync(cancellationToken);
		var entity = parentEntity.SecEntityOwnedRelExactlyOne;
		if (entity is null)
			entity = await CreateEntityAsync(request.EntityDto, parentEntity, request.CultureCode);
		else
			await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);

		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity!);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;


		var result = await _dbContext.SaveChangesAsync();

		return new SecEntityOwnedRelExactlyOneKeyDto();
	}
	
	private async Task<SecEntityOwnedRelExactlyOneEntity> CreateEntityAsync(SecEntityOwnedRelExactlyOneUpsertDto upsertDto, TestEntityOwnedRelationshipExactlyOneEntity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateRefToSecEntityOwnedRelExactlyOne(entity);
		return entity;
	}
}