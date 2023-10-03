﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityTwoRelationshipsOneToOne = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityTwoRelationshipsOneToOneCommand(TestEntityTwoRelationshipsOneToOneCreateDto EntityDto) : IRequest<TestEntityTwoRelationshipsOneToOneKeyDto>;

internal partial class CreateTestEntityTwoRelationshipsOneToOneCommandHandler: CreateTestEntityTwoRelationshipsOneToOneCommandHandlerBase
{
	public CreateTestEntityTwoRelationshipsOneToOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToOne, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> secondtestentitytworelationshipsonetoonefactory,
		IEntityFactory<TestEntityTwoRelationshipsOneToOne, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,secondtestentitytworelationshipsonetoonefactory, entityFactory, serviceProvider)
	{
	}
}


internal abstract class CreateTestEntityTwoRelationshipsOneToOneCommandHandlerBase: CommandBase<CreateTestEntityTwoRelationshipsOneToOneCommand,TestEntityTwoRelationshipsOneToOne>, IRequestHandler <CreateTestEntityTwoRelationshipsOneToOneCommand, TestEntityTwoRelationshipsOneToOneKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityTwoRelationshipsOneToOne, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> _entityFactory;
	private readonly IEntityFactory<SecondTestEntityTwoRelationshipsOneToOne, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> _secondtestentitytworelationshipsonetoonefactory;

	public CreateTestEntityTwoRelationshipsOneToOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToOne, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> secondtestentitytworelationshipsonetoonefactory,
		IEntityFactory<TestEntityTwoRelationshipsOneToOne, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
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
		if(request.EntityDto.TestRelationshipOne is not null)
		{
			var relatedEntity = _secondtestentitytworelationshipsonetoonefactory.CreateEntity(request.EntityDto.TestRelationshipOne);
			entityToCreate.CreateRefToTestRelationshipOne(relatedEntity);
		}
		if(request.EntityDto.TestRelationshipTwo is not null)
		{
			var relatedEntity = _secondtestentitytworelationshipsonetoonefactory.CreateEntity(request.EntityDto.TestRelationshipTwo);
			entityToCreate.CreateRefToTestRelationshipTwo(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.TestEntityTwoRelationshipsOneToOnes.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityTwoRelationshipsOneToOneKeyDto(entityToCreate.Id.Value);
	}
}