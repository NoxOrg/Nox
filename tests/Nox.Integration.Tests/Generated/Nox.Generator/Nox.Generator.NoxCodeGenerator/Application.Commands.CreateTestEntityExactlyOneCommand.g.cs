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
using TestEntityExactlyOneEntity = TestWebApp.Domain.TestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityExactlyOneCommand(TestEntityExactlyOneCreateDto EntityDto) : IRequest<TestEntityExactlyOneKeyDto>;

internal partial class CreateTestEntityExactlyOneCommandHandler : CreateTestEntityExactlyOneCommandHandlerBase
{
	public CreateTestEntityExactlyOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityExactlyOne, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> secondtestentityexactlyonefactory,
		IEntityFactory<TestEntityExactlyOneEntity, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,secondtestentityexactlyonefactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityExactlyOneCommandHandlerBase : CommandBase<CreateTestEntityExactlyOneCommand,TestEntityExactlyOneEntity>, IRequestHandler <CreateTestEntityExactlyOneCommand, TestEntityExactlyOneKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityExactlyOneEntity, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestWebApp.Domain.SecondTestEntityExactlyOne, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> _secondtestentityexactlyonefactory;

	public CreateTestEntityExactlyOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityExactlyOne, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> secondtestentityexactlyonefactory,
		IEntityFactory<TestEntityExactlyOneEntity, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_secondtestentityexactlyonefactory = secondtestentityexactlyonefactory;
	}

	public virtual async Task<TestEntityExactlyOneKeyDto> Handle(CreateTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.SecondTestEntityExactlyOneRelationshipId is not null)
		{
			var relatedKey = TestWebApp.Domain.SecondTestEntityExactlyOneMetadata.CreateId(request.EntityDto.SecondTestEntityExactlyOneRelationshipId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.SecondTestEntityExactlyOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToSecondTestEntityExactlyOneRelationship(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("SecondTestEntityExactlyOneRelationship", request.EntityDto.SecondTestEntityExactlyOneRelationshipId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.SecondTestEntityExactlyOneRelationship is not null)
		{
			var relatedEntity = _secondtestentityexactlyonefactory.CreateEntity(request.EntityDto.SecondTestEntityExactlyOneRelationship);
			entityToCreate.CreateRefToSecondTestEntityExactlyOneRelationship(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.TestEntityExactlyOnes.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityExactlyOneKeyDto(entityToCreate.Id.Value);
	}
}