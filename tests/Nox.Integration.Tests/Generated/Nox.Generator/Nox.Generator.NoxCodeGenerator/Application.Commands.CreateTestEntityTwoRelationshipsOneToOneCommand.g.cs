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
using TestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityTwoRelationshipsOneToOneCommand(TestEntityTwoRelationshipsOneToOneCreateDto EntityDto) : IRequest<TestEntityTwoRelationshipsOneToOneKeyDto>;

internal partial class CreateTestEntityTwoRelationshipsOneToOneCommandHandler : CreateTestEntityTwoRelationshipsOneToOneCommandHandlerBase
{
	public CreateTestEntityTwoRelationshipsOneToOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> secondtestentitytworelationshipsonetoonefactory,
		IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,secondtestentitytworelationshipsonetoonefactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityTwoRelationshipsOneToOneCommandHandlerBase : CommandBase<CreateTestEntityTwoRelationshipsOneToOneCommand,TestEntityTwoRelationshipsOneToOneEntity>, IRequestHandler <CreateTestEntityTwoRelationshipsOneToOneCommand, TestEntityTwoRelationshipsOneToOneKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> _secondtestentitytworelationshipsonetoonefactory;

	public CreateTestEntityTwoRelationshipsOneToOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> secondtestentitytworelationshipsonetoonefactory,
		IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_secondtestentitytworelationshipsonetoonefactory = secondtestentitytworelationshipsonetoonefactory;
	}

	public virtual async Task<TestEntityTwoRelationshipsOneToOneKeyDto> Handle(CreateTestEntityTwoRelationshipsOneToOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestRelationshipOneId is not null)
		{
			var relatedKey = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.EntityDto.TestRelationshipOneId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.SecondTestEntityTwoRelationshipsOneToOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestRelationshipOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipOne", request.EntityDto.TestRelationshipOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestRelationshipOne is not null)
		{
			var relatedEntity = _secondtestentitytworelationshipsonetoonefactory.CreateEntity(request.EntityDto.TestRelationshipOne);
			entityToCreate.CreateRefToTestRelationshipOne(relatedEntity);
		}
		if(request.EntityDto.TestRelationshipTwoId is not null)
		{
			var relatedKey = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.EntityDto.TestRelationshipTwoId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.SecondTestEntityTwoRelationshipsOneToOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestRelationshipTwo(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipTwo", request.EntityDto.TestRelationshipTwoId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestRelationshipTwo is not null)
		{
			var relatedEntity = _secondtestentitytworelationshipsonetoonefactory.CreateEntity(request.EntityDto.TestRelationshipTwo);
			entityToCreate.CreateRefToTestRelationshipTwo(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.TestEntityTwoRelationshipsOneToOnes.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityTwoRelationshipsOneToOneKeyDto(entityToCreate.Id.Value);
	}
}