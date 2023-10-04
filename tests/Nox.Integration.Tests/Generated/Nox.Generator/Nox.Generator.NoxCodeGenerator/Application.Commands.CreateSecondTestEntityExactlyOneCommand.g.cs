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
using SecondTestEntityExactlyOne = TestWebApp.Domain.SecondTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public record CreateSecondTestEntityExactlyOneCommand(SecondTestEntityExactlyOneCreateDto EntityDto) : IRequest<SecondTestEntityExactlyOneKeyDto>;

internal partial class CreateSecondTestEntityExactlyOneCommandHandler: CreateSecondTestEntityExactlyOneCommandHandlerBase
{
	public CreateSecondTestEntityExactlyOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOne, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> testentityexactlyonefactory,
		IEntityFactory<SecondTestEntityExactlyOne, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,testentityexactlyonefactory, entityFactory)
	{
	}
}


internal abstract class CreateSecondTestEntityExactlyOneCommandHandlerBase: CommandBase<CreateSecondTestEntityExactlyOneCommand,SecondTestEntityExactlyOne>, IRequestHandler <CreateSecondTestEntityExactlyOneCommand, SecondTestEntityExactlyOneKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<SecondTestEntityExactlyOne, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestEntityExactlyOne, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> _testentityexactlyonefactory;

	public CreateSecondTestEntityExactlyOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOne, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> testentityexactlyonefactory,
		IEntityFactory<SecondTestEntityExactlyOne, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> entityFactory): base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_testentityexactlyonefactory = testentityexactlyonefactory;
	}

	public virtual async Task<SecondTestEntityExactlyOneKeyDto> Handle(CreateSecondTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestEntityExactlyOneRelationshipId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityExactlyOneMetadata.CreateId(request.EntityDto.TestEntityExactlyOneRelationshipId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.TestEntityExactlyOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityExactlyOneRelationship(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityExactlyOneRelationship", request.EntityDto.TestEntityExactlyOneRelationshipId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityExactlyOneRelationship is not null)
		{
			var relatedEntity = _testentityexactlyonefactory.CreateEntity(request.EntityDto.TestEntityExactlyOneRelationship);
			entityToCreate.CreateRefToTestEntityExactlyOneRelationship(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.SecondTestEntityExactlyOnes.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new SecondTestEntityExactlyOneKeyDto(entityToCreate.Id.Value);
	}
}