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
using Dto = TestWebApp.Application.Dto;
using SecondTestEntityOwnedRelationshipZeroOrOneEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOne;

namespace TestWebApp.Application.Commands;
public partial record CreateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommand(TestEntityOwnedRelationshipZeroOrOneKeyDto ParentKeyDto, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <SecondTestEntityOwnedRelationshipZeroOrOneKeyDto>;

internal partial class CreateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommandHandler : CreateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase
{
	public CreateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrOneEntity, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase : CommandBase<CreateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommand, SecondTestEntityOwnedRelationshipZeroOrOneEntity>, IRequestHandler<CreateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommand, SecondTestEntityOwnedRelationshipZeroOrOneKeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrOneEntity, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto> _entityFactory;
	
	protected CreateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrOneEntity, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual  async Task<SecondTestEntityOwnedRelationshipZeroOrOneKeyDto?> Handle(CreateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = Dto.TestEntityOwnedRelationshipZeroOrOneMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.TestEntityOwnedRelationshipZeroOrOnes.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipZeroOrOne",  $"{keyId.ToString()}");
		}

		var entity = await _entityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		parentEntity.CreateRefToSecondTestEntityOwnedRelationshipZeroOrOne(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		
		var result = await _dbContext.SaveChangesAsync();

		return new SecondTestEntityOwnedRelationshipZeroOrOneKeyDto();
	}
}