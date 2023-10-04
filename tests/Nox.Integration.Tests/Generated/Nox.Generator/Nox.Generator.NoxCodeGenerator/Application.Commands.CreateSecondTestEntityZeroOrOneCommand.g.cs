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
using SecondTestEntityZeroOrOneEntity = TestWebApp.Domain.SecondTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public record CreateSecondTestEntityZeroOrOneCommand(SecondTestEntityZeroOrOneCreateDto EntityDto) : IRequest<SecondTestEntityZeroOrOneKeyDto>;

internal partial class CreateSecondTestEntityZeroOrOneCommandHandler : CreateSecondTestEntityZeroOrOneCommandHandlerBase
{
	public CreateSecondTestEntityZeroOrOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOne, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> testentityzerooronefactory,
		IEntityFactory<SecondTestEntityZeroOrOneEntity, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,testentityzerooronefactory, entityFactory)
	{
	}
}


internal abstract class CreateSecondTestEntityZeroOrOneCommandHandlerBase : CommandBase<CreateSecondTestEntityZeroOrOneCommand,SecondTestEntityZeroOrOneEntity>, IRequestHandler <CreateSecondTestEntityZeroOrOneCommand, SecondTestEntityZeroOrOneKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<SecondTestEntityZeroOrOneEntity, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOne, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> _testentityzerooronefactory;

	public CreateSecondTestEntityZeroOrOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOne, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> testentityzerooronefactory,
		IEntityFactory<SecondTestEntityZeroOrOneEntity, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_testentityzerooronefactory = testentityzerooronefactory;
	}

	public virtual async Task<SecondTestEntityZeroOrOneKeyDto> Handle(CreateSecondTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestEntityZeroOrOneRelationshipId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityZeroOrOneMetadata.CreateId(request.EntityDto.TestEntityZeroOrOneRelationshipId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.TestEntityZeroOrOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityZeroOrOneRelationship(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityZeroOrOneRelationship", request.EntityDto.TestEntityZeroOrOneRelationshipId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityZeroOrOneRelationship is not null)
		{
			var relatedEntity = _testentityzerooronefactory.CreateEntity(request.EntityDto.TestEntityZeroOrOneRelationship);
			entityToCreate.CreateRefToTestEntityZeroOrOneRelationship(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.SecondTestEntityZeroOrOnes.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new SecondTestEntityZeroOrOneKeyDto(entityToCreate.Id.Value);
	}
}