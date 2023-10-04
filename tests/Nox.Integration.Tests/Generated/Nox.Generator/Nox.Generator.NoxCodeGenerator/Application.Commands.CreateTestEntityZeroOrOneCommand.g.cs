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
using Nox.Factories;
using Nox.Solution;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityZeroOrOneEntity = TestWebApp.Domain.TestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityZeroOrOneCommand(TestEntityZeroOrOneCreateDto EntityDto) : IRequest<TestEntityZeroOrOneKeyDto>;

internal partial class CreateTestEntityZeroOrOneCommandHandler : CreateTestEntityZeroOrOneCommandHandlerBase
{
	public CreateTestEntityZeroOrOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityZeroOrOne, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> secondtestentityzerooronefactory,
		IEntityFactory<TestEntityZeroOrOneEntity, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,secondtestentityzerooronefactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrOneCommandHandlerBase : CommandBase<CreateTestEntityZeroOrOneCommand,TestEntityZeroOrOneEntity>, IRequestHandler <CreateTestEntityZeroOrOneCommand, TestEntityZeroOrOneKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityZeroOrOneEntity, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestWebApp.Domain.SecondTestEntityZeroOrOne, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> _secondtestentityzerooronefactory;

	public CreateTestEntityZeroOrOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityZeroOrOne, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> secondtestentityzerooronefactory,
		IEntityFactory<TestEntityZeroOrOneEntity, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_secondtestentityzerooronefactory = secondtestentityzerooronefactory;
	}

	public virtual async Task<TestEntityZeroOrOneKeyDto> Handle(CreateTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.SecondTestEntityZeroOrOneRelationshipId is not null)
		{
			var relatedKey = TestWebApp.Domain.SecondTestEntityZeroOrOneMetadata.CreateId(request.EntityDto.SecondTestEntityZeroOrOneRelationshipId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.SecondTestEntityZeroOrOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToSecondTestEntityZeroOrOneRelationship(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("SecondTestEntityZeroOrOneRelationship", request.EntityDto.SecondTestEntityZeroOrOneRelationshipId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.SecondTestEntityZeroOrOneRelationship is not null)
		{
			var relatedEntity = _secondtestentityzerooronefactory.CreateEntity(request.EntityDto.SecondTestEntityZeroOrOneRelationship);
			entityToCreate.CreateRefToSecondTestEntityZeroOrOneRelationship(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.TestEntityZeroOrOnes.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityZeroOrOneKeyDto(entityToCreate.Id.Value);
	}
}