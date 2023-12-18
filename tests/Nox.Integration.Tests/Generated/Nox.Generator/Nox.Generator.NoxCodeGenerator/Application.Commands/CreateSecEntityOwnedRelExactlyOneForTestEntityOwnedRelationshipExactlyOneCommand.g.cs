﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecEntityOwnedRelExactlyOneEntity = TestWebApp.Domain.SecEntityOwnedRelExactlyOne;

namespace TestWebApp.Application.Commands;
public partial record CreateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(TestEntityOwnedRelationshipExactlyOneKeyDto ParentKeyDto, SecEntityOwnedRelExactlyOneUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <SecEntityOwnedRelExactlyOneKeyDto>;

internal partial class CreateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandler : CreateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase
{
	public CreateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelExactlyOneEntity, SecEntityOwnedRelExactlyOneUpsertDto, SecEntityOwnedRelExactlyOneUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase : CommandBase<CreateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand, SecEntityOwnedRelExactlyOneEntity>, IRequestHandler<CreateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand, SecEntityOwnedRelExactlyOneKeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<SecEntityOwnedRelExactlyOneEntity, SecEntityOwnedRelExactlyOneUpsertDto, SecEntityOwnedRelExactlyOneUpsertDto> _entityFactory;

	protected CreateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelExactlyOneEntity, SecEntityOwnedRelExactlyOneUpsertDto, SecEntityOwnedRelExactlyOneUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual  async Task<SecEntityOwnedRelExactlyOneKeyDto?> Handle(CreateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOneMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.TestEntityOwnedRelationshipExactlyOnes.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipExactlyOne",  $"{keyId.ToString()}");
		}

		var entity = await _entityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		parentEntity.CreateRefToSecEntityOwnedRelExactlyOne(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;

		var result = await _dbContext.SaveChangesAsync();

		return new SecEntityOwnedRelExactlyOneKeyDto();
	}
}