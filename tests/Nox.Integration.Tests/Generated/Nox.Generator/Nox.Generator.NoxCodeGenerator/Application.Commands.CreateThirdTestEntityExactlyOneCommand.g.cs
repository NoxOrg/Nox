﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using ThirdTestEntityExactlyOneEntity = TestWebApp.Domain.ThirdTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public record CreateThirdTestEntityExactlyOneCommand(ThirdTestEntityExactlyOneCreateDto EntityDto) : IRequest<ThirdTestEntityExactlyOneKeyDto>;

internal partial class CreateThirdTestEntityExactlyOneCommandHandler : CreateThirdTestEntityExactlyOneCommandHandlerBase
{
	public CreateThirdTestEntityExactlyOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.ThirdTestEntityZeroOrOne, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> thirdtestentityzerooronefactory,
		IEntityFactory<ThirdTestEntityExactlyOneEntity, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,thirdtestentityzerooronefactory, entityFactory)
	{
	}
}


internal abstract class CreateThirdTestEntityExactlyOneCommandHandlerBase : CommandBase<CreateThirdTestEntityExactlyOneCommand,ThirdTestEntityExactlyOneEntity>, IRequestHandler <CreateThirdTestEntityExactlyOneCommand, ThirdTestEntityExactlyOneKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<ThirdTestEntityExactlyOneEntity, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestWebApp.Domain.ThirdTestEntityZeroOrOne, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> _thirdtestentityzerooronefactory;

	public CreateThirdTestEntityExactlyOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.ThirdTestEntityZeroOrOne, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> thirdtestentityzerooronefactory,
		IEntityFactory<ThirdTestEntityExactlyOneEntity, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_thirdtestentityzerooronefactory = thirdtestentityzerooronefactory;
	}

	public virtual async Task<ThirdTestEntityExactlyOneKeyDto> Handle(CreateThirdTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.ThirdTestEntityZeroOrOneRelationshipId is not null)
		{
			var relatedKey = TestWebApp.Domain.ThirdTestEntityZeroOrOneMetadata.CreateId(request.EntityDto.ThirdTestEntityZeroOrOneRelationshipId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.ThirdTestEntityZeroOrOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToThirdTestEntityZeroOrOneRelationship(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("ThirdTestEntityZeroOrOneRelationship", request.EntityDto.ThirdTestEntityZeroOrOneRelationshipId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.ThirdTestEntityZeroOrOneRelationship is not null)
		{
			var relatedEntity = _thirdtestentityzerooronefactory.CreateEntity(request.EntityDto.ThirdTestEntityZeroOrOneRelationship);
			entityToCreate.CreateRefToThirdTestEntityZeroOrOneRelationship(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.ThirdTestEntityExactlyOnes.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new ThirdTestEntityExactlyOneKeyDto(entityToCreate.Id.Value);
	}
}